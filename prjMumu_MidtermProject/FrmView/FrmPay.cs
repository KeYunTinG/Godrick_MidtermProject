using prjMumu_MidtermProject.FrmSpo;
using prjMumu_MidtermProject.Query;
using prjMumu_MidtermProject.UserControls;
using slnMumu_MidtermProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;

namespace prjMumu_MidtermProject.FrmView
{
    public partial class FrmPay : Form
    {
        private int projectID;
        private int productID;
        private int paymentMethod;
        private Members memberInfo;
        private QueryDB queryDB;
        private FrmMessage message;
        private decimal addToPurchase;
        private decimal currentProductPrice;
        private decimal donate = 0;
        private decimal totalProductPrice = 0;
        private CurrentUserManager cum;
        private ZecZecEntities db;
        bool checkboxchange = false;
        private List<Products> checkedList = new List<Products>();

        public FrmPay(int _projectID, int _productID)
        {
            InitializeComponent();
            this.projectID = _projectID;
            this.productID = _productID;

            db = new ZecZecEntities();
            queryDB = new QueryDB();
            cum = new CurrentUserManager();
        }

        private async void FrmPay_Load(object sender, EventArgs e)
        {
            await MethodAsync();
            LoadPayByChange();
            textBox1.Text = cum.member.Address;
            textBox3.Text = cum.member.Nickname;

        }

        private void LoadPayByChange()
        {
            paybyATM.MouseEnter += Payby_MouseEnter;
            paybyATM.MouseLeave += Payby_MouseLeave;
            paybyCard.MouseEnter += Payby_MouseEnter;
            paybyCard.MouseLeave += Payby_MouseLeave;
            paybyATM.Click += PaybyATM_Click;
            paybyCard.Click += PaybyCard_Click;
        }

        private void PaybyCard_Click(object sender, EventArgs e)
        {
            if (checkboxchange == false)
            {
                creditcard.Checked = true;
                ATM.Checked = false;

            }
            else
            {
                creditcard.Checked = false;

            }
            checkboxchange = !checkboxchange;
        }

        private void PaybyATM_Click(object sender, EventArgs e)
        {
            if (checkboxchange == false)
            {
                ATM.Checked = true;
                creditcard.Checked = false;

            }
            else
            {
                ATM.Checked = false;

            }
            checkboxchange = !checkboxchange;
        }

        private void Payby_MouseLeave(object sender, EventArgs e)
        {
            Panel leavepanel = (Panel)sender;
            leavepanel.BackColor = Color.DimGray;
        }

        private void Payby_MouseEnter(object sender, EventArgs e)
        {
            Panel enterpanel = (Panel)sender;
            enterpanel.BackColor = Color.FromArgb(64, 64, 64);
        }

        private async Task MethodAsync()
        {
            await FindProjectWithProjectID();
            await FindProductWithProjectID();
            await FindOtherProductWithProjectID();
        }

