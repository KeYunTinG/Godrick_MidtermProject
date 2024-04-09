using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace slnMumu_MidtermProject
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
            button1.Paint += new PaintEventHandler(button1_Paint);
        }
        private string currentUser;
        private void PictureBoxPaint()
        {
            // 計算圓形的直徑，這裡取PictureBox的寬度和高度中的較小值
            int diameter = Math.Min(pictureBox1.Width, pictureBox1.Height);
            // 創建一個新的GraphicsPath來添加圓形
            GraphicsPath gp = new GraphicsPath();
            // 添加一個圓形到路徑，圓心為PictureBox的中心，直徑為上面計算的值
            gp.AddEllipse(new Rectangle((pictureBox1.Width - diameter) / 2, (pictureBox1.Height - diameter) / 2, diameter, diameter));
            // 創建一個新的Region並將其設置為PictureBox的Region
            Region region = new Region(gp);
            pictureBox1.Region = region;
            // 釋放資源
            gp.Dispose();
            region.Dispose();
        }
        void button1_Paint(object sender, PaintEventArgs e)
        {
            Button btn = sender as Button;
            Graphics g = e.Graphics;
            // 按鈕的邊界半徑
            int borderRadius = 20;
            // 創建一個GraphicsPath來繪製圓弧形邊界
            GraphicsPath path = new GraphicsPath();
            path.AddArc(0, 0, borderRadius, btn.Height, 90, 180);
            path.AddArc(btn.Width - borderRadius, 0, borderRadius, btn.Height, 270, 180);
            path.CloseFigure();
            // 設置按鈕的Region屬性來實現圓弧形邊界
            btn.Region = new Region(path);
            // 繪製按鈕的背景和文字
            g.FillPath(new SolidBrush(btn.BackColor), path);
            g.DrawString(btn.Text, btn.Font, new SolidBrush(btn.ForeColor), new RectangleF(0, 0, btn.Width, btn.Height), new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
        }
    

        private void FrmProfile_Load(object sender, EventArgs e)
        {
            this.ControlBox = false;

            PictureBoxPaint();

            currentUser = cum.currentUser;   
            
            ZecZecEntities zec = new ZecZecEntities();
            var userInfo = zec.Members.Where(x => x.Username == currentUser).FirstOrDefault();
            if (userInfo != null)
            {
                textBox1.Text = userInfo.Nickname;
                if (userInfo.MemberIntroduction == null)
                    textBox2.Text = "此會員並未設定自我介紹 >\"< ";
                else
                    textBox2.Text = userInfo.MemberIntroduction;
                txtMail.Text = userInfo.Email;
                txtAddress.Text = userInfo.Address;
                txtCreateTime.Text = userInfo.CreateTime?.ToShortDateString();
            }
            if (!string.IsNullOrEmpty(userInfo.Thumbnail))
            {
                string path = Application.StartupPath + "\\Images\\membersThumbnail";
                pictureBox1.Image = new Bitmap(path + "\\" + userInfo.Thumbnail);
            }

        }

      


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
            openFileDialog1.Filter = "個人照片|*.jpg|個人照片|*.png|個人照片|*.bmp";
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            _ImagePath = _ImagePath = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
            string path = System.Windows.Forms.Application.StartupPath + "\\Images\\membersThumbnail";
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
            //如果使用者沒有選擇圖片 使用原本照片
            if (string.IsNullOrEmpty(_ImagePath))
            {
                _ImagePath = prf.Thumbnail;
            }
            prf.Thumbnail = _ImagePath;
            prf.Email=txtMail.Text;
            prf.Address = txtAddress.Text;
            db.SaveChanges();
            MessageBox.Show("修改個人資料成功");
            
        }
       

        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.FromArgb(205, 92, 92);
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            btn.BackColor = Color.RosyBrown;
        }

         
    }
}
