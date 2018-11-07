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
    public class HoaDonsController : ApiController
    {
        private QuanLyTraSuaEntities db = new QuanLyTraSuaEntities();

        // GET: api/HoaDons
        public IHttpActionResult GetHoaDons()
        {
            var hoaDonList = db.HoaDons.Select(v => new HoaDonViewModel { MaHoaDon = v.MaHoaDon, MaKhachHang = v.MaKhachHang, MaNhanVien = v.MaNhanVien, MoTa = v.MoTa, NgayTao = v.NgayTao });
            return Ok(hoaDonList);
        }

        // GET: api/HoaDons/5
        [ResponseType(typeof(HoaDon))]
        public IHttpActionResult GetHoaDon(int id)
        {
            var hoaDonList = db.HoaDons.Where(v => v.MaHoaDon == id).Select(v => new HoaDonViewModel { MaHoaDon = v.MaHoaDon, MaKhachHang = v.MaKhachHang, MaNhanVien = v.MaNhanVien, MoTa = v.MoTa, NgayTao = v.NgayTao });

            if (hoaDonList == null)
            {
                return NotFound();
            }

            return Ok(hoaDonList.ToList());
        }

        // PUT: api/HoaDons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHoaDon(HoaDon hoaDon)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (id != hoaDon.MaHoaDon)
            //{
            //    return BadRequest();
            //}
            var hoaDonCurrent = db.HoaDons.SingleOrDefault(v => v.MaHoaDon == hoaDon.MaHoaDon);

            if (hoaDonCurrent != null)
            {

                db.Entry(hoaDon).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!HoaDonExists(id))
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

        // POST: api/HoaDons
        [ResponseType(typeof(HoaDon))]
        public IHttpActionResult PostHoaDon(HoaDon hoaDon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HoaDons.Add(hoaDon);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hoaDon.MaHoaDon }, hoaDon);
        }

        // DELETE: api/HoaDons/5
        [ResponseType(typeof(HoaDon))]
        public IHttpActionResult DeleteHoaDon(int id)
        {
            HoaDon hoaDon = db.HoaDons.Find(id);
            if (hoaDon == null)
            {
                return NotFound();
            }

            db.HoaDons.Remove(hoaDon);
            db.SaveChanges();

            return Ok(hoaDon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HoaDonExists(int id)
        {
            return db.HoaDons.Count(e => e.MaHoaDon == id) > 0;
        }
    }
}