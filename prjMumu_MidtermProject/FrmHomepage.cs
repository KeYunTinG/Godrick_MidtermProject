using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using prjMumu_MidtermProject;
using prjMumu_MidtermProject.Models;

namespace slnMumu_MidtermProject
{
    public partial class FrmHomepage : Form
    {
        public FrmHomepage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            pb = new PageBefore();
        }

        private PageBefore pb;
        private CurrentUserManager cum;
        public int windowWidth { get; private set; }
        public int windowHeight { get; private set; }

        #region Form
        private FrmProject project;
        private FrmProfile profile;
        private FrmLiked liked;
        private FrmMyProject myProject;
        private FrmSignUp signUp;
        private FrmLogIn logIn;
        private FrmAbout about;
        #endregion

        #region ControlButton
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMax_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion

        #region MoveWindow
        private bool canMove = false;
        private int currentPositionX;
        private int currentPositionY;

        private void pnControl_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                currentPositionX = 0;
                currentPositionY = 0;
                canMove = false;
            }
        }

        private void pnControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                canMove = true;
                currentPositionX = MousePosition.X;
                currentPositionY = MousePosition.Y;
            }
        }
        private void pnControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (canMove)
            {
                this.Left += MousePosition.X - currentPositionX;
                this.Top += MousePosition.Y - currentPositionY;
                currentPositionX = MousePosition.X;
                currentPositionY = MousePosition.Y;
            }
        }
        #endregion

        #region Transition
        private bool memberExpand = false;
        private bool sidebarExpand = true;

        private int pnMemberExpandHeight = 280;
        private int pnMemberCollapseHeight = 70;

        private int pnSidebarExpandWidth = 250;
        private int pnSideBarCollapseWidth = 75;

        private void memberTransition_Tick(object sender, EventArgs e)
        {
            if (!memberExpand)
            {
                pnMember.Height += 10;

                if (pnMember.Height >= pnMemberExpandHeight)
                {
                    memberTransition.Stop();
                    memberExpand = true;
                }
            }
            else
            {
                pnMember.Height -= 10;

                if (pnMember.Height <= pnMemberCollapseHeight)
                {
                    memberTransition.Stop();
                    memberExpand = false;
                }
            }
        }

        private void btnMember_Click(object sender, EventArgs e)
        {
            memberTransition.Start();
            pnCurrentPage.Location = new Point(0, 242);
        }



        private void sidebarTransition_Tick(object sender, EventArgs e)
        {
            if (sidebarExpand)
            {
                pnSidebar.Width -= 10;

                if (pnSidebar.Width <= pnSideBarCollapseWidth)
                {
                    sidebarExpand = false;
                    sidebarTransition.Stop();

                    picLogo.Image = imageList1.Images[0];
                    picLogo.Size = new Size(75, 100);
                    picLogo.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
            else
            {
                pnSidebar.Width += 10;

                if (pnSidebar.Width >= pnSidebarExpandWidth)
                {
                    sidebarExpand = true;
                    sidebarTransition.Stop();

                    picLogo.Image = imageList1.Images[1];
                    picLogo.Size = new Size(250, 100);
                    picLogo.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }
        }
        private void btnNav_Click(object sender, EventArgs e)
        {
            sidebarTransition.Start();
        }

        #endregion

        private void Homepage_Load(object sender, EventArgs e)
        {
            cum = new CurrentUserManager();

            project = new FrmProject();
            project.FormClosed += Project_FormClosed;
            project.MdiParent = this;
            project.Dock = DockStyle.Fill;
            project.Show();

            btnLogOut.Visible = false;
        }

        private void btnHomepage_Click(object sender, EventArgs e)
        {
            pnCurrentPage.Location = new Point(0, 160);

            if (cum.isLogin)
            {
                btnLogOut.Visible = true;
                btnLogIn.Visible = false;
                btnSignUp.Visible = false;
            }
            else
            {
                btnLogOut.Visible = false;
                btnLogIn.Visible = true;
                btnSignUp.Visible = true;
            }

            if (project == null)
            {
                project = new FrmProject();
                project.FormClosed += Project_FormClosed;
                project.MdiParent = this;
                project.Dock = DockStyle.Fill;
                project.Show();
            }
            else
            {
                project.Activate();
            }
        }

        private void Project_FormClosed(object sender, FormClosedEventArgs e)
        {
            project = null;
        }

        public void btnProfile_Click(object sender, EventArgs e)
        {
            pnCurrentPage.Location = new Point(0, 312);



            if (!cum.isLogin)
            {
                pb.page = "profile";
                btnLogIn_Click(sender, e);
                FrmMyMessageBox myMessageBox = new FrmMyMessageBox();
                myMessageBox.msg = "請先登入";
                myMessageBox.ShowDialog();
                return;
            }

            if (profile == null)
            {
                profile = new FrmProfile();
                profile.FormClosed += Profile_FormClosed;
                profile.MdiParent = this;
                profile.Dock = DockStyle.Fill;
                profile.Show();
            }
            else
            {
                profile.Activate();
            }

        }

        private void Profile_FormClosed(object sender, FormClosedEventArgs e)
        {
            profile = null;
        }

        public void btnLiked_Click(object sender, EventArgs e)
        {
            pnCurrentPage.Location = new Point(0, 382);

            if (!cum.isLogin)
            {
                pb.page = "liked";
                btnLogIn_Click(sender, e);
                FrmMyMessageBox myMessageBox = new FrmMyMessageBox();
                myMessageBox.msg = "請先登入";
                myMessageBox.ShowDialog(); return;
            }

            if (liked == null)
            {
                liked = new FrmLiked(cum.member.MemberID);
                liked.FormClosed += Liked_FormClosed;
                liked.MdiParent = this;
                liked.Dock = DockStyle.Fill;
                liked.Show();
            }
            else
            {
                liked.Activate();
            }
        }

        private void Liked_FormClosed(object sender, FormClosedEventArgs e)
        {
            liked = null;
        }

        public void btnMyProject_Click(object sender, EventArgs e)
        {
            pnCurrentPage.Location = new Point(0, 452);

            if (!cum.isLogin)
            {
                pb.page = "myProject";
                btnLogIn_Click(sender, e);
                FrmMyMessageBox myMessageBox = new FrmMyMessageBox();
                myMessageBox.msg = "請先登入";
                myMessageBox.ShowDialog();
                return;
            }

            if (myProject == null)
            {
                myProject = new FrmMyProject();
                myProject.FormClosed += MyProject_FormClosed;
                myProject.MdiParent = this;
                myProject.Dock = DockStyle.Fill;
                myProject.Show();
            }
            else
            {
                myProject.Activate();
            }
        }

        private void MyProject_FormClosed(object sender, FormClosedEventArgs e)
        {
            myProject = null;
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            if (memberExpand)
            {
                pnCurrentPage.Location = new Point(0, 534);
            }
            else
            {
                pnCurrentPage.Location = new Point(0, 324);
            }

            if (signUp == null)
            {
                signUp = new FrmSignUp();
                signUp.FormClosed += SignUp_FormClosed;
                signUp.MdiParent = this;
                signUp.Dock = DockStyle.Fill;
                signUp.Show();
            }
            else
            {
                signUp.Activate();
            }

            signUp.setRedirectHomepage += this.btnHomepage_Click;
        }

        private void SignUp_FormClosed(object sender, FormClosedEventArgs e)
        {
            signUp = null;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            if (memberExpand)
            {
                pnCurrentPage.Location = new Point(0, 628);
            }
            else
            {
                pnCurrentPage.Location = new Point(0, 418);
            }

            if (logIn == null)
            {
                logIn = new FrmLogIn();
                logIn.FormClosed += LogIn_FormClosed;
                logIn.MdiParent = this;
                logIn.Dock = DockStyle.Fill;
                logIn.Show();
            }
            else
            {
                logIn.Activate();
            }

            logIn.setUserState += this.SetLoginState;
            logIn.setRedirectHomepage += this.btnHomepage_Click;
        }

        private void LogIn_FormClosed(object sender, FormClosedEventArgs e)
        {
            logIn = null;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (memberExpand)
            {
                pnCurrentPage.Location = new Point(0, 534);
            }
            else
            {
                pnCurrentPage.Location = new Point(0, 324);
            }

            cum.currentUser = null;
            cum.isLogin = false;

            while (this.ActiveMdiChild != null)
            {
                this.ActiveMdiChild.Close();
            }

            btnSignUp.Visible = true;
            btnLogIn.Visible = true;
            btnLogOut.Visible = false;

            btnHomepage_Click(sender, e);
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            if (!cum.isLogin)
            {
                if (memberExpand)
                {
                    pnCurrentPage.Location = new Point(0, 722);
                }
                else
                {
                    pnCurrentPage.Location = new Point(0, 512);
                }
            }
            else
            {
                if (memberExpand)
                {
                    pnCurrentPage.Location = new Point(0, 628);
                }
                else
                {
                    pnCurrentPage.Location = new Point(0, 418);
                }
            }

            if (about == null)
            {
                about = new FrmAbout();
                about.FormClosed += About_FormClosed;
                about.MdiParent = this;
                about.Dock = DockStyle.Fill;
                about.Show();
            }
            else
            {
                about.Activate();
            }
        }

        private void About_FormClosed(object sender, FormClosedEventArgs e)
        {
            about = null;
        }

        private void SetLoginState()
        {
            cum.isLogin = true;
        }

        private void FrmHomepage_Resize(object sender, EventArgs e)
        {
        }
        public void Click()
        {
            pnCurrentPage.Location = new Point(0, 160);

            if (cum.isLogin)
            {
                btnLogOut.Visible = true;
                btnLogIn.Visible = false;
                btnSignUp.Visible = false;
            }
            else
            {
                btnLogOut.Visible = false;
                btnLogIn.Visible = true;
                btnSignUp.Visible = true;
            }

            //if (memberExpand)
            //{
            //    pnCurrentPage.Location = new Point(0, 628);
            //}
            //else
            //{
            //    pnCurrentPage.Location = new Point(0, 418);
            //}

            //if (logIn == null)
            //{
            //    logIn = new FrmLogIn();
            //    logIn.FormClosed += LogIn_FormClosed;
            //    logIn.MdiParent = this;
            //    logIn.Dock = DockStyle.Fill;
            //    logIn.Show();
            //}
            //else
            //{
            //    logIn.Activate();
            //}
        }
        public void button1_Click(object sender, EventArgs e)
        {
            if (cum.isLogin)
            {
                btnLogOut.Visible = true;
                btnLogIn.Visible = false;
                btnSignUp.Visible = false;
            }
            else
            {
                btnLogOut.Visible = false;
                btnLogIn.Visible = true;
                btnSignUp.Visible = true;
            }

            if (memberExpand)
            {
                pnCurrentPage.Location = new Point(0, 628);
            }
            else
            {
                pnCurrentPage.Location = new Point(0, 418);
            }

            if (logIn == null)
            {
                logIn = new FrmLogIn();
                logIn.FormClosed += LogIn_FormClosed;
                logIn.MdiParent = this;
                logIn.Dock = DockStyle.Fill;
                logIn.Show();
            }
            else
            {
                logIn.Activate();
            }
        }

        private void 登出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!cum.isLogin) return;

            btnLogOut_Click(sender, e);
        }

        private void 離開ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
