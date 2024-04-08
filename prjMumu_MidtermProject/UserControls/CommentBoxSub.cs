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
using System.Xml.Linq;

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
                if (_subComment.Date.Value.AddDays(1) < DateTime.Now)
                    this.lblCommentTime.Text = $"{(DateTime.Now - _subComment.Date.Value).Days} 天前";
                else if (_subComment.Date.Value.AddHours(1) < DateTime.Now)
                    this.lblCommentTime.Text = $"{(DateTime.Now - _subComment.Date.Value).Hours} 小時前";
                else
                    this.lblCommentTime.Text = $"1 小時內";
                this.lblMessage.Text = _subComment.SubCommentMsg;
            }
        }
    }
}
