using Form_QLTS.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_QLTS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ClearRenderbody()
        {
            while (pnlBody.Controls.Count > 0) pnlBody.Controls[pnlBody.Controls.Count - 1].Dispose();
            //foreach (Control ctrl in RenderBody.Controls) ctrl.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ClearRenderbody();
            Home home = new Home();
            home.TopLevel = false;
            home.Width = pnlBody.Width;
            home.Height = pnlBody.Height;
            home.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            pnlBody.Controls.Add(home);
            home.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
