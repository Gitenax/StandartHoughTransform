using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HoughTransform.Services
{
    public class FileManager
    {
        public event Action<Image> ImageLoaded;
        
        
        public void OpenImage()
        {
            FileInfo selectedFile = default;
            
            using (var dialog = new OpenFileDialog())
            {
                dialog.InitialDirectory = Application.StartupPath;
                dialog.Title = "Открыть изображение";
                dialog.Filter = "Изображения PNG (*.png)|*.png" +
                                "|Изображения JPEG (*.jpg)|*.jpg"+
                                "|Изображения BMP (*.bmp)|*.bmp";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFile = new FileInfo(dialog.FileName);
                    var image = Image.FromFile(selectedFile.FullName);
                    ImageLoaded?.Invoke(image);
                }
            }
        }

        public string GetImageInfoString(Image image)
        {
            return $"Ширина: {image.Width}, " +
                   $"Высота: {image.Height} | " +
                   $"Разрешение: {image.HorizontalResolution}x{image.VerticalResolution}";
        }
    }
}