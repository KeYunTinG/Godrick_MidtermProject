using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace slnMumu_MidtermProject
{
    public partial class FrmAbout : Form
    {
        private CurrentUserManager cum;
        public FrmAbout()
        {
            InitializeComponent();
            cum = new CurrentUserManager();
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {

        }

        private void FrmAbout_Activated(object sender, EventArgs e)
        {

        }
    }
}
