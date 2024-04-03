using slnMumu_MidtermProject;
using slnMumu_MidtermProject.Query;
using slnMumu_MidtermProject.UserControls;
using slnMumu_MidtermProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;


namespace slnMumu_MidtermProject.FrmView
{

    public partial class FrmSponsor : Form
    {
        private int projectID;
        private QueryDB queryDB;
        private FrmMessage message;
        private Members memberInfo;
        private FrmPay pay;


        public FrmSponsor(int _projectID)
        {
            InitializeComponent();
            this.projectID = _projectID;

            queryDB = new QueryDB();
        }

        private async void frmSponsor_Load(object sender, EventArgs e)
        {
            splitContainer1.IsSplitterFixed = true;

            await MethodAsync();
        }

        private async Task MethodAsync()
        {
            await FindProjectWithProjectID();
            await FindProductWithProjectID();
        }

        private async Task FindProjectWithProjectID()
        {
            var result = await queryDB.FindDataWithProjectID(projectID);

            foreach (var item in result)
            {
                projecttitle.Text = item.project.ProjectName;

                if (!string.IsNullOrEmpty(item.project.Thumbnail))
                {
                    string path = Application.StartupPath + "\\Images\\ProjectsThumbnail";
                    projectpic.Image = new Bitmap(path + "\\" + item.project.Thumbnail);
                    projectpic.SizeMode = PictureBoxSizeMode.Zoom;
                }
            }

            memberInfo = await queryDB.FindMember(result[0].project.MemberID);

            lblSponsor.Text = memberInfo.Nickname;
            lblSponsor.MouseEnter += LblSponsor_MouseEnter;
            lblSponsor.MouseLeave += LblSponsor_MouseLeave;

            var type = await queryDB.FindProjectType(projectID);

            decimal total = await LoadGoalAndTotal();

            lblTotal.Text = total.ToString("C0") + " / 目標 " + result[0].project.Goal.ToString("C0");

            lblProjectType.Text = type[0].projectName;
        }

        private async Task<decimal> LoadGoalAndTotal()
        {
            var result = await queryDB.ProjJoinProdJoinOD(projectID);

            decimal total = 0;

            foreach (var item in result)
            {
                total += item.price;
            }

            return total;
        }

        private async Task FindProductWithProjectID()
        {
            var result = await queryDB.FindProductsWithProjectID(projectID);

            string pathPd = Application.StartupPath + "\\Images\\ProductsThumbnail";

            foreach (var item in result)
            {
                if (item.Inventory == 0)   //todo增加數量0條件
                {
                    continue;
                }
                PanelProducts pp = new PanelProducts();

                int[] a = new int[2] { item.ProjectID, item.ProductID };

                pp.Tag = a;
                pp.OnPay += this.DirectToPay;
                pp.productImagePath = pathPd + "\\" + item.Thumbnail;
                pp.productName = item.ProductName;
                int i = (int)item.Price;
                pp.productPrice = "NT$ " + i.ToString();
                pp.productIventory = "剩餘 " + item.Inventory.ToString() + " 組";
                int sponsor = item.Quantity - item.Inventory;
                pp.productSelled = "已被贊助 " + sponsor.ToString() + " 組";
                pp.productDescription = item.ProductDescription;

                fpProducts.Controls.Add(pp);
            }
        }

        private void LblSponsor_MouseLeave(object sender, EventArgs e)
        {
            if (message != null)
            {
                message.Close();
            }
        }

        private void LblSponsor_MouseEnter(object sender, EventArgs e)
        {
            message = new FrmMessage(memberInfo);
            message.Show();
        }

        private void DirectToPay(int _projectID, int _productID)
        {
            pay = new FrmPay(_projectID, _productID);
            pay.MdiParent = this.MdiParent as FrmHomepage;
            pay.Dock = DockStyle.Fill;
            pay.Show();
            this.Close();  //TODO 4/3
        }
    }
}
