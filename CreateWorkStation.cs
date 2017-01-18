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
    public partial class CreateWorkStation : Form
    {
        public int      creatingWindowWidth;
        public int      creatingWindowHeight;
        public string   creatingFilename;

        public CreateWorkStation()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            creatingWindowWidth  = Convert.ToInt32(txtCreateWidth.Text);
            creatingWindowHeight = Convert.ToInt32(txtCreateHeight.Text);
            creatingFilename     = txtFileName.Text;
        }
    }
}
