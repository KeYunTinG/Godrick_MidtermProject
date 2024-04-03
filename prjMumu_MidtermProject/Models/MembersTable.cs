using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace slnMumu_MidtermProject.Models
{
    public class MembersTable
    {
        private Members _member;
        public Members member
        {
            get
            {
                if (_member == null)
                {
                    _member = new Members();
                }

                return _member;
            }

            set
            {
                _member = value;
            }
        }
    }
}
