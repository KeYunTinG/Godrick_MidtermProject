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
using slnMumu_MidtermProject.FrmView;
using prjMumu_MidtermProject;
using prjMumu_MidtermProject.UserControls;
using System.Reflection;

namespace slnMumu_MidtermProject
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
#pragma warning disable CS0067 // 事件 'FrmProjectInfo.RefreshHomePage' 從未使用過
        public event D RefreshHomePage;
#pragma warning restore CS0067 // 事件 'FrmProjectInfo.RefreshHomePage' 從未使用過
        public delegate void Redirect(object sender, EventArgs e);
#pragma warning disable CS0067 // 事件 'FrmProjectInfo.rd' 從未使用過
        public event Redirect rd;
#pragma warning restore CS0067 // 事件 'FrmProjectInfo.rd' 從未使用過
        private ZecZecEntities db;
        private int _projID;
        bool _isLike = false;
        CurrentUserManager user;
        public FrmProjectInfo(int pid)
        {
            InitializeComponent();
            _projID = pid;
            user = new CurrentUserManager();
            db = new ZecZecEntities();
        }
        private void FrmProjectInfo_Load(object sender, EventArgs e)
        {
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
            this.lblSponsor.Text = proj.Members.Nickname;
            var projTypes = proj.ProjectIDType.Select(pit => pit.ProjectTypes);
            //var projTypes = proj.ProjectIDType.SelectMany(pit => pit.ProjectTypes);

            //var projTypes = from projectIDType in proj.ProjectIDType
            //                from projectType in projectIDType.ProjectTypes.ProjectTypeName
            //                select projectType;

            this.lblProjectType.Text = "";
            foreach (var projType in projTypes)
            {
                this.lblProjectType.Text += $"{projType.ProjectTypeName} ";
            }
            int total = (int)proj.Products.SelectMany(p => p.OrderDetails).Sum(order => order.Price * order.Count);
            this.lblGoal.Text = $"{total:c0} / {proj.Goal:c0}";
            LoadProgress(total, proj.Goal);

            if (!string.IsNullOrEmpty(proj.Thumbnail))
            {
                this.pbProjectThumbnail.Image =
                    new Bitmap(Application.StartupPath + @"\Images\ProjectsThumbnail\" + proj.Thumbnail);
            }
            this.lblDate.Text = $"{proj.Date:yyyy/MM/dd} ~ {proj.ExpireDate:yyyy/MM/dd}";
            this.label1.Text = proj.Description;
            this.pbLikeButton.Image = (_isLike ? ilLiked.Images[1] : ilLiked.Images[0]);

        }

        private void LoadProgress(int total, decimal goal)
        {
            int percentage = (int)(total / goal * 100);
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

        #region Comments
        private void LoadComments()
        {
            this.flpComments.Controls.Clear();
            ZecZecEntities db = new ZecZecEntities();
            var comments = from c in db.Comments
                           where c.ProjectID == _projID
                           select c;
            foreach (var comment in comments)
            {
                Label l = new Label();
                l.BackColor = Color.Gray;
                l.Size = new Size(this.flpComments.Width - 30, 1);
                l.Anchor = AnchorStyles.Left | AnchorStyles.Right;


                CommentBox c = new CommentBox();
                c.ReplyClick += ReplyClick;
                c.comment = comment;
                c.Size = new Size(this.flpComments.Width - 30, 20);
                c.Anchor = AnchorStyles.Left | AnchorStyles.Right;
                this.flpComments.Controls.Add(l);
                this.flpComments.Controls.Add(c);
                // 印出 SubComment
                foreach(var sc in comment.SubComments)
                {
                    CommentBoxSub cb = new CommentBoxSub();
                    cb.subComment = sc;
                    cb.Margin = new Padding(30,0,0,0);
                    c.Size = new Size(this.flpComments.Width - 30, 20);

                    this.flpComments.Controls.Add(cb);
                }

            }
        }
        private Comments _selectedComment;
        private void ReplyClick(Comments comm)
        {
            lblReply.Text = $"回覆 {comm.Members.Nickname}";
            this.lblReply.Visible = true;
            _selectedComment = comm;
        }
        private void btnSend_Click(object sender, EventArgs e)
        {
            SendMessage(_selectedComment);
        }

        private void SendMessage(Comments comm)
        {
            if (user.member == null)
            {
                GotoLogin();
                return;
            }
            if (string.IsNullOrEmpty(this.tbMessage.Text)) return;
            using (var db = new ZecZecEntities())
            {
                if (comm is null)
                {
                    // 新增一筆 Comment
                    Comments comment = new Comments();
                    comment.MemberID = user.member.MemberID;
                    comment.ProjectID = _projID;
                    comment.CommentMsg = this.tbMessage.Text;
                    comment.Date = DateTime.Now;
                    db.Comments.Add(comment);
                }
                else
                {
                    //新增一筆 SubComment
                    SubComments sc = new SubComments();
                    sc.MemberID = user.member.MemberID;
                    sc.SubCommentMsg = this.tbMessage.Text;
                    sc.Date = DateTime.Now;
                    sc.CommentID = comm.CommentID;
                    db.SubComments.Add(sc);
                }
                db.SaveChanges();
            }

            // 更新畫面
            this.tbMessage.Text = "";
            this.lblReply.Visible = false;
            _selectedComment = null;
            int scrollPosition = this.flpComments.VerticalScroll.Maximum;
            LoadComments();
            //this.flpComments.AutoScrollPosition=new Point(this.flpComments.Height);
            this.flpComments.VerticalScroll.Value = scrollPosition;
        }

        private void tbMessage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Escape)
            {
                this.lblReply.Visible = false;
                _selectedComment = null;
                return;
            };
            if (e.KeyChar != (char)Keys.Enter) return;
            SendMessage(_selectedComment);
        }
        #endregion
        private FrmMessage message;

        private void LblSponsor_MouseLeave(object sender, EventArgs e)
        {
            if (message != null)
            {
                message.Close();
            }
        }

        private void LblSponsor_MouseEnter(object sender, EventArgs e)
        {
            Projects project = SelectProjectById(_projID);
            Members memberInfo = project.Members;
            message = new FrmMessage(memberInfo);
            message.Show();
        }
    }
}
