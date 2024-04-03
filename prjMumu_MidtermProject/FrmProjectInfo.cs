using slnMumu_MidtermProject.Views;
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
using System.Xml.Linq;
using prjMumu_MidtermProject.FrmView;

namespace prjMumu_MidtermProject
{
    /// <summary>
    /// 輸入：一個 Project ID,一個 Member ID
    /// 過程：未做 [X] 做一半 [V] 確定完成 [O]  
    ///     TODO 1 - 顯示這個Project的欄位資訊[V]
    ///     TODO 2 - 顯示這個Project底下的所有Product[X]
    /// 結果：按下 ProductCard 跳轉到產品頁
    /// </summary>
    public delegate void D();
    public partial class FrmProjectInfo : Form
    {
        public event D RefreshHomePage;
        public delegate void Redirect(object sender, EventArgs e);
        public event Redirect rd;
        private ZecZecEntities db;
        private int _projID;
        bool _isLike = false;
        CurrentUserManager user;
        public FrmProjectInfo(int pid)
        {
            InitializeComponent();
            _projID = pid;
            user = new CurrentUserManager();
        }
        private void FrmProjectInfo_Load(object sender, EventArgs e)
        {
            db = new ZecZecEntities();
            //TODO 1 - 顯示這個Project的欄位資訊
            Projects project = SelectProjectById(_projID);
            if (user.member != null)
                QueryLike(_projID, user.member.MemberID);
            DisplayProjectInfo(project);

            //TODO 2 - 顯示這個Project底下的所有Product
            List<Products> products = SelectProductsById(_projID);
            DisplayProductsCard(products);
            LoadComments();
        }

        private void DisplayProductsCard(List<Products> products)
        {
            foreach (Products pd in products)
            {
                ProductCard card = new ProductCard();
                card.product = pd;
                card.Width = this.flowLayoutPanel1.Width - 50;
                card.Margin = new Padding(10, 0, 0, 30);
                card.ClickProduct += this.ClickProduct;
                card.BackColor = this.flowLayoutPanel1.BackColor;
                this.flowLayoutPanel1.Controls.Add(card);
            }
        }

        private void ClickProduct(ProductCard pc)
        {
            if (!user.isLogin)
            {
                GotoLogin();
                return;
            }
            /*MessageBox.Show("跳轉到贊助頁面" +
                "\r\nID: " + pc.product.ProductID +
                "\r\nName: " + pc.product.ProductName);*/
            FrmPay frmPay = new FrmPay(_projID, pc.product.ProductID);
            frmPay.MdiParent = this.MdiParent as FrmHomepage;
            frmPay.Dock = DockStyle.Fill;
            frmPay.Show();
            this.Close();
        }

        private List<Products> SelectProductsById(int id)
        {
            var products = from pd in db.Products
                           where pd.ProjectID == id
                           select pd;
            return products.ToList();
        }

