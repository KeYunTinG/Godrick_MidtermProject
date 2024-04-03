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
    public partial class TransactionDetails : UserControl
    {
        public TransactionDetails()
        {
            InitializeComponent();
        }
        public Label productName
        {
            get { return lblProductName; }
            set { lblProductName = value; }
        }

        public Label productPrice
        {
            get { return lblPrice; }
            set { lblPrice = value; }
        }
    }
}
