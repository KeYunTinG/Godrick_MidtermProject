using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace slnMumu_MidtermProject.Views
{   
    public delegate void RemoveButtonHandler(ProductCardEditable pce);
    public delegate void EditButtonHandler(ProductCardEditable pce);
    public delegate void PositionHandler(ProductCardEditable pce, CardMove move);
    public enum CardMove
    {
        MoveUp, MoveDown
    }
    public partial class ProductCardEditable : UserControl
    {
        
        public event RemoveButtonHandler RemoveButtonClick;
        public event EditButtonHandler EditButtonClick;
        public event PositionHandler PositionButtonClick;
        public ProductCardEditable()
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
                    this.pbThumbnail.Image = new Bitmap(_product.Thumbnail);
                }
                this.lblName.Text = _product.ProductName;
                this.lblPrice.Text = _product.Price.ToString("C0");
                // TODO:計算剩餘數量
                this.lblQuantity.Text = $"剩餘 {_product.Quantity - 0} 份";
                this.rtbDescription.Text = _product.ProductDescription;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RemoveButtonClick?.Invoke(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            EditButtonClick?.Invoke(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PositionButtonClick?.Invoke(this, CardMove.MoveUp);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            PositionButtonClick?.Invoke(this, CardMove.MoveDown);
        }
    }
}
