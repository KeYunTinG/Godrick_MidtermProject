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
using static System.Net.Mime.MediaTypeNames;

namespace slnMumu_MidtermProject
{
    
    public partial class FrmProductList : Form
    {
        private int prjID;
        public FrmProductList(int prjID)
        {
            InitializeComponent();
            this.prjID = prjID;
        }

        private void FrmProductList_Load(object sender, EventArgs e)
        {
            using (ZecZecEntities db=new ZecZecEntities())
            {
                var prod=db.Products.Where(x=>x.ProjectID==prjID).ToList();
                string path = System.Windows.Forms.Application.StartupPath + "\\Images\\ProductsThumbnail";
                foreach (var product in prod)
                {
                    PictureBox pictureBox = new PictureBox
                    {
                        Image = new Bitmap(path + "\\" + product.Thumbnail),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Width = 400,
                        Height = 200,
                        Anchor = AnchorStyles.None,
                        Margin = new Padding(0, 50, 0, 30)
                    };
                    Label label = new Label
                    {
                        Text = product.ProductName,
                        AutoSize = true,
                        Anchor = AnchorStyles.None,
                        Margin = new Padding(0, 0, 0, 30)
                    };
                    Button btn1 = new Button
                    {
                        Text = "編輯商品",
                        Anchor = AnchorStyles.None,
                        Font = new Font("Microsoft JhengHei", 10F, FontStyle.Regular),
                        Width = 100,
                        Height = 50,
                        Margin = new Padding(0, 0, 0, 30)
                    };
                    btn1.Tag = product.ProductID;
                    btn1.Click += Btn1_Click;
                    button1.Tag = product.ProjectID;
                    FlowLayoutPanel panel = new FlowLayoutPanel
                    {
                        FlowDirection = FlowDirection.TopDown
                    };
                    panel.Height = 550;
                    panel.Width = 400;
                    panel.Controls.Add(pictureBox);
                    panel.Controls.Add(label);
                    panel.Controls.Add(btn1);
                    panel.BackColor = Color.LightGray;
                    flowLayoutPanel1.Controls.Add(panel);

                   
                }
            }
        }

        private void Btn1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            FrmEditProduct f = new FrmEditProduct((int)btn.Tag);
            f.MdiParent = this.MdiParent as FrmHomepage;
            f.Dock = DockStyle.Fill;
            f.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            FrmCreateNewPrd f=new FrmCreateNewPrd(prjID);
            f.MdiParent = this.MdiParent as FrmHomepage;
            f.Dock = DockStyle.Fill;
            f.Show();
            this.Close();
        }
    }
}
