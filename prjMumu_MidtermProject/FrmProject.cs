using slnMumu_MidtermProject.FrmView;
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
    public partial class FrmProject : Form
    {
        private Timer _timer;
        private List<Projects> _list;
        private int _pbIndex = 0;
        public FrmProject()
        {
            InitializeComponent();
        }
        private void FrmHomepage_Load(object sender, EventArgs e)
        {
            //屁眼
            //headProject();
            //fillComboPrjType();
            //fillFlowAllPrj();
            //fillPBLong();
        }
        private void headProject()
        {
            //取最新5筆計畫加入_list
            if (_list != null) 
            _list.Clear();
            ZecZecEntities db = new ZecZecEntities();
            var project = from x in db.Projects
                          orderby x.Date descending
                          select x;
            _list = project.Take(5).ToList();
            printHeadPB();
            foreach (var item in homepagePB1.Controls)
            {
                ((Control)item).Click += homepagePB1_Click;
                ((Control)item).MouseEnter += homepagePB1_MouseEnter;
                ((Control)item).MouseLeave += homepagePB1_MouseLeave;
                foreach (var x in ((Control)item).Controls)
                {
                    ((Control)x).Click += homepagePB1_Click;
                    ((Control)x).MouseEnter += homepagePB1_MouseEnter;
                    ((Control)x).MouseLeave += homepagePB1_MouseLeave;
                }
            }
        }
        private void printHeadPB()
        {
            //把拉入_list的計畫以及另外拉總金額跟支持人數加進主頁頭版
            Projects proj = _list[_pbIndex];
            this.homepagePB1.image = new Bitmap(Application.StartupPath + "\\Images\\ProjectsThumbnail\\" + proj.Thumbnail);
            this.homepagePB1.textName = proj.ProjectName;
            this.homepagePB1.Tag = proj.ProjectID;
            ZecZecEntities db = new ZecZecEntities();
            var orders = from y in db.OrderDetails
                         join z in db.Products
                         on y.ProductID equals z.ProductID
                         where z.ProjectID == proj.ProjectID  //_list[_pbIndex] 會有問題，可能 Linq 方法中不能處理陣列
                         select new
                         {
                             tot = y.Price,
                             cou = y.Count
                         };
            decimal total = 0;
            int sup = 0;
            foreach (var o in orders)
            {
                total += o.tot * o.cou;
                sup++;
            }
            this.homepagePB1.textSupport = "已有" + sup + "人支持";
            this.homepagePB1.textTotal = total.ToString("C0");
        }
        private void homepagePB1_Click(object sender, EventArgs e)
        {
            FrmProjectInfo f = new FrmProjectInfo(_list[_pbIndex].ProjectID);
            f.rd += (this.MdiParent as FrmHomepage).button1_Click;
            f.MdiParent = this.MdiParent as FrmHomepage;
            f.Dock = DockStyle.Fill;
            f.Show();
            this.Close();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //主頁list的變數--
            if (_pbIndex == 0)
                _pbIndex = _list.Count - 1;
            else
                _pbIndex--;
            printHeadPB();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //主頁list的變數++
            if (_pbIndex == _list.Count - 1)
                _pbIndex = 0;
            else
                _pbIndex++;
            printHeadPB();
        }
        private void fillPBLong()
        {
            this.flowLayoutPanel1.Controls.Clear();
            ZecZecEntities db = new ZecZecEntities();
            var projects = from x in db.Projects
                           orderby x.Date descending
                           select x;
            foreach (var x in projects.Skip(5).Take(4))
            {
                var order = from y in db.OrderDetails
                            join z in db.Products
                            on y.ProductID equals z.ProductID
                            where z.ProjectID == x.ProjectID
                            select new
                            {
                                tot = y.Price,
                                cou = y.Count
                            };
                decimal total = 0;
                int sup = 0;
                foreach (var o in order)
                {
                    total += o.tot * o.cou;
                    sup++;
                }
                PrjPBLong homepagePBLong = new PrjPBLong();
                homepagePBLong.Image = new Bitmap(Application.StartupPath + "\\Images\\ProjectsThumbnail\\" + x.Thumbnail);
                homepagePBLong.title = x.ProjectName;
                homepagePBLong.Tag = x.ProjectID;
                homepagePBLong.total = total.ToString("C0");
                homepagePBLong.support = sup.ToString() + "人";
                homepagePBLong.Width = 500;
                homepagePBLong.Height = 150;
                homepagePBLong.Margin = new Padding(20, 10, 20, 10);
                homepagePBLong.valueP = (int)(total / x.Goal * 100);
                foreach (var item in homepagePBLong.Controls)
                {
                    ((Control)item).Click += prjAnyClick_Click;
                    ((Control)item).Tag = x.ProjectID;
                    foreach (var o in ((Control)item).Controls)
                    {
                        ((Control)o).Click += prjAnyClick_Click;
                        ((Control)o).Tag = x.ProjectID;
                    }
                }
                this.flowLayoutPanel1.Controls.Add(homepagePBLong);
            }
        }
        private void fillFlowAllPrj()
        {
            //底下所有計畫的生成
            ZecZecEntities db = new ZecZecEntities();
            var projects = from x in db.Projects
                           select x;
            createPBSquare(db, projects);
        }
        private void createPBSquare(ZecZecEntities db, IQueryable<Projects> projects)
        {
            //透過傳入的計畫資料來生成使用者控制項在flowlayout
            this.flowLayoutPanel2.Controls.Clear();
            if (projects.FirstOrDefault() == null)
            {
                Label label = new Label();
                label.Text = "⚠️喔喔~ 找不到喔~ 換個關鍵字再試試看🤪~";
                label.Font = new Font("微軟正黑體", 16, FontStyle.Bold);
                label.ForeColor = Color.Red;
                label.AutoSize = true;
                this.flowLayoutPanel2.Controls.Add(label);
                return;
            }
            foreach (var x in projects.Distinct())
            {
                var order = from y in db.OrderDetails
                            join z in db.Products
                            on y.ProductID equals z.ProductID
                            where z.ProjectID == x.ProjectID
                            select new
                            {
                                tot = y.Price,
                                cou = y.Count
                            };
                decimal total = 0;
                int sup = 0;
                foreach (var o in order)
                {
                    total += o.tot * o.cou;
                    sup++;
                }//屁眼
                PrjPBSquare pBSquare = new PrjPBSquare();
                pBSquare.Image = new Bitmap(Application.StartupPath + "\\Images\\ProjectsThumbnail\\" + x.Thumbnail);
                pBSquare.title = x.ProjectName;
                pBSquare.total = total.ToString("C0");
                pBSquare.support = sup + "人";
                pBSquare.Tag = x.ProjectID;
                pBSquare.Margin = new Padding(10, 10, 10, 10);
                pBSquare.valueP = (int)(total / x.Goal * 100);
                pBSquare.Click += prjAnyClick_Click;
                foreach (var item in pBSquare.Controls)
                {
                    ((Control)item).Click += prjAnyClick_Click;
                    ((Control)item).Tag = x.ProjectID;
                    foreach (var o in ((Control)item).Controls)
                    {
                        ((Control)o).Click += prjAnyClick_Click;
                        ((Control)o).Tag = x.ProjectID;
                    }
                }
                this.flowLayoutPanel2.Controls.Add(pBSquare);
            }
        }
        private void fillComboPrjType()
        {
            //combobox加入計畫分類
            ZecZecEntities db = new ZecZecEntities();
            var prjtype = from x in db.ProjectTypes
                          select x;
            this.comboBox2.Items.Clear();
            this.comboBox2.Items.Add("主題分類");
            foreach (var x in prjtype)
            {
                this.comboBox2.Items.Add(x.ProjectTypeName);
            }
            this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox2.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //透過combox跟textbox的參數去db查詢
            ZecZecEntities db = new ZecZecEntities();
            if (comboBox2.Text == "主題分類")
            {
                var projects = from x in db.Projects
                               join y in db.ProjectIDType
                               on x.ProjectID equals y.ProjectID
                               join z in db.ProjectTypes
                               on y.ProjectTypeID equals z.ProjectTypeID
                               where x.ProjectName.Contains(this.textBox1.Text)
                               select x;
                createPBSquare(db, projects);
            }
            else
            {
                var projects = from x in db.Projects
                               join y in db.ProjectIDType
                               on x.ProjectID equals y.ProjectID
                               join z in db.ProjectTypes
                               on y.ProjectTypeID equals z.ProjectTypeID
                               where z.ProjectTypeName == this.comboBox2.Text && x.ProjectName.Contains(this.textBox1.Text)
                               select x;
                createPBSquare(db, projects);
            }
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //讓textbox可以按enter查詢
            if (e.KeyChar == (char)Keys.Enter)
                this.button1_Click(sender, e);
        }
        private void prjAnyClick_Click(object sender, EventArgs e)
        {
            FrmProjectInfo f = new FrmProjectInfo((int)((Control)sender).Tag);
            f.MdiParent = this.MdiParent as FrmHomepage;
            f.Dock = DockStyle.Fill;
            f.Show();
            this.Close();
        }
        private void setTimer()
        {
            //主頁換圖的計時器
            _timer = new Timer();
            _timer.Interval = 5000;
            _timer.Tick += button3_Click;
            _timer.Start();
        }
        private void FrmHomepage_Deactivate(object sender, EventArgs e)
        {
            //時間停止器
            _timer.Stop();
            _timer.Dispose();
        }
        private void FrmHomepage_Activated(object sender, EventArgs e)
        {
            headProject();
            fillComboPrjType();
            fillFlowAllPrj();
            fillPBLong();
            //設置計時
            setTimer();
        }
        private void homepagePB1_MouseEnter(object sender, EventArgs e)
        {
            _timer.Stop();
        }
        private void homepagePB1_MouseLeave(object sender, EventArgs e)
        {
            _timer.Start();
        }
    }
}
