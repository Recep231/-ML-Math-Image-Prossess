using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace MLMathImageProcess
{
    public partial class Form1 : Form
    {
        private ImageProcessor imageProcessor;
        private Bitmap? originalImage;
        private Bitmap? processedImage;
        private string? currentImagePath;

        public Form1()
        {
            InitializeComponent();
            imageProcessor = new ImageProcessor();
            UpdateStatus("Ready - Load an image to begin");
        }

        private void BtnLoadImage_Click(object? sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image files (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        currentImagePath = openFileDialog.FileName;
                        originalImage = new Bitmap(currentImagePath);
                        pictureBoxOriginal.Image = originalImage;
                        pictureBoxProcessed.Image = null;
                        processedImage = null;
                        txtResult.Clear();
                        btnProcessImage.Enabled = true;
                        btnSaveResult.Enabled = false;
                        UpdateStatus($"Image loaded: {Path.GetFileName(currentImagePath)}");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        UpdateStatus("Error loading image");
                    }
                }
            }
        }

        private async void BtnProcessImage_Click(object? sender, EventArgs e)
        {
            if (originalImage == null)
            {
                MessageBox.Show("Please load an image first.", "No Image", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnProcessImage.Enabled = false;
                UpdateStatus("Processing image... Please wait.");

                var result = await imageProcessor.ProcessImageAsync(originalImage);

                if (result.ProcessedImage != null)
                {
                    processedImage = result.ProcessedImage;
                    pictureBoxProcessed.Image = processedImage;
                    btnSaveResult.Enabled = true;
                }

                // Display results
                txtResult.Text = $"Processing Results:\r\n";
                txtResult.Text += $"━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━\r\n";
                txtResult.Text += $"Image Size: {originalImage.Width} x {originalImage.Height}\r\n";
                txtResult.Text += $"Processing Time: {result.ProcessingTimeMs} ms\r\n\r\n";
                
                if (!string.IsNullOrEmpty(result.DetectedText))
                {
                    txtResult.Text += $"Detected Text:\r\n{result.DetectedText}\r\n\r\n";
                }

                if (result.MathExpressions != null && result.MathExpressions.Count > 0)
                {
                    txtResult.Text += $"Math Expressions Found: {result.MathExpressions.Count}\r\n";
                    foreach (var expr in result.MathExpressions)
                    {
                        txtResult.Text += $"  • {expr}\r\n";
                    }
                }

                txtResult.Text += $"\r\nStatus: {result.Status}\r\n";

                UpdateStatus("Image processed successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                UpdateStatus($"Error: {ex.Message}");
            }
            finally
            {
                btnProcessImage.Enabled = true;
            }
        }

        private void BtnSaveResult_Click(object? sender, EventArgs e)
        {
            if (processedImage == null)
            {
                MessageBox.Show("No processed image to save.", "No Image", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image (*.png)|*.png|JPEG Image (*.jpg)|*.jpg|Bitmap Image (*.bmp)|*.bmp|All files (*.*)|*.*";
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ImageFormat format = ImageFormat.Png;
                        string extension = Path.GetExtension(saveFileDialog.FileName).ToLower();
                        
                        switch (extension)
                        {
                            case ".jpg":
                            case ".jpeg":
                                format = ImageFormat.Jpeg;
                                break;
                            case ".bmp":
                                format = ImageFormat.Bmp;
                                break;
                            default:
                                format = ImageFormat.Png;
                                break;
                        }

                        processedImage.Save(saveFileDialog.FileName, format);
                        UpdateStatus($"Result saved to: {Path.GetFileName(saveFileDialog.FileName)}");
                        MessageBox.Show("Image saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error saving image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        UpdateStatus("Error saving image");
                    }
                }
            }
        }

        private void UpdateStatus(string message)
        {
            lblStatus.Text = $"Status: {message}";
            Application.DoEvents();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            originalImage?.Dispose();
            processedImage?.Dispose();
            base.OnFormClosing(e);
        }
    }
}

