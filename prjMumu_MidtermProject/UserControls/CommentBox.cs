using slnMumu_MidtermProject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace slnMumu_MidtermProject
{
    public partial class CommentBox : UserControl
    {
        private Comments _comment;
        public Comments comment
        {
            get { return _comment; }
            set
            {
                _comment = value;
                this.lblName.Text = _comment.Members.Username;
                if (!string.IsNullOrEmpty(_comment.Members.Thumbnail))
                {
                    this.pbThumbnail.Image = new Bitmap(Application.StartupPath + @"\Image\membersThumbnail\" + _comment.Members.Thumbnail);
                }
                this.lblCommentTime.Text = _comment.Date.Value.ToString("yyyy/MM/dd\nHH:mm");
                this.lblMessage.Text = _comment.CommentMsg;
            }
        }

        public CommentBox()
        {
            InitializeComponent();
            
        }
    }
}
