
namespace Segmentation
{
    partial class Form1
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.menuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutAlgorithmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.greyFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBoxOptions = new System.Windows.Forms.GroupBox();
            this.radioButtonZoom = new System.Windows.Forms.RadioButton();
            this.radioButtonCenterImage = new System.Windows.Forms.RadioButton();
            this.radioButtonStretchImage = new System.Windows.Forms.RadioButton();
            this.radioButtonNormal = new System.Windows.Forms.RadioButton();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonCLean = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.buttonStop = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonByRoot = new System.Windows.Forms.RadioButton();
            this.radioButtonRandom = new System.Windows.Forms.RadioButton();
            this.menuStrip.SuspendLayout();
            this.groupBoxOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemFile,
            this.menuItemHelp});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.menuStrip.Size = new System.Drawing.Size(862, 24);
            this.menuStrip.TabIndex = 1;
            // 
            // menuItemFile
            // 
            this.menuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemOpen,
            this.saveToolStripMenuItem,
            this.toolStripMenuItem1,
            this.menuItemExit});
            this.menuItemFile.Name = "menuItemFile";
            this.menuItemFile.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.menuItemFile.Size = new System.Drawing.Size(37, 20);
            this.menuItemFile.Text = "File";
            // 
            // menuItemOpen
            // 
            this.menuItemOpen.Name = "menuItemOpen";
            this.menuItemOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.menuItemOpen.Size = new System.Drawing.Size(146, 22);
            this.menuItemOpen.Text = "Open";
            this.menuItemOpen.Click += new System.EventHandler(this.MenuItemOpenClick);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.MenuItemSaveClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(143, 6);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.menuItemExit.Size = new System.Drawing.Size(146, 22);
            this.menuItemExit.Text = "Exit";
            this.menuItemExit.Click += new System.EventHandler(this.MenuItemExitClick);
            // 
            // menuItemHelp
            // 
            this.menuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemAbout,
            this.aboutAlgorithmToolStripMenuItem});
            this.menuItemHelp.Name = "menuItemHelp";
            this.menuItemHelp.Size = new System.Drawing.Size(44, 20);
            this.menuItemHelp.Text = "Help";
            // 
            // menuItemAbout
            // 
            this.menuItemAbout.Name = "menuItemAbout";
            this.menuItemAbout.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.menuItemAbout.Size = new System.Drawing.Size(190, 22);
            this.menuItemAbout.Text = "About program...";
            this.menuItemAbout.Click += new System.EventHandler(this.MenuItemAboutProgramClick);
            // 
            // aboutAlgorithmToolStripMenuItem
            // 
            this.aboutAlgorithmToolStripMenuItem.Name = "aboutAlgorithmToolStripMenuItem";
            this.aboutAlgorithmToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.aboutAlgorithmToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.aboutAlgorithmToolStripMenuItem.Text = "About algorithm...";
            this.aboutAlgorithmToolStripMenuItem.Click += new System.EventHandler(this.MenuItemAboutAlgorithmClick);
            // 
            // greyFilterToolStripMenuItem
            // 
            this.greyFilterToolStripMenuItem.Name = "greyFilterToolStripMenuItem";
            this.greyFilterToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // groupBoxOptions
            // 
            this.groupBoxOptions.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBoxOptions.Controls.Add(this.radioButtonZoom);
            this.groupBoxOptions.Controls.Add(this.radioButtonCenterImage);
            this.groupBoxOptions.Controls.Add(this.radioButtonStretchImage);
            this.groupBoxOptions.Controls.Add(this.radioButtonNormal);
            this.groupBoxOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBoxOptions.Location = new System.Drawing.Point(637, 464);
            this.groupBoxOptions.Name = "groupBoxOptions";
            this.groupBoxOptions.Size = new System.Drawing.Size(196, 150);
            this.groupBoxOptions.TabIndex = 2;
            this.groupBoxOptions.TabStop = false;
            this.groupBoxOptions.Text = "Zoom mode";
            // 
            // radioButtonZoom
            // 
            this.radioButtonZoom.AutoSize = true;
            this.radioButtonZoom.Location = new System.Drawing.Point(24, 110);
            this.radioButtonZoom.Name = "radioButtonZoom";
            this.radioButtonZoom.Size = new System.Drawing.Size(61, 20);
            this.radioButtonZoom.TabIndex = 3;
            this.radioButtonZoom.TabStop = true;
            this.radioButtonZoom.Text = "Zoom";
            this.radioButtonZoom.UseVisualStyleBackColor = true;
            this.radioButtonZoom.CheckedChanged += new System.EventHandler(this.RadioButtonZoomCheckedChanged);
            // 
            // radioButtonCenterImage
            // 
            this.radioButtonCenterImage.AutoSize = true;
            this.radioButtonCenterImage.Location = new System.Drawing.Point(24, 84);
            this.radioButtonCenterImage.Name = "radioButtonCenterImage";
            this.radioButtonCenterImage.Size = new System.Drawing.Size(106, 20);
            this.radioButtonCenterImage.TabIndex = 2;
            this.radioButtonCenterImage.TabStop = true;
            this.radioButtonCenterImage.Text = "Center Image";
            this.radioButtonCenterImage.UseVisualStyleBackColor = true;
            this.radioButtonCenterImage.CheckedChanged += new System.EventHandler(this.RadioButtonCenterImageCheckedChanged);
            // 
            // radioButtonStretchImage
            // 
            this.radioButtonStretchImage.AutoSize = true;
            this.radioButtonStretchImage.Location = new System.Drawing.Point(22, 58);
            this.radioButtonStretchImage.Name = "radioButtonStretchImage";
            this.radioButtonStretchImage.Size = new System.Drawing.Size(108, 20);
            this.radioButtonStretchImage.TabIndex = 1;
            this.radioButtonStretchImage.TabStop = true;
            this.radioButtonStretchImage.Text = "Stretch Image";
            this.radioButtonStretchImage.UseVisualStyleBackColor = true;
            this.radioButtonStretchImage.CheckedChanged += new System.EventHandler(this.RadioButtonStretchImageCheckedChanged);
            // 
            // radioButtonNormal
            // 
            this.radioButtonNormal.AutoSize = true;
            this.radioButtonNormal.Checked = true;
            this.radioButtonNormal.Location = new System.Drawing.Point(22, 32);
            this.radioButtonNormal.Name = "radioButtonNormal";
            this.radioButtonNormal.Size = new System.Drawing.Size(70, 20);
            this.radioButtonNormal.TabIndex = 0;
            this.radioButtonNormal.TabStop = true;
            this.radioButtonNormal.Text = "Normal";
            this.radioButtonNormal.UseVisualStyleBackColor = true;
            this.radioButtonNormal.CheckedChanged += new System.EventHandler(this.RadioButtonNormalCheckedChanged);
            // 
            // buttonStart
            // 
            this.buttonStart.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStart.Location = new System.Drawing.Point(720, 658);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(113, 35);
            this.buttonStart.TabIndex = 4;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = false;
            this.buttonStart.Click += new System.EventHandler(this.StartSegmentationButtonClick);
            // 
            // buttonCLean
            // 
            this.buttonCLean.BackColor = System.Drawing.SystemColors.ControlLight;
            this.buttonCLean.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonCLean.Location = new System.Drawing.Point(587, 658);
            this.buttonCLean.Name = "buttonCLean";
            this.buttonCLean.Size = new System.Drawing.Size(113, 35);
            this.buttonCLean.TabIndex = 5;
            this.buttonCLean.Text = "Clean";
            this.buttonCLean.UseVisualStyleBackColor = false;
            this.buttonCLean.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox1.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.After;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Location = new System.Drawing.Point(441, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(392, 417);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.pictureBox.BackgroundImage = global::WindowsFormsApplication1.Properties.Resources.Before;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(12, 41);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(392, 417);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 465);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.TabIndex = 6;
            this.label1.Text = "Segmentation type:";
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "0";
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "By intensivity",
            "By color"});
            this.comboBox1.Location = new System.Drawing.Point(176, 467);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 547);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Value of similarity:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(176, 547);
            this.textBox1.Name = "textBox1";
            this.textBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.textBox1.Size = new System.Drawing.Size(121, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.toolTip1.SetToolTip(this.textBox1, "Only fractional number");
            // 
            // buttonStop
            // 
            this.buttonStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonStop.Location = new System.Drawing.Point(720, 658);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(113, 35);
            this.buttonStop.TabIndex = 10;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Visible = false;
            this.buttonStop.Click += new System.EventHandler(this.StopSegmentationButtonClick);
            // 
            // progressBar1
            // 
            this.progressBar1.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            this.progressBar1.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.progressBar1.Location = new System.Drawing.Point(16, 670);
            this.progressBar1.MarqueeAnimationSpeed = 30;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(388, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 11;
            this.progressBar1.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(12, 501);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(132, 20);
            this.label3.TabIndex = 12;
            this.label3.Text = "Connectivity type:";
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Four",
            "Eight"});
            this.comboBox2.Location = new System.Drawing.Point(176, 499);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 21);
            this.comboBox2.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(330, 468);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 20);
            this.label4.TabIndex = 14;
            this.label4.Text = "Standard:";
            // 
            // comboBox3
            // 
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Digital ITU BT.601",
            "Photometric / digital ITU BT.709",
            "Approximation formula"});
            this.comboBox3.Location = new System.Drawing.Point(416, 466);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 21);
            this.comboBox3.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.groupBox1.Controls.Add(this.radioButtonByRoot);
            this.groupBox1.Controls.Add(this.radioButtonRandom);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(16, 588);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(281, 69);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Colors of segments";
            // 
            // radioButtonByRoot
            // 
            this.radioButtonByRoot.AutoSize = true;
            this.radioButtonByRoot.Location = new System.Drawing.Point(118, 32);
            this.radioButtonByRoot.Name = "radioButtonByRoot";
            this.radioButtonByRoot.Size = new System.Drawing.Size(68, 20);
            this.radioButtonByRoot.TabIndex = 1;
            this.radioButtonByRoot.TabStop = true;
            this.radioButtonByRoot.Text = "By root";
            this.radioButtonByRoot.UseVisualStyleBackColor = true;
            // 
            // radioButtonRandom
            // 
            this.radioButtonRandom.AutoSize = true;
            this.radioButtonRandom.Checked = true;
            this.radioButtonRandom.Location = new System.Drawing.Point(22, 32);
            this.radioButtonRandom.Name = "radioButtonRandom";
            this.radioButtonRandom.Size = new System.Drawing.Size(78, 20);
            this.radioButtonRandom.TabIndex = 0;
            this.radioButtonRandom.TabStop = true;
            this.radioButtonRandom.Text = "Random";
            this.radioButtonRandom.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(862, 705);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.comboBox3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCLean);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBoxOptions);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Text = "Segmentator Images";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBoxOptions.ResumeLayout(false);
            this.groupBoxOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.RadioButton radioButtonCenterImage;
		private System.Windows.Forms.RadioButton radioButtonZoom;
		private System.Windows.Forms.RadioButton radioButtonNormal;
		private System.Windows.Forms.RadioButton radioButtonStretchImage;
		private System.Windows.Forms.GroupBox groupBoxOptions;
		private System.Windows.Forms.ToolStripMenuItem menuItemExit;
		private System.Windows.Forms.ToolStripMenuItem menuItemOpen;
		private System.Windows.Forms.ToolStripMenuItem menuItemAbout;
		private System.Windows.Forms.ToolStripMenuItem menuItemHelp;
		private System.Windows.Forms.ToolStripMenuItem menuItemFile;
		private System.Windows.Forms.PictureBox pictureBox;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem greyFilterToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonCLean;
        private System.Windows.Forms.ToolStripMenuItem aboutAlgorithmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonByRoot;
        private System.Windows.Forms.RadioButton radioButtonRandom;
    }
}
