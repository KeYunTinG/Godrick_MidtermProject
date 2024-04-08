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

namespace prjMumu_MidtermProject.UserControls
{
    public partial class CommentBoxSub : UserControl
    {
        public CommentBoxSub()
        {
            InitializeComponent();
        }

        private SubComments _subComment;
        public SubComments subComment
        {
            get { return _subComment; }
            set
            {
                _subComment = value;
                this.lblName.Text = _subComment.Members.Nickname;
                if (!string.IsNullOrEmpty(_subComment.Members.Thumbnail))
                {
                    this.pbThumbnail.Image = new Bitmap(Application.StartupPath + @"\Images\membersThumbnail\" + _subComment.Members.Thumbnail);
                }
                this.lblCommentTime.Text = _subComment.Date.Value.ToString("yyyy/MM/dd\nHH:mm");
                this.lblMessage.Text = _subComment.SubCommentMsg;
            }
        }
    }
}
