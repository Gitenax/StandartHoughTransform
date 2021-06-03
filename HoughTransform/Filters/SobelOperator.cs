using System;
using System.Drawing;

namespace HoughTransform.Filters
{
    public class SobelOperator
    {
        private Bitmap _image;
        private Color  _outlineColor;
        private Color  _backgroundColor;
        private int    _limit;

        
        public SobelOperator(Image image, Color outlineColor, Color backgroundColor, int limit)
        {
            _image           = new Bitmap(image);
            _outlineColor    = outlineColor;
            _backgroundColor = backgroundColor;
            _limit           = limit;
        }
        

        public Bitmap Execute()
        {
            /* -------------------------------------------------------------------------------- */
            /* ---[ Инициализация переменных ]------------------------------------------------- */
            
            // Ширина и высота изображения (в пикселях)
            int width  = _image.Width;
            int height = _image.Height;

            Bitmap resultImage = new Bitmap(_image);
            
            /*Bitmap resultImage = new Bitmap(width, height, PixelFormat.Format24bppRgb);
            using (var g = Graphics.FromImage(resultImage))
            {
                g.FillRectangle(Brushes.Black, 0, 0, width, height);
            }*/
            
            // Приближенные производные
            int[,] Gx = { {-1, 0, 1}, {-2, 0, 2}, {-1,  0,  1} };
            int[,] Gy = { { 1, 2, 1}, { 0, 0, 0}, {-1, -2, -1} };

            // Массив пикселей каждого цветта
            byte[,] redPixels   = new byte[height, width];
            byte[,] greenPixels = new byte[height, width];
            byte[,] bluePixels  = new byte[height, width];
            
            // Получение пикселей каждого цвета
            for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
            {
                var pixel = _image.GetPixel(x, y);
                redPixels  [y, x] = pixel.R; 
                greenPixels[y, x] = pixel.G; 
                bluePixels [y, x] = pixel.B;
            }
            
            
            /* -------------------------------------------------------------------------------- */
            /* ---[ Преобразование ]----------------------------------------------------------- */
            
            // Новые значения для каждого пикселя
            double newRedX,   newRedY,   redColor;
            double newGreenX, newGreenY, greenColor;
            double newBlueX,  newBlueY,  blueColor;

            int filterOffset = 1;
            
            for (int y = filterOffset; y < height - filterOffset; y++)
            {
                for (int x = filterOffset; x < width - filterOffset; x++)
                {
                    // Обнуление на каждой итерации
                    newRedX = newRedY = newGreenX = newGreenY = newBlueX = newBlueY = redColor = greenColor = blueColor = 0;
        
                    for (int filterY = -filterOffset; filterY <= filterOffset; filterY++)
                    {
                        for (int filterX = -filterOffset; filterX <= filterOffset; filterX++)
                        {
                            redColor = redPixels[y + filterY, x + filterX];
                            newRedX += Gx[filterY + 1, filterX + 1] * redColor;
                            newRedY += Gy[filterY + 1, filterX + 1] * redColor;

                            greenColor = greenPixels[y + filterY, x + filterX];
                            newGreenX += Gx[filterY + 1, filterX + 1] * greenColor;
                            newGreenY += Gy[filterY + 1, filterX + 1] * greenColor;

                            blueColor = bluePixels[y + filterY, x + filterX];
                            newBlueX += Gx[filterY + 1, filterX + 1] * blueColor;
                            newBlueY += Gy[filterY + 1, filterX + 1] * blueColor;
                        }
                    }
                    
                    // Если значение одного из цветов больше предела, то выполняем заливку 
                    // иначе просто закрашиваем пиксель в белый
                    var r = Math.Sqrt(newRedX   * newRedX   + newRedY   * newRedY);
                    var g = Math.Sqrt(newGreenX * newGreenX + newGreenY * newGreenY);
                    var b = Math.Sqrt(newBlueX  * newBlueX  + newBlueY  * newBlueY);
                    
                    // Назначение цвета пикселя согласно условию

                    r = r > _limit ? 255 : r < 0 ? 0 : r;
                    g = g > _limit ? 255 : g < 0 ? 0 : g;
                    b = b > _limit ? 255 : b < 0 ? 0 : b;

                    
                    resultImage.SetPixel(x - 1, y - 1, Color.FromArgb((int)r, (int)g, (int)b));
                    
                    
                    /*if (r + b + g > _limit )
                        resultImage.SetPixel(x - 1, y - 1, _outlineColor);
                    else
                        resultImage.SetPixel(x - 1, y - 1, _backgroundColor);*/
                }
            }

            // Костыль, чтобы отсечь ненужные пики по краям изображения
            using (var g = Graphics.FromImage(resultImage))
                g.DrawRectangle(new Pen(Color.Black, resultImage.HorizontalResolution / 12), 0, 0, width, height);
            
            
            System.Diagnostics.Debug.WriteLine($"Sobel size: {resultImage.Width}x{resultImage.Height}");
            return resultImage;
        }
    }
}