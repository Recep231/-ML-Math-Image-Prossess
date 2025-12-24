using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Threading.Tasks;

namespace MLMathImageProcess
{
    public class ImageProcessor
    {
        public class ProcessingResult
        {
            public Bitmap? ProcessedImage { get; set; }
            public string Status { get; set; } = "Success";
            public long ProcessingTimeMs { get; set; }
            public string? DetectedText { get; set; }
            public List<string>? MathExpressions { get; set; }
        }

        public async Task<ProcessingResult> ProcessImageAsync(Bitmap originalImage)
        {
            var stopwatch = Stopwatch.StartNew();
            var result = new ProcessingResult();

            try
            {
                await Task.Run(() =>
                {
                    // Apply multiple processing techniques
                    Bitmap processed = ApplyPreprocessing(originalImage);
                    
                    // Edge detection for math symbols
                    processed = ApplyEdgeDetection(processed);
                    
                    // Enhance contrast for better recognition
                    processed = EnhanceContrast(processed);
                    
                    // Convert to grayscale if needed
                    processed = ConvertToGrayscale(processed);
                    
                    // Apply thresholding
                    processed = ApplyThresholding(processed);
                    
                    result.ProcessedImage = processed;
                    
                    // Simulate text/math detection (in a real app, you'd use OCR/ML models)
                    result.MathExpressions = DetectMathExpressions(processed);
                    result.DetectedText = ExtractTextInfo(processed);
                });

                stopwatch.Stop();
                result.ProcessingTimeMs = stopwatch.ElapsedMilliseconds;
                result.Status = "Success";
            }
            catch (Exception ex)
            {
                result.Status = $"Error: {ex.Message}";
            }

            return result;
        }

        private Bitmap ApplyPreprocessing(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);
            
            using (Graphics g = Graphics.FromImage(result))
            {
                g.DrawImage(image, 0, 0, image.Width, image.Height);
            }

            return result;
        }

        private Bitmap ApplyEdgeDetection(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);
            
            // Sobel edge detection kernel
            int[,] sobelX = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] sobelY = { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };

            for (int y = 1; y < image.Height - 1; y++)
            {
                for (int x = 1; x < image.Width - 1; x++)
                {
                    int gx = 0, gy = 0;

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            Color pixel = image.GetPixel(x + j, y + i);
                            int gray = (int)(pixel.R * 0.299 + pixel.G * 0.587 + pixel.B * 0.114);
                            
                            gx += gray * sobelX[i + 1, j + 1];
                            gy += gray * sobelY[i + 1, j + 1];
                        }
                    }

                    int magnitude = (int)Math.Sqrt(gx * gx + gy * gy);
                    magnitude = Math.Min(255, Math.Max(0, magnitude));
                    
                    result.SetPixel(x, y, Color.FromArgb(magnitude, magnitude, magnitude));
                }
            }

            return result;
        }

        private Bitmap EnhanceContrast(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);
            
            // Calculate histogram
            int[] histogram = new int[256];
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int gray = (int)(pixel.R * 0.299 + pixel.G * 0.587 + pixel.B * 0.114);
                    histogram[gray]++;
                }
            }

            // Find min and max values
            int min = 0, max = 255;
            for (int i = 0; i < 256; i++)
            {
                if (histogram[i] > 0) { min = i; break; }
            }
            for (int i = 255; i >= 0; i--)
            {
                if (histogram[i] > 0) { max = i; break; }
            }

            // Apply contrast stretching
            double factor = 255.0 / (max - min);
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int gray = (int)(pixel.R * 0.299 + pixel.G * 0.587 + pixel.B * 0.114);
                    int newGray = (int)((gray - min) * factor);
                    newGray = Math.Min(255, Math.Max(0, newGray));
                    result.SetPixel(x, y, Color.FromArgb(newGray, newGray, newGray));
                }
            }

            return result;
        }

        private Bitmap ConvertToGrayscale(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);
            
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int gray = (int)(pixel.R * 0.299 + pixel.G * 0.587 + pixel.B * 0.114);
                    result.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }

            return result;
        }

        private Bitmap ApplyThresholding(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);
            
            // Calculate Otsu's threshold
            int threshold = CalculateOtsuThreshold(image);
            
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int gray = (int)(pixel.R * 0.299 + pixel.G * 0.587 + pixel.B * 0.114);
                    int newValue = gray > threshold ? 255 : 0;
                    result.SetPixel(x, y, Color.FromArgb(newValue, newValue, newValue));
                }
            }

            return result;
        }

        private int CalculateOtsuThreshold(Bitmap image)
        {
            int[] histogram = new int[256];
            
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    int gray = (int)(pixel.R * 0.299 + pixel.G * 0.587 + pixel.B * 0.114);
                    histogram[gray]++;
                }
            }

            int totalPixels = image.Width * image.Height;
            double sum = 0;
            for (int i = 0; i < 256; i++)
            {
                sum += i * histogram[i];
            }

            double sumB = 0;
            int wB = 0;
            int wF = 0;
            double maxVariance = 0;
            int threshold = 0;

            for (int i = 0; i < 256; i++)
            {
                wB += histogram[i];
                if (wB == 0) continue;
                
                wF = totalPixels - wB;
                if (wF == 0) break;

                sumB += i * histogram[i];
                double mB = sumB / wB;
                double mF = (sum - sumB) / wF;
                double variance = wB * wF * (mB - mF) * (mB - mF);

                if (variance > maxVariance)
                {
                    maxVariance = variance;
                    threshold = i;
                }
            }

            return threshold;
        }

        private List<string> DetectMathExpressions(Bitmap image)
        {
            var expressions = new List<string>();
            
            // Simulate math expression detection
            // In a real implementation, you would use OCR or ML models here
            int blackPixels = 0;
            for (int y = 0; y < image.Height; y++)
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixel = image.GetPixel(x, y);
                    if (pixel.R < 128) blackPixels++;
                }
            }

            double density = (double)blackPixels / (image.Width * image.Height);
            
            if (density > 0.1)
            {
                expressions.Add("Mathematical symbols detected");
                expressions.Add($"Image density: {(density * 100):F2}%");
            }

            return expressions;
        }

        private string ExtractTextInfo(Bitmap image)
        {
            // Simulate text extraction
            // In a real implementation, you would use OCR libraries like Tesseract
            return $"Image processed successfully.\nDimensions: {image.Width}x{image.Height}\n" +
                   $"This is a demonstration. For actual text recognition, integrate OCR libraries.";
        }
    }
}

