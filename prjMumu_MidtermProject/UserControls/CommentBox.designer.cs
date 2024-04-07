namespace slnMumu_MidtermProject
{
    partial class CommentBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CommentBox));
            this.pbThumbnail = new System.Windows.Forms.PictureBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCommentTime = new System.Windows.Forms.Label();
            this.lblMessage = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbThumbnail)).BeginInit();
            this.SuspendLayout();
            // 
            // pbThumbnail
            // 
            this.pbThumbnail.BackColor = System.Drawing.SystemColors.Control;
            this.pbThumbnail.Dock = System.Windows.Forms.DockStyle.Left;
            this.pbThumbnail.Image = ((System.Drawing.Image)(resources.GetObject("pbThumbnail.Image")));
            this.pbThumbnail.Location = new System.Drawing.Point(0, 0);
            this.pbThumbnail.Name = "pbThumbnail";
            this.pbThumbnail.Size = new System.Drawing.Size(84, 79);
            this.pbThumbnail.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbThumbnail.TabIndex = 0;
            this.pbThumbnail.TabStop = false;
            // 
            // lblName
            // 
            this.lblName.BackColor = System.Drawing.Color.Transparent;
            this.lblName.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblName.Location = new System.Drawing.Point(88, 4);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(151, 36);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "王大明";
            // 
            // lblCommentTime
            // 
            this.lblCommentTime.Font = new System.Drawing.Font("微軟正黑體", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblCommentTime.Location = new System.Drawing.Point(313, 4);
            this.lblCommentTime.Name = "lblCommentTime";
            this.lblCommentTime.Size = new System.Drawing.Size(61, 21);
            this.lblCommentTime.TabIndex = 3;
            this.lblCommentTime.Text = "16天前";
            this.lblCommentTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblMessage
            // 
            this.lblMessage.Font = new System.Drawing.Font("微軟正黑體", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.lblMessage.Location = new System.Drawing.Point(89, 25);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(244, 52);
            this.lblMessage.TabIndex = 4;
            this.lblMessage.Text = "請問早鳥";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(337, 30);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(37, 15);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "回覆";
            this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // CommentBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblCommentTime);
            this.Controls.Add(this.pbThumbnail);
            this.Name = "CommentBox";
            this.Size = new System.Drawing.Size(379, 79);
            ((System.ComponentModel.ISupportInitialize)(this.pbThumbnail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbThumbnail;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCommentTime;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}
