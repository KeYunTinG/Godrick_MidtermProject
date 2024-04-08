using prjMumu_MidtermProject;
using prjMumu_MidtermProject.UserControls;
using slnMumu_MidtermProject.FrmView;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace slnMumu_MidtermProject
{
    public partial class FrmAbout : Form
    {
        private CurrentUserManager cum;
        private Timer _timer;
        ProgressBar pb = new ProgressBar();
        public FrmAbout()
        {
            InitializeComponent();
            cum = new CurrentUserManager();
        }

        private void FrmAbout_Load(object sender, EventArgs e)
        {

           // ProgressBar pb = new ProgressBar();
            pb.Location = new Point(720, 400);
            pb.Width = 190;
            pb.Height = 30;
            this.Controls.Add(pb);
            setTimer();
        }
        private void setTimer()
        {
            //主頁換圖的計時器
            _timer = new Timer();
            _timer.Interval = 300;
            _timer.Tick += buttonStart_Click;
            _timer.Start();
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            // 設置進度條的最大值
            pb.Maximum = 100;

            // 設置每次增加的值
            pb.Step = 20;

            // 模擬進度條的進度變化
            for (int i = 0; i <= pb.Maximum; i += pb.Step)
            {
                System.Threading.Thread.Sleep(300);
                pb.PerformStep(); 
            }
            PTTButtonShow();
            _timer.Stop();
            _timer.Dispose();
        }

        private void PTTButtonShow()
        {
            Button btn1 = new Button();
            btn1.Location = new Point(750, 500);
            btn1.Width = 120;
            btn1.Height = 50;
            btn1.Text = "啟動!";
            btn1.Font = new Font("微軟正黑體", 12);
            btn1.Click += button1_Click;
            this.Controls.Add(btn1);
        }

        private void FrmAbout_Activated(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FrmShowPPT frmShowPPT = new FrmShowPPT();
            frmShowPPT.MdiParent = this.MdiParent as FrmHomepage;
            frmShowPPT.Dock = DockStyle.Fill;
            frmShowPPT.Show();
        }
    }
}
