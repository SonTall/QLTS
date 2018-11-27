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
using QuanLyTraSua.Models;

namespace QuanLyTraSua.Controllers
{
    public class KhachHangsController : ApiController
    {
        private QuanLyTraSuaEntities db = new QuanLyTraSuaEntities();

        // GET: api/KhachHangs
        public IHttpActionResult GetKhachHangs()
        {
            var khachHangList = db.KhachHangs.Select(v => new KhachHangViewModel { MaKhachHang = v.MaKhachHang, TenKhachHang = v.TenKhachHang, GioiTinh = v.GioiTinh, NgaySinh = v.NgaySinh, DiaChi = v.DiaChi, SDT = v.SDT, Email = v.Email, HinhAnh = v.HinhAnh });
            if (khachHangList != null)
                return Ok(khachHangList);
            else
                return BadRequest();

        }

        // GET: api/KhachHangs/5
        [ResponseType(typeof(KhachHang))]
        public IHttpActionResult GetKhachHang(int id)
        {
            var khachHangList = db.KhachHangs.Where(v => v.MaKhachHang == id).Select(v => new KhachHangViewModel { MaKhachHang = v.MaKhachHang, TenKhachHang = v.TenKhachHang, GioiTinh = v.GioiTinh, NgaySinh = v.NgaySinh, DiaChi = v.DiaChi, SDT = v.SDT, Email = v.Email, HinhAnh = v.HinhAnh });

            if (khachHangList == null)
            {
                return NotFound();
            }

            return Ok(khachHangList.ToList());
        }

        // PUT: api/KhachHangs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKhachHang(KhachHang khachHang)
        {


            var khachHangCurrent = db.KhachHangs.SingleOrDefault(v => v.MaKhachHang == khachHang.MaKhachHang);

            if (khachHangCurrent != null)
            {
                db.Entry(khachHangCurrent).State = EntityState.Detached;
                db.Entry(khachHang).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!KhachHangExists(id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    throw;
                    //}
                }
            }
            else
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/KhachHangs
        [ResponseType(typeof(KhachHang))]
        public IHttpActionResult PostKhachHang(KhachHang khachHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KhachHangs.Add(khachHang);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = khachHang.MaKhachHang }, khachHang);
        }

        // DELETE: api/KhachHangs/5
        [ResponseType(typeof(KhachHang))]
        public IHttpActionResult DeleteKhachHang(int id)
        {
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return NotFound();
            }

            db.KhachHangs.Remove(khachHang);
            db.SaveChanges();

            return Ok(khachHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KhachHangExists(int id)
        {
            return db.KhachHangs.Count(e => e.MaKhachHang == id) > 0;
        }
    }
}