using System;
using System.Drawing;
using HoughTransform.Filters;
using HoughTransform.HoughAlgorithms;
using HoughTransform.Shapes;

namespace HoughTransform
{
    public class HoughTransform
    {
        private Bitmap _originalImage;
        

        
        public HoughTransform(Bitmap image)
        {
            _originalImage = image;
            DrawingPen = new Pen(new SolidBrush(Color.FromArgb(200, Color.Red)), 5);
            Accuracy = 0.6;
        }

        public HoughTransform(Bitmap image, Pen linePen, double accuracy)
        {
            _originalImage = image;
            DrawingPen = linePen;
            Accuracy = accuracy;
        }
       

        // от [0, 1] чем выше значение, тем меньше точность
        public double Accuracy { get; set; }

        public Pen DrawingPen { get; }
        
        public Line[] Lines { get; private set; }
        public Circle[] Circles { get; private set; }

        public Bitmap BinaryImage { get; set; }
        
        public Bitmap LineTransform()
        {
            var gray = new GrayscaledImage(_originalImage);
            Bitmap binaryImage = (Bitmap)gray;
            
            var lineTransform = new HoughLinesStandart();
            lineTransform.ProcessImage(binaryImage);
            
            // Обнаруженные линии
            Lines = lineTransform.GetShapesByRelativeIntensity(Accuracy);
            BinaryImage = binaryImage;

            // Пространство Хафа
            return lineTransform.GetHoughSpaceImage();;
        }
        
        public Bitmap CircleTransform(int detectRadius = 35)
        {
            var gray = new GrayscaledImage(_originalImage);
            Bitmap binaryImage = (Bitmap)gray;
            BinaryImage = binaryImage;

            var circleTransform = new HoughCircle(detectRadius);
            circleTransform.ProcessImage(binaryImage);

            Circles = circleTransform.GetShapesByRelativeIntensity(0.8);

            return circleTransform.GetHoughSpaceImage();
        }


        public Bitmap DrawCircles(Bitmap binaryImage)
        {
            Bitmap imageWithCircles = new Bitmap(binaryImage);
            foreach (Circle circle in Circles)
            {

                // Рисование кругов
                using (var g = Graphics.FromImage(imageWithCircles))
                {
                    int x = circle.X;
                    int y = circle.Y;
                    int r = circle.Radius;
                    
                    g.DrawEllipse(DrawingPen, x - r, y - r,r + r, r + r);
                }
                
                
                string s = string.Format("X = {0}, Y = {1}, I = {2} ({3})", circle.X, circle.Y, circle.Intensity, circle.RelativeIntensity);
                System.Diagnostics.Debug.WriteLine(s);
            }
            return imageWithCircles;
        }
    }
}