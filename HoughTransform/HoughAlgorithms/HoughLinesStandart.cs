using System;
using System.Drawing;
using System.Drawing.Imaging;
using HoughTransform.Shapes;

namespace HoughTransform.HoughAlgorithms
{
    public class HoughLinesStandart : HoughBase<Line>
    { 
        public Bitmap DrawLines(Bitmap binaryImage, Pen drawingPen, Line[] lines)
        {
            Bitmap imageWithLines = new Bitmap(binaryImage);
            
            drawingPen = new Pen(new SolidBrush(Color.Red), 1);
            
            
            using (var g = Graphics.FromImage(imageWithLines))
            {
                foreach (var line in lines)
                {
                    int radius = line.Radius;
                    var theta = line.Theta;

                    if (radius < 0)
                    {
                        theta += 180;
                        radius = -radius;
                    }

                    theta = theta / 180 * Math.PI;

                    var halfWidth = binaryImage.Width / 2;
                    var halfHeight = binaryImage.Height / 2;

                    double x0, x1, y0, y1;
                    
                    if (line.Theta != 0)
                    {
                        x0 = -halfWidth;
                        x1 = halfWidth;

                        y0 = (-Math.Cos(theta) * x0 + radius) / Math.Sin(theta);
                        y1 = (-Math.Cos(theta) * x1 + radius) / Math.Sin(theta);
                    }
                    else
                    {
                        x0 = line.Radius;
                        x1 = line.Radius;
                        y0 = halfHeight;
                        y1 = -halfHeight;
                    }

                    // Рисование линий
                    int startX = Math.Abs((int)x0 + halfWidth);
                    int startY = Math.Abs((int)y0 - halfHeight);
                    int endX   = Math.Abs((int)x1 + halfWidth);
                    int endY   = Math.Abs((int)y1 - halfHeight);


                    startX = Math.Min(startX, binaryImage.Width);
                    startY = Math.Min(startY, binaryImage.Height);
                    endX   = Math.Min(endX,   binaryImage.Width);
                    endY   = Math.Min(endY,   binaryImage.Height);
                    
                    g.DrawLine(drawingPen, // Цвет и толщина линии
                        startX, // X координата 1-й точки
                        startY, // Y координата 1-й точки
                        endX, // X координата 2-й точки
                        endY); // Y координата 2-й точки
                }
            }
            
            System.Diagnostics.Debug.WriteLine($"Image With Lines size: {imageWithLines.Width}x{imageWithLines.Height}");
            return imageWithLines;
        }
        
        protected override void ProcessImage(ref BitmapData data, Rectangle rect)
        {
            OnProcessingStarted(new HoughEventArgs(_imageHeight * _imageWidth, 0));
            
            // Определение предельных координат x, y для декартовой системы
            int startX = -_imageCenterX;
            int startY = -_imageCenterY;
            int stopX  = _imageWidth - _imageCenterX;
            int stopY  = _imageHeight - _imageCenterY;

            // Нужен только для передачи на какой стадии находится процесс обработки
            int counter = 0;
            
            int offset = data.Stride - rect.Width;

            // Рассчет ширины пространства Хафа
            int R = (int)Math.Sqrt(_imageCenterX * _imageCenterX + _imageCenterY * _imageCenterY);
            int houghWidth = R * 2;

            _houghMap = new short[_thetaAngles, houghWidth];
            
            unsafe
            {
                byte* src = (byte*)data.Scan0.ToPointer();
                
                // Для каждой строки
                for (int y = startY; y < stopY; y++)
                {
                    // Для каждого пикселя в строке
                    for (int x = startX; x < stopX; x++, src++, counter++)
                    {
                        if (*src > 0) // Если значение пикселя отлично от черного
                        {
                            // Перебираем каждый угол от 0 до 180 для каждого пикселя
                            for (int theta = 0; theta < _thetaAngles; theta++)
                            {
                                int radius = (int) Math.Round(_cosMap[theta] * x - _sinMap[theta] * y) + R;
                                
                                if(radius > 0 && radius < houghWidth)
                                     _houghMap[theta, radius]++;
                            }
                        }
                        OnProcessingChanged(new HoughEventArgs(_imageHeight * _imageWidth, counter));
                    }
                    src += offset;
                }
            }
            
            // Поиск максимального значения в пространстве Хафа
            _maxMapIntensity = GetMaxIntensity(180, houghWidth);
            
            OnProcessingComplete(null);
        }
        
        // Собирать линии с большей или равной указанной интенсивностью
        protected override void CollectShapes()
        {
            int maxTheta  = _houghMap.GetLength(0); // Углы
            int maxRadius = _houghMap.GetLength(1); // Радиусы

            short intensity;
            bool  foundGreater;

            int halfHoughWidth = maxRadius >> 1;

            // Очистка массива
            _shapes.Clear();

            for (int theta = 0; theta < maxTheta; theta++)
            for (int radius = 0; radius < maxRadius; radius++)
            {
                // Текущее значение интенсивности в точке
                intensity = _houghMap[theta, radius];

                // Если интенсивность меньше указанной, то игнорируем
                if (intensity < _minIntensity) continue;

                foundGreater = false;

                // Проверка соседних значений
                int ttMax = theta + _localPeakRadius;
                for (int tt = theta - _localPeakRadius; tt < ttMax; tt++)
                {
                    // Прервать если уже есть локальный максимум
                    if (foundGreater) break;

                    int cycledTheta = tt;
                    int cycledRadius = radius;

                    // Проверка порогов
                    if (cycledTheta < 0)
                    {
                        cycledTheta  = maxTheta + cycledTheta;
                        cycledRadius = maxRadius - cycledRadius;
                    }
                    if (cycledTheta >= maxTheta)
                    {
                        cycledTheta -= maxTheta;
                        cycledRadius = maxRadius - cycledRadius;
                    }

                    int trMax = cycledRadius + _localPeakRadius;
                    for (int tr = cycledRadius - _localPeakRadius; tr < trMax; tr++)
                    {
                        if (tr < 0) continue;
                        
                        if(tr >= maxRadius) break;
                        
                        // Сравнить соседа с текущим значением
                        if (_houghMap[cycledTheta, tr] > intensity)
                        {
                            foundGreater = true;
                            break;
                        }
                    }
                }

                
                // Это локальный максимум?
                if (!foundGreater)
                    _shapes.Add(new Line(
                       theta, 
                       (short)(radius - halfHoughWidth), 
                       intensity, 
                       (double)intensity / _maxMapIntensity));
            }
            
            _shapes.Sort();
        }
    }
}