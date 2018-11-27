using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form_QLTS.ViewModel
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

        public ThongTinHoaDon(Dictionary<int, int> luaChon, int maNhanVien, DateTime ngayTao, string moTa)
        {
            //MaHoaDon = maHoaDon;
            LuaChon = luaChon;
            MaNhanVien = maNhanVien;
            MaKhachHang = null;
            NgayTao = ngayTao;
            MoTa = moTa;
        }
    }
}
