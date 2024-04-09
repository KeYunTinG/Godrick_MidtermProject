using slnMumu_MidtermProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjMumu_MidtermProject
{
    public partial class FrmShowPPT : Form
    {
        int p = 1;
        int pMax = 9;
        string path = "";
        public FrmShowPPT()
        {
            InitializeComponent();
            string parentDirectory = Path.GetDirectoryName(Path.GetDirectoryName(Application.StartupPath)) + "\\PPT\\";
            path = parentDirectory;
        }

        private void FrmShowPPT_Load(object sender, EventArgs e)
        {
            try
            {
                pictureBox1.Image = new Bitmap(path + p + ".jpg");
            }
            catch
            {
                FrmMyMessageBox fm = new FrmMyMessageBox();
                fm.msg = "啟動失敗";
                fm.ShowDialog();
            }
        }
        private void pictureBoxLeft_Click(object sender, EventArgs e)
        {
            if (p == 1) return;
            p--;
            pictureBox1.Image = new Bitmap(path + p + ".jpg");
        }
        private void pictureRight_Click(object sender, EventArgs e)
        {
            if (p == pMax) return;
            p++;
            pictureBox1.Image = new Bitmap(path + p + ".jpg");
        }

        private void pictureClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (pMax == 8) return;
            p++;
            pictureBox1.Image = new Bitmap(path + p);
        }
    }
}
