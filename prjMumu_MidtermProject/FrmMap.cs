using prjMumu_MidtermProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Web.WebView2;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace prjMumu_MidtermProject
{
    public partial class FrmMap : Form
    {
        private PageBefore pb;
        private WebView2 wb;

        public FrmMap()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            pb = new PageBefore();
            wb = new WebView2();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnGetAddress_Click(object sender, EventArgs e)
        {
            string mapUrl = wb.Source.ToString();

            int start = mapUrl.IndexOf("https://www.google.com.tw/maps/place/");

            if (start == -1) return;

            int startIndex = start + "https://www.google.com.tw/maps/place/".Length;
            int endIndex = mapUrl.IndexOf("/@");

            if (startIndex <= 0) return;

            if (endIndex == -1)
            {
                endIndex = mapUrl.Length;
            }

            string addrRaw = mapUrl.Substring(startIndex, endIndex - startIndex);

            string addr = addrRaw.Replace('+', ',');

            richTextBox1.Text = addr;
        }

        private void FrmMap_Load(object sender, EventArgs e)
        {
            panel1.Controls.Add(wb);
            wb.Dock = DockStyle.Fill;
            wb.Source = new Uri("https://www.google.com.tw/maps/place/台北市");
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            pb.address = richTextBox1.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void 貼上ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = Clipboard.GetText();
        }

        private void 全選ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void 複製ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }
    }
}
