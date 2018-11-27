using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form_QLTS.ViewModel
{
    public class HoaDonViewModel
    {
        public int MaHoaDon { get; set; }
        public Nullable<int> MaKhachHang { get; set; }
        public Nullable<int> MaNhanVien { get; set; }
        public Nullable<System.DateTime> NgayTao { get; set; }
        public string MoTa { get; set; }

        public HoaDonViewModel(int maHoaDon, int maNhanVien, string moTa)
        {
            MaHoaDon = maHoaDon;
            MaKhachHang = null;
            MaNhanVien = maNhanVien;
            NgayTao = DateTime.Now;
            MoTa = moTa;
        }
    }
}
