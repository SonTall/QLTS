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
    public class ChuDesController : ApiController
    {
        private QuanLyTraSuaEntities db = new QuanLyTraSuaEntities();

        // GET: api/ChuDes
        //[ResponseType(typeof(ChuDe))]
        //[HttpGet]
        //[Route("~/api/ChuDes")]
        public IHttpActionResult GetChuDe()
        {
            var listChuDe = db.ChuDes.Select(v => new Models.ChuDeViewModel { MaChuDe = v.MaChuDe, TenChuDe = v.TenChuDe, MoTa = v.MoTa });

            if (listChuDe != null)
                return Ok(listChuDe.ToList());
            else
                return BadRequest();
        }

        // GET: api/ChuDes/5
        //[HttpGet]
        //[Route("~/api/ChuDes")]
        [ResponseType(typeof(ChuDe))]
        public IHttpActionResult GetChuDe(int id)
        {
            var chuDe = db.ChuDes.Where(v => v.MaChuDe == id).Select(v => new Models.ChuDeViewModel { MaChuDe = v.MaChuDe, TenChuDe = v.TenChuDe, MoTa = v.MoTa });

            if (chuDe == null)
            {
                return NotFound();
            }

            return Ok(chuDe.ToList());
        }

        // PUT: api/ChuDes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChuDe(ChuDe chuDe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //if (id != chuDe.MaChuDe)
            //{
            //    return BadRequest();
            //}
            var chuDeCurrent = db.ChuDes.SingleOrDefault(v => v.MaChuDe == chuDe.MaChuDe);

            if (chuDeCurrent != null)
            {

                db.Entry(chuDe).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!ChuDeExists(id))
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

        // POST: api/ChuDes
        [ResponseType(typeof(ChuDe))]
        public IHttpActionResult PostChuDe(ChuDe chuDe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ChuDes.Add(chuDe);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = chuDe.MaChuDe }, chuDe);
        }

        // DELETE: api/ChuDes/5
        [ResponseType(typeof(ChuDe))]
        public IHttpActionResult DeleteChuDe(int id)
        {
            ChuDe chuDe = db.ChuDes.Find(id);
            if (chuDe == null)
            {
                return NotFound();
            }

            db.ChuDes.Remove(chuDe);
            db.SaveChanges();

            return Ok(chuDe);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ChuDeExists(int id)
        {
            return db.ChuDes.Count(e => e.MaChuDe == id) > 0;
        }
    }
}