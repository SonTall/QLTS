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
    public class HoaDonChiTietsController : ApiController
    {
        private QuanLyTraSuaEntities db = new QuanLyTraSuaEntities();

        // GET: api/HoaDonChiTiets
        public IHttpActionResult GetHoaDonChiTiets()
        {
            var hoaDonChiTietList = db.HoaDonChiTiets.Select(v => new HoaDonChiTietViewModel { MaHoaDon = v.MaHoaDon, MaLuaChon = v.MaLuaChon, SoLuong = v.SoLuong });
            if (hoaDonChiTietList != null)
            {
                return Ok(hoaDonChiTietList);

            }
            else
            {
                return BadRequest();
            }
        }

        // GET: api/HoaDonChiTiets/5
        [ResponseType(typeof(HoaDonChiTiet))]
        public IHttpActionResult GetHoaDonChiTiet(int id)
        {
            var hoaDonChiTiet = db.HoaDonChiTiets.Where(v => v.MaHoaDon == id).Select(v => new HoaDonChiTietViewModel { MaHoaDon = v.MaHoaDon, MaLuaChon = v.MaLuaChon, SoLuong = v.SoLuong });

            if (hoaDonChiTiet == null)
            {
                return NotFound();
            }

            return Ok(hoaDonChiTiet.ToList());
        }

        // PUT: api/HoaDonChiTiets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHoaDonChiTiet(HoaDonChiTiet hoaDonChiTiet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var hoaDonCurrent = db.HoaDonChiTiets.SingleOrDefault(v => v.MaHoaDon == hoaDonChiTiet.MaHoaDon);

            if (hoaDonCurrent != null)
            {


                db.Entry(hoaDonCurrent).State = EntityState.Detached;
                db.Entry(hoaDonChiTiet).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //    if (!HoaDonChiTietExists(id))
                    //    {
                    //        return NotFound();
                    //    }
                    //    else
                    //    {
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

        // POST: api/HoaDonChiTiets
        [ResponseType(typeof(HoaDonChiTiet))]
        public IHttpActionResult PostHoaDonChiTiet(HoaDonChiTiet hoaDonChiTiet)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HoaDonChiTiets.Add(hoaDonChiTiet);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (HoaDonChiTietExists(hoaDonChiTiet.MaHoaDon))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = hoaDonChiTiet.MaHoaDon }, hoaDonChiTiet);
        }

        // DELETE: api/HoaDonChiTiets/5
        [ResponseType(typeof(HoaDonChiTiet))]
        public IHttpActionResult DeleteHoaDonChiTiet(int id)
        {
            HoaDonChiTiet hoaDonChiTiet = db.HoaDonChiTiets.Find(id);
            if (hoaDonChiTiet == null)
            {
                return NotFound();
            }

            db.HoaDonChiTiets.Remove(hoaDonChiTiet);
            db.SaveChanges();

            return Ok(hoaDonChiTiet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HoaDonChiTietExists(int id)
        {
            return db.HoaDonChiTiets.Count(e => e.MaHoaDon == id) > 0;
        }
    }
}