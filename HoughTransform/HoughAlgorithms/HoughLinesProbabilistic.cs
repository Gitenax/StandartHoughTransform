using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using HoughTransform.Filters;
using HoughTransform.Shapes;

namespace HoughTransform.HoughAlgorithms
{
    public class HoughLinesProbabilistic : HoughBase<Line>
    {
        private int _minLineLenght = 100;
        private int _maxLineGap = 10;
        private double _scaleValue = 0.1D;
        
        private List<Line> _lines1 = new List<Line>();
        private List<Line> _lines2 = new List<Line>();

        public Bitmap DrawLines(Bitmap binaryImage, Pen drawingPen)
        {
            Bitmap imageWithLines = new Bitmap(binaryImage);
            
            // Рисование линий
            using (var g = Graphics.FromImage(imageWithLines))
            {
                foreach (Line line in _shapes)
                {
                    g.DrawLine(drawingPen, // Цвет и толщина линии
                        line.Start.X,      // X координата 1-й точки
                        line.Start.Y,      // Y координата 1-й точки
                        line.End.X,        // X координата 2-й точки
                        line.End.Y);       // Y координата 2-й точки
                }
            }
            
            System.Diagnostics.Debug.WriteLine($"Image With Lines size: {imageWithLines.Width}x{imageWithLines.Height}");
            return imageWithLines;
        }

