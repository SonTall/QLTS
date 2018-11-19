using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form_QLTS.ViewModel
{
    class TaiKhoanViewModel
    {
        public int MaTaiKhoan { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public Nullable<int> MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }

        public TaiKhoanViewModel()
        {
            MaTaiKhoan = 0;
            TenTaiKhoan = "";
            MatKhau = "";
            MaNhanVien = 0;
            TenNhanVien = "";
        }

        public TaiKhoanViewModel(int maTaiKhoan, string tenTaiKhoan, string matKhau, int maNhanVien, string tenNhanVien)
        {
            MaTaiKhoan = maTaiKhoan;
            TenTaiKhoan = tenTaiKhoan;
            MatKhau = matKhau;
            MaNhanVien = maNhanVien;
            TenNhanVien = tenNhanVien;
        }
    }
}
