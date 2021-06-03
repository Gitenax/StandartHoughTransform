using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using HoughTransform.Filters;
using HoughTransform.HoughAlgorithms;
using HoughTransform.Services;
using HoughTransform.Shapes;

namespace HoughTransform
{
    public partial class MainForm : Form
    {
        private FileManager _fileManager;
        
        public MainForm()
        {
            InitializeComponent();
            _fileManager = new FileManager();
            _fileManager.ImageLoaded += ImageManagerOnImageLoaded;

            SetPictureBoxesInvisible();
            SetUpSobelParams();
            SetUpHoughParams();
        }

        private void SetPictureBoxesInvisible()
        {
            GB_Original.Visible  = false;
            GB_Grayscale.Visible = false;
            GB_Gauss.Visible     = false;
            GB_Sobel.Visible     = false;
            GB_Hough.Visible     = false;
            GB_Shapes.Visible    = false;
        }
        
        private void SetPictureBoxesVisible()
        {
            GB_Original.Visible  = true;
            GB_Grayscale.Visible = true;
            GB_Gauss.Visible     = true;
            GB_Sobel.Visible     = true;
            GB_Hough.Visible     = true;
            GB_Shapes.Visible    = true;
        }
        
        private void SetUpSobelParams()
        {
            // Настройка порогового ползунка оператора собеля
            int sobelMax = 255;
            int sobelDefault = sobelMax / 2;
            SobelThresholdTrackBar.Maximum = sobelMax;
            SobelThresholdNumBox.Maximum   = sobelMax;

            SobelThresholdTrackBar.Value = sobelDefault;
            SobelThresholdNumBox.Value   = sobelDefault;
            
            SobelThresholdTrackBar.ValueChanged += (sender, args) => 
                { SobelThresholdNumBox.Value = ((TrackBar) sender).Value; }; 
            SobelThresholdNumBox.ValueChanged   += (sender, args) => 
                { SobelThresholdTrackBar.Value = (int)((NumericUpDown)sender).Value; };
        }

        private void SetUpHoughParams()
        {
            HoughAccuracyTrackBar.ValueChanged += (sender, args) => 
                { HoughAccuracyNumBox.Value = ((TrackBar) sender).Value; };
            HoughAccuracyNumBox.ValueChanged += (sender, args) => 
                { HoughAccuracyTrackBar.Value = (int)((NumericUpDown)sender).Value; };
            
            HoughLineColorButton.BackColor = Color.Red;
            
            // Настройка списка типов
            HoughTypeBox.DataSource = Enum.GetNames(typeof(HoughType));
        }
        
        
        
        
        /// <summary>
        /// Событие клика на главном меню: [Файл] >> [Открыть файл]
        /// </summary>
        private void MainMenuControlFileOpen_Click(object sender, EventArgs e)
        {
           _fileManager.OpenImage();
        }
        
        private void ImageManagerOnImageLoaded(Image image)
        {
            ImageBoxControl.Image = image;
            StatusBarControl.Text = _fileManager.GetImageInfoString(image);
            GB_Original.Visible = true;
        }
        

        private void OnPickUpColorButton_Click(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (SobelOutlineColorDialog.ShowDialog() == DialogResult.OK)
                button.BackColor = SobelOutlineColorDialog.Color;
        }

        
        private void ConvertButton_Click(object sender, EventArgs e)
        {
            if(ImageBoxControl.Image == null) return;

            SetPictureBoxesInvisible();
            
            // Очистка изображений
            GrayscaleImageBoxControl.Image  = null;
            GaussianImageBoxControl.Image   = null;
            SobelImageBoxControl.Image      = null;
            HoughSpaceImageBoxControl.Image = null;
            HoughShapesImageBox.Image       = null;
            
      
            Image           originalImage   = ImageBoxControl.Image;
            GrayscaledImage grayscaledImage = null;
            BluredImage     bluredImage     = null;
            Image           sobelImage      = null;
            Image           houghSpaceImage = null;
            Image           houghShapeImage = null;

            GB_Original.Visible = true;
            
            // Чб изображение
            if(GrayscaleCheckBox.Checked)
            {
                grayscaledImage = new GrayscaledImage(originalImage);
                GrayscaleImageBoxControl.Image = (Image)grayscaledImage;
                GB_Grayscale.Visible = true;
            }
        
            // Размытие гаусса
            if(GaussCheckBox.Checked)
            {
                bluredImage = new BluredImage((Image)grayscaledImage ?? originalImage, 5, 16d);
                GaussianImageBoxControl.Image = (Image) bluredImage;
                GB_Gauss.Visible = true;
            }
        
            // Преобразование собеля
            if (SobelCheckBox.Checked)
            {
                sobelImage = new SobelOperator((Image)bluredImage ?? (Image)grayscaledImage ?? originalImage, 
                    Color.White, 
                    Color.Black, 
                    (int)SobelThresholdNumBox.Value).Execute();
                
                // Удаление шума
                sobelImage = NoiseFilter.Process(sobelImage);
                
                SobelImageBoxControl.Image = sobelImage;
                GB_Sobel.Visible = true;
            }

            if (HoughCheckBox.Checked && SobelCheckBox.Checked)
            {
                switch ((HoughType)HoughTypeBox.SelectedIndex)
                {
                    case HoughType.CircleDetection:
                        DrawHoughLineStandart((Bitmap) sobelImage
                                           ?? (Bitmap) bluredImage
                                           ?? (Bitmap) grayscaledImage
                                           ?? (Bitmap) originalImage); break;
                    
                    case HoughType.Combinatorical:
                        DrawHoughLineCombinatorical((Bitmap) sobelImage
                                                    ?? (Bitmap) bluredImage
                                                    ?? (Bitmap) grayscaledImage
                                                    ?? (Bitmap) originalImage); break;
                    default:
                        DrawHoughLineProbabilistic((Bitmap) sobelImage
                                                   ?? (Bitmap) bluredImage
                                                   ?? (Bitmap) grayscaledImage
                                                   ?? (Bitmap) originalImage); break;
                }
                
                GB_Hough.Visible = true;
                GB_Shapes.Visible = true;
            }
        }

