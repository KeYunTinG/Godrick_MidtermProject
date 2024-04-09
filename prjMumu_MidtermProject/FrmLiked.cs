using prjMumu_MidtermProject.UserControls;
using slnMumu_MidtermProject;
using slnMumu_MidtermProject.FrmView;
using slnMumu_MidtermProject.UserControls;
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
    public partial class FrmLiked : Form
    {
        private int m_id;
        private CurrentUserManager cum;
        public FrmLiked(int id)
        {
            m_id = id;
            InitializeComponent();
            cum = new CurrentUserManager();
            //loadLikeData(m_id, 1);
        }

        private string currentUser;

        private void FrmLiked_Load(object sender, EventArgs e)
        {
            currentUser = cum.currentUser;
            label2.Text = currentUser;
            this.ControlBox = false;

        }
        private void FrmLiked_Activated(object sender, EventArgs e)
        {
            this.flowLayoutPanel1.Controls.Clear();
            //loadLikeData(m_id, 1);
            loadBuyData(m_id, 1);
        }
        private void loadLikeData(int memberId, int currentPage) //收藏顯示
        {
            titleChanged(1);
            using (ZecZecEntities db = new ZecZecEntities())
            {
                string path = Application.StartupPath + "\\Images\\ProjectsThumbnail\\";
                List<string> list = new List<string>();
                var OQ = from o in db.Likes.Where(o => o.MemberID == memberId)
                         join pj in db.Projects
                         on o.ProjectID equals pj.ProjectID
                         orderby o.LikeID
                         select new
                         {
                             _id = o.LikeID,
                             _name = pj.ProjectName,
                             _info = pj.Description,
                             _photo = pj.Thumbnail,
                         };
                int pageSize = 5; // 每頁顯示的訂單數量

                // 計算總頁數
                int totalOrders = OQ.Count();
                int totalPages = (int)Math.Ceiling((double)totalOrders / pageSize);

                // 根據當前頁數進行分頁
                int skipAmount = (currentPage - 1) * pageSize;

                //每頁資料
                foreach (var oq in OQ.Skip(skipAmount).Take(pageSize))
                {
                    CUserLike CUL = new CUserLike();
                    CUL.fieldTitle = oq._name;
                    CUL.fieldDescription = oq._info;
                    CUL.fieldPhoto = new Bitmap(path + oq._photo);
                    Projects pID = db.Projects.FirstOrDefault(p => p.ProjectName == CUL.fieldTitle);
                    if (pID != null)
                    {
                        ContextMenuStrip cms = new ContextMenuStrip();
                        CUL.ContextMenuStrip = cms;
                        ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                        toolStripMenuItem.Text = "移除";
                        toolStripMenuItem.Click += Like_DeleteClick(pID.ProjectID);
                        ToolStripMenuItem toolStripMenuItem2 = new ToolStripMenuItem();
                        toolStripMenuItem2.Text = "即刻贊助";
                        toolStripMenuItem2.Click += DirectToSponsor(pID.ProjectID);

                        cms.Items.AddRange(new ToolStripMenuItem[] { toolStripMenuItem, toolStripMenuItem2 });
                        CUL.fieldClick += Item_itemFieldClick(pID.ProjectID);
                        CUL.DeleteClick += Like_DeleteClick(pID.ProjectID);
                    }
                    flowLayoutPanel1.Controls.Add(CUL);
                }
                //分頁計算
                this.flowLayoutPanel2.Controls.Clear();
                for (int i = 1; i <= totalPages; i++)
                {
                    if (totalPages < 2) return;
                    Button btn1 = new Button();
                    btn1.Width = 102;
                    btn1.Height = 32;
                    btn1.Text = i.ToString();
                    btn1.FlatStyle = FlatStyle.Flat;
                    if (i != currentPage)
                        btn1.FlatAppearance.BorderSize = 0;
                    btn1.Font = new Font("微軟正黑體", 12);
                    btn1.Click += Likebtn1_Click;
                    this.flowLayoutPanel2.Controls.Add(btn1);
                }

            }
        }
        private void loadBuyData(int memberId, int currentPage)  //購買顯示
        {
            titleChanged(2);
            using (ZecZecEntities db = new ZecZecEntities())
            {
                string path = Application.StartupPath + "\\Images\\ProjectsThumbnail\\";
                List<string> list = new List<string>();
                var OQ = (from m in db.Members
                          join o in db.Orders on m.MemberID equals o.MemberID
                          join od in db.OrderDetails on o.OrderID equals od.OrderID
                          join pd in db.Products on od.ProductID equals pd.ProductID
                          join pj in db.Projects on pd.ProjectID equals pj.ProjectID
                          where m.MemberID == memberId
                          select new
                          {
                              _id = od.OrderID,
                              _name = pj.ProjectName,
                              //_info = pj.Description,
                              _photo = pj.Thumbnail,
                              _date = pj.Date,
                          }).Distinct().OrderBy(o => o._id); //屁眼派對
                int pageSize = 5; // 每頁顯示的訂單數量

                // 計算總頁數
                int totalOrders = OQ.Count();
                int totalPages = (int)Math.Ceiling((double)totalOrders / pageSize);

                // 根據當前頁數進行分頁
                int skipAmount = (currentPage - 1) * pageSize;

                //每頁資料
                foreach (var oq in OQ.Skip(skipAmount).Take(pageSize))
                {
                    var order = from od in db.OrderDetails.Where(o => o.OrderID == oq._id)
                                join pd in db.Products
                                on od.ProductID equals pd.ProductID
                                select new
                                {
                                    _name = pd.ProductName,
                                    _tot = od.Price * od.Count
                                };
                    //算錢
                    decimal total = 0;
                    List<string> pdName = new List<string>();
                    foreach (var o in order)
                    {
                        pdName.Add(o._name);
                        total += o._tot;
                    }
                    CCPurchaseHistory CCP = new CCPurchaseHistory();
                    CCP.fieldTitle = oq._name;
                    CCP.fieldDate = oq._date.ToString("yyyy/MM/dd");
                    //CCP.fieldDescription = oq._info;
                    CCP.fieldPhoto = new Bitmap(path + oq._photo);
                    CCP.fieldPrice = total.ToString();
                    CCP.fieldProduct1 = pdName[0];//購買方案
                    if (pdName.Count > 1 && pdName[1].Length > 0)
                        CCP.fieldProduct2 = pdName[1];
                    if (pdName.Count > 2 && pdName[2].Length > 0)
                        CCP.fieldProduct3 = pdName[2];
                    if (pdName.Count > 3 && pdName[3].Length > 0)
                        CCP.fieldProduct4 = pdName[3];
                    Projects pID = db.Projects.FirstOrDefault(p => p.ProjectName == CCP.fieldTitle);
                    if (pID == null)
                        return;
                    CCP.fieldClick += Item_itemFieldClick(pID.ProjectID);
                    flowLayoutPanel1.Controls.Add(CCP);
                }
                //分頁計算
                this.flowLayoutPanel2.Controls.Clear();
                for (int i = 1; i <= totalPages; i++)
                {
                    if (totalPages < 2) return;
                    Button btn1 = new Button();
                    btn1.Width = 102;
                    btn1.Height = 32;
                    btn1.Text = i.ToString();
                    btn1.FlatStyle = FlatStyle.Flat;
                    if (i != currentPage)
                        btn1.FlatAppearance.BorderSize = 0;
                    btn1.Font = new Font("微軟正黑體", 12);
                    btn1.Click += Buybtn1_Click;
                    this.flowLayoutPanel2.Controls.Add(btn1);
                }

            }
        }
        private void LikeTitle_Click(object sender, EventArgs e) //喜愛清單
        {
            this.flowLayoutPanel1.Controls.Clear();
            loadLikeData(m_id, 1);
        }
        private void BuyTitle_Click(object sender, EventArgs e) //購買清單
        {
            this.flowLayoutPanel1.Controls.Clear();
            loadBuyData(m_id, 1);
        }
        private void Likebtn1_Click(object sender, EventArgs e) //LIKE頁數切換
        {
            Button btn1 = sender as Button;
            this.flowLayoutPanel1.Controls.Clear();
            loadLikeData(m_id, int.Parse(btn1.Text));
        }
        private void Buybtn1_Click(object sender, EventArgs e) //BUY頁數切換
        {
            Button btn1 = sender as Button;
            this.flowLayoutPanel1.Controls.Clear();
            loadBuyData(m_id, int.Parse(btn1.Text));
        }
        private void titleChanged(int i)//改變標題顯示
        {
            if (i == 1)
            {
                Titlelabel1.ForeColor = Color.Black;
                Titlelabel1.Font = new Font(Titlelabel2.Font, FontStyle.Regular);
                Titlelabel1.Cursor = Cursors.Default;
                Titlelabel2.ForeColor = Color.FromArgb(0, 0, 238);
                Titlelabel2.Font = new Font(Titlelabel2.Font, FontStyle.Underline);
                Titlelabel2.Cursor = Cursors.Hand;
            }
            if (i == 2)
            {
                Titlelabel2.ForeColor = Color.Black;
                Titlelabel2.Font = new Font(Titlelabel2.Font, FontStyle.Regular);
                Titlelabel2.Cursor = Cursors.Default;
                Titlelabel1.ForeColor = Color.FromArgb(0, 0, 238);
                Titlelabel1.Font = new Font(Titlelabel2.Font, FontStyle.Underline);
                Titlelabel1.Cursor = Cursors.Hand;
            }
        }
        private EventHandler Item_itemFieldClick(int i)
        {
            return (sender, e) =>
            {
                FrmProjectInfo frmProjectInfo = new FrmProjectInfo(i);
                frmProjectInfo.MdiParent = this.MdiParent as FrmHomepage;
                frmProjectInfo.Dock = DockStyle.Fill;
                frmProjectInfo.Show();
                Close();
            };
        }
 private EventHandler DirectToSponsor(int projectID)
        {
            return (sender, e) =>
            {
                FrmSponsor sponsor = new FrmSponsor(projectID);
                sponsor.MdiParent = this.MdiParent as FrmHomepage;
                sponsor.Dock = DockStyle.Fill;
                sponsor.Show();
            };
        }
        private EventHandler Like_DeleteClick(int i)
        {
            return (sender, e) =>
            {
                FrmMyMessageBoxYesNo myn = new FrmMyMessageBoxYesNo();
                myn.msg = " 確定要移除最愛嗎? ";
                myn.ShowDialog();
                if (myn.DialogResult == DialogResult.Cancel) return;

                using (ZecZecEntities db = new ZecZecEntities())
                {
                    Likes like = db.Likes.FirstOrDefault(x => x.MemberID == m_id && x.ProjectID == i);
                    LikeDetails ld = db.LikeDetails.FirstOrDefault(x => x.LikeID == like.LikeID);
                    db.LikeDetails.Remove(ld);
                    db.Likes.Remove(like);
                    db.SaveChanges();
                }
                this.flowLayoutPanel1.Controls.Clear();
                loadLikeData(m_id, 1);
            };
        }
    }
}
