using prjMumu_MidtermProject.UserControls;
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
    public partial class FrmMessage : Form
    {
        private Members member;
        public FrmMessage(Members member)
        {
            InitializeComponent();
            this.member = member;
        }

        private void FrmMessage_Load(object sender, EventArgs e)
        {
            MemberPanel mp = new MemberPanel(member);
            this.Controls.Add(mp);
            mp.Dock = DockStyle.Fill;
            int x = MousePosition.X;
            int y = MousePosition.Y;
            this.Location = new Point(x, y);
        }
    }
}
