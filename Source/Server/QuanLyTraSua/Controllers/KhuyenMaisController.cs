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
    public class KhuyenMaisController : ApiController
    {
        private QuanLyTraSuaEntities db = new QuanLyTraSuaEntities();

        // GET: api/KhuyenMais
        [HttpGet]
        [Route("~/api/KhuyenMais")]
        public IHttpActionResult GetKhuyenMais()
        {
            var khuyenMaiList = db.KhuyenMais.Select(v => new KhuyenMaiViewModel
            {
                MaKhuyenMai = v.MaKhuyenMai,
                TenKhuyenMai = v.TenKhuyenMai,
                GiaTri = v.GiaTri,
                MoTa = v.MoTa,
                NgayBatDau = v.NgayBatDau,
                NgayKetThuc = v.NgayKetThuc
            });

            if (khuyenMaiList == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(khuyenMaiList.ToList());
            }


        }

        // GET: api/KhuyenMais/5
        [ResponseType(typeof(KhuyenMai))]
        public IHttpActionResult GetKhuyenMai(int id)
        {
            var khuyenMaiList = db.KhuyenMais.Where(v => v.MaKhuyenMai == id).Select(v => new KhuyenMaiViewModel
            {
                MaKhuyenMai = v.MaKhuyenMai,
                TenKhuyenMai = v.TenKhuyenMai,
                GiaTri = v.GiaTri,
                MoTa = v.MoTa,
                NgayBatDau = v.NgayBatDau,
                NgayKetThuc = v.NgayKetThuc
            });

            if (khuyenMaiList == null)
            {
                return NotFound();
            }

            return Ok(khuyenMaiList.ToList());
        }

        // PUT: api/KhuyenMais/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKhuyenMai(KhuyenMai khuyenMai)
        {
            var khuyenMaiCurrent = db.KhuyenMais.SingleOrDefault(v => v.MaKhuyenMai == khuyenMai.MaKhuyenMai);

            if (khuyenMaiCurrent != null)
            {
                db.Entry(khuyenMaiCurrent).State = EntityState.Detached;
                db.Entry(khuyenMai).State = EntityState.Modified;

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

        // POST: api/KhuyenMais
        [ResponseType(typeof(KhuyenMai))]
        public IHttpActionResult PostKhuyenMai(KhuyenMai khuyenMai)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.KhuyenMais.Add(khuyenMai);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = khuyenMai.MaKhuyenMai }, khuyenMai);
        }

        // DELETE: api/KhuyenMais/5
        [ResponseType(typeof(KhuyenMai))]
        public IHttpActionResult DeleteKhuyenMai(int id)
        {
            KhuyenMai khuyenMai = db.KhuyenMais.Find(id);
            if (khuyenMai == null)
            {
                return NotFound();
            }

            db.KhuyenMais.Remove(khuyenMai);
            db.SaveChanges();

            return Ok(khuyenMai);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KhuyenMaiExists(int id)
        {
            return db.KhuyenMais.Count(e => e.MaKhuyenMai == id) > 0;
        }
    }
}