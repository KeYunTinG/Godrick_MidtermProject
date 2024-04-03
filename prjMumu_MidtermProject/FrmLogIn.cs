using slnMumu_MidtermProject.Query;
using slnMumu_MidtermProject.Services;
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
    public partial class FrmLogIn : Form
    {
        public delegate void SetUserState();
        public event SetUserState setUserState;
        public delegate void RedirectHomepage(object sender, EventArgs e);
        public event RedirectHomepage setRedirectHomepage;
        public FrmProjectInfo frmProjectInfo;

        private CurrentUserManager cum;
        private QueryDB queryDB;

        private string saltString = "肉抱枕";



        public FrmLogIn()
        {
            InitializeComponent();
            cum = new CurrentUserManager();
            queryDB = new QueryDB();
        }
        public FrmLogIn(FrmProjectInfo form)
        {
            this.frmProjectInfo = form;
            InitializeComponent();
            cum = new CurrentUserManager();
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
    }
}
