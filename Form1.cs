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
using System.Drawing.Imaging;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form2 f               = new Form2();
        public CreateWorkStation cws = new CreateWorkStation();

        public Form1()
        {
            InitializeComponent();
            f.MdiParent = this;            
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                f.filename = openFileDialog1.FileName;                                              
            }

            f.WindowState = FormWindowState.Maximized;
            f.Show();
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(cws.ShowDialog() == DialogResult.OK)
            {
                f.widthImage      = cws.creatingWindowWidth;
                f.heightImage     = cws.creatingWindowHeight;
                f.filenameImage   = cws.creatingFilename;
                f.isCreating      = true;
                f.WindowState     = FormWindowState.Maximized;

                f.Show();
            }
        }

        private void resizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f.SelectedTools("ResizeImage");
        }        

        private void BlackAndWhiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f.SelectedTools("ImageColorBlackAndWhite");
        }

        private void sepiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f.SelectedTools("ImageColorSepia");
        }

        private void negativToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f.SelectedTools("ImageColorNegativ");
        }

        private void blueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f.SelectedTools("ImageColorBlue");
        }

        private void redToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f.SelectedTools("ImageColorRed");
        }

        private void greenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f.SelectedTools("ImageColorGreen");
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f.SelectedTools("Save");
            if(saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                f.bmp.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
                f.filename = saveFileDialog1.FileName;
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (f.filename != null)
                f.bmp.Save(f.filename, ImageFormat.Jpeg);
            else
                saveAsToolStripMenuItem_Click(sender, e);
        }
    }
}
