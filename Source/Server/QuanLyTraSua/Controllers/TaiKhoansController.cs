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
            var taiKhoanCurrent = db.TaiKhoans.SingleOrDefault(v => v.MaTaiKhoan == taiKhoan.MaTaiKhoan);

            if (taiKhoanCurrent != null)
            {

                db.Entry(taiKhoanCurrent).State = EntityState.Detached;
                db.Entry(taiKhoan).State = EntityState.Modified;


                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    throw;
                }
            }
            else
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        [AllowAnonymous]
        // POST: api/TaiKhoans
        [ResponseType(typeof(TaiKhoan))]
        public IHttpActionResult PostTaiKhoan(TaiKhoan taiKhoan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.TaiKhoans.Add(taiKhoan);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = taiKhoan.MaTaiKhoan }, taiKhoan);
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