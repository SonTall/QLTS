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
    public partial class SanPham : Form
    {
        CallAPI requestData = new CallAPI();
        public SanPham()
        {
            InitializeComponent();
        }

        private void SanPham_Load(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = requestData.GetListSanPham();
            dgvTopping.DataSource = requestData.GetListTopping();
        }
    }
}
