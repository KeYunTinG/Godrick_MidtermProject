using slnMumu_MidtermProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace prjMumu_MidtermProject
{

    public partial class FrmEdit : Form
    {
        private int prjID;
        private string _ImagePath = "";
        private CurrentUserManager cum;
        private string currentUser;
        public FrmEdit(int prjID)
        {
            InitializeComponent();
            cum = new CurrentUserManager();
            this.prjID = prjID;
            ZecZecEntities db = new ZecZecEntities();
            var prj = db.Projects.Where(x => x.ProjectID == prjID).FirstOrDefault();
            if (prj != null)
            {
                textBox1.Text = prj.ProjectName;
                dateTimePicker1.Value = prj.ExpireDate;
                textBox3.Text = prj.Description;
                //textBox4.Text = prj.Discount.ToString();
                textBox2.Text = prj.Goal.ToString();
                string path = System.Windows.Forms.Application.StartupPath + "\\Image\\ProjectsThumbnail";
                pictureBox1.Image = new Bitmap(path + "\\" + prj.Thumbnail);

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmMyProject f = new FrmMyProject();
            f.MdiParent = this.MdiParent as FrmHomepage;
            f.Dock = DockStyle.Fill;
            f.Show();
            Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ZecZecEntities db = new ZecZecEntities())
            {
                //折扣暫時都先註解掉 visible設為false 需要再改回來即可
                var prj = db.Projects.Where(x => x.ProjectID == prjID).FirstOrDefault();
                if (prj != null)
                {
                    //bool isDiscount = double.TryParse(textBox4.Text, out double discount);
                    bool isGoal = decimal.TryParse(textBox2.Text, out decimal Goal);
                    if (isGoal)
                    {
                        //if (isDiscount && discount >= 0.1 && discount <= 1)
                        //{
                            prj.ProjectName = textBox1.Text;
                            prj.ExpireDate = dateTimePicker1.Value;
                            prj.Description = textBox3.Text;
                            //prj.Discount = discount;
                            prj.Goal = Goal;
                            //避免沒選圖片直接點儲存會造成把path清空
                            if (_ImagePath != "")
                            {
                                prj.Thumbnail = _ImagePath;
                            }
                            
                            db.SaveChanges();
                            MessageBox.Show("修改成功!");
                            FrmMyProject f = new FrmMyProject();
                            f.MdiParent = this.MdiParent as FrmHomepage;
                            f.Dock = DockStyle.Fill;
                            f.Show();
                            Close();
                       // }
                        //else
                          //  MessageBox.Show("請輸入正確的折扣數字(0.1~1)");
                    }
                    if (!isGoal)
                    {
                        MessageBox.Show("請輸入正確的目標數字");
                    }

                }
                var user = db.Members.FirstOrDefault(x => x.Username == currentUser);
                if (prjID == 0 && _ImagePath != "")
                {
                    //bool isDiscount = double.TryParse(textBox4.Text, out double discount);
                    bool isGoal = decimal.TryParse(textBox2.Text, out decimal Goal);

                    var project = new Projects()
                    {
                        MemberID = user.MemberID,
                        ProjectName = textBox1.Text,
                        ExpireDate = dateTimePicker1.Value,
                        Description = textBox3.Text,
                        //Discount = discount,
                        Goal = Goal,
                        //沒選圖片會有bug 要先設置_ImagePath條件再儲存
                        Thumbnail = _ImagePath,
                        RoleID = 2,
                        Date = DateTime.Now


                    };

                    db.Projects.Add(project);
                    if (isGoal)
                    {

                        db.SaveChanges();
                        MessageBox.Show("修改成功!");

                    }
                    else
                        MessageBox.Show("請輸入正確的目標數字");

                    var newPrjID = project.ProjectID;
                    var editPrj = db.Projects.FirstOrDefault(x => x.MemberID == user.MemberID);
                    //設定修改權限 因為我我的專案那邊是用ProjectEditPermissions去抓的
                    if (editPrj != null)
                    {
                        var editPer = new ProjectEditPermissions
                        {
                            ProjectID = newPrjID,
                            MemberID = user.MemberID,
                            PermissionLevelID = 1
                        };
                        db.ProjectEditPermissions.Add(editPer);
                        db.SaveChanges();
                        FrmMyProject f = new FrmMyProject();
                        f.MdiParent = this.MdiParent as FrmHomepage;
                        f.Dock = DockStyle.Fill;
                        f.Show();
                        Close();
                    }
                }
                else
                    MessageBox.Show("請選擇圖片");
            }

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {


            openFileDialog1.Filter = "專案照片|*.jpg|專案照片|*.png|專案照片|*.bmp";
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
                return;
            _ImagePath = _ImagePath = DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
            string path = System.Windows.Forms.Application.StartupPath + "\\Image\\ProjectsThumbnail";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            File.Copy(openFileDialog1.FileName, path + "\\" + _ImagePath, true);
            pictureBox1.Image = new Bitmap(path + "\\" + _ImagePath);

        }

        private void FrmEdit_Load(object sender, EventArgs e)
        {
            currentUser = cum.currentUser;
        }

        

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != 127)
            {
                e.Handled = true;
            }

        }
    }
}
