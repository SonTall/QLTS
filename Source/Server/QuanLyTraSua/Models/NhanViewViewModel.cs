using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyTraSua.Models
{
    public class NhanViewViewModel
    {
        public int MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public bool? GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
        public string Email { get; set; }
        public string HinhAnh { get; set; }
        public DateTime? NgayBatDau { get; set; }
    }
}