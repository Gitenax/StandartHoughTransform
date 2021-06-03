using System;
using System.Drawing;

namespace HoughTransform.Shapes
{
    public class Line : Shape, IComparable<Line>
    {
        private readonly double _theta;
        private readonly short  _radius;
        private readonly Point  _start;
        private readonly Point  _end;
        
        
        /// <param name="theta">Наклон линии.</param>
        /// <param name="radius">Расстояние линии от центра изображения.</param>
        /// <param name="intensity">Абсолютная интенсивность линии.</param>
        /// <param name="relativeIntensity">Относительная интенсивность линии.</param>
        public Line(double theta, short radius, short intensity, double relativeIntensity)
        {
            _theta             = theta;
            _radius            = radius;
            _intensity         = intensity;
            _relativeIntensity = relativeIntensity;
        }

        public Line(Point start, Point end, short intensity, double relativeIntensity)
        {
            _start             = start;
            _end               = end;
            _intensity         = intensity;
            _relativeIntensity = relativeIntensity;
        }
        
        public Line(Point start, Point end)
        {
            _start = start;
            _end   = end;
        }

        
        
        /// <summary>Наклон линии - угол между полярной осью и радиусом линии (нормальный
        /// от полюса до линии). Измеряется в градусах [0, 180).</summary>
        public double Theta => _theta;
        
        /// <summary>Расстояние линии от центра изображения, (−∞, +∞).</summary>
        /// <remarks><note>Отрицательный радиус линии означает, что линия находится в нижнем
        /// часть полярной системы координат. Это означает, что значение <see cref="Theta"/> 
        /// следует увеличить на 180 градусов, а радиус сделать положительным.</note></remarks>
        public short Radius => _radius;
        
        /// <summary>Координаты X/Y начала линии на изображении.</summary>
        public Point Start => _start;

        /// <summary>Координаты X/Y конца линии на изображении.</summary>
        public Point End => _end;


        public int CompareTo(Line other)
        {
            if (Intensity == other.Intensity)
                return -Radius.CompareTo(other.Radius);
            
            return -Intensity.CompareTo(other.Intensity);
        }
    }
}