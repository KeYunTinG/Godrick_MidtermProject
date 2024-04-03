namespace slnMumu_MidtermProject
{
    partial class FrmMyProject
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
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanelMyProject = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(32, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 76);
            this.label1.TabIndex = 5;
            this.label1.Text = "我的專案";
            // 
            // flowLayoutPanelMyProject
            // 
            this.flowLayoutPanelMyProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanelMyProject.AutoScroll = true;
            this.flowLayoutPanelMyProject.Location = new System.Drawing.Point(37, 52);
            this.flowLayoutPanelMyProject.Margin = new System.Windows.Forms.Padding(4);
            this.flowLayoutPanelMyProject.Name = "flowLayoutPanelMyProject";
            this.flowLayoutPanelMyProject.Size = new System.Drawing.Size(1697, 589);
            this.flowLayoutPanelMyProject.TabIndex = 7;
            this.flowLayoutPanelMyProject.WrapContents = false;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(1294, 650);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(187, 59);
            this.button1.TabIndex = 8;
            this.button1.Text = "新增專案";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(548, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 76);
            this.label2.TabIndex = 6;
            this.label2.Visible = false;
            // 
            // FrmMyProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1800, 722);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowLayoutPanelMyProject);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmMyProject";
            this.Text = "FrmMyProject";
            this.Activated += new System.EventHandler(this.FrmMyProject_Activated);
            this.Load += new System.EventHandler(this.FrmMyProject_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelMyProject;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
    }
}