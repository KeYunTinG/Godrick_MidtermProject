using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjMumu_MidtermProject
{
    public partial class FrmLiked : Form
    {
        private CurrentUserManager cum;
        public FrmLiked()
        {
            InitializeComponent();
            cum = new CurrentUserManager();
        }

        private string currentUser;

        private void FrmLiked_Load(object sender, EventArgs e)
        {
            currentUser = cum.currentUser;
            label2.Text = currentUser;
        }
    }
}
