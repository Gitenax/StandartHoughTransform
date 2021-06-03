using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace HoughTransform.Filters
{
    /// <summary>Удаление шумов на изображении</summary>
    public class NoiseFilter
    {
        public static Bitmap Process(Image image)
        {
            return Process((Bitmap) image);
        }
        
        public static Bitmap Process(Bitmap image)
        {
            // Копия изображения
            var bitmap = new Bitmap(image);
            
            var imageData = bitmap.LockBits(
                new Rectangle(0, 0, bitmap.Width, bitmap.Height), 
                ImageLockMode.ReadWrite, 
                bitmap.PixelFormat);
            
            var pointer = imageData.Scan0;
            int bytes = bitmap.Height * Math.Abs(imageData.Stride);
            
            // Пиксели исходного изображения
            byte[] rgbValue = new byte[bytes];
            Marshal.Copy(pointer, rgbValue, 0, bytes);
            
            // Обновленные пиксели
            byte[] rgbNew = new byte[bytes];
            Marshal.Copy(pointer, rgbNew, 0, bytes);

            // Проход по всем пикселям
            for (int j = 4; j < bytes; j += 4)
            {
                if (rgbValue[j - 4] > 200 && rgbValue[j - 3] > 200 && rgbValue[j - 2] > 200)
                {
                    rgbNew[j - 2] = rgbValue[j - 2];
                    rgbNew[j - 3] = rgbValue[j - 3];
                    rgbNew[j - 4] = rgbValue[j - 4];
                }
                else
                {
                    rgbNew[j - 2] = 0;
                    rgbNew[j - 3] = 0;
                    rgbNew[j - 4] = 0;
                }
            }

            Marshal.Copy(rgbNew, 0, pointer, bytes);
            bitmap.UnlockBits(imageData);
            
            return bitmap;
        }
    }
}