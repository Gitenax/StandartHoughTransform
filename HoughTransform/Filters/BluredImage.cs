using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace HoughTransform.Filters
{
    public class BluredImage
    {
        private readonly Bitmap _image;
        

        public BluredImage(Image original, int lenght, double weight)
        {
            _image = (Bitmap)original;
            _image = Convolve(GetKernel(lenght, weight));;
        }


        public static explicit operator Image(BluredImage bluredImage) => bluredImage?._image;
        
        
        private Bitmap Convolve(double[,] kernel)
        {
            var width  = _image.Width;
            var height = _image.Height;
            
            var srcData = _image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            
            var bytes = srcData.Stride * srcData.Height;
            
            var buffer = new byte[bytes];
            var result = new byte[bytes];
            
            Marshal.Copy(srcData.Scan0, buffer, 0, bytes);
            _image.UnlockBits(srcData);
            
            var colorChannels = 3;
            var rgb = new double[colorChannels];
            var foff = (kernel.GetLength(0) - 1) / 2;
            var kcenter = 0;
            var kpixel = 0;
            
            for (var y = foff; y < height - foff; y++)
            for (var x = foff; x < width - foff; x++)
            {
                for (var c = 0; c < colorChannels; c++) 
                    rgb[c] = 0.0;
                
                kcenter = y * srcData.Stride + x * 4;
                
                for (var fy = -foff; fy <= foff; fy++)
                for (var fx = -foff; fx <= foff; fx++)
                {
                    kpixel = kcenter + fy * srcData.Stride + fx * 4;
                    
                    for (var c = 0; c < colorChannels; c++) 
                        rgb[c] += buffer[kpixel + c] * kernel[fy + foff, fx + foff];
                }

                for (var c = 0; c < colorChannels; c++)
                {
                    if      (rgb[c] > 255) rgb[c] = 255;
                    else if (rgb[c] < 0)   rgb[c] = 0;
                }
                
                for (var c = 0; c < colorChannels; c++) 
                    result[kcenter + c] = (byte) rgb[c];
                
                result[kcenter + 3] = 255;
            }

            var resultImage = new Bitmap(width, height);
            var resultData  = resultImage.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);
            Marshal.Copy(result, 0, resultData.Scan0, bytes);
            resultImage.UnlockBits(resultData);

            return resultImage;
        }
        
        private static double[,] GetKernel(int lenght, double weight)
        {
            double[,] kernel    = new double[lenght, lenght];
            double    kernelSum = 0;
            int       foff      = (lenght - 1) / 2;
            double    distance  = 0;
            double    constant  = 1d / (2 * Math.PI * weight * weight);
            
            for (int y = -foff; y <= foff; y++)
            for (int x = -foff; x <= foff; x++)
            {
                distance                   = (y * y + x * x) / (2 * weight * weight);
                kernel[y + foff, x + foff] = constant * Math.Exp(-distance);
                kernelSum                 += kernel[y + foff, x + foff];
            }
            
            for (int y = 0; y < lenght; y++)
            for (int x = 0; x < lenght; x++)
            {
                kernel[y, x] = kernel[y, x] * 1d / kernelSum;
            }
            
            return kernel;
        }
    }
}