        private async Task FindProjectWithProjectID()
        {
            var result = await queryDB.FindDataWithProjectID(projectID);

            foreach (var item in result)
            {
                lblProjectTitle.Text = item.project.ProjectName;

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

        private async Task FindProductWithProjectID()
        {
            var result = await queryDB.FindProductWithProductID(productID);

            PanelProducts pp = new PanelProducts();

            string pathPd = Application.StartupPath + "\\Images\\ProductsThumbnail";
            pp.productImagePath = pathPd + "\\" + result.Thumbnail;
            pp.productName = result.ProductName;
            currentProductPrice = result.Price;
            lblTotalPrice.Text = currentProductPrice.ToString("C0");
            labelprice.Text = currentProductPrice.ToString("C0");
            pp.productPrice = currentProductPrice.ToString("C0");
            pp.productIventory = "剩餘 " + result.Inventory.ToString() + " 組";
            int sponsor = result.Quantity - result.Inventory;
            pp.productSelled = "已被贊助 " + sponsor.ToString() + " 組";
            pp.productDescription = result.ProductDescription;

            flowLayoutPanel2.Controls.Add(pp);
        }

        private async Task FindOtherProductWithProjectID()
        {
            var result = await queryDB.FindProductsWithProjectID(projectID);

            foreach (var item in result)
            {

                if (item.ProductID == productID)
                {
                    continue;
                }
                if (item.Inventory == 0)   //todo增加數量0條件
                {
                    continue;
                }
                Addtopurchase ad = new Addtopurchase();

                if (!string.IsNullOrEmpty(item.Thumbnail))
                {
                    string path = Application.StartupPath + "\\Images\\ProductsThumbnail";
                    ad.productpic.Image = new Bitmap(path + "\\" + item.Thumbnail);
                    ad.productpic.SizeMode = PictureBoxSizeMode.Zoom;
                }

                ad.Tag = item;
                ad.productname = item.ProductName;
                ad.price = ((int)item.Price).ToString("C0");
                ad.description = item.ProductDescription;
                ad.Inventory = "剩餘 " + item.Inventory + " 件";
                int Sponsored = item.Quantity - item.Inventory;
                ad.alreadySponsored.Text = "已被贊助 " + Sponsored + "/" + item.Quantity + " 次";
                ad.checkedchange += CheckedState;

                flowAddtopurchase.Controls.Add(ad);
            }

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

        private void btnbackToSponsor_Click(object sender, EventArgs e)
        {
            FrmSponsor sponsor = new FrmSponsor(projectID);
            sponsor.MdiParent = this.MdiParent as FrmHomepage;
            sponsor.Dock = DockStyle.Fill;
            sponsor.Show();
            this.Close();
        }

        private void CheckedState(Products _product)
        {
            if (checkedList.Contains(_product))
            {
                checkedList.Remove(_product);
            }
            else
            {
                checkedList.Add(_product);
            }

            addToPurchase = 0;

            foreach (var item in checkedList)
            {
                addToPurchase += item.Price;
            }

            if (checkedList.Count == 0)
            {
                totalProductPrice = currentProductPrice;
            }

            lblAddtopurchase.Text = addToPurchase.ToString("C0");

            totalProductPrice = currentProductPrice + addToPurchase;

            lblTotalPrice.Text = totalProductPrice.ToString("C0");
        }

        private void NOAddPurchases(int paymentMethod)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    Orders addOrder = new Orders()
                    {
                        MemberID = cum.member.MemberID,
                        OrderDate = DateTime.Now,
                        ShipDate = DateTime.Now.AddDays(7),
                        ShipmentStatusID = 1,
                        PaymentMethodID = paymentMethod,
                        PaymentStatusID = 1,
                        //Donate = donate
                    };
                    db.Orders.Add(addOrder);
                    db.SaveChanges();

                    int newOrderID = addOrder.OrderID;

                    decimal x;

                    if (totalProductPrice == 0)
                    {
                        x = currentProductPrice;
                    }
                    else
                    {
                        x = totalProductPrice;
                    }

                    OrderDetails addOrderDetail = new OrderDetails()
                    {
                        OrderID = newOrderID,
                        ProductID = productID,
                        Price = x,
                        Count = 1,
                    };

                    db.OrderDetails.Add(addOrderDetail);

                    var productEdit = db.Products.FirstOrDefault(p => p.ProductID == productID);
                    if (productEdit.Inventory == 0) //TODO 如剩餘總數為0
                    {
                        productEdit.Inventory = 0;

                        FrmMyMessageBox mms = new FrmMyMessageBox();
                        mms.msg = "商品已無庫存";
                        mms.ShowDialog();
                        return;
                    }
                    if (productEdit != null && productEdit.Inventory > 0)
                    {
                        productEdit.Inventory -= 1;
                    }


                    db.SaveChanges();

                    ts.Complete();
                    FrmMyMessageBox mm = new FrmMyMessageBox();
                    mm.msg = "交易已完成，感謝您的贊助";
                    mm.ShowDialog();

                    FrmTransactionDetails ftd = new FrmTransactionDetails();
                    TransactionDetails td = new TransactionDetails();

                    ftd.lblDate.Text = DateTime.Now.ToString();
                    ftd.lblDonate.Text = donate.ToString("C0");
                    td.productName.Text = productEdit.ProductName;
                    td.productPrice.Text = currentProductPrice.ToString("C0");
                    ftd.flpDateils.Controls.Add(td);
                    ftd.ShowDialog();



                }

                catch (TransactionAbortedException)
                {
                    FrmMyMessageBox mm = new FrmMyMessageBox();
                    mm.msg = "交易失敗";
                    mm.ShowDialog();
                    throw;
                }

            }
            FrmLiked fk = new FrmLiked(cum.member.MemberID);
            fk.MdiParent = this.MdiParent as FrmHomepage;
            fk.Dock = DockStyle.Fill;
            fk.Show();
            this.Close();

        }


