using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using QuanLyTraSua;
using QuanLyTraSua.Attribute;
using QuanLyTraSua.Models;

namespace QuanLyTraSua.Controllers
{
    public class TaiKhoansController : ApiController
    {
        private QuanLyTraSuaEntities db = new QuanLyTraSuaEntities();

        [AuthorizeRoles("Admin")]
        [HttpGet]
        //[Route("api/TaiKhoans")]
        // GET: api/TaiKhoans
        public IHttpActionResult GetTaiKhoans()
        {
            var taiKhoanList = db.TaiKhoans.Select(v => new TaiKhoanViewModel
            {
                MaTaiKhoan = v.MaTaiKhoan,
                TenTaiKhoan = v.TenTaiKhoan,
                MatKhau = v.MatKhau,
                MaNhanVien = v.MaNhanVien,
                MaKhachHang = v.MaKhachHang
            });

            if (taiKhoanList != null)
            {
                return Ok(taiKhoanList);
            }
            else
            {
                return BadRequest();
            }
        }

        [AuthorizeRoles("Admin", "NhanVien", "KhachHang")]
        [HttpGet]
        // GET: api/TaiKhoans/5
        [ResponseType(typeof(TaiKhoan))]
        public IHttpActionResult GetTaiKhoan(int maTaiKhoan)
        {
            var taiKhoan = db.TaiKhoans.SingleOrDefault(v => v.MaTaiKhoan == maTaiKhoan);
            if (taiKhoan == null)
            {
                return NotFound();
            }
            else
            {
                var result = new TaiKhoanViewModel()
                {
                    MaTaiKhoan = taiKhoan.MaTaiKhoan,
                    TenTaiKhoan = taiKhoan.TenTaiKhoan,
                    MatKhau = taiKhoan.MatKhau,
                    MaNhanVien = taiKhoan.MaNhanVien,
                    MaKhachHang = taiKhoan.MaKhachHang
                };

                return Ok(result);
            }
        }

        [AuthorizeRoles("Admin", "NhanVien", "KhachHang")]
        // PUT: api/TaiKhoans/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTaiKhoan(TaiKhoan taiKhoan)
        {
            if (ModelState.IsValid)
            {
                var taiKhoanCurrent = db.TaiKhoans.SingleOrDefault(v => v.MaTaiKhoan == taiKhoan.MaTaiKhoan);

                if (taiKhoanCurrent != null)
                {
                    taiKhoanCurrent.MaKhachHang = taiKhoan.MaKhachHang;
                    taiKhoanCurrent.MaNhanVien = taiKhoan.MaNhanVien;
                    taiKhoanCurrent.TenTaiKhoan = taiKhoan.TenTaiKhoan;
                    taiKhoanCurrent.MatKhau = taiKhoan.MatKhau;
                    db.SaveChanges();
                }

                return Ok();
            }
            else
                return BadRequest("Not a valid model");

        }

        [AllowAnonymous]
        // POST: api/TaiKhoans
        [ResponseType(typeof(TaiKhoan))]
        public IHttpActionResult PostTaiKhoan(ThongTinTaiKhoan taiKhoan)
        {
            var taiKhoanCurrent = db.TaiKhoans.SingleOrDefault(v => v.TenTaiKhoan == taiKhoan.TenTaiKhoan);
            if (taiKhoanCurrent != null)
            {
                return BadRequest("Tên tài khoản đã tồn tại");
            }
            else
            {
                //validate mat khau
                // if(taiKhoan.MatKhau)
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // them thong tin vao bang? khach hang trc de? lay ma~ khach hang`
            KhachHang khachHangNew = new KhachHang
            {
                //MaKhachHang = -1,
                //TenKhachHang = taiKhoan.TenKhachHang,
                //GioiTinh = taiKhoan.GioiTinh,
                //NgaySinh = taiKhoan.NgaySinh,
                //DiaChi = taiKhoan.DiaChi,
                //Email = taiKhoan.Email,
                //SDT = taiKhoan.SDT,
                //HinhAnh = taiKhoan.HinhAnh
                // MaKhachHang = -1,
                //TenKhachHang = "x",
                TenKhachHang = taiKhoan.TenKhachHang,
                GioiTinh = taiKhoan.GioiTinh,
                NgaySinh = taiKhoan.NgaySinh,
                DiaChi = "x",
                Email = "x",
                SDT = "x",
                HinhAnh = "x",
            };
            db.KhachHangs.Add(khachHangNew);
            db.SaveChanges();
            // sau do them vao bang tai khoan? nhu bthg
            //TaiKhoan taiKhoanNew = new TaiKhoan { TenTaiKhoan = taiKhoan.TenTaiKhoan, MatKhau = taiKhoan.MatKhau, MaNhanVien = null ,MaKhachHang = khachHangNew.MaKhachHang };
            //db.TaiKhoans.Add(taiKhoanNew);

            //// cuoi cung them bang phan quyen`
            ////taiKhoan.Quyen.ForEach(v =>
            ////{
            ////    var quyenKhachHang = db.Quyens.Where(n => n.TenQuyen == n.TenQuyen);
            ////    quyenKhachHang.ToList().ForEach(n =>
            ////    {
            ////        db.PostPhanQuyen(taiKhoanNew.MaTaiKhoan, n.MaQuyen);
            ////    });

            ////});

            //db.SaveChanges();
            return Ok();
        }

        [AuthorizeRoles("Admin")]
        // DELETE: api/TaiKhoans/5
        [ResponseType(typeof(TaiKhoan))]
        public IHttpActionResult DeleteTaiKhoan(int id)
        {
            TaiKhoan taiKhoan = db.TaiKhoans.Find(id);
            if (taiKhoan == null)
            {
                return NotFound();
            }

            db.TaiKhoans.Remove(taiKhoan);
            db.SaveChanges();

            return Ok(taiKhoan);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaiKhoanExists(int id)
        {
            return db.TaiKhoans.Count(e => e.MaTaiKhoan == id) > 0;
        }
    }
}