        private void DrawHoughLineCombinatorical(Bitmap original)
        {
            var outlineColor = Color.FromArgb(
                180, // Прозрачность
                HoughLineColorButton.BackColor.R,
                HoughLineColorButton.BackColor.G,
                HoughLineColorButton.BackColor.B);
                
            var pen = new Pen(new SolidBrush(outlineColor), (float)HoughLineThicknessNumBox.Value);

            int invertedTrackBarValue = (100 - HoughAccuracyTrackBar.Value) == 0
                ? 1
                : (100 - HoughAccuracyTrackBar.Value);
                
            double accuracy = invertedTrackBarValue / 100d;

            var binaryImage = (Bitmap)new GrayscaledImage(original);
            
            
            var combinatoricalTransform = new HoughLinesCombinatorial();
            combinatoricalTransform.ProcessImage(binaryImage);
            HoughSpaceImageBoxControl.Image = combinatoricalTransform.GetHoughSpaceImage();
            
            // Обнаруженные линии
            //var lines = lineTransform.GetShapesByRelativeIntensity(accuracy);
                
            //HoughSpaceImageBoxControl.Image = lineTransform.GetHoughSpaceImage();
            //HoughShapesImageBox.Image = lineTransform.DrawLines(original, pen, lines);
        }
        
        private void DrawHoughLineStandart(Bitmap original)
        {
            var outlineColor = Color.FromArgb(
                180, // Прозрачность
                HoughLineColorButton.BackColor.R,
                HoughLineColorButton.BackColor.G,
                HoughLineColorButton.BackColor.B);
                
            var pen = new Pen(new SolidBrush(outlineColor), (float)HoughLineThicknessNumBox.Value);

            int invertedTrackBarValue = (100 - HoughAccuracyTrackBar.Value) == 0
                ? 1
                : (100 - HoughAccuracyTrackBar.Value);
                
            double accuracy = invertedTrackBarValue / 100d;

            var binaryImage = (Bitmap)new GrayscaledImage(original);
            
            var lineTransform = new HoughLinesStandart();
                
            lineTransform.ProcessImage(binaryImage);
        
            // Обнаруженные линии
            var lines = lineTransform.GetShapesByRelativeIntensity(accuracy);
                
            HoughSpaceImageBoxControl.Image = lineTransform.GetHoughSpaceImage();
            HoughShapesImageBox.Image = lineTransform.DrawLines(original, pen, lines);
        }
        
        private void DrawHoughLineProbabilistic(Bitmap original)
        {
            var outlineColor = Color.FromArgb(
                180, // Прозрачность
                HoughLineColorButton.BackColor.R,
                HoughLineColorButton.BackColor.G,
                HoughLineColorButton.BackColor.B);
                
            var pen = new Pen(new SolidBrush(outlineColor), (float)HoughLineThicknessNumBox.Value);

            int invertedTrackBarValue = (100 - HoughAccuracyTrackBar.Value) == 0
                ? 1
                : (100 - HoughAccuracyTrackBar.Value);
            
            double accuracy = invertedTrackBarValue / 100d;

            var binaryImage = (Bitmap)new GrayscaledImage(original);

            
            
            
            var probabilisticTransform = new HoughLinesProbabilistic();
            probabilisticTransform.ProcessImage(binaryImage);

           HoughSpaceImageBoxControl.Image = probabilisticTransform.GetHoughSpaceImage();
            HoughShapesImageBox.Image = probabilisticTransform.DrawLines(original, pen);
/*
            
            var data = binaryImage.LockBits(new Rectangle(0, 0, binaryImage.Width, binaryImage.Height),
                ImageLockMode.ReadOnly, PixelFormat.Format8bppIndexed);
            Bitmap v = probabilisticTransform.DrawPixels(data);
            binaryImage.UnlockBits(data);
            
            HoughShapesImageBox.Image = v;*/



            // Обнаруженные линии
            //var lines = probabilisticTransform.GetShapesByRelativeIntensity(accuracy);

            // HoughSpaceImageBoxControl.Image = probabilisticTransform.GetHoughSpaceImage();
            // HoughShapesImageBox.Image = probabilisticTransform.DrawLines(original, pen);
        }

        
        // Установка миниатюр изображения
        private void OnSetMiniatureSize_Click(object sender, EventArgs e)
        {
            
            if(sender is ToolStripItem item)
            {
                switch (int.Parse(item.Tag.ToString()))
                {
                    case 250: SetControlSize(250); break;
                    case 300: SetControlSize(300); break;
                    case 350: SetControlSize(350); break;
                    case 400: SetControlSize(400); break;
                    case 500: SetControlSize(500); break;
                    default:  SetControlSize(250); break;
                }
            }

            void SetControlSize(int size)
            {
                foreach (GroupBox box in ImagesFlowPanel.Controls)
                    box.Size = new Size(size, size);
            }
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}