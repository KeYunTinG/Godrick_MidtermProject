using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slnMumu_MidtermProject
{
    public class CurrentUserManager
    {
        private static Members _member;
        private static string _currentUser;
        private static bool _isLogin = false;

        public Members member { get { return _member; } set { _member = value; } }
        public string currentUser { get { return _currentUser; } set { _currentUser = value; } }
        public bool isLogin { get { return _isLogin; } set { _isLogin = value; } }

    }
}
