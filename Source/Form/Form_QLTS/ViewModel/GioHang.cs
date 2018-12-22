using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form_QLTS.ViewModel
{
    public class GioHang
    {
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public List<int> MaTopping { get; set; }
        public int SoLuong { get; set; }

        public GioHang()
        {
            MaSanPham = 0;
            MaTopping = new List<int>();
            SoLuong = 0;
        }

        public GioHang(int maSanPham, List<int> maTopping, int soLuong)
        {
            MaSanPham = maSanPham;
            MaTopping.AddRange(maTopping);
            SoLuong = soLuong;
        }

        /// <summary>
        /// xoa ma topping tu gio hang`
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool XoaTopping(int id)
        {
            bool check = false;
            MaTopping.Remove(id);
            return check;
        }

        /// <summary>
        /// them tooping vao gio hang`
        /// </summary>
        /// <param name="id"></param>
        public void ThemTopping(int id)
        {
            this.MaTopping.Add(id);
        }
    }
}
