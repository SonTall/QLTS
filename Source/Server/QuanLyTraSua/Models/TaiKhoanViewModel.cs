using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyTraSua.Models
{
    public class TaiKhoanViewModel
    {
        public int MaTaiKhoan { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public Nullable<int> MaNhanVien { get; set; }
        public Nullable<int> MaKhachHang { get; set; }
    }
}