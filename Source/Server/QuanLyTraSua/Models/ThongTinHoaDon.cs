using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyTraSua.Models
{
    public class ThongTinHoaDon
    {
        /// <summary>
        /// key: ma lua. chon, value: so luong.
        /// </summary>
        public Dictionary<int, int> LuaChon { get; set; }
        public Nullable<int> MaKhachHang { get; set; }
        public Nullable<int> MaNhanVien { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public string MoTa { get; set; }
    }
}