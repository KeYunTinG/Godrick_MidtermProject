using slnMumu_MidtermProject.Views;
using ReaLTaiizor.Extension;
using slnMumu_MidtermProject;
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
    public delegate void AddProductHandler(FrmProposeProduct f);
    public delegate void EditHandler(FrmProposeProduct f);
    public partial class FrmProposeProduct : Form
    {
        FrmMyMessageBox f = new FrmMyMessageBox();
        public event AddProductHandler AddProduct;
        public event EditHandler confirmEdit;
        private string _path;
        private Products _product;
        public Products product
        {
            get
            {
                if (_product == null) _product = new Products();
                _product.ProductName = this.txtPName.Text;
                _product.Price = Convert.ToDecimal(txtPPrice.Text);
                _product.Quantity = Convert.ToInt32(txtPQty.Text);
                _product.ProductDescription = txtPDecs.Text;
                _product.Date = dtPStart.Value;
                _product.ExpireDate = dtPEnd.Value;
                _product.Thumbnail = _path;
                return _product;
            }
            set
            {
                _product = value;
                this.txtPName.Text = _product.ProductName;
                this.txtPPrice.Text = _product.Price.ToString();
                this.txtPQty.Text = _product.Quantity.ToString();
                this.txtPDecs.Text = _product.ProductDescription;
                this.dtPStart.Value = _product.Date;
                this.dtPEnd.Value = _product.ExpireDate;
                this.hopePictureBox1.Image = new Bitmap(_product.Thumbnail);
                _path = _product.Thumbnail;
            }
        }
        public FrmProposeProduct()
        {
            InitializeComponent();
            this.hopePictureBox1.AllowDrop = true;
        }
        #region 照片相關
        private void hopePictureBox1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "照片|*.jpg;*.png;*.jpeg";
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            _path = openFileDialog1.FileName;
            this.hopePictureBox1.Image = new Bitmap(_path);
        }
        private void hopePictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string droppedFile = files[0];
            _path = droppedFile;
            this.hopePictureBox1.Image = new Bitmap(_path);
        }
        private void hopePictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            // 檢查是否只有一個拖放的文件，並且是允許的格式
            if (files.Length == 1 && IsFileAllowed(files[0]))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private bool IsFileAllowed(string fileName)
        {
            // 在這裡添加您希望允許的檔案格式，例如.txt和.jpg
            string[] allowedExtensions = { ".png", ".jpg", ".jpeg" };
            // 檢查檔案擴展名是否在允許的擴展名陣列中
            string extension = System.IO.Path.GetExtension(fileName);
            return allowedExtensions.Contains(extension);
        }
        #endregion

        private void dtPStart_ValueChanged(object sender, EventArgs e)
        {
            if (this.dtPStart.Value < DateTime.Now.AddDays(-1))
            {
                FrmMyMessageBox f = new FrmMyMessageBox();
                f.msg = "開始日期不得在今天之前";
                f.ShowDialog();
                //MessageBox.Show("開始日期不得在今天之前");
                this.dtPStart.Value = DateTime.Now;
            }
        }

        private void dtPEnd_ValueChanged(object sender, EventArgs e)
        {
            if (this.dtPEnd.Value <= this.dtPStart.Value.AddDays(-1))
            {
                FrmMyMessageBox f = new FrmMyMessageBox();
                f.msg = "結束日期不得在開始日之前";
                f.ShowDialog();
                //MessageBox.Show("結束日期不得在開始日之前");
                this.dtPEnd.Value = this.dtPStart.Value;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            decimal price;
            int qty;
            if (this.txtPName.Text.Length <= 0)
            {
                FrmMyMessageBox f = new FrmMyMessageBox();
                f.msg = "語言能力喪失了逆?";
                f.ShowDialog();
                //MessageBox.Show("語言能力喪失了逆?");
                return;
            }
            if (!decimal.TryParse(this.txtPPrice.Text, out price) || !int.TryParse(this.txtPQty.Text, out qty) || price < 0 || qty < 0)
            {
                FrmMyMessageBox f = new FrmMyMessageBox();
                f.msg = "你對數字理解有什麼障礙?";
                f.ShowDialog();
                //MessageBox.Show("你對數字理解有什麼障礙");
                return;
            }
            if (this.dtPEnd.Value <= this.dtPStart.Value.AddDays(-1))
            {
                FrmMyMessageBox f = new FrmMyMessageBox();
                f.msg = "結束日期不得在開始日之前";
                f.ShowDialog();
                //MessageBox.Show("結束日期不得在開始日之前");
                this.dtPStart.Value = this.dtPEnd.Value;
                return;
            }
            if (string.IsNullOrEmpty(_path))
            {
                FrmMyMessageBox f = new FrmMyMessageBox();
                f.msg = "不會上傳照片484?";
                f.ShowDialog();
                //MessageBox.Show("不會上傳照片484?");
                return;
            }
            confirmEdit?.Invoke(this);
            AddProduct?.Invoke(this);
            this.Close();
        }

        private void demo_Click(object sender, EventArgs e)
        {
            this.txtPName.Text = "這是一個普拉大可";
            this.txtPPrice.Text = "55";
            this.txtPQty.Text = "66";
            this.txtPDecs.Text = "大阪念osaka\n東京念tokyo\n京都念慈庵";
        }
    }
}
