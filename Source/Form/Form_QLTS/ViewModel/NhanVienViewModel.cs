using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form_QLTS.ViewModel
{
    public class NhanVienViewModel
    {
        public int MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public Nullable<bool> GioiTinh { get; set; }
        public Nullable<System.DateTime> NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string HinhAnh { get; set; }
        public Nullable<System.DateTime> NgayBatDau { get; set; }
    }
}
