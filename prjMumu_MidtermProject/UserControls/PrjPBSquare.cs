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

    public partial class PrjPBSquare : UserControl
    {

        public Image Image
        {
            get
            {
                return this.pictureBox1.Image;
            }
            set
            {
                this.pictureBox1.Image = value;
            }
        }
        public string title
        {
            get
            {
                return this.label1.Text;
            }
            set
            {
                this.label1.Text = value;
            }
        }
        public string total
        {
            get
            {
                return this.label2.Text;
            }
            set
            {
                this.label2.Text = value;
            }
        }
        public string support
        {
            get
            {
                return this.label3.Text;
            }
            set
            {
                this.label3.Text = value;
            }
        }
        public int valueP
        {
            get
            {
                return this.cyberProgressBar1.Value;
            }
            set
            {
                this.cyberProgressBar1.Value = value;
            }
        }
        public PrjPBSquare()
        {
            InitializeComponent();
        }
    }
}
