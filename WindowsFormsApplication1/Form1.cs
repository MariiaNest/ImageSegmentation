using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Segmentation

{
	public partial class Form1 : Form
	{
        CancellationTokenSource tokenSource;

        public Form1()
		{
			InitializeComponent();           
        }
       
		private void OpenFile()
		{
			OpenFileDialog dialog = new OpenFileDialog();

            dialog.Title = "Open an image file";
			dialog.Filter = "Gif Image(*.gif)|*.gif|JPeg Image(*.jpg)|*.jpg|Png Image(*.png)|*.png|Bitmap Image(*.bmp)|*.bmp|All Files(*.*)|*.*";
            
			if (dialog.ShowDialog() == DialogResult.OK)
			{
                pictureBox.Image = new Bitmap(dialog.FileName);
                pictureBox.Refresh();

                pictureBox1.Image = null;
                pictureBox1.Refresh();
            }
		}     
		
        private void SaveFile()
        {
            if (pictureBox1.Image == null)
            {
                return;
            }
            else
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Title = "Save an image file";
                dialog.Filter = "Gif Image(*.gif)|*.gif|JPeg Image(*.jpg)|*.jpg|Png Image(*.png)|*.png|Bitmap Image(*.bmp)|*.bmp";
                if (dialog.ShowDialog() == DialogResult.OK && !String.IsNullOrEmpty(dialog.FileName))
                {
                    FileStream fs = (FileStream)dialog.OpenFile();
                    switch (dialog.FilterIndex)
                    {
                        case 1:
                            pictureBox1.Image.Save(fs, ImageFormat.Gif);
                            break;

                        case 2:
                            pictureBox1.Image.Save(fs, ImageFormat.Jpeg);
                            break;

                        case 3:
                            pictureBox1.Image.Save(fs, ImageFormat.Png);
                            break;
                        case 4:
                            pictureBox1.Image.Save(fs, ImageFormat.Bmp);
                            break;
                    }
                    fs.Close();
                }
            }
        }

		private void SetSizeMode()
		{
			if (radioButtonNormal.Checked)
            {
                pictureBox.SizeMode = PictureBoxSizeMode.Normal;
                pictureBox1.SizeMode = PictureBoxSizeMode.Normal;
            }
			else
				if (radioButtonStretchImage.Checked)
                {
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                }
				else
                    if (radioButtonCenterImage.Checked)
                    {
                        pictureBox.SizeMode = PictureBoxSizeMode.CenterImage;
                        pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                    }
                    else
                        if (radioButtonZoom.Checked)
                        {
                            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                        }
		}
		
		private void MenuItemOpenClick(object sender, EventArgs e)
		{
			OpenFile();
		}

        private void MenuItemSaveClick(object sender, EventArgs e)
        {
            SaveFile();
        }

        private void MenuItemExitClick(object sender, EventArgs e)
		{
			Close();
		}
		
		private void MenuItemAboutProgramClick(object sender, EventArgs e)
		{		
			AboutProgram aboutProgram = new AboutProgram();
			aboutProgram.Show();
		}

        private void MenuItemAboutAlgorithmClick(object sender, EventArgs e)
        {
            AboutAlgorithm aboutAlgorithm = new AboutAlgorithm();
            aboutAlgorithm.Show();
        }
		
		private void RadioButtonNormalCheckedChanged(object sender, EventArgs e)
		{
			SetSizeMode();
		}
		
		private void RadioButtonStretchImageCheckedChanged(object sender, EventArgs e)
		{
			SetSizeMode();
		}
		
		private void RadioButtonCenterImageCheckedChanged(object sender, EventArgs e)
		{
			SetSizeMode();
		}
		
		private void RadioButtonZoomCheckedChanged(object sender, EventArgs e)
		{
			SetSizeMode();
		}

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox.Image = null;
            pictureBox1.Image = null;            
        }

        private async void StartSegmentationButtonClick(object sender, EventArgs e)
        {
            double similarityValue = Double.NaN;
            ColorsOfSegments colorsOfSegments;
            if (radioButtonByRoot.Checked)
            {
                colorsOfSegments = ColorsOfSegments.ByRoot;
            }
            else
            {
                colorsOfSegments = ColorsOfSegments.Random;
            }
            
            if (pictureBox.Image == null)
            {
                MessageBox.Show("Please, select image for segmentation", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please, select type of segmentation image", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (comboBox1.SelectedIndex == 0 && comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Please, select type of standart by calculate intensivity of pixel", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Please, insert value of similarity pixels for segmentation image", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if(!Double.TryParse(textBox1.Text.Replace(',','.'), NumberStyles.Any, CultureInfo.InvariantCulture, out similarityValue))
            {
                MessageBox.Show("Value of similarity can be only fractional number", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                buttonStop.Visible = true;
                progressBar1.Visible = true;
                buttonCLean.Enabled = false;
                comboBox1.Enabled = false;
                comboBox2.Enabled = false;
                comboBox3.Enabled = false;
                textBox1.Enabled = false;
                tokenSource = new CancellationTokenSource();
                try
                {
                    Connectivity connect = Connectivity.Four;
                    switch (comboBox2.SelectedIndex)
                    {
                        case 0: connect = Connectivity.Four; 
                                break;
                        case 1: connect = Connectivity.Eight; 
                                break;
                    }
                    IntensivityStandard standard = IntensivityStandard.Photometric;
                    switch (comboBox3.SelectedIndex)
                    {
                        case 0: standard = IntensivityStandard.DigitalITU;
                            break;
                        case 1: standard = IntensivityStandard.Photometric;
                            break;
                        case 2: standard = IntensivityStandard.ApproximationFormula;
                            break;
                    }

                    switch (comboBox1.SelectedIndex)
                    {
                        case 0:
                            pictureBox1.Image = await Task.Run(() => SegmentationBitmap.RunSeparation((Bitmap)pictureBox.Image, SegmentationType.Intensity, connect, similarityValue, standard, colorsOfSegments, tokenSource.Token), tokenSource.Token);
                            break;
                        case 1:
                            pictureBox1.Image = await Task.Run(() => SegmentationBitmap.RunSeparation((Bitmap)pictureBox.Image, SegmentationType.Color, connect, similarityValue, standard, colorsOfSegments, tokenSource.Token), tokenSource.Token);
                            break; 
                        default: break;
                    }
                }
                catch(OperationCanceledException)
                {
                    return;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    buttonStop.Visible = false;
                    progressBar1.Visible = false;
                    buttonCLean.Enabled = true;
                    comboBox1.Enabled = true;
                    comboBox2.Enabled = true;
                    comboBox3.Enabled = true;
                    textBox1.Enabled = true;
                }
                pictureBox1.Refresh();
            }
        }

        private void StopSegmentationButtonClick(object sender, EventArgs e)
        {
            tokenSource.Cancel();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                label4.Visible = true;
                comboBox3.Visible = true;                
            }
            else
            {
                label4.Visible = false;
                comboBox3.Visible = false;
            }
        }      
    }
}
