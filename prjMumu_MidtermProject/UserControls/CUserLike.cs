using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjMumu_MidtermProject.UserControls
{
    public partial class CUserLike : UserControl
    {
        public event EventHandler fieldClick;
        public event EventHandler DeleteClick;
        public CUserLike()
        {
            InitializeComponent();
            oClick();
        }
        public Image fieldPhoto
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }
        public string fieldTitle
        {
            get { return Titlelabel.Text; }
            set { Titlelabel.Text = value; }
        }
        public string fieldDescription
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
        private void oClick()
        {
            Titlelabel.Click += _Click;
            pictureBox2.Click += _DeleteClick;
        }
        public void _Click(object sender, EventArgs e)
        {
            fieldClick?.Invoke(sender, e);
        }

        private void _DeleteClick(object sender, EventArgs e)
        {
            DeleteClick?.Invoke(sender, e);
        }
    }
}
