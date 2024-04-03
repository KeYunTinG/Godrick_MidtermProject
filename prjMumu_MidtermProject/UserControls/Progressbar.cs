using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjMumu_MidtermProject.UserControls
{
    public partial class Progressbar : UserControl
    {
        private int _progress { get; set; }
        private int i = 0;
        public int progress
        {
            get { return _progress; }
            set
            {
                if (value < 0)
                {
                    value = 0;
                }

                if (value >= 100)
                {
                    value = 100;
                }

                _progress = value;
            }
        }


        public Progressbar()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            panel2.Width += 2;

            label1.ForeColor = Color.Black;
            i++;
            label1.Text = i.ToString();

            if (panel2.Width == _progress * 2)
            {

                i = _progress;
                label1.Text = i.ToString();
                panel2.Controls.Add(label1);
                label1.Location = new Point(0, 0);
                timer1.Stop();
            }

            if (_progress >= 100)
            {
                panel2.BackColor = Color.Gold;
            }
        }
    }
}
