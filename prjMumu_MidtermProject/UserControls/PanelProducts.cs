using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace slnMumu_MidtermProject.UserControls
{
    public partial class PanelProducts : UserControl
    {
        public delegate void DirectToPay(int projectID, int productID);
        public event DirectToPay OnPay;

        public PanelProducts()
        {
            InitializeComponent();

        }

        private string _productImagePath { get; set; }
        private string _productName { get; set; }
        private string _productPrice { get; set; }
        private string _productIventory { get; set; }
        private string _productSelled { get; set; }
        private string _productDescription { get; set; }

        public string productImagePath
        {
            get { return _productImagePath; }
            set { _productImagePath = value; }
        }

        public string productName
        {
            get { return _productName; }
            set { _productName = value; lblProductTitle.Text = productName; }
        }

        public string productPrice
        {
            get { return _productPrice; }
            set { _productPrice = value; lblPrice.Text = productPrice; }
        }

        public string productIventory
        {
            get { return _productIventory; }
            set { _productIventory = value; label1.Text = _productIventory; }
        }

        public string productSelled
        {
            get { return _productSelled; }
            set
            {
                _productSelled = value; label2.Text = _productSelled;
            }
        }

        public string productDescription
        {
            get { return _productDescription; }
            set { _productDescription = value; richTextBox1.Text = productDescription; }
        }


        private void PanelProducts_Load(object sender, EventArgs e)
        {
            panel1.MouseEnter += C_MouseEnter;
            panel1.MouseLeave += C_MouseLeave;
            panel1.Click += C_Click;

            foreach (Control c in panel1.Controls)
            {
                c.MouseEnter += C_MouseEnter;
                c.MouseLeave += C_MouseLeave;

                if (c != this.richTextBox1)
                    c.Click += C_Click;
            }

            foreach (Control cc in flowLayoutPanel1.Controls)
            {
                cc.MouseEnter += C_MouseEnter;
                cc.MouseLeave += C_MouseLeave;
                cc.Click += C_Click;
            }

            if (string.IsNullOrEmpty(_productImagePath))
            {
                pictureBox1.Image = new Bitmap(Application.StartupPath + "\\Images\\error.png");
            }

            pictureBox1.Image = new Bitmap(_productImagePath);
            richTextBox1.ReadOnly = true;
        }

        private void C_Click(object sender, EventArgs e)
        {
            int[] a = (int[])this.Tag;

            OnPay?.Invoke(a[0], a[1]);
        }

        private void C_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }

        private void C_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.SlateGray;
        }
    }
}
