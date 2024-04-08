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

    public partial class PrjPBLong : UserControl
    {
        private Timer _timer;
        private int _PBValue;
        public Image Image
        {
            get
            {
                return this.pictureBox1.Image;
            }
            set
            {
                this.pictureBox1.Image = value;
            }
         }
        public string title
        {
            get
            {
                return this.label1.Text;
            }
            set
            {
                this.label1.Text = value;
            }
        }
        public string total
        {
            get
            {
                return this.label2.Text;
            }
            set
            {
                this.label2.Text = value;
            }
        }
        public string support
        {
            get
            {
                return this.label3.Text;
            }
            set
            {
                this.label3.Text = value;
            }
        }
        public int valueP
        {
            get
            {
                return _PBValue;
            }
            set
            {
                _PBValue = value;
            }
        }
        public PrjPBLong()
        {
            InitializeComponent();
            setTimer();
        }
        private void setTimer()
        {
            //主頁換圖的計時器
            _timer = new Timer();
            _timer.Interval = 30;
            _timer.Tick += _timer_Tick;
            _timer.Start();
        }

        private void _timer_Tick(object sender, EventArgs e)
        {
            if (this.cyberProgressBar1.Value < _PBValue)
                this.cyberProgressBar1.Value += 1;
            else
            {
                _timer.Stop();
                _timer.Dispose();
            }
        }
    }
}
