using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form_QLTS.ViewModel
{
    class LuaChonViewModel
    {
        public int MaLuaChon { get; set; }
        public int MaSanPham { get; set; }
        public Nullable<int> MaTopping { get; set; }

        public LuaChonViewModel(int maLuaChon, int maSanPham, int maTopping)
        {
            MaLuaChon = maLuaChon;
            MaSanPham = maSanPham;
            MaTopping = maTopping;
        }
    }
}
