using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjMumu_MidtermProject
{
    public partial class CCPurchaseHistory : UserControl
    {
        public event EventHandler fieldClick;
        public CCPurchaseHistory()
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
        public string fieldPrice
        {
            get { return Pricelabel.Text; }
            set 
            {
                Money m = new Money();
                Pricelabel.Text = m.MoneyProcess(value);
                //Pricelabel.Text = value;
            }
        }
        public string fieldDate
        {
            get { return Datelabel.Text; }
            set { Datelabel.Text = value; }
        }
        public string fieldProduct1
        {
            get { return Productlabel1.Text; }
            set { Productlabel1.Text = value; }
        }
        public string fieldProduct2
        {
            get { return Productlabel2.Text; }
            set { Productlabel2.Text = value; }
        }
        public string fieldProduct3
        {
            get { return Productlabel3.Text; }
            set { Productlabel3.Text = value; }
        }
        public string fieldProduct4
        {
            get { return Productlabel4.Text; }
            set { Productlabel4.Text = value; }
        }
        /*public string fieldDescription
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }*/
        private void oClick()
        {
                Titlelabel.Click += _Click;
        }
        public void _Click(object sender, EventArgs e)
        {
            fieldClick?.Invoke(sender, e);
        }
    }
}
