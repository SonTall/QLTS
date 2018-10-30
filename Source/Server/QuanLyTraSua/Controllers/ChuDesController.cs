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

namespace QuanLyTraSua.Controllers
{
    public class ChuDesController : ApiController
    {
        private QuanLyTraSuaEntities db = new QuanLyTraSuaEntities();

        // GET: api/ChuDes
        //[ResponseType(typeof(ChuDe))]
        [HttpGet]
        [Route("~/api/ChuDes")]
        public IHttpActionResult GetChuDe()
        {
            var listChuDe = db.ChuDes.Select(v => new Models.ChuDeViewModel { MaChuDe = v.MaChuDe, TenChuDe = v.TenChuDe, MoTa = v.MoTa });
            return Ok(listChuDe);
        }

        // GET: api/ChuDes/5
        [ResponseType(typeof(ChuDe))]
        public IHttpActionResult GetChuDe(int id)
        {
            ChuDe chuDe = db.ChuDes.Find(id);
            if (chuDe == null)
            {
                return NotFound();
            }

            return Ok(chuDe);
        }

        // PUT: api/ChuDes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutChuDe(int id, ChuDe chuDe)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != chuDe.MaChuDe)
            {
                return BadRequest();
            }

            db.Entry(chuDe).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChuDeExists(id))
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