        private void HasAddPurchases(int paymentMethod)
        {

            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    Orders addOrder = new Orders()
                    {
                        MemberID = cum.member.MemberID,                    //TODO 還未帶入會員ID變數 先用變數取代
                        OrderDate = DateTime.Now,
                        ShipDate = DateTime.Now.AddDays(7),
                        ShipmentStatusID = 1,
                        PaymentMethodID = paymentMethod,
                        PaymentStatusID = 1,
                        //Donate = donate
                    };
                    db.Orders.Add(addOrder);
                    db.SaveChanges();

                    var newOrderID = addOrder.OrderID;

                    int[] a = new int[checkedList.Count];

                    for (int i = 0; i < checkedList.Count; i++)
                    {
                        a[i] = checkedList[i].ProductID;
                    }

                    var result = from p in db.Products
                                 where a.Contains(p.ProductID)
                                 select p;

                    foreach (var p in result)
                    {
                        OrderDetails Addtopurchase = new OrderDetails()
                        {
                            OrderID = newOrderID,
                            ProductID = p.ProductID,
                            Price = p.Price,
                            Count = 1,

                        };
                        db.OrderDetails.Add(Addtopurchase);
                    }



                    OrderDetails addOrderDetail = new OrderDetails()    //主要商品
                    {
                        OrderID = newOrderID,      //帶入剛新增的OrderID
                        ProductID = productID,
                        Price = (totalProductPrice - addToPurchase), //TODO 如要加上加碼功能這裡要取總額而不是商品售價
                        Count = 1,
                    };

                    db.OrderDetails.Add(addOrderDetail);

                    var product = db.Products.FirstOrDefault(p => p.ProductID == productID);

                    checkedList.Add(product);
                    List<string> allProductName = new List<string>();
                    List<decimal> allPRoductPrice = new List<decimal>();
                    for (int i = 0; i < checkedList.Count; i++)
                    {
                        int productIDToFind = checkedList[i].ProductID;
                        var pEdit = db.Products.FirstOrDefault(p => p.ProductID == productIDToFind);
                        allProductName.Add(pEdit.ProductName);
                        allPRoductPrice.Add(pEdit.Price);
                        if (pEdit.Inventory == 0) //TODO 如剩餘總數為0
                        {
                            pEdit.Inventory = 0;
                            FrmMyMessageBox mms = new FrmMyMessageBox();
                            mms.msg = "訂單含庫存為0的商品，請重新操作";
                            mms.ShowDialog();
                            return;
                        }
                        if (pEdit != null && pEdit.Inventory > 0)
                        {
                            pEdit.Inventory -= 1;
                        }

                    }


                    db.SaveChanges();

                    ts.Complete();
                    FrmMyMessageBox mm = new FrmMyMessageBox();
                    mm.msg = "交易完成，感謝您的贊助";
                    mm.ShowDialog();


                    FrmTransactionDetails ftd = new FrmTransactionDetails();

                    for (int i = 0; i < checkedList.Count; i++)
                    {

                        TransactionDetails td = new TransactionDetails();
                        ftd.lblDate.Text = DateTime.Now.ToString();
                        ftd.lblDonate.Text = donate.ToString("C0");
                        td.productName.Text = allProductName[i];
                        td.productPrice.Text = allPRoductPrice[i].ToString("C0");
                        ftd.flpDateils.Controls.Add(td);

                    }
                    ftd.ShowDialog();






                }

                catch (TransactionAbortedException)
                {
                    FrmMyMessageBox mm = new FrmMyMessageBox();
                    mm.msg = "交易失敗";
                    mm.ShowDialog();
                    throw;
                }
            }
            FrmLiked fk = new FrmLiked(cum.member.MemberID);
            fk.MdiParent = this.MdiParent as FrmHomepage;
            fk.Dock = DockStyle.Fill;
            fk.Show();
            this.Close();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if (creditcard.Checked == false && ATM.Checked == false)
            {
                FrmMyMessageBox mm = new FrmMyMessageBox();
                mm.msg = "請先選擇付款方式";
                mm.ShowDialog();
                return;
            }

            if (creditcard.Checked == true && ATM.Checked == true)
            {
                FrmMyMessageBox mm = new FrmMyMessageBox();
                mm.msg = "請選定一種付款方式";
                mm.ShowDialog();
                return;
            }

            if (creditcard.Checked == true)
            {
                paymentMethod = 1;
            }
            else if (ATM.Checked == true)
            {
                paymentMethod = 3;
            }
            FrmMyMessageBoxYesNo myn = new FrmMyMessageBoxYesNo();
            myn.msg = " 確定要進行交易嗎? ";
            myn.ShowDialog();
            //DialogResult = MessageBox.Show(" 確定要進行交易嗎? ", "交易提示", MessageBoxButtons.OKCancel);
            if (myn.DialogResult == DialogResult.Cancel)
            {
                FrmMyMessageBox mm = new FrmMyMessageBox();
                mm.msg = "交易已取消";
                mm.ShowDialog();
                return;
            }



            if (checkedList.Count == 0)
            {
                NOAddPurchases(paymentMethod);
            }
            else
            {
                HasAddPurchases(paymentMethod);
            }
        }

        private void textBox6_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {

                if (decimal.TryParse(textBox6.Text, out decimal value) && value >= 0)
                {
                    if (value == 0 && checkedList.Count == 0)
                    {
                        lblTotalPrice.Text = currentProductPrice.ToString("c0");
                    }

                    if (value == 0 && checkedList.Count > 0)
                    {
                        lblTotalPrice.Text = (addToPurchase + currentProductPrice).ToString("C0");
                    }

                    if (checkedList.Count == 0)
                    {
                        totalProductPrice = currentProductPrice + value;
                        lblTotalPrice.Text = totalProductPrice.ToString("C0");
                        donate = value;
                    }

                    if (checkedList.Count > 0)
                    {
                        totalProductPrice = currentProductPrice + addToPurchase + value;
                        lblTotalPrice.Text = totalProductPrice.ToString("C0");
                        donate = value;
                    }
                }
            }
        }
    }
}
