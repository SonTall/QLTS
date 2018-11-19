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
        string token;
        public Form1(string _token)
        {
            InitializeComponent();
            token = _token;
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

        private void btnTrangChu_Click(object sender, EventArgs e)
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

        private void btnHoaDon_Click(object sender, EventArgs e)
        {
            ClearRenderbody();
            HoaDon hoaDon = new HoaDon();
            hoaDon.TopLevel = false;
            hoaDon.Width = pnlBody.Width;
            hoaDon.Height = pnlBody.Height;
            hoaDon.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            pnlBody.Controls.Add(hoaDon);
            hoaDon.Show();
        }

        private void btnThongTin_Click(object sender, EventArgs e)
        {
            ClearRenderbody();
            ThongTinTaiKhoan thongTinTaiKhoan = new ThongTinTaiKhoan();
            thongTinTaiKhoan.TopLevel = false;
            thongTinTaiKhoan.Width = pnlBody.Width;
            thongTinTaiKhoan.Height = pnlBody.Height;
            thongTinTaiKhoan.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            pnlBody.Controls.Add(thongTinTaiKhoan);
            thongTinTaiKhoan.Show();
        }
    }
}
