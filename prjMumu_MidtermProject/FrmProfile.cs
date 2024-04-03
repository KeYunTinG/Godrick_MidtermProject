using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjMumu_MidtermProject
{
    //此頁面會不會讓其他頁面跳轉?不然A看B的個人檔案結果能編輯會有問題要另外做一個頁面
    public partial class FrmProfile : Form
    {
        private CurrentUserManager cum;
        private string _ImagePath = "";
        public FrmProfile()
        {
            InitializeComponent();
            cum = new CurrentUserManager();
            
        }

        private string currentUser;

        private void FrmProfile_Load(object sender, EventArgs e)
        {
        

            currentUser = cum.currentUser;
           // dbDemo db=new dbDemo();
            ZecZecEntities zec = new ZecZecEntities();
            
            

            // 當 Form 的大小改變時，保持 Label 在中心
            this.Resize += FrmProfile_Resize;

            var userInfo =zec.Members.Where(x=>x.Username==currentUser).FirstOrDefault();
            if (userInfo != null)
            {
                textBox1.Text = userInfo.Nickname;
                if (userInfo.MemberIntroduction ==null)
                    textBox2.Text="此會員並未設定自我介紹 >\"< " ;
                else
                    textBox2.Text = userInfo.MemberIntroduction;
            }

            if (!string.IsNullOrEmpty(userInfo.Thumbnail))
            {
                string path = Application.StartupPath + "\\Image\\membersThumbnail";
                pictureBox1.Image = new Bitmap(path + "\\" + userInfo.Thumbnail);
             }

        }

        private void FrmProfile_Resize(object sender, EventArgs e)
        {
           
            
           
        }

        private void textBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            openFileDialog1.Filter = "個人照片|*.jpg|個人照片|*.png|個人照片|*.bmp";
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            _ImagePath = _ImagePath = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
            string path = System.Windows.Forms.Application.StartupPath + "\\Image\\membersThumbnail";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            File.Copy(openFileDialog1.FileName, path + "\\" + _ImagePath, true);
            pictureBox1.Image = new Bitmap(path + "\\" + _ImagePath);
            
        }

        //有個BUG 圖片在沒按下這個button1就會更改
        private void button1_Click(object sender, EventArgs e)
        {
            ZecZecEntities db = new ZecZecEntities();
            var prf = db.Members.Where(x => x.Username == currentUser).FirstOrDefault();
            prf.Nickname = textBox1.Text;
            prf.MemberIntroduction = textBox2.Text;
            prf.Thumbnail = _ImagePath;
            db.SaveChanges();
            MessageBox.Show("修改個人資料成功");
            
        }
    }
}
