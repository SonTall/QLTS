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

        /// <summary>
        /// thong ke tong san pham ban duoc theo thang yeu cau`
        /// </summary>
        /// <param name="thang"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ThongKe/TongHoaDonTheoThang")]
        public IHttpActionResult GetTongSanPhamBanTheoThang(int thang)
        {
            using (var db = new QuanLyTraSuaEntities())
            {
                var hoaDonList = db.ThongKeSanPhamTheoCacThang().SingleOrDefault(v => v.thang == thang);

                if (hoaDonList == null)
                {
                    return Content(HttpStatusCode.NotFound, "Thang nhap vao khong co san pham duoc ban");
                }
                else
                {
                    var result = (int)hoaDonList.soluong;
                    return Ok(result);
                }
            };
        }

        /// <summary>
        /// thong ke san pham da ban duoc theo cac' thang'
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ThongKe/TongHoaDonTheoThang")]
        public IHttpActionResult GetTongSanPhamBanTheoThang()
        {
            using (var db = new QuanLyTraSuaEntities())
            {
                var hoaDonList = db.ThongKeSanPhamTheoCacThang();
                if (hoaDonList == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(hoaDonList.ToList());
                }
            }
        }

        /// <summary>
        /// thong ke tong tien da ban duoc theo thang yeu cau`
        /// </summary>
        /// <param name="thang"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ThongKe/TongHoaDonTheoThang")]
        public IHttpActionResult GetTongTienBanDuocTheoThang(int nam, int thang)
        {
            using (QuanLyTraSuaEntities db = new QuanLyTraSuaEntities())
            {
                var tongTien = db.ThongKeTienBanDuocTheoThang().SingleOrDefault(v => v.thang == thang && v.nam == nam);
                if (tongTien == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(tongTien);
                }
            };
        }

        /// <summary>
        /// thong ke tong tien da ban duoc theo cac thang
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/ThongKe/TongTienBanDuocTheoThang")]
        public IHttpActionResult GetTongTienBanDuocTheoThang()
        {
            using (QuanLyTraSuaEntities db = new QuanLyTraSuaEntities())
            {
                var tongTien = db.ThongKeTienBanDuocTheoThang().ToList();

                if (tongTien == null)
                {
                    return BadRequest();
                }
                else
                {
                    return Ok(tongTien);
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
                if(tongHoaDon != null)
                {
                    return Ok(tongHoaDon.Count());
                }
                else
                {
                    return BadRequest();
                }
            }
        }

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
        #endregion

        #region LietKe
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
        #endregion
    }
}

