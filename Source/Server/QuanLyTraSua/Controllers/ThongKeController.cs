using QuanLyTraSua.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Xml.Linq;

namespace QuanLyTraSua.Controllers
{
    public class ThongKeController : ApiController
    {

        #region ThongKe
        /// <summary>
        /// Tong? so luong lua. chon dang co trong csdl
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ThongKe/GetSumLuaChon")]
        public IHttpActionResult GetSumLuaChon()
        {
            using (var db = new QuanLyTraSuaEntities())
            {
                var result = db.MaLuaChons.Count();

                return Ok(result);
            }
        }


        /// <summary>
        /// Dem so luong san pham trong bang san pham
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        //[ActionName("CountSanPham")]
        [Route("api/ThongKe/GetAllSanPham")]
        public IHttpActionResult GetAllSanPham()
        {
            using (var db = new QuanLyTraSuaEntities())
            {
                var result = db.SanPhams.Count();

                return Ok(result);
            }
        }

        /// <summary>
        /// Dem so luong topping trong bang topping
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ThongKe/GetAllTopping")]
        //[ActionName("CountTopping")]
        public IHttpActionResult GetAllTopping()
        {
            using (var db = new QuanLyTraSuaEntities())
            {
                var result = db.Toppings.Count();

                return Content(HttpStatusCode.OK, result);
            }
        }

        /// <summary>
        /// thong ke tong hoa don theo thang yeu cau`
        /// </summary>
        /// <param name="thang"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ThongKe/GetSumHoaDonTheoThang")]
        public IHttpActionResult GetSumHoaDonTheoThang(int thang)
        {
            using (QuanLyTraSuaEntities db = new QuanLyTraSuaEntities())
            {

                var result = db.ThongKeHoaDonTheoCacThang().Where(v => v.thang == thang);

                if (result == null)
                {
                    // return Request.CreateResponse(HttpStatusCode.NotFound, "Thang nhap vao khong co don hang");
                    return Content(HttpStatusCode.NotFound, "Thang nhap vao khong co don hang");
                }
                else
                {
                    return Ok(result.ToList().Count());
                }

            };
        }

        /// <summary>
        /// thong ke tong hoa don da ban theo cac' thang'
        /// </summary>
        [HttpGet]
        [Route("api/ThongKe/TongHoaDonTheoThang")]
        public IHttpActionResult GetTongHoaDonTheoThang()
        {
            using (QuanLyTraSuaEntities db = new QuanLyTraSuaEntities())
            {
                var result = db.ThongKeHoaDonTheoCacThang().ToList();
                if (result == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(result);
                }
            }
        }

        ///// <summary>
        ///// thong ke tong san pham ban duoc theo thang yeu cau`
        ///// </summary>
        ///// <param name="thang"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("api/ThongKe/TongHoaDonTheoThang")]
        //public IHttpActionResult GetTongSanPhamBanTheoThang(int thang)
        //{
        //    using (var db = new QuanLyTraSuaEntities())
        //    {
        //        var hoaDonList = db.ThongKeSanPhamTheoCacThang().SingleOrDefault(v => v.thang == thang);

        //        if (hoaDonList == null)
        //        {
        //            return Content(HttpStatusCode.NotFound, "Thang nhap vao khong co san pham duoc ban");
        //        }
        //        else
        //        {
        //            var result = (int)hoaDonList.soluong;
        //            return Ok(result);
        //        }
        //    };
        //}

        ///// <summary>
        ///// thong ke san pham da ban duoc theo cac' thang'
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("api/ThongKe/TongHoaDonTheoThang")]
        //public IHttpActionResult GetTongSanPhamBanTheoThang()
        //{
        //    using (var db = new QuanLyTraSuaEntities())
        //    {
        //        var hoaDonList = db.ThongKeSanPhamTheoCacThang();
        //        if (hoaDonList == null)
        //        {
        //            return BadRequest();
        //        }
        //        else
        //        {
        //            return Ok(hoaDonList.ToList());
        //        }
        //    }
        //}

