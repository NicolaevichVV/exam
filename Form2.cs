using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication2
{
    public partial class Form2 : Form
    {
        public string filename { get; set; }
        private int _widthImg, _heightImg;

        private ResizeImageForms rif = new ResizeImageForms();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.Text = filename;
            pictureBox1.Image = Image.FromStream(new MemoryStream(File.ReadAllBytes(filename)));
            pictureBox1.Refresh();
        }

        //private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    this.Close();
        //}
        /*----------------------- Menu item -----------------------------*/
        public void SelectedTools(string toolType)
        {
            switch (toolType)
            {
                case "ResizeImage":
                    ResizeImage();
                    break;
                case "ImageColorBlackAndWhite":
                    ImageColors("BlackAndWhite");
                    break;
                case "ImageColorSepia":
                    ImageColors("Sepia");
                    break;
                case "ImageColorNegativ":
                    ImageColors("Negativ");
                    break;
                case "ImageColorRed":
                    ImageColors("Red");
                    break;
                case "ImageColorGreen":
                    ImageColors("Green");
                    break;
                case "ImageColorBlue":
                    ImageColors("Blue");
                    break;
                default:
                    break;
            }
        }
        /*------------------- Redact image function ---------------------*/
        private void ResizeImage()
        {
            rif.Show();
            _widthImg = Convert.ToInt32(rif.widthImg);
            _heightImg = Convert.ToInt32(rif.heightImg);
        }

        private void ImageColors(string colors)
        {
            Image img = pictureBox1.Image;
            System.Drawing.Imaging.ImageAttributes imageAttrs = new System.Drawing.Imaging.ImageAttributes();

            switch (colors)
            {
                case "BlackAndWhite":
                    imageAttrs.SetColorMatrix(CreateBlackAndWhiteMatrix());
                    break;
                case "Sepia":
                    imageAttrs.SetColorMatrix(CreateSepiaMatrix());
                    break;
                case "Negativ":
                    imageAttrs.SetColorMatrix(CreateNegativMatrix());
                    break;
                case "Red":
                    imageAttrs.SetColorMatrix(CreateRedMatrix());
                    break;
                case "Green":
                    imageAttrs.SetColorMatrix(CreateBlueMatrix());
                    break;
                case "Blue":
                    imageAttrs.SetColorMatrix(CreateGreenMatrix());
                    break;
                default:
                    break;
            }

            using (Graphics g = Graphics.FromImage(img))
            {
                g.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height),
                    0, 0, img.Width, img.Height, GraphicsUnit.Pixel, imageAttrs);
            }
            pictureBox1.Invalidate();
        }  
        /*------------------- Redact color image -------------------------*/
        private System.Drawing.Imaging.ColorMatrix CreateBlackAndWhiteMatrix()
        {
            return new System.Drawing.Imaging.ColorMatrix(new float[][]{
                    new float[] { 0.299f, 0.299f, 0.299f, 0, 0 },
                    new float[] { 0.587f, 0.587f, 0.587f, 0, 0 },
                    new float[] { 0.114f, 0.114f, 0.114f, 0, 0 },
                    new float[] {   0,    0,    0, 1, 0},
                    new float[] {   0,    0,    0, 0, 1}
            });
        }

        private System.Drawing.Imaging.ColorMatrix CreateSepiaMatrix()
        {
            return new System.Drawing.Imaging.ColorMatrix(new float[][]{
                    new float[] {0.396f, 0.349f, 0.272f, 0, 0},
                    new float[] {0.769f, 0.686f, 0.534f, 0, 0},
                    new float[] {0.189f, 0.168f, 0.131f, 0, 0},
                    new float[] {   0,    0,    0, 1, 0},
                    new float[] {   0,    0,    0, 0, 1}
            });
        }

        private System.Drawing.Imaging.ColorMatrix CreateNegativMatrix()
        {
            return new System.Drawing.Imaging.ColorMatrix(new float[][]{
                    new float[] {-1, 0, 0, 0, 0},
                    new float[] {0, -1, 0, 0, 0},
                    new float[] {0, 0, -1, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {1, 1, 1, 0, 1}
            });
        }

        private System.Drawing.Imaging.ColorMatrix CreateRedMatrix()
        {
            return new System.Drawing.Imaging.ColorMatrix(new float[][]{
                    new float[] {1, 0, 0, 0, 0},
                    new float[] {0, 0, 0, 0, 0},
                    new float[] {0, 0, 0, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
            });
        }

        private System.Drawing.Imaging.ColorMatrix CreateGreenMatrix()
        {
            return new System.Drawing.Imaging.ColorMatrix(new float[][]{
                    new float[] {0, 0, 0, 0, 0},
                    new float[] {0, 1, 0, 0, 0},
                    new float[] {0, 0, 0, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
            });
        }

        private System.Drawing.Imaging.ColorMatrix CreateBlueMatrix()
        {
            return new System.Drawing.Imaging.ColorMatrix(new float[][]{
                    new float[] {0, 0, 0, 0, 0},
                    new float[] {0, 0, 0, 0, 0},
                    new float[] {0, 0, 1, 0, 0},
                    new float[] {0, 0, 0, 1, 0},
                    new float[] {0, 0, 0, 0, 1}
            });
        }
    }
}
