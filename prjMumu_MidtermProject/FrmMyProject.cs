using slnMumu_MidtermProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjMumu_MidtermProject
{
    public partial class FrmMyProject : Form
    {
        private CurrentUserManager cum;
        public FrmMyProject()
        {
            InitializeComponent();
            cum = new CurrentUserManager();
        }

        private string currentUser;

        private void FrmMyProject_Load(object sender, EventArgs e)
        {


            currentUser = cum.currentUser;
            label2.Text = currentUser;
            ZecZecEntities db = new ZecZecEntities();

            //具體權限還沒弄 
            var photo = (from r in db.Members
                         join r1 in db.ProjectEditPermissions on r.MemberID equals r1.MemberID
                         join r2 in db.Projects on r1.ProjectID equals r2.ProjectID
                         where r.Username == currentUser
                         select new { Members=r , ProjectEditPermissions = r1, Projects =r2});

            foreach (var image in photo)
            {
                string path = System.Windows.Forms.Application.StartupPath + "\\Image\\ProjectsThumbnail";
                
                
                PictureBox pictureBox = new PictureBox
                {
                    Image = new Bitmap(path + "\\" + image.Projects.Thumbnail),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    Width = 400,
                    Height = 200,
                    Anchor = AnchorStyles.None,
                    Margin = new Padding(0, 50, 0, 30)
                };
                //設定TAG
                pictureBox.Tag = image.Projects.ProjectID;
                pictureBox.DoubleClick += PictureBox_DoubleClick;
                
                Label label = new Label
                {
                    Text = image.Projects.ProjectName,
                    AutoSize = true,
                    Anchor = AnchorStyles.None,
                    Margin = new Padding(0, 0, 0, 30)
                };
                Button btn1 = new Button
                {
                    Text = "編輯專案",
                    Anchor = AnchorStyles.None,
                    Font = new Font("Microsoft JhengHei", 10F, FontStyle.Regular),
                    Width = 100,
                    Height =50,
                    Margin = new Padding(0, 0, 0, 30)
                };

                Button btn2 = new Button
                {
                    Text = "編輯專案中的商品",
                    Anchor = AnchorStyles.None,
                    Font = new Font("Microsoft JhengHei", 10F, FontStyle.Regular),
                    Width = 180,
                    Height = 50,
                    
                };
                

                btn1.Click += Btn1_Click;
                btn1.Tag= image.Projects.ProjectID;

                btn2.Click += Btn2_Click;
                btn2.Tag= image.Projects.ProjectID;


                FlowLayoutPanel panel = new FlowLayoutPanel
                {
                    FlowDirection = FlowDirection.TopDown
                };
                panel.Height = 550;
                panel.Width = 400;
                panel.Controls.Add(pictureBox);
                panel.Controls.Add(label);
                panel.Controls.Add(btn1);
                panel.Controls.Add(btn2);
                panel.BackColor= Color.LightGray;


                flowLayoutPanelMyProject.Controls.Add(panel);


            }

        }

        private void Btn2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            FrmProductList f = new FrmProductList((int)btn.Tag);
            f.MdiParent = this.MdiParent as FrmHomepage;
            f.Dock = DockStyle.Fill;
            f.Show();
            this.Close();
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            FrmEdit f = new FrmEdit((int)btn.Tag);
            f.MdiParent = this.MdiParent as FrmHomepage;
            f.Dock = DockStyle.Fill;
            f.Show();
            this.Close();
        }

        private void PictureBox_DoubleClick(object sender, EventArgs e)
        {
            //FrmTest改成要跳轉的專案頁面
            PictureBox pic = (PictureBox)sender;
            FrmProjectInfo f = new FrmProjectInfo((int)pic.Tag);
            f.MdiParent = this.MdiParent as FrmHomepage;
            f.Dock = DockStyle.Fill;
            f.Show();
        }

        private void userControl11_Load(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            FrmEdit f = new FrmEdit((int)btn.Tag);
            f.MdiParent = this.MdiParent as FrmHomepage;
            f.Dock = DockStyle.Fill;
            f.Show();
            this.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmEdit f = new FrmEdit(0);
            f.MdiParent = this.MdiParent as FrmHomepage;
            f.Dock = DockStyle.Fill;
            f.Show();
            this.Close();
        }
    }
}