        public Bitmap DrawPixels(BitmapData data)
        {
            var availablePixels = GetOnPixels(ref data);
            
            Bitmap     newImage    = GrayscaledImage.CreateGrayscaleImage(_imageWidth, _imageHeight);
            BitmapData imageData   = newImage.LockBits(new Rectangle(0, 0, _imageWidth, _imageHeight), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

            unsafe
            {
                byte* pointer = (byte*)imageData.Scan0.ToPointer();
                
                for (int y = 0; y < _imageHeight; y++, pointer += _imageStrideOffset)
                {
                    for (int x = 0; x < _imageWidth; x++, pointer++)
                    {
                        if (availablePixels.Contains(new Point(x, y)))
                        {
                            *pointer = 255;
                        }
                    }
                }
            }

            newImage.UnlockBits(imageData);
            return newImage;
        }

        
        
        protected override void ProcessImage(ref BitmapData data, Rectangle rect)
        {
            var _random = new Random();
            
            _houghMap = new short[_thetaAngles, _rhoMax];

            // collect ON pixels (in src image) to onPixels*/
            var availablePixels = GetOnPixels(ref data);
            
            // Если нет пикселей, то выходим
            while (availablePixels.Count > 0)
            {
                // select a random ON pixel from onPixels
                // +int randomNum = util.generateRandomNumberOpenCV(onPixels->total);
                int randomNum = _random.Next(0, availablePixels.Count);

                // Выбираем случайный пиксель
                var selected = availablePixels[randomNum];

                // Берем его координаты на изображении
                var (x, y) = (selected.X, selected.Y);

                // update accumulator with the selected random pixel
                AccumulateOrDeaccumulate(x, y, 1);
                availablePixels.RemoveAt(randomNum);

                // find highest peak in accumulator		
                int maxIntensityTheta = 0,
                    maxIntensityRho   = 0;

                _maxMapIntensity = 0;
                for (int i = 0; i < _thetaAngles; i++)
                for (int j = 0; j < _rhoMax; j++)
                {
                    int value = _houghMap[i, j];

                    if (value > _maxMapIntensity)
                    {
                        _maxMapIntensity  = value;
                        maxIntensityTheta = i;
                        maxIntensityRho   = j;
                    }
                }

                if (_maxMapIntensity < _minIntensity) continue;
                
                // смотреть по коридору, обозначенному пиком в гидроаккумуляторе
                //    (fиз текущей точки пройдите в каждом направлении по найденной линии и извлеките отрезок линии)
                double rho = (maxIntensityRho - _rhoHalf) * _rhoResolution; // CACH TINH RHO TU index
                double theta = maxIntensityTheta * _thetaResolution - (Math.PI / 2); // CACH TINH THETA TU index

                if (Math.Abs(theta) < 5 * (Math.PI / 2) / 90)
                {
                    FindPixelsUpAndDown(x, y, maxIntensityTheta, rho, 1, ref availablePixels);
                    FindPixelsUpAndDown(x, y, maxIntensityTheta, rho, -1, ref availablePixels);
                }
                else
                {
                    FindPixelsLeftAndRight(x, y, maxIntensityTheta, rho, 1, ref availablePixels);
                    FindPixelsLeftAndRight(x, y, maxIntensityTheta, rho, -1, ref availablePixels);
                }

                // if line segment > min length, add it into output list (connect 2 lines,which run in 2 directions, together)
                int startX = _lines1[0].End.X;	
                int startY = _lines1[0].End.Y;
                int endX   = _lines2[0].End.X;	
                int endY   = _lines2[0].End.Y;
                
                _lines1.Clear();
                _lines2.Clear();
                
                if (Math.Abs(startX - endX) >= _minLineLenght || Math.Abs(startY - endY) >= _minLineLenght) 
                {
                    var start = new Point(startX, startY);
                    var end   = new Point(endX, endY);
                    
                    _shapes.Add(new Line(start, end));
                }
            }
        }

        protected override void CollectShapes()
        {
            // do nothing
        }

        private unsafe List<Point> GetOnPixels(ref BitmapData image)
        {
            var   onPixels = new List<Point>();
            byte* pointer  = (byte*) image.Scan0.ToPointer();
            
            int offset = 1;

            for (int y = 0; y < _imageHeight; y += offset, pointer += (offset - 1) * image.Stride)
            for (int x = 0; x < _imageWidth; x += offset,  pointer += offset)
            {
                if (*pointer > 0)
                    onPixels.Add(new Point(x, y));
            }
            
            return onPixels;
        }
        

        
        private void AccumulateOrDeaccumulate(int x, int y, int accOrDeacc)
        {
            for (int theta = 0; theta < _thetaAngles; theta++)
            {
                /*double radius    = x * _cosMap[theta] + y * _sinMap[theta];
                int indexRho     = (int) Math.Round(radius / _rhoResolution + halfOfRho);
                double remainder = radius - (indexRho - halfOfRho) * _rhoResolution;
                 if (remainder > _rhoResolution / 2d)
                    indexRho++;
                _houghMap[theta, indexRho] += (short) accOrDeacc;*/

                int radius = (int) Math.Round(_cosMap[theta] * x + _sinMap[theta] * y) + _rhoHalf;

                //radius = Math.Abs(radius);
                
                if (radius > 0 && radius < _rhoMax)
                {
                    var result = _houghMap[theta, radius] + accOrDeacc;
                    //_houghMap[theta, radius] = Convert.ToInt16(result);
                    
                    _houghMap[theta, radius] = result < 0
                        ? (short)0 
                        : Convert.ToInt16(result);
                }
            }
        }


        private void FindPixelsUpAndDown(int x, int y, int thetaIndex, double rho, int upOrDown, ref List<Point> pixels)
        {
            var (currentX, currentY) = (x, y);
            int maxY;
            bool foundOnPixelInCorridor = false;

            while (true)
            {
                int leftX = -Math.Min(_maxLineGap / 2, currentX);
                int rightX = Math.Min(_maxLineGap / 2, _imageWidth - currentX - 1);

                maxY = upOrDown == 1
                    ? Math.Min(_maxLineGap, _imageHeight - currentY - 1)
                    : Math.Min(_maxLineGap, currentY);

                for (int i = 1; i < maxY; i++)
                {
                    for (int j = leftX; j <= rightX; j++)
                    {
                        if (i == 0 && j == 0) continue;

                        int nextX = currentX + j;
                        int nextY = currentY + upOrDown * i;
                        
                        if(nextX >= _thetaAngles || nextY >= _rhoMax)
                            continue;

                        if (_houghMap[nextX, nextY] > 0
                            && Math.Abs(rho - (nextX * _cosMap[thetaIndex] + nextY * _sinMap[thetaIndex])) < _rhoMax)
                        {
                            // "Unvote" from accumulator all pixels from the line that previously voted
                            if (!pixels.Contains(new Point(nextX, nextY)))
                                AccumulateOrDeaccumulate(nextX, nextY, -1); // -1 means deaccumulate

                            // remove pixels in segment from image
                            pixels.Remove(new Point(nextX, nextY));

                            currentX = nextX;
                            currentY = nextY;
                            foundOnPixelInCorridor = true;
                            break;
                        }
                    }

                    if (foundOnPixelInCorridor) break;
                }

                if (!foundOnPixelInCorridor) break;
                foundOnPixelInCorridor = false;
            }
            
            var start = new Point(x, y);
            var end   = new Point(currentX, currentY);
            
            if (upOrDown == 1)
                _lines1.Add(new Line(start, end));
            else
                _lines2.Add(new Line(start, end));
        }
        
        private void FindPixelsLeftAndRight(int x, int y, int thetaIndex, double rho, int leftOrRight, ref List<Point> pixels)
        {
            var (currentX, currentY) = (x, y);
            int maxX;
            bool foundOnPixelInCorridor = false;

            while (true)
            {
                int upperY = -Math.Min(_maxLineGap / 2, currentY);
                int lowerY = Math.Min(_maxLineGap / 2, _imageHeight - currentY);

                maxX = leftOrRight == 1
                    ? Math.Min(_maxLineGap, _imageWidth - currentX)
                    : Math.Min(_maxLineGap, currentX);

                for (int i = upperY; i <= lowerY; i++)
                {
                    for (int j = 1; j < maxX; j++)
                    {
                        if (i == 0 && j == 0) continue;

                        int nextX = currentX + leftOrRight * j;
                        int nextY = currentY + i;
                        
                        if(nextX >= _thetaAngles || nextY >= _rhoMax)
                            continue;
                        
                        
                        if (_houghMap[nextX, nextY] > 0
                            && Math.Abs(rho - (nextX * _cosMap[thetaIndex] + nextY * _sinMap[thetaIndex])) < _rhoMax)
                        {
                            // "Unvote" from accumulator all pixels from the line that previously voted
                            if (!pixels.Contains(new Point(nextX, nextY)))
                                AccumulateOrDeaccumulate(nextX, nextY, -1); // -1 means deaccumulate

                            // remove pixels in segment from image
                            pixels.Remove(new Point(nextX, nextY));

                            currentX = nextX;	
                            currentY = nextY;
                            foundOnPixelInCorridor = true;
                            break;
                        }
                    }

                    if (foundOnPixelInCorridor) break;
                }

                if (!foundOnPixelInCorridor) break;
                foundOnPixelInCorridor = false;
            }
            
            var start = new Point(x, y);
            var end   = new Point(currentX, currentY);
            
            if (leftOrRight == 1)
                _lines1.Add(new Line(start, end));
            else
                _lines2.Add(new Line(start, end));
        }
    }
}