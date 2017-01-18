using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class ResizeImageForms : Form
    {
        public string widthImg { get; set; }
        public string heightImg { get; set; }
        public ResizeImageForms()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            widthImg = txtWidth.Text;
            heightImg = txtHeight.Text;
        }
    }
}
