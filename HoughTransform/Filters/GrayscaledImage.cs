using System.Drawing;
using System.Drawing.Imaging;

namespace HoughTransform.Filters
{
    public class GrayscaledImage
    {
        private Bitmap _image;


        public GrayscaledImage(Image original)
        {
            _image = (Bitmap)original;
            
            // Обработка изображения
            AssertGrayscale();
        }

        
        // Явное преобразование для получения обработанной картинки
        public static explicit operator Image(GrayscaledImage grayscaledImage)  => grayscaledImage?._image;
        public static explicit operator Bitmap(GrayscaledImage grayscaledImage) => grayscaledImage?._image;


        /// <summary>Создает пустое изображение в градациях серого</summary>
        public static Bitmap CreateGrayscaleImage(int width, int height)
        {
            Bitmap newImage = new Bitmap(width, height, PixelFormat.Format8bppIndexed);

            newImage = SetGrayscalePalette(newImage);

            return newImage;
        }

  
        private void AssertGrayscale()
        {
            // Новое изображение
            var newBitmap = new Bitmap(_image.Width, _image.Height, PixelFormat.Format8bppIndexed);
            newBitmap = SetGrayscalePalette(newBitmap);
      
            var bmpData    = _image.LockBits(new Rectangle(0, 0, _image.Width, _image.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            var outputData = newBitmap.LockBits(new Rectangle(0, 0, newBitmap.Width, newBitmap.Height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);
            
            var bmpStride    = bmpData.Stride;
            var outputStride = outputData.Stride;
            
            // Проход кажого пикселя
            unsafe
            {
                byte* bmpPtr    = (byte*) bmpData.Scan0.ToPointer();
                byte* outputPtr = (byte*) outputData.Scan0.ToPointer();
                
                // Преобразование пикселя по яркоси:
                // L = .299*R + .587*G + .114*B
                // ic - входной столбец
                // oc - выходной столбец.
                for (int r = 0; r < _image.Height; r++)
                for (int oc = 0, ic = 0; oc < _image.Width; ic += 3, ++oc)
                {
                    outputPtr[r * outputStride + oc] = (byte) (int)
                        (0.299F * bmpPtr[r * bmpStride + ic] +
                         0.587F * bmpPtr[r * bmpStride + ic + 1] +
                         0.114F * bmpPtr[r * bmpStride + ic + 2]);
                }
            }

            _image.UnlockBits(bmpData);
            newBitmap.UnlockBits(outputData);

            // Замена полученного изображения на обработанное
            _image = newBitmap;
        }
        
        private static Bitmap SetGrayscalePalette(Bitmap image)
        {
            ColorPalette palette = image.Palette;

            for (int i = 0; i < 256; i++)
                palette.Entries[i] = Color.FromArgb(i, i, i);

            image.Palette = palette;

            return image;
        }
    }
}