using System.Drawing;
using System.Drawing.Imaging;
using HoughTransform.Shapes;

namespace HoughTransform.HoughAlgorithms
{
    public class HoughCircle : HoughBase<Circle>
    {
        // Радиус круга для обнаружения
        private int _radiusToDetect;
        
        // Ширина и высота пространства Хафа
        private int _width;
        private int _height;
        
        /// <param name="radiusToDetect">Радиус кругов для обнаружения.</param>
        public HoughCircle(int radiusToDetect)
        {
            _radiusToDetect = radiusToDetect;
        }
        
        protected override void ProcessImage(ref BitmapData data, Rectangle rect)
        {
            _width        = data.Width;
            _height       = data.Height;
            int srcOffset = data.Stride - _width;

            // выделить пространство Хафа того же размера, что и изображение
            _houghMap = new short[_height, _width];
            
            unsafe
            {
                byte* src = (byte*)data.Scan0.ToPointer();

                // Для каждой строки
                for (int y = 0; y < _height; y++)
                {
                    // Для каждого пикселя в строке
                    for (int x = 0; x < _width; x++, src++)
                    {
                        if (*src != 0)
                            DrawHoughCircle(x, y);
                    }
                    src += srcOffset;
                }
            }
            // Поиск максимального значения в пространстве Хафа
            _maxMapIntensity = GetMaxIntensity(_height, _width);
            
            CollectShapes();
        }

        
        // Собирайтm круги с интенсивностью больше или равной указанной
        protected override void CollectShapes()
        {
            short intensity;
            bool  foundGreater;

            // Очистка массива
            _shapes.Clear();
            
            for (int y = 0; y < _height; y++)
            for (int x = 0; x < _width; x++)
            {
                // Текущее значение
                intensity = _houghMap[y, x];

                if (intensity < _minIntensity) continue;

                foundGreater = false;

                // Проверка соседей
                for (int ty = y - _localPeakRadius, tyMax = y + _localPeakRadius; ty < tyMax; ty++)
                {
                
                    if (ty < 0) continue;
                    
                    if (foundGreater || ty >= _height) break;

                    for (int tx = x - _localPeakRadius, txMax = x + _localPeakRadius; tx < txMax; tx++)
                    {
                        if (tx < 0) continue;
                        
                        if (tx >= _width) break;
                        
                        if (_houghMap[ty, tx] > intensity)
                        {
                            foundGreater = true;
                            break;
                        }
                    }
                }
                if (!foundGreater)
                    _shapes.Add(new Circle(x, y, _radiusToDetect, intensity, (double)intensity / _maxMapIntensity));
            }
            
            _shapes.Sort();
        }


        private void DrawHoughCircle(int xCenter, int yCenter)
        {
            int x = 0;
            int y = _radiusToDetect;
            int p = (5 - _radiusToDetect * 4) / 4;

            SetHoughCirclePoints(xCenter, yCenter, x, y);

            while (x < y)
            {
                x++;
                if (p < 0)
                    p += 2 * x + 1;
                else
                {
                    y--;
                    p += 2 * (x - y) + 1;
                }

                SetHoughCirclePoints(xCenter, yCenter, x, y);
            }
        }

        private void SetHoughCirclePoints(int cx, int cy, int x, int y)
        {
            if (x == 0)
            {
                SetHoughPoint(cx, cy + y);
                SetHoughPoint(cx, cy - y);
                SetHoughPoint(cx + y, cy);
                SetHoughPoint(cx - y, cy);
            }
            else if (x == y)
            {
                SetHoughPoint(cx + x, cy + y);
                SetHoughPoint(cx - x, cy + y);
                SetHoughPoint(cx + x, cy - y);
                SetHoughPoint(cx - x, cy - y);
            }
            else if (x < y)
            {
                SetHoughPoint(cx + x, cy + y);
                SetHoughPoint(cx - x, cy + y);
                SetHoughPoint(cx + x, cy - y);
                SetHoughPoint(cx - x, cy - y);
                SetHoughPoint(cx + y, cy + x);
                SetHoughPoint(cx - y, cy + x);
                SetHoughPoint(cx + y, cy - x);
                SetHoughPoint(cx - y, cy - x);
            }
        }
        
        private void SetHoughPoint(int x, int y)
        {
            if (x >= 0 && y >= 0 && x < _width && y < _height)
                _houghMap[y, x]++;
        }
    }
}