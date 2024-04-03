using slnMumu_MidtermProject.Views;
using slnMumu_MidtermProject;
using slnMumu_MidtermProject.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace slnMumu_MidtermProject
{
    public partial class FrmPropose : Form
    {
        Members _member = new CurrentUserManager().member;

        // 預存
        string _imagePath;
        
        public FrmPropose()
        {
            InitializeComponent();
            this.btnConfirm.Click += btnConfirm_Click;
        }
        public FrmPropose(int id)
        {
            InitializeComponent();
            this.btnDemo.Visible = false;
            this.btnConfirm.Click += EditConfirm;
            this.btnConfirm.Tag = id;
            // 開load
            using (ZecZecEntities db = new ZecZecEntities())
            {
                Projects proj = db.Projects.FirstOrDefault(p=>p.ProjectID == id);
                if (proj == null) return;
                _imagePath = Application.StartupPath + @"\Images\ProjectsThumbnail\" + proj.Thumbnail;
                this.pbProjectThumbnail.Image = new Bitmap(Application.StartupPath + @"\Images\ProjectsThumbnail\" + proj.Thumbnail);
                this.tbProjectName.Text = proj.ProjectName;
                this.tbProjectDescription.Text = proj.Description;
                this.tbProjectGoal.Text = proj.Goal.ToString();
                this.poisonDateTime1.Value = proj.Date;
                this.poisonDateTime2.Value = proj.ExpireDate;

                foreach(var pd in proj.Products)
                {
                    pd.Thumbnail = Application.StartupPath+ @"\Images\ProductsThumbnail\"+pd.Thumbnail;
                    ProductCardEditable pce = new ProductCardEditable();
                    pce.EditButtonClick += this.Card_EditButtonClick;
                    pce.RemoveButtonClick += this.Card_RemoveButtonClick;
                    pce.PositionButtonClick += this.Card_PositionButtonClick;
                    pce.product = pd;
                    this.flowLayoutPanel1.Controls.Add(pce); 
                }
            }
        }

        private void EditConfirm(object sender, EventArgs e)
        {
            //todo
            int pid = (int)((Button)sender).Tag;

            decimal goal;
            // 確認輸入正確
            if (string.IsNullOrEmpty(this.tbProjectName.Text))
            {
                MessageBox.Show("專案名稱不可空白");
            }
            if (string.IsNullOrEmpty(this.tbProjectDescription.Text))
            {
                MessageBox.Show("專案名稱不可空白");
                return;
            }

            if (!decimal.TryParse(tbProjectGoal.Text, out goal))
            {
                MessageBox.Show("募資目標");
                return;
            }
            // 存入資料庫
            using (var db = new ZecZecEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Projects newProj = db.Projects.FirstOrDefault(p => p.ProjectID == pid);
                        newProj.ProjectName = this.tbProjectName.Text;
                        newProj.Description = this.tbProjectDescription.Text;
                        newProj.Goal = decimal.Parse(this.tbProjectGoal.Text);
                        newProj.Date = this.poisonDateTime1.Value;
                        newProj.ExpireDate = this.poisonDateTime2.Value;
                        newProj.MemberID = _member.MemberID;
                        string storedPath = Path.GetFileName(_imagePath);
                        if (storedPath != newProj.Thumbnail)
                        storedPath = CopyImage(_imagePath, ImageType.Project); //
                        newProj.Thumbnail = storedPath;
                        newProj.RoleID = 1;

                        // 資料庫原本products都刪掉
                        //newProj.Products.Clear();

                        var pd = db.Products.Where(x => x.ProjectID == pid);
                        

                        // 新增products到資料庫
                        List<Products> products = new List<Products>();
                        foreach (var pce in this.flowLayoutPanel1.Controls)
                        {
                            Products p = ((ProductCardEditable)pce).product;
                            //照片
                            string stored = Path.GetFileName(p.Thumbnail);
                            //if (stored != db.Products.Where(x=>x.ProductID==p.ProductID))
                            if(!newProj.Products.Any(item=>item.Thumbnail==stored))
                                stored = CopyImage(p.Thumbnail, ImageType.Product);
                            p.Thumbnail = stored;
                            p.Projects = newProj;
                            products.Add(p);
                        }
                        //刪除
                        foreach (var p in pd)
                            db.Products.Remove(p);

                        db.Products.AddRange(products);
                        // 3. 保存更改
                        db.SaveChanges();
                        transaction.Commit();

                        MessageBox.Show("Victory");
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }

                }
            }
        }

        private void FrmPropose_Load(object sender, EventArgs e)
        {
            this.pbProjectThumbnail.AllowDrop = true;
        }

        private void pbProjectThumbnail_Click(object sender, EventArgs e)
        {
            this.openFileDialog1.Filter = "照片|*.jpg;*.png;*.jpeg";
            if (this.openFileDialog1.ShowDialog() != DialogResult.OK) return;
            this.pbProjectThumbnail.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pbProjectThumbnail.Image = new Bitmap(this.openFileDialog1.FileName);
            _imagePath = this.openFileDialog1.FileName;
        }

        private void pbProjectThumbnail_DragDrop(object sender, DragEventArgs e)
        {

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            string droppedFile = files[0];
            this.pbProjectThumbnail.SizeMode = PictureBoxSizeMode.StretchImage;
            this.pbProjectThumbnail.Image = new Bitmap(droppedFile);
            _imagePath = droppedFile;

        }
        private bool IsFileAllowed(string fileName)
        {
            // 在這裡添加您希望允許的檔案格式，例如.txt和.jpg
            string[] allowedExtensions = { ".png", ".jpg", ".jpeg" };
            // 檢查檔案擴展名是否在允許的擴展名陣列中
            string extension = System.IO.Path.GetExtension(fileName);
            return allowedExtensions.Contains(extension);
        }

        private void pbProjectThumbnail_DragEnter(object sender, DragEventArgs e)
        {

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            // 檢查是否只有一個拖放的文件，並且是允許的格式
            if (files.Length == 1 && IsFileAllowed(files[0]))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }

        }

        private void btnDemo_Click(object sender, EventArgs e)
        {
            this.tbProjectName.Text = "示範專案名稱";
            this.tbProjectDescription.Text = "範例專案內容\n範例專案內容\n範例專案內容";
            this.tbProjectGoal.Text = "10000";
            this.poisonDateTime2.Value = DateTime.Now.AddDays(10);
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            decimal goal;
            // 確認輸入正確
            if (string.IsNullOrEmpty(this.tbProjectName.Text))
            {
                MessageBox.Show("專案名稱不可空白");
            }
            if (string.IsNullOrEmpty(this.tbProjectDescription.Text))
            {
                MessageBox.Show("專案名稱不可空白");
                return;
            }

            if (!decimal.TryParse(tbProjectGoal.Text, out goal))
            {
                MessageBox.Show("募資目標");
                return;
            }
            // 存入資料庫
            using (var db = new ZecZecEntities())
            {
                using (var transaction = db.Database.BeginTransaction())
                {
                    try
                    {
                        Projects newProj = new Projects();
                        newProj.ProjectName = this.tbProjectName.Text;
                        newProj.Description = this.tbProjectDescription.Text;
                        newProj.Goal = decimal.Parse(this.tbProjectGoal.Text);
                        newProj.Date = this.poisonDateTime1.Value;
                        newProj.ExpireDate = this.poisonDateTime2.Value;
                        newProj.MemberID = _member.MemberID;//todo: 改成接到正確 member
                        string storedPath = CopyImage(_imagePath,ImageType.Project);
                        newProj.Thumbnail = storedPath;
                        newProj.RoleID = 1;


                        // 
                       
                        List<Products> products = new List<Products>();
                        foreach (var pce in this.flowLayoutPanel1.Controls)
                        {
                            Products p = ((ProductCardEditable)pce).product;
                            //照片
                            string stored = CopyImage(p.Thumbnail,ImageType.Product);
                            p.Thumbnail = stored;
                            p.Projects = newProj;
                            products.Add(p);
                        }
                        db.Projects.Add(newProj);
                        db.Products.AddRange(products);
                        // 3. 保存更改
                        db.SaveChanges();
                        transaction.Commit();

                        MessageBox.Show("Victory");
                    }
                    catch (Exception)
                    {
                        transaction.Rollback();
                        throw;
                    }
                    
                }
            }

        }

        private enum ImageType
        {
            Project,
            Product
        }

        private string CopyImage(string path, ImageType imgType)
        {
            string destinationDirectory="";
            string fileName = Path.GetFileName(path);

            switch (imgType){
                case ImageType.Project:
                    destinationDirectory = $@"{Application.StartupPath}\Images\ProjectsThumbnail";
                    break;
                case ImageType.Product:
                    destinationDirectory = $@"{Application.StartupPath}\Images\ProductsThumbnail";
                    break;
                    
            }

            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            string destinationFilePath = Path.Combine(destinationDirectory, fileName);

            try
            {
                File.Copy(path, destinationFilePath, true);
                return fileName;
            }
            catch (IOException ex)
            {
                return ex.Message;
            }
        }
        #region Product
        private void button2_Click(object sender, EventArgs e)
        {
            FrmProposeProduct f = new FrmProposeProduct();
            f.AddProduct += addProduct;
            f.ShowDialog();
        }

        private void addProduct(FrmProposeProduct f)
        {
            ProductCardEditable card = new ProductCardEditable();
            card.product = f.product;
            card.Width = this.flowLayoutPanel1.Width - 50;
            card.Margin = new Padding(10, 0, 0, 30);
            card.BackColor = this.flowLayoutPanel1.BackColor;
            card.RemoveButtonClick += Card_RemoveButtonClick;
            card.EditButtonClick += Card_EditButtonClick;
            card.PositionButtonClick += Card_PositionButtonClick;
            this.flowLayoutPanel1.Controls.Add(card);
        }

        private void Card_PositionButtonClick(ProductCardEditable pce, CardMove move)
        {
            int index = this.flowLayoutPanel1.Controls.IndexOf(pce);

            switch (move)
            {
                case CardMove.MoveUp:
                    if (index <= 0) return;
                    var pcePrevious = this.flowLayoutPanel1.Controls[index - 1];
                    this.flowLayoutPanel1.Controls.SetChildIndex(pce, index - 1);
                    this.flowLayoutPanel1.Controls.SetChildIndex(pcePrevious, index);
                    break;
                case CardMove.MoveDown:
                    if (index >= this.flowLayoutPanel1.Controls.Count - 1) return;
                    var pceNext = this.flowLayoutPanel1.Controls[index + 1];
                    this.flowLayoutPanel1.Controls.SetChildIndex(pce, index + 1);
                    this.flowLayoutPanel1.Controls.SetChildIndex(pceNext, index);
                    break;
            }

        }

        private void Card_EditButtonClick(ProductCardEditable pce)
        {
            FrmProposeProduct f = new FrmProposeProduct();
            f.product = pce.product;
            f.Tag = pce;
            f.confirmEdit += editProduct;
            f.ShowDialog();
        }

        private void editProduct(FrmProposeProduct f)
        {
            // todo
            ((ProductCardEditable)f.Tag).product = f.product;
        }

        private void Card_RemoveButtonClick(ProductCardEditable pce)
        {
            this.flowLayoutPanel1.Controls.Remove(pce);
        }
        #endregion

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
