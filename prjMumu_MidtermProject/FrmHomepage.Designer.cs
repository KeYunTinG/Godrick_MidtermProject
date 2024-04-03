namespace slnMumu_MidtermProject
{
    partial class FrmHomepage
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

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHomepage));
            this.pnControl = new System.Windows.Forms.Panel();
            this.btnNav = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnMin = new System.Windows.Forms.Button();
            this.btnMax = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnSidebar = new System.Windows.Forms.FlowLayoutPanel();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.btnHomepage = new System.Windows.Forms.Button();
            this.pnMember = new System.Windows.Forms.Panel();
            this.btnMyProject = new System.Windows.Forms.Button();
            this.btnLiked = new System.Windows.Forms.Button();
            this.btnProfile = new System.Windows.Forms.Button();
            this.btnMember = new System.Windows.Forms.Button();
            this.btnSignUp = new System.Windows.Forms.Button();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnAbout = new System.Windows.Forms.Button();
            this.memberTransition = new System.Windows.Forms.Timer(this.components);
            this.sidebarTransition = new System.Windows.Forms.Timer(this.components);
            this.pnCurrentPage = new System.Windows.Forms.Panel();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.重新整理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.登出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.離開ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnControl.SuspendLayout();
            this.pnSidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pnMember.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnControl
            // 
            this.pnControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.pnControl.Controls.Add(this.btnNav);
            this.pnControl.Controls.Add(this.lblTitle);
            this.pnControl.Controls.Add(this.btnMin);
            this.pnControl.Controls.Add(this.btnMax);
            this.pnControl.Controls.Add(this.btnClose);
            this.pnControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnControl.Location = new System.Drawing.Point(0, 0);
            this.pnControl.Margin = new System.Windows.Forms.Padding(0);
            this.pnControl.Name = "pnControl";
            this.pnControl.Size = new System.Drawing.Size(1600, 48);
            this.pnControl.TabIndex = 0;
            this.pnControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnControl_MouseDown);
            this.pnControl.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnControl_MouseMove);
            this.pnControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pnControl_MouseUp);
            // 
            // btnNav
            // 
            this.btnNav.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(13)))), ((int)(((byte)(13)))));
            this.btnNav.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNav.FlatAppearance.BorderSize = 0;
            this.btnNav.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNav.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnNav.Image = ((System.Drawing.Image)(resources.GetObject("btnNav.Image")));
            this.btnNav.Location = new System.Drawing.Point(0, 0);
            this.btnNav.Margin = new System.Windows.Forms.Padding(0);
            this.btnNav.Name = "btnNav";
            this.btnNav.Size = new System.Drawing.Size(48, 48);
            this.btnNav.TabIndex = 4;
            this.btnNav.UseVisualStyleBackColor = false;
            this.btnNav.Click += new System.EventHandler(this.btnNav_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Impact", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.Color.AliceBlue;
            this.lblTitle.Location = new System.Drawing.Point(63, 5);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(323, 37);
            this.lblTitle.TabIndex = 3;
            this.lblTitle.Text = "   MUMU | Midterm Project";
            // 
            // btnMin
            // 
            this.btnMin.BackColor = System.Drawing.Color.Gray;
            this.btnMin.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMin.FlatAppearance.BorderSize = 0;
            this.btnMin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMin.Image = ((System.Drawing.Image)(resources.GetObject("btnMin.Image")));
            this.btnMin.Location = new System.Drawing.Point(1456, 0);
            this.btnMin.Margin = new System.Windows.Forms.Padding(0);
            this.btnMin.Name = "btnMin";
            this.btnMin.Size = new System.Drawing.Size(48, 48);
            this.btnMin.TabIndex = 2;
            this.btnMin.UseVisualStyleBackColor = false;
            this.btnMin.Click += new System.EventHandler(this.btnMin_Click);
            // 
            // btnMax
            // 
            this.btnMax.BackColor = System.Drawing.Color.Gray;
            this.btnMax.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMax.FlatAppearance.BorderSize = 0;
            this.btnMax.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMax.Image = ((System.Drawing.Image)(resources.GetObject("btnMax.Image")));
            this.btnMax.Location = new System.Drawing.Point(1504, 0);
            this.btnMax.Margin = new System.Windows.Forms.Padding(0);
            this.btnMax.Name = "btnMax";
            this.btnMax.Size = new System.Drawing.Size(48, 48);
            this.btnMax.TabIndex = 1;
            this.btnMax.UseVisualStyleBackColor = false;
            this.btnMax.Click += new System.EventHandler(this.btnMax_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(35)))), ((int)(((byte)(35)))));
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(1552, 0);
            this.btnClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(48, 48);
            this.btnClose.TabIndex = 0;
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnSidebar
            // 
            this.pnSidebar.BackColor = System.Drawing.Color.DarkRed;
            this.pnSidebar.Controls.Add(this.picLogo);
            this.pnSidebar.Controls.Add(this.btnHomepage);
            this.pnSidebar.Controls.Add(this.pnMember);
            this.pnSidebar.Controls.Add(this.btnSignUp);
            this.pnSidebar.Controls.Add(this.btnLogIn);
            this.pnSidebar.Controls.Add(this.btnLogOut);
            this.pnSidebar.Controls.Add(this.btnAbout);
            this.pnSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnSidebar.Location = new System.Drawing.Point(0, 48);
            this.pnSidebar.Margin = new System.Windows.Forms.Padding(0);
            this.pnSidebar.Name = "pnSidebar";
            this.pnSidebar.Size = new System.Drawing.Size(250, 852);
            this.pnSidebar.TabIndex = 5;
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Image)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(0, 0);
            this.picLogo.Margin = new System.Windows.Forms.Padding(0);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(250, 100);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 6;
            this.picLogo.TabStop = false;
            // 
            // btnHomepage
            // 
            this.btnHomepage.BackColor = System.Drawing.Color.DarkRed;
            this.btnHomepage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHomepage.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHomepage.FlatAppearance.BorderSize = 0;
            this.btnHomepage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHomepage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHomepage.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnHomepage.Image = ((System.Drawing.Image)(resources.GetObject("btnHomepage.Image")));
            this.btnHomepage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHomepage.Location = new System.Drawing.Point(0, 112);
            this.btnHomepage.Margin = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.btnHomepage.Name = "btnHomepage";
            this.btnHomepage.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnHomepage.Size = new System.Drawing.Size(250, 70);
            this.btnHomepage.TabIndex = 0;
            this.btnHomepage.Text = "  Homepage";
            this.btnHomepage.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnHomepage.UseVisualStyleBackColor = false;
            this.btnHomepage.Click += new System.EventHandler(this.btnHomepage_Click);
            // 
            // pnMember
            // 
            this.pnMember.BackColor = System.Drawing.Color.Maroon;
            this.pnMember.Controls.Add(this.btnMyProject);
            this.pnMember.Controls.Add(this.btnLiked);
            this.pnMember.Controls.Add(this.btnProfile);
            this.pnMember.Controls.Add(this.btnMember);
            this.pnMember.Location = new System.Drawing.Point(0, 194);
            this.pnMember.Margin = new System.Windows.Forms.Padding(0);
            this.pnMember.Name = "pnMember";
            this.pnMember.Size = new System.Drawing.Size(250, 70);
            this.pnMember.TabIndex = 6;
            // 
            // btnMyProject
            // 
            this.btnMyProject.BackColor = System.Drawing.Color.Maroon;
            this.btnMyProject.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMyProject.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMyProject.FlatAppearance.BorderSize = 0;
            this.btnMyProject.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMyProject.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMyProject.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnMyProject.Image = ((System.Drawing.Image)(resources.GetObject("btnMyProject.Image")));
            this.btnMyProject.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMyProject.Location = new System.Drawing.Point(0, 210);
            this.btnMyProject.Margin = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.btnMyProject.Name = "btnMyProject";
            this.btnMyProject.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMyProject.Size = new System.Drawing.Size(250, 70);
            this.btnMyProject.TabIndex = 10;
            this.btnMyProject.Text = "   My Project";
            this.btnMyProject.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMyProject.UseVisualStyleBackColor = false;
            this.btnMyProject.Click += new System.EventHandler(this.btnMyProject_Click);
            // 
            // btnLiked
            // 
            this.btnLiked.BackColor = System.Drawing.Color.Maroon;
            this.btnLiked.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLiked.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLiked.FlatAppearance.BorderSize = 0;
            this.btnLiked.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLiked.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLiked.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnLiked.Image = ((System.Drawing.Image)(resources.GetObject("btnLiked.Image")));
            this.btnLiked.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLiked.Location = new System.Drawing.Point(0, 140);
            this.btnLiked.Margin = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.btnLiked.Name = "btnLiked";
            this.btnLiked.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnLiked.Size = new System.Drawing.Size(250, 70);
            this.btnLiked.TabIndex = 9;
            this.btnLiked.Text = "   Liked";
            this.btnLiked.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLiked.UseVisualStyleBackColor = false;
            this.btnLiked.Click += new System.EventHandler(this.btnLiked_Click);
            // 
            // btnProfile
            // 
            this.btnProfile.BackColor = System.Drawing.Color.Maroon;
            this.btnProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProfile.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnProfile.FlatAppearance.BorderSize = 0;
            this.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfile.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnProfile.Image = ((System.Drawing.Image)(resources.GetObject("btnProfile.Image")));
            this.btnProfile.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProfile.Location = new System.Drawing.Point(0, 70);
            this.btnProfile.Margin = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.btnProfile.Name = "btnProfile";
            this.btnProfile.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnProfile.Size = new System.Drawing.Size(250, 70);
            this.btnProfile.TabIndex = 8;
            this.btnProfile.Text = "   Profile";
            this.btnProfile.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnProfile.UseVisualStyleBackColor = false;
            this.btnProfile.Click += new System.EventHandler(this.btnProfile_Click);
            // 
            // btnMember
            // 
            this.btnMember.BackColor = System.Drawing.Color.DarkRed;
            this.btnMember.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMember.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMember.FlatAppearance.BorderSize = 0;
            this.btnMember.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMember.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMember.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnMember.Image = ((System.Drawing.Image)(resources.GetObject("btnMember.Image")));
            this.btnMember.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMember.Location = new System.Drawing.Point(0, 0);
            this.btnMember.Margin = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.btnMember.Name = "btnMember";
            this.btnMember.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnMember.Size = new System.Drawing.Size(250, 70);
            this.btnMember.TabIndex = 7;
            this.btnMember.Text = "   Member";
            this.btnMember.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnMember.UseVisualStyleBackColor = false;
            this.btnMember.Click += new System.EventHandler(this.btnMember_Click);
            // 
            // btnSignUp
            // 
            this.btnSignUp.BackColor = System.Drawing.Color.DarkRed;
            this.btnSignUp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSignUp.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSignUp.FlatAppearance.BorderSize = 0;
            this.btnSignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSignUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSignUp.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnSignUp.Image = ((System.Drawing.Image)(resources.GetObject("btnSignUp.Image")));
            this.btnSignUp.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSignUp.Location = new System.Drawing.Point(0, 276);
            this.btnSignUp.Margin = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.btnSignUp.Name = "btnSignUp";
            this.btnSignUp.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnSignUp.Size = new System.Drawing.Size(250, 70);
            this.btnSignUp.TabIndex = 8;
            this.btnSignUp.Text = "   Sign Up";
            this.btnSignUp.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSignUp.UseVisualStyleBackColor = false;
            this.btnSignUp.Click += new System.EventHandler(this.btnSignUp_Click);
            // 
            // btnLogIn
            // 
            this.btnLogIn.BackColor = System.Drawing.Color.DarkRed;
            this.btnLogIn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogIn.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLogIn.FlatAppearance.BorderSize = 0;
            this.btnLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogIn.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnLogIn.Image = ((System.Drawing.Image)(resources.GetObject("btnLogIn.Image")));
            this.btnLogIn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogIn.Location = new System.Drawing.Point(0, 370);
            this.btnLogIn.Margin = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnLogIn.Size = new System.Drawing.Size(250, 70);
            this.btnLogIn.TabIndex = 7;
            this.btnLogIn.Text = "   Log In";
            this.btnLogIn.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogIn.UseVisualStyleBackColor = false;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.DarkRed;
            this.btnLogOut.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogOut.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnLogOut.FlatAppearance.BorderSize = 0;
            this.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnLogOut.Image = ((System.Drawing.Image)(resources.GetObject("btnLogOut.Image")));
            this.btnLogOut.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLogOut.Location = new System.Drawing.Point(0, 464);
            this.btnLogOut.Margin = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnLogOut.Size = new System.Drawing.Size(250, 70);
            this.btnLogOut.TabIndex = 9;
            this.btnLogOut.Text = "   Log Out";
            this.btnLogOut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.BackColor = System.Drawing.Color.DarkRed;
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbout.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAbout.FlatAppearance.BorderSize = 0;
            this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbout.ForeColor = System.Drawing.Color.AliceBlue;
            this.btnAbout.Image = ((System.Drawing.Image)(resources.GetObject("btnAbout.Image")));
            this.btnAbout.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAbout.Location = new System.Drawing.Point(0, 558);
            this.btnAbout.Margin = new System.Windows.Forms.Padding(0, 12, 0, 12);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnAbout.Size = new System.Drawing.Size(250, 70);
            this.btnAbout.TabIndex = 10;
            this.btnAbout.Text = "   About";
            this.btnAbout.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAbout.UseVisualStyleBackColor = false;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // memberTransition
            // 
            this.memberTransition.Interval = 10;
            this.memberTransition.Tick += new System.EventHandler(this.memberTransition_Tick);
            // 
            // sidebarTransition
            // 
            this.sidebarTransition.Interval = 10;
            this.sidebarTransition.Tick += new System.EventHandler(this.sidebarTransition_Tick);
            // 
            // pnCurrentPage
            // 
            this.pnCurrentPage.BackColor = System.Drawing.Color.White;
            this.pnCurrentPage.Location = new System.Drawing.Point(0, 160);
            this.pnCurrentPage.Margin = new System.Windows.Forms.Padding(0);
            this.pnCurrentPage.Name = "pnCurrentPage";
            this.pnCurrentPage.Size = new System.Drawing.Size(5, 70);
            this.pnCurrentPage.TabIndex = 6;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Dragon Quest.png");
            this.imageList1.Images.SetKeyName(1, "dragon.png");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.重新整理ToolStripMenuItem,
            this.toolStripMenuItem1,
            this.登出ToolStripMenuItem,
            this.離開ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(139, 82);
            // 
            // 重新整理ToolStripMenuItem
            // 
            this.重新整理ToolStripMenuItem.Name = "重新整理ToolStripMenuItem";
            this.重新整理ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.重新整理ToolStripMenuItem.Text = "重新整理";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(135, 6);
            // 
            // 登出ToolStripMenuItem
            // 
            this.登出ToolStripMenuItem.Name = "登出ToolStripMenuItem";
            this.登出ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.登出ToolStripMenuItem.Text = "登出";
            this.登出ToolStripMenuItem.Click += new System.EventHandler(this.登出ToolStripMenuItem_Click);
            // 
            // 離開ToolStripMenuItem
            // 
            this.離開ToolStripMenuItem.Name = "離開ToolStripMenuItem";
            this.離開ToolStripMenuItem.Size = new System.Drawing.Size(138, 24);
            this.離開ToolStripMenuItem.Text = "離開";
            this.離開ToolStripMenuItem.Click += new System.EventHandler(this.離開ToolStripMenuItem_Click);
            // 
            // FrmHomepage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 900);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.pnCurrentPage);
            this.Controls.Add(this.pnSidebar);
            this.Controls.Add(this.pnControl);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmHomepage";
            this.Text = "Homepage";
            this.Load += new System.EventHandler(this.Homepage_Load);
            this.Resize += new System.EventHandler(this.FrmHomepage_Resize);
            this.pnControl.ResumeLayout(false);
            this.pnControl.PerformLayout();
            this.pnSidebar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pnMember.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnControl;
        private System.Windows.Forms.Button btnMin;
        private System.Windows.Forms.Button btnMax;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnNav;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.FlowLayoutPanel pnSidebar;
        private System.Windows.Forms.Button btnHomepage;
        private System.Windows.Forms.Panel pnMember;
        private System.Windows.Forms.Button btnLiked;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Button btnMember;
        private System.Windows.Forms.Button btnMyProject;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.Button btnSignUp;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Timer memberTransition;
        private System.Windows.Forms.Timer sidebarTransition;
        private System.Windows.Forms.Panel pnCurrentPage;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 重新整理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 登出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 離開ToolStripMenuItem;
    }
}

