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
    public partial class MemberPanel : UserControl
    {
        private Members member;

        public MemberPanel(Members member)
        {
            InitializeComponent();
            this.member = member;
        }

        private void MemberPanel_Load(object sender, EventArgs e)
        {
            string path = Application.StartupPath + "\\Images\\membersThumbnail\\" + member.Thumbnail;

            pictureBox1.Image = new Bitmap(path);


            lblUsername.Text = member.Nickname;
            richTextBox1.ReadOnly = true;
            richTextBox1.Text = member.MemberIntroduction;
        }
    }
}
