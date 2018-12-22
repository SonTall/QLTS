using Form_QLTS.ViewModel;
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
    public partial class Home1 : Form
    {
        CallAPI requestData = new CallAPI();
        TaiKhoan taiKhoan = new TaiKhoan();

        List<KhuyenMaiViewModel> listKhuyenMai = new List<KhuyenMaiViewModel>();
        public Home1(TaiKhoan _taiKhoan)
        {
            InitializeComponent();
            taiKhoan = _taiKhoan;
        }

        public void ThongKeThread()
        {

        }

        private void Home_Load(object sender, EventArgs e)
        {
            lbNgay.Text = "Hóa đơn đã bán được ngày: " + DateTime.Now.ToString("dd/MM/yyyy");

            #region ThongKe

            // 4 o ben tren
            lbSoHoaDon.Text = requestData.GetTongHoaDonTheoNgay().ToString();
            lbSoSanPham.Text = requestData.GetTongSanPham().ToString();
            lbSoTopping.Text = requestData.GetTongTopping().ToString();
            lbLuaChon.Text = requestData.GetTongLuaChon().ToString();

            // bang khuyen mai dang duoc ap dung
            var _listKhuyenMai = requestData.GetListKhuyenMaiDangDuocApDung();
            dgvKhuyenMai.DataSource = _listKhuyenMai;
            listKhuyenMai.AddRange(_listKhuyenMai);

            // bang hoa' don theo ngay`
            dgvHoaDon.DataSource = requestData.GetListHoaDonTrongNgayByMaNhanVien(taiKhoan.Id);

            #endregion
        }
    }
}
