namespace slnMumu_MidtermProject
{
    partial class FrmProposeProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmProposeProduct));
            this.lblPName = new ReaLTaiizor.Controls.CrownLabel();
            this.lblPPrice = new ReaLTaiizor.Controls.CrownLabel();
            this.lblPDesc = new ReaLTaiizor.Controls.CrownLabel();
            this.lblPQty = new ReaLTaiizor.Controls.CrownLabel();
            this.txtPName = new ReaLTaiizor.Controls.HopeTextBox();
            this.txtPPrice = new ReaLTaiizor.Controls.HopeTextBox();
            this.txtPQty = new ReaLTaiizor.Controls.HopeTextBox();
            this.dtPStart = new ReaLTaiizor.Controls.PoisonDateTime();
            this.lblPStart = new ReaLTaiizor.Controls.CrownLabel();
            this.lblPend = new ReaLTaiizor.Controls.CrownLabel();
            this.dtPEnd = new ReaLTaiizor.Controls.PoisonDateTime();
            this.hopePictureBox1 = new ReaLTaiizor.Controls.HopePictureBox();
            this.txtPDecs = new ReaLTaiizor.Controls.DungeonRichTextBox();
            this.materialButton1 = new ReaLTaiizor.Controls.MaterialButton();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnAdd = new ReaLTaiizor.Controls.SpaceButton();
            this.btnCancel = new ReaLTaiizor.Controls.SpaceButton();
            ((System.ComponentModel.ISupportInitialize)(this.hopePictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPName
            // 
            this.lblPName.AutoSize = true;
            this.lblPName.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblPName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lblPName.Location = new System.Drawing.Point(34, 31);
            this.lblPName.Name = "lblPName";
            this.lblPName.Size = new System.Drawing.Size(112, 25);
            this.lblPName.TabIndex = 0;
            this.lblPName.Text = "產品名稱：";
            // 
            // lblPPrice
            // 
            this.lblPPrice.AutoSize = true;
            this.lblPPrice.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblPPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lblPPrice.Location = new System.Drawing.Point(34, 95);
            this.lblPPrice.Name = "lblPPrice";
            this.lblPPrice.Size = new System.Drawing.Size(112, 25);
            this.lblPPrice.TabIndex = 1;
            this.lblPPrice.Text = "產品金額：";
            // 
            // lblPDesc
            // 
            this.lblPDesc.AutoSize = true;
            this.lblPDesc.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblPDesc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lblPDesc.Location = new System.Drawing.Point(34, 223);
            this.lblPDesc.Name = "lblPDesc";
            this.lblPDesc.Size = new System.Drawing.Size(112, 25);
            this.lblPDesc.TabIndex = 2;
            this.lblPDesc.Text = "產品描述：";
            // 
            // lblPQty
            // 
            this.lblPQty.AutoSize = true;
            this.lblPQty.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblPQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lblPQty.Location = new System.Drawing.Point(34, 159);
            this.lblPQty.Name = "lblPQty";
            this.lblPQty.Size = new System.Drawing.Size(112, 25);
            this.lblPQty.TabIndex = 3;
            this.lblPQty.Text = "產品數量：";
            // 
            // txtPName
            // 
            this.txtPName.BackColor = System.Drawing.Color.White;
            this.txtPName.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(66)))));
            this.txtPName.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(158)))), ((int)(((byte)(100)))));
            this.txtPName.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.txtPName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.txtPName.Hint = "請輸入產品名稱";
            this.txtPName.Location = new System.Drawing.Point(149, 31);
            this.txtPName.MaxLength = 32767;
            this.txtPName.Multiline = false;
            this.txtPName.Name = "txtPName";
            this.txtPName.PasswordChar = '\0';
            this.txtPName.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPName.SelectedText = "";
            this.txtPName.SelectionLength = 0;
            this.txtPName.SelectionStart = 0;
            this.txtPName.Size = new System.Drawing.Size(697, 43);
            this.txtPName.TabIndex = 4;
            this.txtPName.TabStop = false;
            this.txtPName.UseSystemPasswordChar = false;
            // 
            // txtPPrice
            // 
            this.txtPPrice.BackColor = System.Drawing.Color.White;
            this.txtPPrice.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(66)))));
            this.txtPPrice.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(158)))), ((int)(((byte)(100)))));
            this.txtPPrice.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.txtPPrice.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.txtPPrice.Hint = "請輸入數字";
            this.txtPPrice.Location = new System.Drawing.Point(149, 95);
            this.txtPPrice.MaxLength = 32767;
            this.txtPPrice.Multiline = false;
            this.txtPPrice.Name = "txtPPrice";
            this.txtPPrice.PasswordChar = '\0';
            this.txtPPrice.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPPrice.SelectedText = "";
            this.txtPPrice.SelectionLength = 0;
            this.txtPPrice.SelectionStart = 0;
            this.txtPPrice.Size = new System.Drawing.Size(143, 43);
            this.txtPPrice.TabIndex = 5;
            this.txtPPrice.TabStop = false;
            this.txtPPrice.UseSystemPasswordChar = false;
            // 
            // txtPQty
            // 
            this.txtPQty.BackColor = System.Drawing.Color.White;
            this.txtPQty.BaseColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(55)))), ((int)(((byte)(66)))));
            this.txtPQty.BorderColorA = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(158)))), ((int)(((byte)(100)))));
            this.txtPQty.BorderColorB = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(223)))), ((int)(((byte)(230)))));
            this.txtPQty.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtPQty.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(49)))), ((int)(((byte)(51)))));
            this.txtPQty.Hint = "請輸入數字";
            this.txtPQty.Location = new System.Drawing.Point(149, 159);
            this.txtPQty.MaxLength = 32767;
            this.txtPQty.Multiline = false;
            this.txtPQty.Name = "txtPQty";
            this.txtPQty.PasswordChar = '\0';
            this.txtPQty.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPQty.SelectedText = "";
            this.txtPQty.SelectionLength = 0;
            this.txtPQty.SelectionStart = 0;
            this.txtPQty.Size = new System.Drawing.Size(143, 43);
            this.txtPQty.TabIndex = 6;
            this.txtPQty.TabStop = false;
            this.txtPQty.UseSystemPasswordChar = false;
            // 
            // dtPStart
            // 
            this.dtPStart.Location = new System.Drawing.Point(416, 95);
            this.dtPStart.MinimumSize = new System.Drawing.Size(0, 30);
            this.dtPStart.Name = "dtPStart";
            this.dtPStart.Size = new System.Drawing.Size(140, 30);
            this.dtPStart.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Orange;
            this.dtPStart.TabIndex = 8;
            this.dtPStart.ValueChanged += new System.EventHandler(this.dtPStart_ValueChanged);
            // 
            // lblPStart
            // 
            this.lblPStart.AutoSize = true;
            this.lblPStart.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblPStart.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lblPStart.Location = new System.Drawing.Point(298, 95);
            this.lblPStart.Name = "lblPStart";
            this.lblPStart.Size = new System.Drawing.Size(112, 25);
            this.lblPStart.TabIndex = 9;
            this.lblPStart.Text = "開始日期：";
            // 
            // lblPend
            // 
            this.lblPend.AutoSize = true;
            this.lblPend.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblPend.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.lblPend.Location = new System.Drawing.Point(298, 159);
            this.lblPend.Name = "lblPend";
            this.lblPend.Size = new System.Drawing.Size(112, 25);
            this.lblPend.TabIndex = 10;
            this.lblPend.Text = "結束日期：";
            // 
            // dtPEnd
            // 
            this.dtPEnd.Location = new System.Drawing.Point(416, 154);
            this.dtPEnd.MinimumSize = new System.Drawing.Size(0, 30);
            this.dtPEnd.Name = "dtPEnd";
            this.dtPEnd.Size = new System.Drawing.Size(140, 30);
            this.dtPEnd.Style = ReaLTaiizor.Enum.Poison.ColorStyle.Orange;
            this.dtPEnd.TabIndex = 11;
            this.dtPEnd.ValueChanged += new System.EventHandler(this.dtPEnd_ValueChanged);
            // 
            // hopePictureBox1
            // 
            this.hopePictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(196)))), ((int)(((byte)(204)))));
            this.hopePictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("hopePictureBox1.Image")));
            this.hopePictureBox1.Location = new System.Drawing.Point(470, 267);
            this.hopePictureBox1.Name = "hopePictureBox1";
            this.hopePictureBox1.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            this.hopePictureBox1.Size = new System.Drawing.Size(376, 291);
            this.hopePictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.hopePictureBox1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            this.hopePictureBox1.TabIndex = 12;
            this.hopePictureBox1.TabStop = false;
            this.hopePictureBox1.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            this.hopePictureBox1.Click += new System.EventHandler(this.hopePictureBox1_Click);
            this.hopePictureBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.hopePictureBox1_DragDrop);
            this.hopePictureBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.hopePictureBox1_DragEnter);
            // 
            // dungeonRichTextBox1
            // 
            this.txtPDecs.AutoWordSelection = false;
            this.txtPDecs.BackColor = System.Drawing.Color.Transparent;
            this.txtPDecs.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.txtPDecs.EdgeColor = System.Drawing.Color.White;
            this.txtPDecs.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txtPDecs.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(76)))));
            this.txtPDecs.Location = new System.Drawing.Point(39, 267);
            this.txtPDecs.Name = "dungeonRichTextBox1";
            this.txtPDecs.ReadOnly = false;
            this.txtPDecs.Size = new System.Drawing.Size(414, 291);
            this.txtPDecs.TabIndex = 13;
            this.txtPDecs.TextBackColor = System.Drawing.Color.White;
            this.txtPDecs.WordWrap = true;
            // 
            // materialButton1
            // 
            this.materialButton1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialButton1.Density = ReaLTaiizor.Controls.MaterialButton.MaterialButtonDensity.Default;
            this.materialButton1.Depth = 0;
            this.materialButton1.HighEmphasis = true;
            this.materialButton1.Icon = null;
            this.materialButton1.IconType = ReaLTaiizor.Controls.MaterialButton.MaterialIconType.Rebase;
            this.materialButton1.Location = new System.Drawing.Point(766, 138);
            this.materialButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialButton1.MouseState = ReaLTaiizor.Helper.MaterialDrawHelper.MaterialMouseState.HOVER;
            this.materialButton1.Name = "materialButton1";
            this.materialButton1.NoAccentTextColor = System.Drawing.Color.Empty;
            this.materialButton1.Size = new System.Drawing.Size(64, 36);
            this.materialButton1.TabIndex = 14;
            this.materialButton1.Text = "爹摸";
            this.materialButton1.Type = ReaLTaiizor.Controls.MaterialButton.MaterialButtonType.Contained;
            this.materialButton1.UseAccentColor = false;
            this.materialButton1.UseVisualStyleBackColor = true;
            this.materialButton1.Click += new System.EventHandler(this.demo_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // btnAdd
            // 
            this.btnAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdd.Customization = "Kioq/zIyMv8yMjL/Kioq/y8vL/8nJyf//v7+/yMjI/8qKir/";
            this.btnAdd.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Image = null;
            this.btnAdd.Location = new System.Drawing.Point(635, 199);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.NoRounding = false;
            this.btnAdd.Size = new System.Drawing.Size(83, 49);
            this.btnAdd.TabIndex = 17;
            this.btnAdd.Text = "確定";
            this.btnAdd.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnAdd.Transparent = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Customization = "Kioq/zIyMv8yMjL/Kioq/y8vL/8nJyf//v7+/yMjI/8qKir/";
            this.btnCancel.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = null;
            this.btnCancel.Location = new System.Drawing.Point(747, 199);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NoRounding = false;
            this.btnCancel.Size = new System.Drawing.Size(83, 49);
            this.btnCancel.TabIndex = 18;
            this.btnCancel.Text = "取消";
            this.btnCancel.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.btnCancel.Transparent = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmProposeProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(858, 589);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.materialButton1);
            this.Controls.Add(this.txtPDecs);
            this.Controls.Add(this.hopePictureBox1);
            this.Controls.Add(this.dtPEnd);
            this.Controls.Add(this.lblPend);
            this.Controls.Add(this.lblPStart);
            this.Controls.Add(this.dtPStart);
            this.Controls.Add(this.txtPQty);
            this.Controls.Add(this.txtPPrice);
            this.Controls.Add(this.txtPName);
            this.Controls.Add(this.lblPQty);
            this.Controls.Add(this.lblPDesc);
            this.Controls.Add(this.lblPPrice);
            this.Controls.Add(this.lblPName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmProposeProduct";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmProposeProduct";
            ((System.ComponentModel.ISupportInitialize)(this.hopePictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ReaLTaiizor.Controls.CrownLabel lblPName;
        private ReaLTaiizor.Controls.CrownLabel lblPPrice;
        private ReaLTaiizor.Controls.CrownLabel lblPDesc;
        private ReaLTaiizor.Controls.CrownLabel lblPQty;
        private ReaLTaiizor.Controls.HopeTextBox txtPName;
        private ReaLTaiizor.Controls.HopeTextBox txtPPrice;
        private ReaLTaiizor.Controls.HopeTextBox txtPQty;
        private ReaLTaiizor.Controls.PoisonDateTime dtPStart;
        private ReaLTaiizor.Controls.CrownLabel lblPStart;
        private ReaLTaiizor.Controls.CrownLabel lblPend;
        private ReaLTaiizor.Controls.PoisonDateTime dtPEnd;
        private ReaLTaiizor.Controls.HopePictureBox hopePictureBox1;
        private ReaLTaiizor.Controls.DungeonRichTextBox txtPDecs;
        private ReaLTaiizor.Controls.MaterialButton materialButton1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private ReaLTaiizor.Controls.SpaceButton btnAdd;
        private ReaLTaiizor.Controls.SpaceButton btnCancel;
    }
}