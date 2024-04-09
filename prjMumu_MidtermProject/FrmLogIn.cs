using prjMumu_MidtermProject.Models;
using slnMumu_MidtermProject;
using slnMumu_MidtermProject.Query;
using slnMumu_MidtermProject.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjMumu_MidtermProject
{
    public partial class FrmLogIn : Form
    {
        public delegate void SetUserState();
        public event SetUserState setUserState;
        public delegate void RedirectHomepage(object sender, EventArgs e);
        public event RedirectHomepage setRedirectHomepage;
        public FrmProjectInfo frmProjectInfo;
        public PageBefore pb;

        private CurrentUserManager cum;
        private QueryDB queryDB;

        private string saltString = "肉抱枕";



        public FrmLogIn()
        {
            InitializeComponent();
            cum = new CurrentUserManager();
            pb = new PageBefore();
            queryDB = new QueryDB();
        }
        public FrmLogIn(FrmProjectInfo form)
        {
            this.frmProjectInfo = form;
            InitializeComponent();
            cum = new CurrentUserManager();
            pb = new PageBefore();
            queryDB = new QueryDB();
        }


        private void ShowErrorMsg(string msg)
        {
            lblErrorMsg.Visible = true;
            lblErrorMsg.Text = msg;
        }

        private async void button1_Click(object sender, EventArgs e)
        {

            Members member = await queryDB.FindMember(txtUsername.Text);

            if (member == null) { ShowErrorMsg("查無此帳號"); return; }

            bool isPasswordValid = Authenticator.VerifyPassword(txtPassword.Text, member.Password, saltString);

            if (!isPasswordValid) { ShowErrorMsg("密碼錯誤"); return; }

            cum.currentUser = txtUsername.Text;
            cum.isLogin = true;
            cum.member = member;

            FrmMyMessageBox myMessageBox = new FrmMyMessageBox();
            myMessageBox.msg = "登入成功";
            myMessageBox.ShowDialog();

            if (pb.page != null)
            {
                if (pb.page == "liked")
                {
                    (this.MdiParent as FrmHomepage).ClickButNotClick();
                    (this.MdiParent as FrmHomepage).btnLiked_Click(sender, e);
                    return;
                }

                if (pb.page == "profile")
                {
                    (this.MdiParent as FrmHomepage).ClickButNotClick();

                    (this.MdiParent as FrmHomepage).btnProfile_Click(sender, e);
                    return;
                }

                if (pb.page == "myProject")
                {
                    (this.MdiParent as FrmHomepage).ClickButNotClick();

                    (this.MdiParent as FrmHomepage).btnMyProject_Click(sender, e);
                    return;
                }
            }

            if (setUserState != null)
            {
                setUserState();
            }

            if (setRedirectHomepage != null)
            {
                setRedirectHomepage(sender, e);
            }
        }

        private void FrmLogIn_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "UserTest1234";
            txtPassword.Text = "UserTest1234";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "test123456";
            txtPassword.Text = "test123456";
        }
    }
}