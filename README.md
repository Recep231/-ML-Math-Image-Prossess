# ML Math Image Processor

C# WinForms uygulaması ile matematik görüntülerini işlemek için geliştirilmiş bir makine öğrenmesi görüntü işleme uygulaması.

## Özellikler

- 📸 Görüntü yükleme (JPG, PNG, BMP, GIF)
- 🔍 Görüntü işleme (kenar tespiti, kontrast artırma, eşikleme)
- 📊 İşleme sonuçlarını görüntüleme
- 💾 İşlenmiş görüntüleri kaydetme
- ⚡ Asenkron işleme desteği

## Gereksinimler

- .NET 8.0 SDK veya üzeri
- Windows işletim sistemi
- Visual Studio 2022 veya Visual Studio Code (isteğe bağlı)

## Kurulum

1. Projeyi klonlayın veya indirin
2. Terminal/Command Prompt'ta proje dizinine gidin:
   ```bash
   cd "ML Math Image Prossess"
   ```

3. NuGet paketlerini geri yükleyin:
   ```bash
   dotnet restore
   ```

4. Projeyi derleyin:
   ```bash
   dotnet build
   ```

5. Uygulamayı çalıştırın:
   ```bash
   dotnet run
   ```

## Kullanım

1. **Görüntü Yükleme**: "Load Image" butonuna tıklayarak bir matematik görüntüsü seçin
2. **İşleme**: "Process Image" butonuna tıklayarak görüntüyü işleyin
3. **Sonuçları Görüntüleme**: İşleme sonuçları sağ panelde görüntülenecektir
4. **Kaydetme**: "Save Result" butonuna tıklayarak işlenmiş görüntüyü kaydedin

## İşleme Teknikleri

Uygulama aşağıdaki görüntü işleme tekniklerini kullanır:

- **Kenar Tespiti (Edge Detection)**: Sobel operatörü ile kenar tespiti
- **Kontrast Artırma**: Histogram eşitleme ve kontrast germe
- **Gri Tonlama**: RGB'den gri tonlama dönüşümü
- **Eşikleme (Thresholding)**: Otsu algoritması ile otomatik eşikleme

## Geliştirme

### Proje Yapısı

- `Form1.cs` - Ana form ve kullanıcı arayüzü mantığı
- `Form1.Designer.cs` - Form tasarımı ve kontroller
- `ImageProcessor.cs` - Görüntü işleme algoritmaları
- `Program.cs` - Uygulama giriş noktası

### Gelecek Geliştirmeler

- OCR entegrasyonu (Tesseract veya Azure Computer Vision)
- Gerçek zamanlı matematik sembol tanıma
- ML.NET model eğitimi ve kullanımı
- Çoklu görüntü toplu işleme
- PDF'den görüntü çıkarma

## Lisans

Bu proje eğitim amaçlı geliştirilmiştir.

## Notlar

- Bu uygulama temel görüntü işleme tekniklerini gösterir
- Gerçek matematik sembol tanıma için OCR kütüphaneleri (Tesseract, Azure Computer Vision) entegre edilmelidir
- ML.NET paketleri projeye eklenmiştir ancak henüz kullanılmamaktadır (gelecek geliştirmeler için)

