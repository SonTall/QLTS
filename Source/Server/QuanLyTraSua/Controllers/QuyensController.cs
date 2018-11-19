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
    public class QuyensController : ApiController
    {
        private QuanLyTraSuaEntities db = new QuanLyTraSuaEntities();

        // GET: api/Quyens
        public IQueryable<Quyen> GetQuyens()
        {
            return db.Quyens;
        }

        // GET: api/Quyens/5
        [ResponseType(typeof(Quyen))]
        public IHttpActionResult GetQuyen(int id)
        {
            Quyen quyen = db.Quyens.Find(id);
            if (quyen == null)
            {
                return NotFound();
            }

            return Ok(quyen);
        }

        // PUT: api/Quyens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQuyen(int id, Quyen quyen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != quyen.MaQuyen)
            {
                return BadRequest();
            }

            db.Entry(quyen).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QuyenExists(id))
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

        // POST: api/Quyens
        [ResponseType(typeof(Quyen))]
        public IHttpActionResult PostQuyen(Quyen quyen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Quyens.Add(quyen);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = quyen.MaQuyen }, quyen);
        }

        // DELETE: api/Quyens/5
        [ResponseType(typeof(Quyen))]
        public IHttpActionResult DeleteQuyen(int id)
        {
            Quyen quyen = db.Quyens.Find(id);
            if (quyen == null)
            {
                return NotFound();
            }

            db.Quyens.Remove(quyen);
            db.SaveChanges();

            return Ok(quyen);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QuyenExists(int id)
        {
            return db.Quyens.Count(e => e.MaQuyen == id) > 0;
        }
    }
}