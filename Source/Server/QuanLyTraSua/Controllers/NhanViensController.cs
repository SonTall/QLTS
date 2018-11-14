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
    public class NhanViensController : ApiController
    {
        private QuanLyTraSuaEntities db = new QuanLyTraSuaEntities();

        // GET: api/NhanViens
        public IHttpActionResult GetNhanViens()
        {
            var nhanVienList = db.NhanViens.Select(v => new NhanViewViewModel { MaNhanVien = v.MaNhanVien, TenNhanVien = v.TenNhanVien, GioiTinh = v.GioiTinh, NgaySinh = v.NgaySinh, DiaChi = v.DiaChi, SDT = v.SDT, Email = v.Email, NgayBatDau = v.NgayBatDau, HinhAnh = v.HinhAnh });
            if (nhanVienList != null)
                return Ok(nhanVienList.ToList());
            else
                return BadRequest();
        }

        // GET: api/NhanViens/5
        [ResponseType(typeof(NhanVien))]
        public IHttpActionResult GetNhanVien(int id)
        {
            var nhanVienList = db.NhanViens.Where(v => v.MaNhanVien == id).Select(v => new NhanViewViewModel { MaNhanVien = v.MaNhanVien, TenNhanVien = v.TenNhanVien, GioiTinh = v.GioiTinh, NgaySinh = v.NgaySinh, DiaChi = v.DiaChi, SDT = v.SDT, Email = v.Email, NgayBatDau = v.NgayBatDau, HinhAnh = v.HinhAnh });

            if (nhanVienList == null)
            {
                return NotFound();
            }

            return Ok(nhanVienList.ToList());
        }

        // PUT: api/NhanViens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNhanVien(NhanVien nhanVien)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (id != nhanVien.MaNhanVien)
            //{
            //    return BadRequest();
            //}
            var nhanVienCurrent = db.NhanViens.SingleOrDefault(v => v.MaNhanVien == nhanVien.MaNhanVien);
            if (nhanVienCurrent != null)
            {


                db.Entry(nhanVien).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!NhanVienExists(id))
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

        // POST: api/NhanViens
        [ResponseType(typeof(NhanVien))]
        public IHttpActionResult PostNhanVien(NhanVien nhanVien)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NhanViens.Add(nhanVien);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = nhanVien.MaNhanVien }, nhanVien);
        }

        // DELETE: api/NhanViens/5
        [ResponseType(typeof(NhanVien))]
        public IHttpActionResult DeleteNhanVien(int id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            db.NhanViens.Remove(nhanVien);
            db.SaveChanges();

            return Ok(nhanVien);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NhanVienExists(int id)
        {
            return db.NhanViens.Count(e => e.MaNhanVien == id) > 0;
        }
    }
}