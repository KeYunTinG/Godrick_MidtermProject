using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace slnMumu_MidtermProject
{
    public partial class PrjPBFront : UserControl
    {
        public string textName
        {
            get
            {
                return label1.Text;
            }
            set
            {
                this.label1.Text = value;
            }
        }
        public Image image
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
        public string textSupport
        {
            get
            {
                return label2.Text;
            }
            set
            {
                this.label2.Text = value;
            }
        }
        public string textTotal
        {
            get
            {
                return label3.Text;
            }
            set
            {
                this.label3.Text = value;
            }
        }
        public PrjPBFront()
        {
            InitializeComponent();
            this.label1.Parent= this.pictureBox1;
            this.label2.Parent = this.pictureBox1;
            this.label3.Parent = this.pictureBox1;
        }
    }
}