        private void DisplayProjectInfo(Projects proj)
        {
            this.lblProjectName.Text = proj.ProjectName;
            this.lblGoal.Text = proj.Goal.ToString("C0");
            if (!string.IsNullOrEmpty(proj.Thumbnail))
            {
                this.pbProjectThumbnail.Image =
                    new Bitmap(Application.StartupPath + @"\Images\ProjectsThumbnail\" + proj.Thumbnail);
            }
            this.lblDate.Text = $"{proj.Date:yyyy/MM/dd} ~ {proj.ExpireDate:yyyy/MM/dd}";
            this.label1.Text = proj.Description;
            this.pbLikeButton.Image = (_isLike ? ilLiked.Images[1] : ilLiked.Images[0]);
            LoadProgress(proj.ProjectID);

        }

        private void LoadProgress(int projID)
        {
            var proj = from p in db.Projects
                       select p;
            var currentProject = proj.FirstOrDefault(x => x.ProjectID == projID);
            int total = (int)currentProject.Products.SelectMany(p => p.OrderDetails).Sum(order => order.Price * order.Count);
            int percentage = (int)(total / currentProject.Goal * 100);
            this.cpbGoal.Text = percentage.ToString() + "%";
            this.cpbGoal.Value = (percentage > 100) ? 100 : percentage;
        }

        private Projects SelectProjectById(int id)
        {
            var projects = from p in db.Projects
                           select p;

            return projects.FirstOrDefault(x => x.ProjectID == id);
        }

        private void btnSponsor_Click(object sender, EventArgs e)
        {
            if (!user.isLogin)
            {
                GotoLogin();
                return;
            }
            /*MessageBox.Show("跳轉到贊助頁面" +
               "\r\nID: " + _projID);*/
            FrmSponsor frmSponsor = new FrmSponsor(_projID);
            frmSponsor.MdiParent = this.MdiParent as FrmHomepage;
            frmSponsor.Dock = DockStyle.Fill;
            frmSponsor.Show();
            this.Close();
        }

        private void pbLikeButton_Click(object sender, EventArgs e)
        {
            // 沒登入請先登入
            if (!user.isLogin)
            {
                GotoLogin();
                return;
            }

            // Like 資料表增加一筆
            _isLike = !_isLike;
            if (_isLike)
            {
                this.pbLikeButton.Image = ilLiked.Images[1];
                Likes like = new Likes();
                like.ProjectID = _projID;
                like.MemberID = user.member.MemberID;
                db.Likes.Add(like);
                db.SaveChanges();

                LikeDetails ld = new LikeDetails();
                ld.LikeID = like.LikeID;
                ld.MemberID = user.member.MemberID;
                db.LikeDetails.Add(ld);
                db.SaveChanges();

            }
            else
            {
                this.pbLikeButton.Image = ilLiked.Images[0];
                Likes like = db.Likes.FirstOrDefault(x => x.MemberID == user.member.MemberID && x.ProjectID == _projID);
                LikeDetails ld = db.LikeDetails.FirstOrDefault(x => x.LikeID == like.LikeID);
                db.LikeDetails.Remove(ld);
                db.Likes.Remove(like);
                db.SaveChanges();
            }
        }


        private void GotoLogin()
        {
            FrmMyMessageBox mb = new FrmMyMessageBox() { msg = "請先登入會員" };
            mb.ShowDialog();


            FrmLogIn fLogin = new FrmLogIn(this);
            fLogin.MdiParent = this.MdiParent as FrmHomepage;
            fLogin.Dock = DockStyle.Fill;
            fLogin.setUserState += () => { user.isLogin = true; };
            fLogin.setRedirectHomepage += (s, a) =>
            {
                (this.MdiParent as FrmHomepage).Click();
                fLogin.Close();
                //RefreshHomePage?.Invoke();
            };
            fLogin.Show();
        }

        private void QueryLike(int pid, int mid)
        {
            var likes = from like in db.Likes
                        select like;
            if (likes.FirstOrDefault(x => x.MemberID == mid && x.ProjectID == pid) == null) return;

            _isLike = true;
        }
        private void LoadComments()
        {
            this.flpComments.Controls.Clear();
            ZecZecEntities db = new ZecZecEntities();
            var comments = from c in db.Comments
                           where c.ProjectID == _projID
                           select c;
            foreach (var comment in comments)
            {
                CommentBox c = new CommentBox();
                c.comment = comment;
                this.flpComments.Controls.Add(c);
            }
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage();
        }

        private void SendMessage()
        {
            // 插入一筆資料到 Comments 表
            ZecZecEntities db = new ZecZecEntities();
            Comments comment = new Comments();
            if (user.member == null)
            {
                GotoLogin();
                return;
            }
            comment.MemberID = user.member.MemberID;
            comment.ProjectID = _projID;
            comment.CommentMsg = this.tbMessage.Text;
            comment.Date = DateTime.Now;
            db.Comments.Add(comment);
            db.SaveChanges();
            // 更新畫面
            this.tbMessage.Text = "";
            int scrollPosition = this.flpComments.VerticalScroll.Maximum;
            LoadComments();
            //this.flpComments.AutoScrollPosition=new Point(this.flpComments.Height);
            this.flpComments.VerticalScroll.Value = scrollPosition;
        }

        private void tbMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != (char)Keys.Enter) return;
            SendMessage();
        }
    }
}
