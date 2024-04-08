using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace prjMumu_MidtermProject.Models
{
    public class PageBefore
    {
        private static string _page;
        public string page { get { return _page; } set { _page = value; } }
        private static string _address;
        public string address { get { return _address; } set { _address = value; } }
    }
}
