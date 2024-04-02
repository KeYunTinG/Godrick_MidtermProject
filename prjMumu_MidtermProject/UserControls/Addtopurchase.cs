using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjMumu_MidtermProject.FrmSpo
{
    public partial class Addtopurchase : UserControl
    {
        public delegate void CheckedChange(Products _product);
        public event CheckedChange checkedchange;

        public Addtopurchase()
        {
            InitializeComponent();
        }
        public PictureBox productpic
        { get { return pictureBox2; } set { pictureBox2 = value; } }

        public string productname
        { get { return label3.Text; } set { label3.Text = value; } }
        public string price
        { get { return label4.Text; } set { label4.Text = value; } }
        public string Inventory
        { get { return label7.Text; } set { label7.Text = value; } }
        public string description
        { get { return richTextBox1.Text; } set { richTextBox1.Text = value; } }

        public Label alreadySponsored
        { get { return label8; } set { label8 = value; } }

        public RichTextBox RichTextBox
        { get { return richTextBox1; } set { richTextBox1 = value; richTextBox1.ReadOnly = false; } }

        public CheckBox checkBox
        { get { return checkBox1; } set { checkBox1 = value; } }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

            if (this.checkBox1.Checked == true)
            {

                Products p = this.Tag as Products;

                checkedchange(p);

            }
            if (this.checkBox1.Checked == false)
            {
                Products p = this.Tag as Products;

                checkedchange(p);
            }
        }
    }
}
