namespace slnMumu_MidtermProject.Views
{
    partial class ProductCard
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductCard));
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtbDescription = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.pbThumbnail = new System.Windows.Forms.PictureBox();
            this.lblSponsorTime = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumbnail)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MistyRose;
            this.panel1.Controls.Add(this.rtbDescription);
            this.panel1.Controls.Add(this.lblPrice);
            this.panel1.Controls.Add(this.lblName);
            this.panel1.Controls.Add(this.lblSponsorTime);
            this.panel1.Controls.Add(this.lblQuantity);
            this.panel1.Controls.Add(this.pbThumbnail);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 672);
            this.panel1.TabIndex = 8;
            // 
            // rtbDescription
            // 
            this.rtbDescription.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.rtbDescription.Location = new System.Drawing.Point(21, 311);
            this.rtbDescription.Name = "rtbDescription";
            this.rtbDescription.Size = new System.Drawing.Size(301, 338);
            this.rtbDescription.TabIndex = 22;
            this.rtbDescription.Text = "label1";
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblPrice.Location = new System.Drawing.Point(21, 242);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(99, 25);
            this.lblPrice.TabIndex = 19;
            this.lblPrice.Text = "NT$1299";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblName.Location = new System.Drawing.Point(21, 212);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(92, 25);
            this.lblName.TabIndex = 17;
            this.lblName.Text = "早鳥方案";
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.BackColor = System.Drawing.Color.IndianRed;
            this.lblQuantity.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblQuantity.ForeColor = System.Drawing.Color.White;
            this.lblQuantity.Location = new System.Drawing.Point(21, 272);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(106, 25);
            this.lblQuantity.TabIndex = 18;
            this.lblQuantity.Text = "剩餘 10 份";
            // 
            // pbThumbnail
            // 
            this.pbThumbnail.Dock = System.Windows.Forms.DockStyle.Top;
            this.pbThumbnail.Image = ((System.Drawing.Image)(resources.GetObject("pbThumbnail.Image")));
            this.pbThumbnail.Location = new System.Drawing.Point(0, 0);
            this.pbThumbnail.Margin = new System.Windows.Forms.Padding(0);
            this.pbThumbnail.Name = "pbThumbnail";
            this.pbThumbnail.Size = new System.Drawing.Size(345, 193);
            this.pbThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbThumbnail.TabIndex = 8;
            this.pbThumbnail.TabStop = false;
            // 
            // lblSponsorTime
            // 
            this.lblSponsorTime.AutoSize = true;
            this.lblSponsorTime.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblSponsorTime.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblSponsorTime.ForeColor = System.Drawing.Color.White;
            this.lblSponsorTime.Location = new System.Drawing.Point(133, 272);
            this.lblSponsorTime.Name = "lblSponsorTime";
            this.lblSponsorTime.Size = new System.Drawing.Size(136, 25);
            this.lblSponsorTime.TabIndex = 18;
            this.lblSponsorTime.Text = "已被贊助10次";
            // 
            // ProductCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.panel1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ProductCard";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Size = new System.Drawing.Size(351, 678);
            this.Load += new System.EventHandler(this.ProductCard_Load);
            this.Click += new System.EventHandler(this.ProductCard_Click);
            this.MouseEnter += new System.EventHandler(this.ProductCard_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.ProductCard_MouseLeave);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumbnail)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbThumbnail;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label rtbDescription;
        private System.Windows.Forms.Label lblSponsorTime;
    }
}
