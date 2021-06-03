using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using HoughTransform.Filters;
using HoughTransform.Shapes;

namespace HoughTransform.HoughAlgorithms
{
    public abstract class HoughBase<T> where T : Shape
    {
        // Пространство Хафа
        protected short[,] _houghMap;
        protected int      _maxMapIntensity;
        protected int      _localPeakRadius  = 4;
        protected int      _minIntensity = 10;
        
        protected int _imageWidth;
        protected int _imageHeight;
        protected int _imageCenterX;
        protected int _imageCenterY;
        protected int _imageStrideOffset;
        
        protected int    _rhoMax;
        protected int    _rhoHalf;
        protected int    _thetaAngles = 181;
        protected int    _rhoResolution = 1;
        protected double _thetaResolution = Math.PI / 180;
        
        
        // Предварительно рассчитанные значения синуса и косинуса
        protected double[] _sinMap;
        protected double[] _cosMap;

        // Массив найденых фигур
        protected List<T> _shapes = new List<T>();

        public HoughBase()
        {
            PrecalculateAngles();
        }


        public event HoughEvent ProcessingStarted;
        public event HoughEvent ProcessingChanged;
        public event HoughEvent ProcessingComplete;
        
        
        
        /// <summary>Максимальная найденная интенсивность в пространстве Хафа.</summary>
        /// <remarks><para>Свойство обеспечивает максимальную интенсивность найденной фигуры.</para></remarks>
        public int MaxIntensity => _maxMapIntensity;
        
        /// <summary>Радиус поиска локального пикового значения.</summary>
        /// <remarks><para>Значение определяет радиус вокруг значения пространства, которое анализируется,
        /// чтобы определить, является ли значение пространства локальным максимумом в указанной области.</para>
        /// <para>Значение по умолчанию: <b>4</b>. Минимум: <b>1</b>. Максимум: <b>10</b>.</para></remarks>
        public int LocalPeakRadius
        {
            get => _localPeakRadius;
            set => _localPeakRadius = Math.Max(1, Math.Min(10, value));
        }
        
        /// <summary>Минимальная интенсивность в пространстве Хафа для распознавания фигуры.</summary>
        /// <remarks><para>Значение устанавливает минимальный уровень интенсивности для фигуры.
        /// Если значение в пространстве Хафа имеет более низкую интенсивность, оно не рассматривается как фигура.</para>
        /// <para>Значение по умолчанию: <see langword="10"/>.</para></remarks>
        public int MinLineIntensity
        {
            get => _minIntensity;
            set => _minIntensity = value;
        }

        public List<T> Shapes => _shapes;


        public void ProcessImage(Bitmap image)
        {
            // Проверка формата изображения
            if (image.PixelFormat != PixelFormat.Format8bppIndexed)
                throw new FormatException("Не поддерживаемый формат пикселей изображения");

            _imageWidth   = image.Width;
            _imageHeight  = image.Height;
            _imageCenterX = _imageWidth / 2;
            _imageCenterY = _imageHeight / 2;
            _rhoMax       = (int) Math.Sqrt(_imageWidth * _imageWidth + _imageHeight * _imageHeight);
            _rhoHalf      = _rhoMax / 2;
            
            BitmapData imageData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
            
            _imageStrideOffset   = imageData.Stride - _imageWidth;
            
            try
            {
                ProcessImage(ref imageData, new Rectangle(0, 0, image.Width, image.Height));
                CollectShapes();
            }
            finally { image.UnlockBits(imageData); }
        }

        public Bitmap GetHoughSpaceImage()
        {
            // Проверка, что преобразование Хафа уже выполнено
            if (_houghMap == null)
                throw new InvalidOperationException("Преобразование Хафа еще не выполнено.");

            int width  = _houghMap.GetLength(1);
            int height = _houghMap.GetLength(0);

            // Создание нового изображения
            Bitmap image = GrayscaledImage.CreateGrayscaleImage(width, height);
            
            BitmapData imageData = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.WriteOnly, PixelFormat.Format8bppIndexed);

            int offset  = imageData.Stride - width;
            float scale = 255F / _maxMapIntensity;
            
            unsafe
            {
                byte* pointer = (byte*)imageData.Scan0.ToPointer();

                for (int y = 0; y < height; y++, pointer += offset)
                for (int x = 0; x < width;  x++, pointer++)
                {
                    *pointer = (byte)Math.Min(255, (int)(scale * _houghMap[y, x]));
                }
            }

            image.UnlockBits(imageData);

            System.Diagnostics.Debug.WriteLine($"Hough space image size: {image.Width}x{image.Height}");
            
            return image;
        }
        
        public T[] GetShapesByRelativeIntensity(double minRelativeIntensity)
        {
            int count = 0;
            int n = _shapes.Count;
            
            var output = new List<T>();
            
            while (count < n && _shapes[count].RelativeIntensity >= minRelativeIntensity)
            {
                output.Add(_shapes[count]);
                count++;
            }
            
            return output.ToArray();
        }
        
        protected short GetMaxIntensity(int height, int width)
        {
            short intensity = 0;
            
            for (int y = 0; y < height; y++)
            for (int x = 0; x < width; x++)
            {
                if (_houghMap[y, x] > intensity)
                    intensity = _houghMap[y, x];
            }

            return intensity;
        }

        protected virtual void OnProcessingStarted(HoughEventArgs e)  => ProcessingStarted?.Invoke(this, e);
        protected virtual void OnProcessingChanged(HoughEventArgs e)  => ProcessingChanged?.Invoke(this, e);
        protected virtual void OnProcessingComplete(HoughEventArgs e) => ProcessingComplete?.Invoke(this, e);
        
        
        protected abstract void ProcessImage(ref BitmapData data, Rectangle rect);

        protected abstract void CollectShapes();
        
        
        private void PrecalculateAngles()
        {
            // предварительные вычисления значения синуса и косинуса
            _sinMap = new double[_thetaAngles];
            _cosMap = new double[_thetaAngles];
            
            for (int i = 0; i < 180; i++)
            {
                _sinMap[i] = Math.Sin(i * _thetaResolution);
                _cosMap[i] = Math.Cos(i * _thetaResolution);
            }
        }
    }
}