using System;

namespace HoughTransform.Shapes
{
    public class Circle : Shape, IComparable
    {
        private readonly int    _x;
        private readonly int    _y;
        private readonly int    _radius;
        
        
        /// <param name="x">Центр окружности по X.</param>
        /// <param name="y">Центр окружности по Y.</param>
        /// <param name="radius">Радиус круга.</param>
        /// <param name="intensity">Абсолютная интенсивность.</param>
        /// <param name="relativeIntensity">Относительная интенсивность.</param>
        public Circle(int x, int y, int radius, short intensity, double relativeIntensity)
        {
            _x                 = x;
            _y                 = y;
            _radius            = radius;
            _intensity         = intensity;
            _relativeIntensity = relativeIntensity;
        }

        
        /// <summary>Центр окружности по X</summary>
        public int X => _x;

        /// <summary>Центр окружности по Y</summary>
        public int Y => _y;

        /// <summary>Радиус круга</summary>
        public int Radius => _radius;
        

        public int CompareTo(object obj)
        {
            return -Intensity.CompareTo(((Circle)obj).Intensity);
        }
    }
}