        ///// <summary>
        ///// thong ke tong tien da ban duoc theo thang yeu cau`
        ///// </summary>
        ///// <param name="thang"></param>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("api/ThongKe/TongHoaDonTheoThang")]
        //public IHttpActionResult GetTongTienBanDuocTheoThang(int nam, int thang)
        //{
        //    using (QuanLyTraSuaEntities db = new QuanLyTraSuaEntities())
        //    {
        //        var tongTien = db.ThongKeTienBanDuocTheoThang().SingleOrDefault(v => v.thang == thang && v.nam == nam);
        //        if (tongTien == null)
        //        {
        //            return BadRequest();
        //        }
        //        else
        //        {
        //            return Ok(tongTien);
        //        }
        //    };
        //}

        ///// <summary>
        ///// thong ke tong tien da ban duoc theo cac thang
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("api/ThongKe/TongTienBanDuocTheoThang")]
        //public IHttpActionResult GetTongTienBanDuocTheoThang()
        //{
        //    using (QuanLyTraSuaEntities db = new QuanLyTraSuaEntities())
        //    {
        //        var tongTien = db.ThongKeTienBanDuocTheoThang().ToList();

        //        if (tongTien == null)
        //        {
        //            return BadRequest();
        //        }
        //        else
        //        {
        //            return Ok(tongTien);
        //        }
        //    }
        //}




        /// <summary>
        /// dem tong so khuyen mai dang duoc ap dung
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ThongKe/TongKhuyenMaiApDungDangApDung")]
        public IHttpActionResult GetTongKhuyenMaiApDungDangApDung()
        {
            using (QuanLyTraSuaEntities db = new QuanLyTraSuaEntities())
            {
                DateTime dateTime = DateTime.Now;
                var tongKhuyenMai = db.KhuyenMais.Where(v => v.NgayBatDau.Value <= dateTime && v.NgayKetThuc.Value > dateTime);

                if (tongKhuyenMai != null)
                {
                    return Ok(tongKhuyenMai.Count());
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        /// <summary>
        /// tong so hoa don ban duoc theo ngay
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ThongKe/TongHoaDonTheoNgay")]
        public IHttpActionResult GetTongHoaDonTheoNgay()
        {
            using (QuanLyTraSuaEntities db = new QuanLyTraSuaEntities())
            {
                DateTime dateTime = DateTime.Now;
                var tongHoaDon = db.HoaDons.Where(v => v.NgayTao.Value.Year == dateTime.Year && v.NgayTao.Value.Month == dateTime.Month && v.NgayTao.Value.Day == dateTime.Day);
                if (tongHoaDon != null)
                {
                    return Ok(tongHoaDon.Count());
                }
                else
                {
                    return BadRequest();
                }
            }
        }
        #endregion

        #region LietKe
        /// <summary>
        /// liet ke danh sach hoa don theo thang
        /// </summary>
        /// <param name="nam"></param>
        /// <param name="thang"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ThongKe/GetListHoaDonByThang")]
        // [ActionName("GetListHoaDonByThang")]
        public IHttpActionResult GetListHoaDonByThang(int nam, int thang)
        {
            using (QuanLyTraSuaEntities db = new QuanLyTraSuaEntities())
            {
                var hoaDonList = db.HoaDons.Select(v => new HoaDonViewModel
                {
                    MaHoaDon = v.MaHoaDon,
                    MaKhachHang = v.MaKhachHang,
                    MaNhanVien = v.MaNhanVien,
                    MoTa = v.MoTa,
                    NgayTao = v.NgayTao
                    //var hoaDonList = db.HoaDons.Select(v => new
                    //{
                    //     v.MaHoaDon,
                    //     v.NgayTao
                }).Where(v => v.NgayTao.Value.Month == thang && v.NgayTao.Value.Year == nam);


                if (hoaDonList != null)
                {
                    return Ok(hoaDonList.ToList());
                }
                else
                    return NotFound();
            }
        }

        /// <summary>
        /// liet ke danh sach hoa don theo cac thang theo ma nhan viens
        /// </summary>
        /// <param name="nam"></param>
        /// <param name="thang"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ThongKe/GetListHoaDonByThangByMaNhanVien")]
        // [ActionName("GetListHoaDonByThang")]
        public IHttpActionResult GetListHoaDonByThangByMaNhanVien(int maNhanVien)
        {
            using (QuanLyTraSuaEntities db = new QuanLyTraSuaEntities())
            {
                var result = db.ThongKeHoaDonTheoCacThangByMaNhanVien(maNhanVien);

                if (result != null)
                {
                    return Ok(result.ToList());
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        /// <summary>
        /// liet ke danh sach khuyen mai dang duoc ap dung
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ThongKe/GetListKhuyenMaiDangDuocApDung")]
        public IHttpActionResult GetListKhuyenMaiDangDuocApDung()
        {
            using (QuanLyTraSuaEntities db = new QuanLyTraSuaEntities())
            {
                DateTime dateTime = DateTime.Now;
                var tongKhuyenMai = db.KhuyenMais.Where(v => v.NgayBatDau.Value <= dateTime && v.NgayKetThuc.Value > dateTime).Select(n => new KhuyenMaiViewModel
                {
                    MaKhuyenMai = n.MaKhuyenMai,
                    TenKhuyenMai = n.TenKhuyenMai,
                    GiaTri = n.GiaTri,
                    MoTa = n.MoTa,
                    NgayBatDau = n.NgayBatDau,
                    NgayKetThuc = n.NgayKetThuc,
                });


                if (tongKhuyenMai != null)
                {
                    return Ok(tongKhuyenMai.ToList());
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        /// <summary>
        /// liet ke danh sach san pham? loc. theo ma~ chu? de`
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ThongKe/GetListSanPhamByMaChuDe")]
        public IHttpActionResult GetListSanPhamByMaChuDe(int maChuDe)
        {
            using (QuanLyTraSuaEntities db = new QuanLyTraSuaEntities())
            {
                var sanPhamList = db.SanPhams.Where(v => v.MaChuDe == maChuDe).Select(n => new SanPhamViewModel
                {
                    MaSanPham = n.MaSanPham,
                    TenSanPham = n.TenSanPham,
                    KichCo = n.KichCo,
                    DonGia = n.DonGia,
                    HinhAnh = n.HinhAnh,
                    MaChuDe = n.MaChuDe
                });

                if (sanPhamList != null)
                {
                    return Ok(sanPhamList.ToList());
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        /// <summary>
        /// liet ke danh sach cac chu de`
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ThongKe/GetListChuDe")]
        public IHttpActionResult GetListChuDe()
        {
            using (QuanLyTraSuaEntities db = new QuanLyTraSuaEntities())
            {
                var chuDeList = db.ChuDes.OrderBy(v => v.TenChuDe).Select(n => new ChuDeViewModel
                {
                    MaChuDe = n.MaChuDe,
                    TenChuDe = n.TenChuDe,
                    MoTa = n.MoTa
                });

                if (chuDeList != null)
                {
                    return Ok(chuDeList.ToList());
                }
                else
                {
                    return BadRequest();
                }
            }
        }

        #region cac' loai. get list hoa don theo cac tieu chi
        /// <summary>
        /// liet ke danh sach hoa don ban duoc theo ngay theo ma nhan vien
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ThongKe/GetListHoaDonTrongNgayByMaNhanVien")]
        public IHttpActionResult GetListHoaDonTrongNgayByMaNhanVien(int maNhanVien)
        {
            using (var db = new QuanLyTraSuaEntities())
            {
                DateTime dateTime = DateTime.Now;
                var result = db.HoaDons.Where(v => v.MaNhanVien == maNhanVien && (v.NgayTao.Value.Year == dateTime.Year && v.NgayTao.Value.Month == dateTime.Month && v.NgayTao.Value.Day == dateTime.Day)).Select(v => new HoaDonViewModel
                {
                    MaHoaDon = v.MaHoaDon,
                    MaKhachHang = v.MaKhachHang,
                    MaNhanVien = v.MaNhanVien,
                    NgayTao = v.NgayTao,
                    MoTa = v.MoTa
                });

                if (result != null)
                {
                    return Ok(result.ToList());
                }
                else
                {
                    return NotFound();
                }
            }
        }

        /// <summary>
        /// liet ke danh sach hoa don ban duoc trong khoang thoi gian theo ma nhan vien- phuc vu form
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ThongKe/GetListHoaDonTrongKhoangThoiGianByMaNhanVien")]
        public IHttpActionResult GetListHoaDonByPeriodOfTime(int maNhanVien, int date1, int month1, int year1, int date2, int month2, int year2)
        {
            using (var db = new QuanLyTraSuaEntities())
            {
                //DateTime tuNgay = Convert.ToDateTime(nhanVienBanHang.TuNgay);
                // DateTime denNgay = Convert.ToDateTime(nhanVienBanHang.DenNgay);
                var result = db.HoaDons
                    .Where(v => v.MaNhanVien == maNhanVien
                    && (v.NgayTao.Value.Year >= year1
                    && v.NgayTao.Value.Month >= month1
                    && v.NgayTao.Value.Day >= date1)
                    && (v.NgayTao.Value.Year <= year2
                    && v.NgayTao.Value.Month <= month2
                    && v.NgayTao.Value.Day <= date2))
                    .Select(v => new HoaDonViewModel
                    {
                        MaHoaDon = v.MaHoaDon,
                        MaKhachHang = v.MaKhachHang,
                        MaNhanVien = v.MaNhanVien,
                        NgayTao = v.NgayTao,
                        MoTa = v.MoTa
                    });

                if (result != null)
                {
                    return Ok(result.ToList());
                }
                else
                {
                    return NotFound();
                }
            }
        }


        /// <summary>
        /// liet ke danh sach hoa don ban duoc theo thang chi? dinh. theo ma~ nhan vien.  - phuc vu form
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ThongKe/GetListHoaDonTheoThangByMaNhanVien")]
        public IHttpActionResult GetListHoaDonByMonth(int maNhanVien, int month)
        {
            using (var db = new QuanLyTraSuaEntities())
            {
                DateTime now = DateTime.Now;
                var result = db.HoaDons
                    .Where(v => v.MaNhanVien == maNhanVien
                    && v.NgayTao.Value.Year == now.Year
                    && v.NgayTao.Value.Month == month)
                    .Select(v => new HoaDonViewModel
                    {
                        MaHoaDon = v.MaHoaDon,
                        MaKhachHang = v.MaKhachHang,
                        MaNhanVien = v.MaNhanVien,
                        NgayTao = v.NgayTao,
                        MoTa = v.MoTa
                    });

                if (result != null)
                {
                    return Ok(result.ToList());
                }
                else
                {
                    return NotFound();
                }
            }
        }

        /// <summary>
        /// liet ke danh sach hoa don ban duoc theo thang theo ma~ nhan vien.  - phuc vu form
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ThongKe/GetListHoaDonByMaNhanVien")]
        public IHttpActionResult GetListHoaDonByMaNhanVien(NhanVienBanHang nhanVienBanHang)
        {
            using (var db = new QuanLyTraSuaEntities())
            {
                DateTime now = DateTime.Now;
                var result = db.HoaDons
                    .Where(v => v.MaNhanVien == nhanVienBanHang.MaNhanVien)
                    .Select(v => new HoaDonViewModel
                    {
                        MaHoaDon = v.MaHoaDon,
                        MaKhachHang = v.MaKhachHang,
                        MaNhanVien = v.MaNhanVien,
                        NgayTao = v.NgayTao,
                        MoTa = v.MoTa
                    });

                if (result != null)
                {
                    return Ok(result.ToList());
                }
                else
                {
                    return NotFound();
                }
            }
        }
        #endregion

        #region bang? hoa' don form ma fail mat' roi` :(
        /// <summary>
        /// danh sach san pham? theo ma hoa don
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ThongKe/GetListSanPhamByMaHoaDon")]
        public IHttpActionResult GetListSanPhamByMaHoaDon(int maHoaDon)
        {
            using (var db = new QuanLyTraSuaEntities())
            {
                var maLuaChon = db.HoaDonChiTiets.SingleOrDefault(v => v.MaHoaDon == maHoaDon).MaLuaChon;
                var maSanPham = db.LuaChons.Where(v => v.MaLuaChon == maLuaChon).ToList();
                var result = new List<SanPhamViewModel>();

                maSanPham.ForEach(v =>
                {
                    var temp = db.SanPhams.Single(n => n.MaSanPham == v.MaSanPham);
                    var resultItem = new SanPhamViewModel()
                    {
                        MaSanPham = temp.MaSanPham,
                        TenSanPham = temp.TenSanPham,
                        KichCo = temp.KichCo,
                        DonGia = temp.DonGia,
                        HinhAnh = temp.HinhAnh,
                        MaChuDe = temp.MaChuDe
                    };
                    result.Add(resultItem);
                });

                return Ok(result.ToList());
            }
        }

        ///// <summary>
        ///// danh sach topping theo ma hoa don
        ///// </summary>
        ///// <returns></returns>
        //[HttpGet]
        //[Route("api/ThongKe/GetListToppingByMaHoaDon")]
        //public IHttpActionResult GetListToppingByMaHoaDon(int maHoaDon)
        //{
        //    using (var db = new QuanLyTraSuaEntities())
        //    {
        //        var maLuaChon = db.HoaDonChiTiets.Where(v => v.MaHoaDon == maHoaDon);
        //        var maTopping = new List<LuaChon>();
        //        maLuaChon.ToList().ForEach(v =>
        //        {
        //            maTopping.AddRange(db.LuaChons.Where(n => n.MaLuaChon == v.MaHoaDon).Distinct(p => p.).ToList());

        //        });

        //        var maTopping = db.LuaChons.Where(v => v.MaLuaChon == maLuaChon).ToList();
        //        var result = new List<ToppingViewModel>();

        //        maTopping.ForEach(v =>
        //        {
        //            var temp = db.Toppings.Single(n => n.MaTopping == v.MaTopping);
        //            var resultItem = new ToppingViewModel()
        //            {
        //                MaTopping = temp.MaTopping,
        //                TenTopping = temp.TenTopping,
        //                DonGia = temp.DonGia,
        //                HinhAnh = temp.HinhAnh
        //            };
        //            result.Add(resultItem);
        //        });

        //        return Ok(result.ToList());
        //    }
        //}


        /// <summary>
        /// danh sach topping theo ma hoa don
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ThongKe/GetSumLuaChonByMaHoaDon")]
        public IHttpActionResult GetSumLuaChonByMaHoaDon(int maHoaDon)
        {
            using (var db = new QuanLyTraSuaEntities())
            {
                var maLuaChon = db.HoaDonChiTiets.SingleOrDefault(v => v.MaHoaDon == maHoaDon).MaLuaChon;
                var maTopping = db.LuaChons.Where(v => v.MaLuaChon == maLuaChon).ToList();
                var result = new List<ToppingViewModel>();

                maTopping.ForEach(v =>
                {
                    var temp = db.Toppings.Single(n => n.MaTopping == v.MaTopping);
                    var resultItem = new ToppingViewModel()
                    {
                        MaTopping = temp.MaTopping,
                        TenTopping = temp.TenTopping,
                        DonGia = temp.DonGia,
                        HinhAnh = temp.HinhAnh
                    };
                    result.Add(resultItem);
                });

                return Ok(result.ToList());
            }
        }
        #endregion

        #endregion
    }
}

