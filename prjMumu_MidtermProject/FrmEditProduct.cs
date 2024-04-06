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

namespace slnMumu_MidtermProject
{
    public partial class FrmEditProduct : Form
    {
        private int prjID;
        private int prdID;
        private string path = System.Windows.Forms.Application.StartupPath + "\\Images\\ProductsThumbnail";
        private string _ImagePath = "";
        public FrmEditProduct(int prdID)
        {
            InitializeComponent();
            this.prdID = prdID;
        }

        private void FrmEditProduct_Load(object sender, EventArgs e)
        {
            
            using (ZecZecEntities db=new ZecZecEntities())
            {
                var product=db.Products.FirstOrDefault(x => x.ProductID == prdID);
                if (product != null)
                {
                    textBox1.Text = product.ProductName;
                    textBox2.Text = product.ProductDescription;
                    textBox3.Text = product.Price.ToString();
                    textBox4.Text = product.Quantity.ToString();
                    textBox5.Text = product.Inventory.ToString();
                    pictureBox1.Image = new Bitmap(path + "\\" + product.Thumbnail);
                    prjID = product.ProjectID;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmProductList f = new FrmProductList(prjID);
            f.MdiParent = this.MdiParent as FrmHomepage;
            f.Dock = DockStyle.Fill;
            f.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (ZecZecEntities db = new ZecZecEntities())
            {
                //編輯部分
                //Inventory庫存是編輯的嗎?還是用算的?
                bool isPrice = decimal.TryParse(textBox3.Text, out decimal price);
                bool isQuantity = int.TryParse(textBox4.Text, out int quantity);
                bool isInventory = int.TryParse(textBox5.Text, out int inventory);
                var product = db.Products.FirstOrDefault(x => x.ProductID == prdID);
                if (product != null)
                {
                    product.ProductName = textBox1.Text;
                    product.ProductDescription = textBox2.Text;
                    product.Price = price;
                    product.Quantity = quantity;
                    product.Inventory = inventory;
                    if (_ImagePath != "")
                    {
                        product.Thumbnail = _ImagePath;
                    }

                    if (quantity >= inventory)
                    {
                        db.SaveChanges();
                        MessageBox.Show("修改成功");
                        FrmProductList f = new FrmProductList(prjID);
                        f.MdiParent = this.MdiParent as FrmHomepage;
                        f.Dock = DockStyle.Fill;
                        f.Show();
                        this.Close();
                    }
                    
                    else
                    {
                        MessageBox.Show("請輸入正確的商品總數或庫存");
                    }
                }
                
                
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "專案照片|*.jpg|專案照片|*.png|專案照片|*.bmp";
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            _ImagePath = _ImagePath = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
            string path = System.Windows.Forms.Application.StartupPath + "\\Images\\ProductsThumbnail";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            File.Copy(openFileDialog1.FileName, path + "\\" + _ImagePath, true);
            pictureBox1.Image = new Bitmap(path + "\\" + _ImagePath);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 8 是Backspace 127 是delete
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127)
            {
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127)
            {
                e.Handled = true;
            }
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127)
            {
                e.Handled = true;
                
            }
        }

        private void textBox4_KeyDown(object sender, KeyEventArgs e)
        {

          
        }
    }
}
