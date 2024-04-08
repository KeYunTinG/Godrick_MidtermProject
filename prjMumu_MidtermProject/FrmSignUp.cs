using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;
using slnMumu_MidtermProject.Services;
using System.Text.RegularExpressions;
using slnMumu_MidtermProject.Query;
using prjMumu_MidtermProject;
using prjMumu_MidtermProject.Models;

namespace slnMumu_MidtermProject
{
    public partial class FrmSignUp : Form
    {
        public delegate void RedirectHomepage(object sender, EventArgs e);
        public event RedirectHomepage setRedirectHomepage;

        private string saltString = "肉抱枕";

        private ZecZecEntities db;
        private QueryDB queryDB;
        private PageBefore pb;


        public FrmSignUp()
        {
            InitializeComponent();
            db = new ZecZecEntities();
            queryDB = new QueryDB();
            pb = new PageBefore();
        }

        private void FrmSignUp_Load(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';
        }

        private async Task<bool> SignUpValidate()
        {
            #region Username
            if (string.IsNullOrWhiteSpace(txtUsername.Text)) { ShowErrorMsg("帳號不可空白"); return false; }

            //Members member = db.Members.FirstOrDefault(x => x.Username == txtUsername.Text);

            Members foundMember = await queryDB.FindMember(txtUsername.Text);

            if (foundMember != null) { ShowErrorMsg("帳號重複"); return false; }

            if (txtUsername.Text.Length < 8) { ShowErrorMsg("帳號不可少於8字"); return false; }
            if (txtUsername.Text.Length > 14) { ShowErrorMsg("帳號不可超過14字"); return false; }

            if (!IsEnAndNumbers(txtUsername.Text)) { ShowErrorMsg("帳號只可為英文或數字"); return false; }
            #endregion

            #region Password
            if (string.IsNullOrWhiteSpace(txtPassword.Text)) { ShowErrorMsg("密碼不可空白"); return false; }

            if (txtPassword.Text.Length < 8) { ShowErrorMsg("密碼不可少於8字"); return false; }
            if (txtPassword.Text.Length > 14) { ShowErrorMsg("密碼不可超過14字"); return false; }

            if (!IsEnAndNumbers(txtPassword.Text)) { ShowErrorMsg("密碼只可為英文或數字"); return false; }

            if (string.IsNullOrWhiteSpace(txtConfirmPassword.Text)) { ShowErrorMsg("確認密碼不可空白"); return false; }

            if (txtPassword.Text != txtConfirmPassword.Text) { ShowErrorMsg("確認密碼與密碼有異"); return false; }
            #endregion

            #region Email
            if (string.IsNullOrWhiteSpace(txtEmail.Text)) { ShowErrorMsg("Email不可空白"); return false; }

            if (txtEmail.Text.Length > 100) { ShowErrorMsg("Email不可超過100字"); return false; }

            if (!txtEmail.Text.Contains("@")) { ShowErrorMsg("Email格式錯誤"); return false; }

            if (!IsEnAndNumbersForEmail(txtEmail.Text)) { ShowErrorMsg("Email只可為英文或數字"); return false; }
            #endregion

            #region Address
            if (string.IsNullOrWhiteSpace(txtAddress.Text)) { ShowErrorMsg("地址不可空白"); return false; }

            if (txtAddress.Text.Length > 100) { ShowErrorMsg("地址不可超過100字"); return false; }
            #endregion


            return true;
        }

        private bool IsEnAndNumbers(string input)
        {
            bool isValid = Regex.IsMatch(input, @"^[A-Za-z0-9]+$");

            if (isValid)
            {
                return isValid;
            }
            else
            {
                return isValid;
            }
        }

        private bool IsEnAndNumbersForEmail(string input)
        {
            bool isValid = Regex.IsMatch(input, @"^[A-Za-z0-9@.]+$");

            if (isValid)
            {
                return isValid;
            }
            else
            {
                return isValid;
            }
        }

        private void ShowErrorMsg(string msg)
        {
            lblErrorMsg.Visible = true;
            lblErrorMsg.Text = msg;
        }

        private async void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                bool isValidate = await SignUpValidate();

                if (!isValidate) return;

                Members member = new Members();

                member.Username = txtUsername.Text;

                string hashedPassword = Authenticator.HashPasswordWithSalt(txtPassword.Text, saltString);
                member.Password = hashedPassword;

                member.Nickname = txtNickname.Text;
                member.Email = txtEmail.Text;
                member.Address = txtAddress.Text;
                member.CreateTime = DateTime.Now;

                db.Members.Add(member);
                db.SaveChanges();

                FrmMyMessageBox myMessageBox = new FrmMyMessageBox();
                myMessageBox.msg = "註冊成功，將為您導向至首頁";
                myMessageBox.ShowDialog();

                txtUsername.Text = "";
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
                txtNickname.Text = "";
                txtEmail.Text = "";
                txtAddress.Text = "";

                if (setRedirectHomepage != null)
                {
                    setRedirectHomepage(sender, e);
                }


            }
            catch (Exception)
            {
                throw;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "UserTest1234";
            txtPassword.Text = "UserTest1234";
            txtConfirmPassword.Text = "UserTest1234";
            txtNickname.Text = "UserTest1234";
            txtAddress.Text = "台北市大安區復興南路一段390號";
            txtEmail.Text = "UserTest1234@msit.com";
        }

        private void btnGoogleMap_Click(object sender, EventArgs e)
        {
            FrmMap fm = new FrmMap();
            fm.ShowDialog();
            if (fm.DialogResult == DialogResult.OK)
            {
                txtAddress.Text = pb.address;
            }
        }
    }
}
