using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyTraSua.Models
{
    public class NhanVienBanHang
    {
        public int MaNhanVien { get; set; }
        public DateTime? TuNgay { get; set; }
        public DateTime? DenNgay { get; set; }
        public int? TheoThang { get; set; }
        public bool? AllOf { get; set; }
        public bool? Now { get; set; }
    }
}