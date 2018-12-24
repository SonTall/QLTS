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
    public partial class HoaDon : Form
    {
        CallAPI requestData = new CallAPI();
        TaiKhoan taiKhoan = new TaiKhoan();

        public HoaDon(TaiKhoan _taiKhoan)
        {
            InitializeComponent();
            taiKhoan = _taiKhoan;
        }

        private void btnSuaThongTin_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void btnXem_Click(object sender, EventArgs e)
        {
            var nhanVienBanHang = new NhanVienBanHang();
            if(cbLuaChon.Text == "" || cbLuaChon.Text == null)
            {
                MessageBox.Show("Chọn tiêu chí muốn xem!");
            }
            if(cbLuaChon.Text.Equals("Liệt kê theo các tháng."))
            {
                nhanVienBanHang.MaNhanVien = taiKhoan.Id;
                nhanVienBanHang.TheoThang = null;
                nhanVienBanHang.TuNgay = null;
                nhanVienBanHang.DenNgay = null;

                var data = requestData.GetListHoaDonCacThangByMaNhanVien(nhanVienBanHang);
                dgvHoaDon.DataSource = data;
            }
            if (cbLuaChon.Text.Equals("Xem theo tháng được lựa chọn."))
            {
                nhanVienBanHang.MaNhanVien = taiKhoan.Id;
                nhanVienBanHang.TheoThang = Convert.ToInt32(txtThang.Text.ToString());
                nhanVienBanHang.TuNgay = null;
                nhanVienBanHang.DenNgay = null;

                var data = requestData.GetListHoaDonTrongThangByMaNhanVien(nhanVienBanHang);
                dgvHoaDon.DataSource = data;
           
            }
            if (cbLuaChon.Text.Equals("Khoảng thời gian."))
            {
                nhanVienBanHang.MaNhanVien = taiKhoan.Id;
                nhanVienBanHang.TheoThang = Convert.ToInt32(txtThang.Text.ToString());
                nhanVienBanHang.TuNgay = dbTuNgay.Value;
                nhanVienBanHang.DenNgay = dtDenNgay.Value;

                var data = requestData.GetListHoaDonTrongKhoangThoiGianByMaNhanVien(nhanVienBanHang);
                dgvHoaDon.DataSource = data;
            }
           
        }

        private void txtThang_TextChanged(object sender, EventArgs e)
        {

        }

        private void HoaDon_Load(object sender, EventArgs e)
        {
           // dgvHoaDon.DataSource(requestData.GetListHoaDonTrongThangByMaNhanVien());
        }
    }
}
