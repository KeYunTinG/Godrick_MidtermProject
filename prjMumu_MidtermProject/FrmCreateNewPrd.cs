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
    public partial class FrmCreateNewPrd : Form
    {
        private int prjID;
        private string path = System.Windows.Forms.Application.StartupPath + "\\Images\\ProductsThumbnail";
        private string _ImagePath = "";
        public FrmCreateNewPrd(int prjID)
        {
            InitializeComponent();
            this.prjID = prjID;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (ZecZecEntities db = new ZecZecEntities())
            {
                bool isPrice = decimal.TryParse(textBox3.Text, out decimal price);
                bool isQuantity = int.TryParse(textBox4.Text, out int quantity);
                bool isInventory = int.TryParse(textBox5.Text, out int inventory);
                var prj = db.Projects.FirstOrDefault(x=>x.ProjectID==prjID);
                if (_ImagePath == "")
                {
                    MessageBox.Show("請選擇圖片");
                    return;
                }
                    if (_ImagePath != "")
                {
                    var newPrd = new Products()
                    {
                        ProjectID= prjID,
                        ProductName = textBox1.Text,
                        ProductDescription = textBox2.Text,
                        Price = price,
                        Quantity = quantity,
                        Inventory = inventory,
                        Date = DateTime.Now,
                        ExpireDate = prj.ExpireDate,
                        Thumbnail= _ImagePath
                    };
                    if (quantity>= inventory)
                    {
                        db.Products.Add(newPrd);
                        db.SaveChanges();
                        MessageBox.Show("新增成功");
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

        private void button1_Click(object sender, EventArgs e)
        {
            FrmProductList f = new FrmProductList(prjID);
            f.MdiParent = this.MdiParent as FrmHomepage;
            f.Dock = DockStyle.Fill;
            f.Show();
            this.Close();
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
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

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)

        {
            KeyPreview = true;

            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127)
            {
                e.Handled = true;
            }

        }
    }
}
