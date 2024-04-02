using prjMumu_MidtermProject;
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

namespace slnMumu_MidtermProject.Views
{
    public delegate void D(ProductCard pd);
    public partial class ProductCard : UserControl
    {
        public event D ClickProduct;
        public ProductCard()
        {
            InitializeComponent();
        }
        private Products _product;
        public Products product
        {
            get
            {
                return _product;
            }
            set
            {
                _product = value;
                if (!string.IsNullOrEmpty(_product.Thumbnail))
                {
                    string prefix = Application.StartupPath + @"\Images\ProductsThumbnail\";
                    this.pbThumbnail.Image = new Bitmap(prefix + _product.Thumbnail);
                }
                this.lblName.Text = _product.ProductName;
                this.lblPrice.Text = _product.Price.ToString("C0");
                // TODO:計算剩餘數量
                this.lblQuantity.Text = $"剩餘 {_product.Quantity} 份";
                this.rtbDescription.Text = _product.ProductDescription;
            }
        }

        private void ProductCard_Load(object sender, EventArgs e)
        {
            // 關於設計

            // 所有元素都可以觸發事件
            this.panel1.Click += ProductCard_Click;
            this.panel1.MouseEnter += ProductCard_MouseEnter;
            this.panel1.MouseLeave += ProductCard_MouseLeave;

            foreach (var el in this.panel1.Controls)
            {
                ((Control)el).Click += ProductCard_Click;
                ((Control)el).MouseEnter += ProductCard_MouseEnter;
                ((Control)el).MouseLeave += ProductCard_MouseLeave;
            }

        }

        private void ProductCard_Click(object sender, EventArgs e)
        {
            if (this.ClickProduct != null)
                this.ClickProduct(this);
        }

        private void ProductCard_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.Transparent;
        }

        private void ProductCard_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.Gray;
        }

    }
}
