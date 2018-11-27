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
using QuanLyTraSua.Models;

namespace QuanLyTraSua.Controllers
{
    public class ToppingsController : ApiController
    {
        private QuanLyTraSuaEntities db = new QuanLyTraSuaEntities();

        // GET: api/Toppings
        public IHttpActionResult GetToppings()
        {
            var toppingList = db.Toppings.Select(v => new ToppingViewModel { MaTopping = v.MaTopping, TenTopping = v.TenTopping, DonGia = v.DonGia, HinhAnh = v.HinhAnh });
            if (toppingList != null)
                return Ok(toppingList);
            else
                return BadRequest();
        }

        // GET: api/Toppings/5
        [ResponseType(typeof(Topping))]
        public IHttpActionResult GetTopping(int id)
        {
            var toppingList = db.Toppings.Where(v => v.MaTopping == id).Select(v => new ToppingViewModel { MaTopping = v.MaTopping, TenTopping = v.TenTopping, DonGia = v.DonGia, HinhAnh = v.HinhAnh });

            if (toppingList == null)
            {
                return NotFound();
            }

            return Ok(toppingList.ToList());
        }

        // PUT: api/Toppings/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTopping(Topping topping)
        {
            var toppingCurrent = db.Toppings.SingleOrDefault(v => v.MaTopping == topping.MaTopping);

            if (toppingCurrent != null)
            {

                db.Entry(toppingCurrent).State = EntityState.Detached;
                db.Entry(topping).State = EntityState.Modified;


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

        // POST: api/Toppings
        [ResponseType(typeof(Topping))]
        public IHttpActionResult PostTopping(Topping topping)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Toppings.Add(topping);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = topping.MaTopping }, topping);
        }

        // DELETE: api/Toppings/5
        [ResponseType(typeof(Topping))]
        public IHttpActionResult DeleteTopping(int id)
        {
            Topping topping = db.Toppings.Find(id);
            if (topping == null)
            {
                return NotFound();
            }

            db.Toppings.Remove(topping);
            db.SaveChanges();

            return Ok(topping);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ToppingExists(int id)
        {
            return db.Toppings.Count(e => e.MaTopping == id) > 0;
        }
    }
}