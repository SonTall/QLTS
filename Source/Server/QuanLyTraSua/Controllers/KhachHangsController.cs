using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Description;
using QuanLyTraSua;
using QuanLyTraSua.Models;

namespace QuanLyTraSua.Controllers
{
    public class KhachHangsController : ApiController
    {
        private QuanLyTraSuaEntities db = new QuanLyTraSuaEntities();

        // GET: api/KhachHangs
        public IHttpActionResult GetKhachHangs()
        {
            var khachHangList = db.KhachHangs;
            var khachHangEntity = new List<KhachHangViewModel>();
            khachHangList.ToList().ForEach(v =>
            {

                string tmp = "";
                if (v.HinhAnh != "")
                {
                    tmp = ImageTask.GetImage(v.HinhAnh);
                    v.HinhAnh = tmp;
                }
                khachHangEntity.Add(new KhachHangViewModel
                {
                    MaKhachHang = v.MaKhachHang,
                    TenKhachHang = v.TenKhachHang,
                    GioiTinh = v.GioiTinh,
                    NgaySinh = v.NgaySinh,
                    DiaChi = v.DiaChi,
                    SDT = v.SDT,
                    Email = v.Email,
                    HinhAnh = v.HinhAnh
                });
            });
            if (khachHangList != null)
                return Ok(khachHangList);
            else
                return BadRequest();



            //MaKhachHang = v.MaKhachHang,
            //        TenKhachHang = v.TenKhachHang,
            //        GioiTinh = v.GioiTinh,
            //        NgaySinh = v.NgaySinh,
            //        DiaChi = v.DiaChi,
            //        SDT = v.SDT,
            //        Email = v.Email,
            //        HinhAnh = v.HinhAnh

        }

        // GET: api/KhachHangs/5
        [ResponseType(typeof(KhachHang))]
        public IHttpActionResult GetKhachHang(int id)
        {
            //var khachHangList = db.KhachHangs.Where(v => v.MaKhachHang == id).Select(v => new KhachHangViewModel { MaKhachHang = v.MaKhachHang, TenKhachHang = v.TenKhachHang, GioiTinh = v.GioiTinh, NgaySinh = v.NgaySinh, DiaChi = v.DiaChi, SDT = v.SDT, Email = v.Email, HinhAnh = v.HinhAnh });

            //if (khachHangList == null)
            //{
            //    return NotFound();
            //}

            var khachHangList = db.KhachHangs.SingleOrDefault(v => v.MaKhachHang == id);

            if (khachHangList == null)
            {
                return NotFound();
            }

            string tmp = "";
            if (khachHangList.HinhAnh != "")
            {
                tmp = ImageTask.GetImage(khachHangList.HinhAnh);
                khachHangList.HinhAnh = tmp;
            }
            var khachHangEntity = new KhachHangViewModel()
            {
                MaKhachHang = khachHangList.MaKhachHang,
                TenKhachHang = khachHangList.TenKhachHang,
                GioiTinh = khachHangList.GioiTinh,
                NgaySinh = khachHangList.NgaySinh,
                DiaChi = khachHangList.DiaChi,
                SDT = khachHangList.SDT,
                Email = khachHangList.Email,
                HinhAnh = khachHangList.HinhAnh
            };

            return Ok(khachHangEntity);
        }

        // PUT: api/KhachHangs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKhachHang(KhachHang khachHang)
        {


            //var khachHangCurrent = db.KhachHangs.SingleOrDefault(v => v.MaKhachHang == khachHang.MaKhachHang);

            //if (khachHangCurrent != null)
            //{
            //    db.Entry(khachHangCurrent).State = EntityState.Detached;
            //    db.Entry(khachHang).State = EntityState.Modified;

            //    try
            //    {
            //        db.SaveChanges();
            //    }
            //    catch (DbUpdateConcurrencyException)
            //    {
            //        //if (!KhachHangExists(id))
            //        //{
            //        //    return NotFound();
            //        //}
            //        //else
            //        //{
            //        throw;
            //        //}
            //    }
            //}
            //else
            //{
            //    return NotFound();
            //}
            //_________________________
            var khachHangCurrent = db.KhachHangs.SingleOrDefault(v => v.MaKhachHang == khachHang.MaKhachHang);
            if (khachHangCurrent != null)
            {

                if (khachHang.HinhAnh != null)
                {
                    byte[] bytes = Encoding.Default.GetBytes(khachHang.HinhAnh);
                    var str = ImageTask.Write(bytes);
                    khachHang.HinhAnh = str;
                }

                db.Entry(khachHangCurrent).State = EntityState.Detached;
                db.Entry(khachHang).State = EntityState.Modified;

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

        // POST: api/KhachHangs
        [ResponseType(typeof(KhachHang))]
        public IHttpActionResult PostKhachHang(KhachHang khachHang)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (khachHang.HinhAnh != null)
            {
                byte[] bytes = Encoding.Default.GetBytes(khachHang.HinhAnh);
                var str = ImageTask.Write(bytes);
                khachHang.HinhAnh = str;
            }
            db.KhachHangs.Add(khachHang);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = khachHang.MaKhachHang }, khachHang);
        }

        // DELETE: api/KhachHangs/5
        [ResponseType(typeof(KhachHang))]
        public IHttpActionResult DeleteKhachHang(int id)
        {
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return NotFound();
            }

            db.KhachHangs.Remove(khachHang);
            db.SaveChanges();

            return Ok(khachHang);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KhachHangExists(int id)
        {
            return db.KhachHangs.Count(e => e.MaKhachHang == id) > 0;
        }
    }
}