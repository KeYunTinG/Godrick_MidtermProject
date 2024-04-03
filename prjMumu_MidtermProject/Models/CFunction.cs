using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace slnMumu_MidtermProject
{
    internal class CFunction
    {
    }
    public class Money
    {
        public string MoneyProcess(string value)
        {
            try
            {
                decimal ic = decimal.Parse(value);
                string c = ic.ToString("C0");
                return c;
            }
            catch (FormatException)
            {
                return "Invalid input"; 
            }
        }

    }
}
