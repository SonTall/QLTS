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
    public class LuaChonsController : ApiController
    {
        private QuanLyTraSuaEntities db = new QuanLyTraSuaEntities();

        // GET: api/LuaChons
        public IHttpActionResult GetLuaChons()
        {
            var luaChonList = db.LuaChons.Select(v => new LuaChonViewModel { MaLuaChon = v.MaLuaChon, MaSanPham = v.MaSanPham, MaTopping = v.MaTopping });
            if (luaChonList != null)
            {

                return Ok(luaChonList);
            }
            else
            {
                return BadRequest();
            }

        }

        // GET: api/LuaChons/5
        [ResponseType(typeof(LuaChon))]
        public IHttpActionResult GetLuaChon(int id)
        {
            var luaChonList = db.LuaChons.Where(v => v.MaLuaChon == id).Select(v => new LuaChonViewModel { MaLuaChon = v.MaLuaChon, MaSanPham = v.MaSanPham, MaTopping = v.MaTopping });

            if (luaChonList == null)
            {
                return NotFound();
            }

            return Ok(luaChonList.ToList());
        }

        // PUT: api/LuaChons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLuaChon(LuaChon luaChon)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //if (id != luaChon.MaLuaChon)
            //{
            //    return BadRequest();
            //}
            var luaChonCurrent = db.LuaChons.SingleOrDefault(v => v.MaLuaChon == luaChon.MaLuaChon);
            if (luaChonCurrent != null)
            {
                db.Entry(luaChon).State = EntityState.Modified;

                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!LuaChonExists(id))
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

        // POST: api/LuaChons
        [ResponseType(typeof(LuaChon))]
        public IHttpActionResult PostLuaChon(LuaChon luaChon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LuaChons.Add(luaChon);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = luaChon.MaLuaChon }, luaChon);
        }

        // DELETE: api/LuaChons/5
        [ResponseType(typeof(LuaChon))]
        public IHttpActionResult DeleteLuaChon(int id)
        {
            LuaChon luaChon = db.LuaChons.Find(id);
            if (luaChon == null)
            {
                return NotFound();
            }

            db.LuaChons.Remove(luaChon);
            db.SaveChanges();

            return Ok(luaChon);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LuaChonExists(int id)
        {
            return db.LuaChons.Count(e => e.MaLuaChon == id) > 0;
        }
    }
}