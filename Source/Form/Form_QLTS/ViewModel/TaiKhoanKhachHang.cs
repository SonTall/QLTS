using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form_QLTS.ViewModel
{
    public class TaiKhoanKhachHang
    {
        public int MaTaiKhoan { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public Nullable<int> MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public Nullable<bool> GioiTinh { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string HinhAnh { get; set; }
        public List<string> Quyen { get; set; }
    }
}
