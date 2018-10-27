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
    public class SanPhamsController : ApiController
    {
        private QuanLyTraSuaEntities db = new QuanLyTraSuaEntities();

        // GET: api/SanPhams
        public IHttpActionResult GetSanPhams()
        {
            var sanPhamList = db.SanPhams.Select(v => new SanPhamViewModel { MaSanPham = v.MaSanPham, TenSanPham = v.TenSanPham, KichCo = v.KichCo, DonGia = v.DonGia, HinhAnh = v.HinhAnh, MaChuDe = v.MaChuDe });
            return Ok(sanPhamList);
        }

        // GET: api/SanPhams/5
        [ResponseType(typeof(SanPham))]
        public IHttpActionResult GetSanPham(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return NotFound();
            }

            return Ok(sanPham);
        }

        // PUT: api/SanPhams/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSanPham(int id, SanPham sanPham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sanPham.MaSanPham)
            {
                return BadRequest();
            }

            db.Entry(sanPham).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SanPhamExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/SanPhams
        [ResponseType(typeof(SanPham))]
        public IHttpActionResult PostSanPham(SanPham sanPham)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SanPhams.Add(sanPham);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sanPham.MaSanPham }, sanPham);
        }

        // DELETE: api/SanPhams/5
        [ResponseType(typeof(SanPham))]
        public IHttpActionResult DeleteSanPham(int id)
        {
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return NotFound();
            }

            db.SanPhams.Remove(sanPham);
            db.SaveChanges();

            return Ok(sanPham);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SanPhamExists(int id)
        {
            return db.SanPhams.Count(e => e.MaSanPham == id) > 0;
        }
    }
}