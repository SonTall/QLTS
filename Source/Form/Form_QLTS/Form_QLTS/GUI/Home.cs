using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Form_QLTS.GUI
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void btnThemHoaDon_Click(object sender, EventArgs e)
        {
            using (ThemHoaDon form2 = new ThemHoaDon())
            {

                //if (form2.ShowDialog() == DialogResult.OK)
                //{
                //    someControlOnForm1.Text = form2.TheValue;
                //}
                //this.Container.Add(form2);
                MessageBox.Show("haha");
                form2.ShowDialog();
            }
            
        }
    }
}
