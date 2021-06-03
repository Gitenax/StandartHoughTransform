namespace HoughTransform
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainMenuControl = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuControlFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.размерМиниатюрToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x250ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x300ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x350ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x400ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x500ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ImagesFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.GB_Original = new System.Windows.Forms.GroupBox();
            this.ImageBoxControl = new System.Windows.Forms.PictureBox();
            this.GB_Grayscale = new System.Windows.Forms.GroupBox();
            this.GrayscaleImageBoxControl = new System.Windows.Forms.PictureBox();
            this.GB_Gauss = new System.Windows.Forms.GroupBox();
            this.GaussianImageBoxControl = new System.Windows.Forms.PictureBox();
            this.GB_Sobel = new System.Windows.Forms.GroupBox();
            this.SobelImageBoxControl = new System.Windows.Forms.PictureBox();
            this.GB_Hough = new System.Windows.Forms.GroupBox();
            this.HoughSpaceImageBoxControl = new System.Windows.Forms.PictureBox();
            this.GB_Shapes = new System.Windows.Forms.GroupBox();
            this.HoughShapesImageBox = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ProcessingBox = new System.Windows.Forms.GroupBox();
            this.ProcessingBar = new System.Windows.Forms.ProgressBar();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.HoughTypeBox = new System.Windows.Forms.ComboBox();
            this.HoughLineThicknessNumBox = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.HoughLineColorButton = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.HoughAccuracyNumBox = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.HoughAccuracyTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.SobelThresholdNumBox = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.SobelThresholdTrackBar = new System.Windows.Forms.TrackBar();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.HoughCheckBox = new System.Windows.Forms.CheckBox();
            this.SobelCheckBox = new System.Windows.Forms.CheckBox();
            this.GaussCheckBox = new System.Windows.Forms.CheckBox();
            this.GrayscaleCheckBox = new System.Windows.Forms.CheckBox();
            this.StatusBarControl = new System.Windows.Forms.StatusBar();
            this.SobelOutlineColorDialog = new System.Windows.Forms.ColorDialog();
            this.MainMenuControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.ImagesFlowPanel.SuspendLayout();
            this.GB_Original.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.ImageBoxControl)).BeginInit();
            this.GB_Grayscale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.GrayscaleImageBoxControl)).BeginInit();
            this.GB_Gauss.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.GaussianImageBoxControl)).BeginInit();
            this.GB_Sobel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.SobelImageBoxControl)).BeginInit();
            this.GB_Hough.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.HoughSpaceImageBoxControl)).BeginInit();
            this.GB_Shapes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.HoughShapesImageBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.ProcessingBox.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.HoughLineThicknessNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.HoughAccuracyNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.HoughAccuracyTrackBar)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.SobelThresholdNumBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.SobelThresholdTrackBar)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenuControl
            // 
            this.MainMenuControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.файлToolStripMenuItem, this.правкаToolStripMenuItem});
            this.MainMenuControl.Location = new System.Drawing.Point(0, 0);
            this.MainMenuControl.Name = "MainMenuControl";
            this.MainMenuControl.Size = new System.Drawing.Size(1064, 24);
            this.MainMenuControl.TabIndex = 0;
            this.MainMenuControl.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.MainMenuControlFileOpen, this.toolStripMenuItem1, this.MenuItemExit});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // MainMenuControlFileOpen
            // 
            this.MainMenuControlFileOpen.Name = "MainMenuControlFileOpen";
            this.MainMenuControlFileOpen.Size = new System.Drawing.Size(121, 22);
            this.MainMenuControlFileOpen.Text = "Открыть";
            this.MainMenuControlFileOpen.Click += new System.EventHandler(this.MainMenuControlFileOpen_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(118, 6);
            // 
            // MenuItemExit
            // 
            this.MenuItemExit.Name = "MenuItemExit";
            this.MenuItemExit.Size = new System.Drawing.Size(121, 22);
            this.MenuItemExit.Text = "Выход";
            this.MenuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);
            // 
            // правкаToolStripMenuItem
            // 
            this.правкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.размерМиниатюрToolStripMenuItem});
            this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            this.правкаToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.правкаToolStripMenuItem.Text = "Вид";
            // 
            // размерМиниатюрToolStripMenuItem
            // 
            this.размерМиниатюрToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {this.x250ToolStripMenuItem, this.x300ToolStripMenuItem, this.x350ToolStripMenuItem, this.x400ToolStripMenuItem, this.x500ToolStripMenuItem});
            this.размерМиниатюрToolStripMenuItem.Name = "размерМиниатюрToolStripMenuItem";
            this.размерМиниатюрToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.размерМиниатюрToolStripMenuItem.Text = "Размер миниатюр";
            // 
            // x250ToolStripMenuItem
            // 
            this.x250ToolStripMenuItem.Name = "x250ToolStripMenuItem";
            this.x250ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.x250ToolStripMenuItem.Tag = "250";
            this.x250ToolStripMenuItem.Text = "250x250";
            this.x250ToolStripMenuItem.Click += new System.EventHandler(this.OnSetMiniatureSize_Click);
            // 
            // x300ToolStripMenuItem
            // 
            this.x300ToolStripMenuItem.Name = "x300ToolStripMenuItem";
            this.x300ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.x300ToolStripMenuItem.Tag = "300";
            this.x300ToolStripMenuItem.Text = "300x300";
            this.x300ToolStripMenuItem.Click += new System.EventHandler(this.OnSetMiniatureSize_Click);
            // 
            // x350ToolStripMenuItem
            // 
            this.x350ToolStripMenuItem.Name = "x350ToolStripMenuItem";
            this.x350ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.x350ToolStripMenuItem.Tag = "350";
            this.x350ToolStripMenuItem.Text = "350x350";
            this.x350ToolStripMenuItem.Click += new System.EventHandler(this.OnSetMiniatureSize_Click);
            // 
            // x400ToolStripMenuItem
            // 
            this.x400ToolStripMenuItem.Name = "x400ToolStripMenuItem";
            this.x400ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.x400ToolStripMenuItem.Tag = "400";
            this.x400ToolStripMenuItem.Text = "400x400";
            this.x400ToolStripMenuItem.Click += new System.EventHandler(this.OnSetMiniatureSize_Click);
            // 
            // x500ToolStripMenuItem
            // 
            this.x500ToolStripMenuItem.Name = "x500ToolStripMenuItem";
            this.x500ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.x500ToolStripMenuItem.Tag = "500";
            this.x500ToolStripMenuItem.Text = "500x500";
            this.x500ToolStripMenuItem.Click += new System.EventHandler(this.OnSetMiniatureSize_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ImagesFlowPanel);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(1064, 628);
            this.splitContainer1.SplitterDistance = 835;
            this.splitContainer1.TabIndex = 1;
            // 
            // ImagesFlowPanel
            // 
            this.ImagesFlowPanel.AutoScroll = true;
            this.ImagesFlowPanel.Controls.Add(this.GB_Original);
            this.ImagesFlowPanel.Controls.Add(this.GB_Grayscale);
            this.ImagesFlowPanel.Controls.Add(this.GB_Gauss);
            this.ImagesFlowPanel.Controls.Add(this.GB_Sobel);
            this.ImagesFlowPanel.Controls.Add(this.GB_Hough);
            this.ImagesFlowPanel.Controls.Add(this.GB_Shapes);
            this.ImagesFlowPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImagesFlowPanel.Location = new System.Drawing.Point(0, 0);
            this.ImagesFlowPanel.Name = "ImagesFlowPanel";
            this.ImagesFlowPanel.Size = new System.Drawing.Size(835, 628);
            this.ImagesFlowPanel.TabIndex = 0;
            // 
            // GB_Original
            // 
            this.GB_Original.Controls.Add(this.ImageBoxControl);
            this.GB_Original.Location = new System.Drawing.Point(3, 3);
            this.GB_Original.Name = "GB_Original";
            this.GB_Original.Size = new System.Drawing.Size(250, 250);
            this.GB_Original.TabIndex = 0;
            this.GB_Original.TabStop = false;
            this.GB_Original.Text = "Исходное изображение";
            // 
            // ImageBoxControl
            // 
            this.ImageBoxControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImageBoxControl.Location = new System.Drawing.Point(3, 16);
            this.ImageBoxControl.Name = "ImageBoxControl";
            this.ImageBoxControl.Size = new System.Drawing.Size(244, 231);
            this.ImageBoxControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImageBoxControl.TabIndex = 3;
            this.ImageBoxControl.TabStop = false;
            // 
            // GB_Grayscale
            // 
            this.GB_Grayscale.Controls.Add(this.GrayscaleImageBoxControl);
            this.GB_Grayscale.Location = new System.Drawing.Point(259, 3);
            this.GB_Grayscale.Name = "GB_Grayscale";
            this.GB_Grayscale.Size = new System.Drawing.Size(250, 250);
            this.GB_Grayscale.TabIndex = 1;
            this.GB_Grayscale.TabStop = false;
            this.GB_Grayscale.Text = "ЧБ Изображение";
            // 
            // GrayscaleImageBoxControl
            // 
            this.GrayscaleImageBoxControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrayscaleImageBoxControl.Location = new System.Drawing.Point(3, 16);
            this.GrayscaleImageBoxControl.Name = "GrayscaleImageBoxControl";
            this.GrayscaleImageBoxControl.Size = new System.Drawing.Size(244, 231);
            this.GrayscaleImageBoxControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GrayscaleImageBoxControl.TabIndex = 0;
            this.GrayscaleImageBoxControl.TabStop = false;
            // 
            // GB_Gauss
            // 
            this.GB_Gauss.Controls.Add(this.GaussianImageBoxControl);
            this.GB_Gauss.Location = new System.Drawing.Point(515, 3);
            this.GB_Gauss.Name = "GB_Gauss";
            this.GB_Gauss.Size = new System.Drawing.Size(250, 250);
            this.GB_Gauss.TabIndex = 3;
            this.GB_Gauss.TabStop = false;
            this.GB_Gauss.Text = "Размытие Гаусса";
            // 
            // GaussianImageBoxControl
            // 
            this.GaussianImageBoxControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GaussianImageBoxControl.Location = new System.Drawing.Point(3, 16);
            this.GaussianImageBoxControl.Name = "GaussianImageBoxControl";
            this.GaussianImageBoxControl.Size = new System.Drawing.Size(244, 231);
            this.GaussianImageBoxControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.GaussianImageBoxControl.TabIndex = 0;
            this.GaussianImageBoxControl.TabStop = false;
            // 
            // GB_Sobel
            // 
            this.GB_Sobel.Controls.Add(this.SobelImageBoxControl);
            this.GB_Sobel.Location = new System.Drawing.Point(3, 259);
            this.GB_Sobel.Name = "GB_Sobel";
            this.GB_Sobel.Size = new System.Drawing.Size(250, 250);
            this.GB_Sobel.TabIndex = 2;
            this.GB_Sobel.TabStop = false;
            this.GB_Sobel.Text = "Оператор Собеля";
            // 
            // SobelImageBoxControl
            // 
            this.SobelImageBoxControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SobelImageBoxControl.Location = new System.Drawing.Point(3, 16);
            this.SobelImageBoxControl.Name = "SobelImageBoxControl";
            this.SobelImageBoxControl.Size = new System.Drawing.Size(244, 231);
            this.SobelImageBoxControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.SobelImageBoxControl.TabIndex = 0;
            this.SobelImageBoxControl.TabStop = false;
            // 
            // GB_Hough
            // 
            this.GB_Hough.Controls.Add(this.HoughSpaceImageBoxControl);
            this.GB_Hough.Location = new System.Drawing.Point(259, 259);
            this.GB_Hough.Name = "GB_Hough";
            this.GB_Hough.Size = new System.Drawing.Size(250, 250);
            this.GB_Hough.TabIndex = 3;
            this.GB_Hough.TabStop = false;
            this.GB_Hough.Text = "Пространство Хафа";
            // 
            // HoughSpaceImageBoxControl
            // 
            this.HoughSpaceImageBoxControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HoughSpaceImageBoxControl.Location = new System.Drawing.Point(3, 16);
            this.HoughSpaceImageBoxControl.Name = "HoughSpaceImageBoxControl";
            this.HoughSpaceImageBoxControl.Size = new System.Drawing.Size(244, 231);
            this.HoughSpaceImageBoxControl.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HoughSpaceImageBoxControl.TabIndex = 0;
            this.HoughSpaceImageBoxControl.TabStop = false;
            // 
            // GB_Shapes
            // 
            this.GB_Shapes.Controls.Add(this.HoughShapesImageBox);
            this.GB_Shapes.Location = new System.Drawing.Point(515, 259);
            this.GB_Shapes.Name = "GB_Shapes";
            this.GB_Shapes.Size = new System.Drawing.Size(250, 250);
            this.GB_Shapes.TabIndex = 4;
            this.GB_Shapes.TabStop = false;
            this.GB_Shapes.Text = "Найденные фигуры";
            // 
            // HoughShapesImageBox
            // 
            this.HoughShapesImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.HoughShapesImageBox.Location = new System.Drawing.Point(3, 16);
            this.HoughShapesImageBox.Name = "HoughShapesImageBox";
            this.HoughShapesImageBox.Size = new System.Drawing.Size(244, 231);
            this.HoughShapesImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HoughShapesImageBox.TabIndex = 0;
            this.HoughShapesImageBox.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ProcessingBox);
            this.groupBox1.Controls.Add(this.groupBox10);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.groupBox8);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(225, 628);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Обработка";
            // 
            // ProcessingBox
            // 
            this.ProcessingBox.Controls.Add(this.ProcessingBar);
            this.ProcessingBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProcessingBox.Location = new System.Drawing.Point(3, 580);
            this.ProcessingBox.Name = "ProcessingBox";
            this.ProcessingBox.Size = new System.Drawing.Size(219, 53);
            this.ProcessingBox.TabIndex = 8;
            this.ProcessingBox.TabStop = false;
            this.ProcessingBox.Text = "Прогресс";
            this.ProcessingBox.Visible = false;
            // 
            // ProcessingBar
            // 
            this.ProcessingBar.Location = new System.Drawing.Point(6, 19);
            this.ProcessingBar.Name = "ProcessingBar";
            this.ProcessingBar.Size = new System.Drawing.Size(207, 23);
            this.ProcessingBar.TabIndex = 0;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.HoughTypeBox);
            this.groupBox10.Controls.Add(this.HoughLineThicknessNumBox);
            this.groupBox10.Controls.Add(this.label6);
            this.groupBox10.Controls.Add(this.HoughLineColorButton);
            this.groupBox10.Controls.Add(this.label5);
            this.groupBox10.Controls.Add(this.HoughAccuracyNumBox);
            this.groupBox10.Controls.Add(this.label4);
            this.groupBox10.Controls.Add(this.HoughAccuracyTrackBar);
            this.groupBox10.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox10.Location = new System.Drawing.Point(3, 276);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(219, 304);
            this.groupBox10.TabIndex = 7;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Параметры преобразования Хафа";
            // 
            // HoughTypeBox
            // 
            this.HoughTypeBox.FormattingEnabled = true;
            this.HoughTypeBox.Location = new System.Drawing.Point(6, 19);
            this.HoughTypeBox.Name = "HoughTypeBox";
            this.HoughTypeBox.Size = new System.Drawing.Size(204, 21);
            this.HoughTypeBox.TabIndex = 15;
            // 
            // HoughLineThicknessNumBox
            // 
            this.HoughLineThicknessNumBox.Location = new System.Drawing.Point(95, 269);
            this.HoughLineThicknessNumBox.Maximum = new decimal(new int[] {10, 0, 0, 0});
            this.HoughLineThicknessNumBox.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.HoughLineThicknessNumBox.Name = "HoughLineThicknessNumBox";
            this.HoughLineThicknessNumBox.Size = new System.Drawing.Size(121, 20);
            this.HoughLineThicknessNumBox.TabIndex = 14;
            this.HoughLineThicknessNumBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.HoughLineThicknessNumBox.Value = new decimal(new int[] {3, 0, 0, 0});
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(6, 271);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Толщина:";
            // 
            // HoughLineColorButton
            // 
            this.HoughLineColorButton.Location = new System.Drawing.Point(95, 243);
            this.HoughLineColorButton.Name = "HoughLineColorButton";
            this.HoughLineColorButton.Size = new System.Drawing.Size(121, 23);
            this.HoughLineColorButton.TabIndex = 12;
            this.HoughLineColorButton.UseVisualStyleBackColor = true;
            this.HoughLineColorButton.Click += new System.EventHandler(this.OnPickUpColorButton_Click);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(6, 248);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 23);
            this.label5.TabIndex = 11;
            this.label5.Text = "Цвет линий:";
            // 
            // HoughAccuracyNumBox
            // 
            this.HoughAccuracyNumBox.Location = new System.Drawing.Point(6, 217);
            this.HoughAccuracyNumBox.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.HoughAccuracyNumBox.Name = "HoughAccuracyNumBox";
            this.HoughAccuracyNumBox.Size = new System.Drawing.Size(210, 20);
            this.HoughAccuracyNumBox.TabIndex = 10;
            this.HoughAccuracyNumBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.HoughAccuracyNumBox.Value = new decimal(new int[] {60, 0, 0, 0});
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(6, 43);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 30);
            this.label4.TabIndex = 9;
            this.label4.Text = "Точность(в случае окружностей - радиус):";
            // 
            // HoughAccuracyTrackBar
            // 
            this.HoughAccuracyTrackBar.Location = new System.Drawing.Point(6, 166);
            this.HoughAccuracyTrackBar.Maximum = 100;
            this.HoughAccuracyTrackBar.Minimum = 1;
            this.HoughAccuracyTrackBar.Name = "HoughAccuracyTrackBar";
            this.HoughAccuracyTrackBar.Size = new System.Drawing.Size(204, 45);
            this.HoughAccuracyTrackBar.TabIndex = 8;
            this.HoughAccuracyTrackBar.TickFrequency = 10;
            this.HoughAccuracyTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.HoughAccuracyTrackBar.Value = 60;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.SobelThresholdNumBox);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.SobelThresholdTrackBar);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 162);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(219, 114);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Оператор Собеля";
            // 
            // SobelThresholdNumBox
            // 
            this.SobelThresholdNumBox.Location = new System.Drawing.Point(3, 84);
            this.SobelThresholdNumBox.Name = "SobelThresholdNumBox";
            this.SobelThresholdNumBox.Size = new System.Drawing.Size(210, 20);
            this.SobelThresholdNumBox.TabIndex = 7;
            this.SobelThresholdNumBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(3, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 23);
            this.label3.TabIndex = 6;
            this.label3.Text = "Порог:";
            // 
            // SobelThresholdTrackBar
            // 
            this.SobelThresholdTrackBar.Location = new System.Drawing.Point(3, 33);
            this.SobelThresholdTrackBar.Maximum = 255;
            this.SobelThresholdTrackBar.Minimum = 1;
            this.SobelThresholdTrackBar.Name = "SobelThresholdTrackBar";
            this.SobelThresholdTrackBar.Size = new System.Drawing.Size(204, 45);
            this.SobelThresholdTrackBar.TabIndex = 5;
            this.SobelThresholdTrackBar.TickFrequency = 25;
            this.SobelThresholdTrackBar.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.SobelThresholdTrackBar.Value = 1;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.ConvertButton);
            this.groupBox8.Controls.Add(this.HoughCheckBox);
            this.groupBox8.Controls.Add(this.SobelCheckBox);
            this.groupBox8.Controls.Add(this.GaussCheckBox);
            this.groupBox8.Controls.Add(this.GrayscaleCheckBox);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox8.Location = new System.Drawing.Point(3, 16);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(219, 146);
            this.groupBox8.TabIndex = 3;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Преобразования";
            // 
            // ConvertButton
            // 
            this.ConvertButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConvertButton.Location = new System.Drawing.Point(3, 112);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(213, 23);
            this.ConvertButton.TabIndex = 8;
            this.ConvertButton.Text = "Преобразовать";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // HoughCheckBox
            // 
            this.HoughCheckBox.Checked = true;
            this.HoughCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.HoughCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.HoughCheckBox.Location = new System.Drawing.Point(3, 88);
            this.HoughCheckBox.Name = "HoughCheckBox";
            this.HoughCheckBox.Size = new System.Drawing.Size(213, 24);
            this.HoughCheckBox.TabIndex = 7;
            this.HoughCheckBox.Text = "Преобразование Хафа";
            this.HoughCheckBox.UseVisualStyleBackColor = true;
            // 
            // SobelCheckBox
            // 
            this.SobelCheckBox.Checked = true;
            this.SobelCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SobelCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.SobelCheckBox.Location = new System.Drawing.Point(3, 64);
            this.SobelCheckBox.Name = "SobelCheckBox";
            this.SobelCheckBox.Size = new System.Drawing.Size(213, 24);
            this.SobelCheckBox.TabIndex = 6;
            this.SobelCheckBox.Text = "Оператор Собеля";
            this.SobelCheckBox.UseVisualStyleBackColor = true;
            // 
            // GaussCheckBox
            // 
            this.GaussCheckBox.Checked = true;
            this.GaussCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GaussCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.GaussCheckBox.Location = new System.Drawing.Point(3, 40);
            this.GaussCheckBox.Name = "GaussCheckBox";
            this.GaussCheckBox.Size = new System.Drawing.Size(213, 24);
            this.GaussCheckBox.TabIndex = 2;
            this.GaussCheckBox.Text = "Размытие Гаусса";
            this.GaussCheckBox.UseVisualStyleBackColor = true;
            // 
            // GrayscaleCheckBox
            // 
            this.GrayscaleCheckBox.Checked = true;
            this.GrayscaleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.GrayscaleCheckBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrayscaleCheckBox.Location = new System.Drawing.Point(3, 16);
            this.GrayscaleCheckBox.Name = "GrayscaleCheckBox";
            this.GrayscaleCheckBox.Size = new System.Drawing.Size(213, 24);
            this.GrayscaleCheckBox.TabIndex = 0;
            this.GrayscaleCheckBox.Text = "ЧБ изображение";
            this.GrayscaleCheckBox.UseVisualStyleBackColor = true;
            // 
            // StatusBarControl
            // 
            this.StatusBarControl.Location = new System.Drawing.Point(0, 630);
            this.StatusBarControl.Name = "StatusBarControl";
            this.StatusBarControl.Size = new System.Drawing.Size(1064, 22);
            this.StatusBarControl.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1064, 652);
            this.Controls.Add(this.StatusBarControl);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.MainMenuControl);
            this.MainMenuStrip = this.MainMenuControl;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Алгоритм Хафа ";
            this.MainMenuControl.ResumeLayout(false);
            this.MainMenuControl.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ImagesFlowPanel.ResumeLayout(false);
            this.GB_Original.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.ImageBoxControl)).EndInit();
            this.GB_Grayscale.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.GrayscaleImageBoxControl)).EndInit();
            this.GB_Gauss.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.GaussianImageBoxControl)).EndInit();
            this.GB_Sobel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.SobelImageBoxControl)).EndInit();
            this.GB_Hough.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.HoughSpaceImageBoxControl)).EndInit();
            this.GB_Shapes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize) (this.HoughShapesImageBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ProcessingBox.ResumeLayout(false);
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.HoughLineThicknessNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.HoughAccuracyNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.HoughAccuracyTrackBar)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.SobelThresholdNumBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.SobelThresholdTrackBar)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.GroupBox GB_Gauss;
        private System.Windows.Forms.GroupBox GB_Grayscale;
        private System.Windows.Forms.GroupBox GB_Hough;
        private System.Windows.Forms.GroupBox GB_Original;
        private System.Windows.Forms.GroupBox GB_Shapes;
        private System.Windows.Forms.GroupBox GB_Sobel;

        private System.Windows.Forms.ToolStripMenuItem MenuItemExit;

        private System.Windows.Forms.GroupBox ProcessingBox;

        private System.Windows.Forms.ProgressBar ProcessingBar;

        private System.Windows.Forms.FlowLayoutPanel ImagesFlowPanel;

        private System.Windows.Forms.ToolStripMenuItem x250ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x300ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x350ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x400ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x500ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem размерМиниатюрToolStripMenuItem;

        private System.Windows.Forms.ComboBox HoughTypeBox;

        private System.Windows.Forms.PictureBox HoughShapesImageBox;

        private System.Windows.Forms.Button HoughLineColorButton;
        private System.Windows.Forms.NumericUpDown HoughLineThicknessNumBox;
        private System.Windows.Forms.Label label6;

        private System.Windows.Forms.NumericUpDown HoughAccuracyNumBox;
        private System.Windows.Forms.TrackBar HoughAccuracyTrackBar;
        private System.Windows.Forms.Label label5;

        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label4;

        private System.Windows.Forms.CheckBox GaussCheckBox;
        private System.Windows.Forms.PictureBox GaussianImageBoxControl;

        private System.Windows.Forms.Button ConvertButton;

        private System.Windows.Forms.CheckBox GrayscaleCheckBox;
        private System.Windows.Forms.CheckBox HoughCheckBox;
        private System.Windows.Forms.CheckBox SobelCheckBox;

        private System.Windows.Forms.NumericUpDown SobelThresholdNumBox;
        private System.Windows.Forms.TrackBar SobelThresholdTrackBar;

        private System.Windows.Forms.Label label3;

        private System.Windows.Forms.GroupBox groupBox8;

        private System.Windows.Forms.PictureBox HoughSpaceImageBoxControl;

        private System.Windows.Forms.PictureBox GrayscaleImageBoxControl;

        private System.Windows.Forms.PictureBox SobelImageBoxControl;

        private System.Windows.Forms.ColorDialog SobelOutlineColorDialog;

        private System.Windows.Forms.GroupBox groupBox2;

        private System.Windows.Forms.PictureBox ImageBoxControl;

        private System.Windows.Forms.StatusBar StatusBarControl;

        private System.Windows.Forms.GroupBox groupBox1;

        private System.Windows.Forms.ToolStripMenuItem MainMenuControlFileOpen;

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;

        private System.Windows.Forms.MenuStrip MainMenuControl;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;

        #endregion
    }
}