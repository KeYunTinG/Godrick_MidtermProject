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
    public partial class FrmTransactionDetails : Form
    {
        public FrmTransactionDetails()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public FlowLayoutPanel flpDateils
        { get { return flpTransactionDateils; } set { flpTransactionDateils = value; } } 

        public Label lblDate
        { get { return lbltDate; } set { lbltDate = value; }  }

        public Label lblDonate
        { get { return label3 ; } set { label3 = value; } }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
