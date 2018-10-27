using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyTraSua.Models
{
    public class SanPhamViewModel
    {
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string KichCo { get; set; }
        public Nullable<int> MaChuDe { get; set; }
        public string HinhAnh { get; set; }
        public Nullable<decimal> DonGia { get; set; }
    }
}