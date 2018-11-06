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
        RESTful requestData = new RESTful();
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

        private void bunifuCustomLabel2_Click(object sender, EventArgs e)
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            lbNgay.Text = "Hóa đơn đã bán được ngày: " + DateTime.Now.ToString("dd/MM/yyyy");

            lbSoHoaDon.Text = requestData.GetTongHoaDonTheoNgay().ToString();
            lbSoSanPham.Text = requestData.GetTongSanPham().ToString();
            lbSoTopping.Text = requestData.GetTongTopping().ToString();
            lbSoKhuyenMai.Text = requestData.GetTongKhuyenMaiDangApDung().ToString();
        }
    }
}
