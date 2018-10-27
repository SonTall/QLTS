using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyTraSua.Models
{
    public class HoaDonViewModel
    {
        public int MaHoaDon { get; set; }
        public int? MaKhachHang { get; set; }
        public int? MaNhanVien { get; set; }
        public DateTime? NgayTao { get; set; }
        public string MoTa { get; set; }
    }
}