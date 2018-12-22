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
            var sanPham = db.SanPhams;
            var sanPhamList = new List<SanPhamViewModel>();
            if (sanPham != null)
            {
                sanPham.ToList().ForEach(v =>
                {
                    var tmp = new SanPhamViewModel()
                    {
                        MaSanPham = v.MaSanPham,
                        TenSanPham = v.TenSanPham,
                        KichCo = v.KichCo,
                        DonGia = v.DonGia,
                        HinhAnh = ImageTask.GetImage(v.HinhAnh),
                        MaChuDe = v.MaChuDe
                    };

                    sanPhamList.Add(tmp);
                });

                return Ok(sanPhamList.ToList());
            }
            else
            {
                return BadRequest();
            }
        }

        // GET: api/SanPhams/5
        [ResponseType(typeof(SanPham))]
        public IHttpActionResult GetSanPhams(int id)
        {

            var sanPham = db.SanPhams.SingleOrDefault(v => v.MaSanPham == id);

            if (sanPham == null)
            {
                return NotFound();
            }
            else
            {
                var sanPhamViewModel = new SanPhamViewModel()
                {
                    MaSanPham = sanPham.MaSanPham,
                    TenSanPham = sanPham.TenSanPham,
                    KichCo = sanPham.KichCo,
                    DonGia = sanPham.DonGia,
                    HinhAnh = ImageTask.GetImage(sanPham.HinhAnh),
                    MaChuDe = sanPham.MaChuDe
                };
                return Ok(sanPhamViewModel);
            }
        }

        // PUT: api/SanPhams/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSanPham(SanPham sanPham)
        {
            var sanPhamCurrent = db.SanPhams.SingleOrDefault(v => v.MaSanPham == sanPham.MaSanPham);

            if (sanPhamCurrent != null)
            {

                db.Entry(sanPhamCurrent).State = EntityState.Detached;
                db.Entry(sanPham).State = EntityState.Modified;

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