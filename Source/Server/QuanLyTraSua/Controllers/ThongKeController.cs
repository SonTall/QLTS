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
        public IHttpActionResult CountSanPham()
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
        public IHttpActionResult CountTopping()
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
        public IHttpActionResult TongHoaDonTheoThang(int thang)
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
        public IHttpActionResult TongHoaDonTheoThang()
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
        public IHttpActionResult TongSanPhamBanTheoThang(int thang)
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
        public IHttpActionResult TongSanPhamBanTheoThang()
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
        public IHttpActionResult TongTienBanDuocTheoThang(int nam, int thang)
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
        public IHttpActionResult TongTienBanDuocTheoThang()
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

        #endregion

        #region LietKe
        #endregion
    }
}

