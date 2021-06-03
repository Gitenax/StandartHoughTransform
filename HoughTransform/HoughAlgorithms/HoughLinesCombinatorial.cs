using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading.Tasks;
using HoughTransform.Shapes;

namespace HoughTransform.HoughAlgorithms
{
    public class HoughLinesCombinatorial : HoughBase<Line>
    {
        private int _piecesCount = 10;
        
        
        protected override void ProcessImage(ref BitmapData data, Rectangle rect)
        {
            // Деление на части
            List<byte[,]> pieces = new List<byte[,]>();
            List<Rectangle> rects = new List<Rectangle>();

            int pieceWidth  = _imageWidth  / _piecesCount;
            int pieceHeight = _imageHeight / _piecesCount;

            for (int y = 0; y < _piecesCount; y++)
            for (int x = 0; x < _piecesCount; x++)
            {
                var rectangle = new Rectangle(x * pieceWidth, y * pieceHeight, pieceWidth, pieceHeight);
                pieces.Add(GetPieceFromImage(rectangle, data));
                rects.Add(rectangle);
            }
            
            
            // Расчеты
            _houghMap = new short[_thetaAngles, _rhoMax];

            Parallel.For(0, pieces.Count, (i, state) =>
            {
                ProcessPiece(pieces[i], rects[i]);
            });
            
            // Поиск максимального значения в пространстве Хафа
            _maxMapIntensity = GetMaxIntensity(_thetaAngles, _rhoMax);
        }

        private unsafe byte[,] GetPieceFromImage(Rectangle rect, BitmapData data)
        {
            byte[,] pixels  = new byte[rect.Height, rect.Width];
            byte*   pointer = (byte*)data.Scan0.ToPointer();

            pointer += rect.Y * data.Stride;
            
            for (int y = rect.Y; y < rect.Height; y++, pointer += data.Stride)
            for (int x = rect.X; x < rect.Width;  x++, pointer++)
            {
                pixels[y, x] = *pointer;
            }
            
            return pixels;
        }

        private void ProcessPiece(byte[,] pixels, Rectangle rect)
        {
            // Определение предельных координат x, y для декартовой системы
            int height = pixels.GetLength(0);
            int width  = pixels.GetLength(1);
            int startX = -(width / 2);
            int startY = -(height / 2);
            int stopX  = width - (width / 2);
            int stopY  = height - (height / 2);
            
            int rhoHalf = (int)Math.Sqrt((width / 2) * (width / 2) + (height / 2) * (height / 2));
            int rhoMax = rhoHalf * 2;

            for (int y = startY; y < stopY; y++)
            for (int x = startX; x < stopX; x++)
            {
                int currentX = width + startX + x;
                int currentY = height + startY + y;
                
                if(currentX >= width)  continue;
                if(currentY >= height) break;
                
                if (pixels[currentY, currentX] > 0)
                {
                    // Перебираем каждый угол от 0 до 180 для каждого пикселя
                    for (int theta = 0; theta < _thetaAngles; theta++)
                    {
                        int radius = (int) Math.Round(_cosMap[theta] * x - _sinMap[theta] * y) + rhoHalf;
                            
                        if(radius > 0 && radius < rhoMax)
                            _houghMap[theta, radius]++;
                    }
                }
            }
        }
        

        protected override void CollectShapes()
        {
            //
        }
    }
}