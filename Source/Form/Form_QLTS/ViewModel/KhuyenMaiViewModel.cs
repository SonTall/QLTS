using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Form_QLTS.ViewModel
{
    class KhuyenMaiViewModel
    {
        public int MaKhuyenMai { get; set; }
        public string TenKhuyenMai { get; set; }
        public Nullable<double> GiaTri { get; set; }
        public string MoTa { get; set; }
        public Nullable<System.DateTime> NgayBatDau { get; set; }
        public Nullable<System.DateTime> NgayKetThuc { get; set; }

        //public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
