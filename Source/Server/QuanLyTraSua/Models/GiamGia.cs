//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace QuanLyTraSua
//{
//    public class GiamGia
//    {
//        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
//        public GiamGia()
//        {
//            this.HoaDonChiTiets = new HashSet<HoaDonChiTiet>();
//            this.KhuyenMais = new HashSet<KhuyenMai>();
//        }

//        public int MaKhuyenMai { get; set; }
//        public int MaHoaDon { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<HoaDonChiTiet> HoaDonChiTiets { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
//        public virtual ICollection<KhuyenMai> KhuyenMais { get; set; }
//    }
//}