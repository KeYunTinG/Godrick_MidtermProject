using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjMumu_MidtermProject
{
    public partial class FrmMyMessageBoxYesNo : Form
    {
        private string _msg;
        public string msg { get { return _msg; } set { _msg = value; } }

        
        public FrmMyMessageBoxYesNo()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.btnClose.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void FrmMyMessageBoxYesNo_Load(object sender, EventArgs e)
        {
            label1.Text = _msg;
        }
    }
}
