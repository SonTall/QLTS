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
    public class NhanViensController : ApiController
    {
        private QuanLyTraSuaEntities db = new QuanLyTraSuaEntities();

        // GET: api/NhanViens
        public IHttpActionResult GetNhanViens()
        {
            var nhanVienList = db.NhanViens;
            var nhanVienEntity = new List<NhanVienViewModel>();
            nhanVienList.ToList().ForEach(v =>
            {
                string tmp = "";
                if (v.HinhAnh != "")
                {
                    tmp = ImageTask.GetImage(v.HinhAnh);
                    v.HinhAnh = tmp;
                }
                nhanVienEntity.Add(new NhanVienViewModel
                {
                    MaNhanVien = v.MaNhanVien,
                    TenNhanVien = v.TenNhanVien,
                    GioiTinh = v.GioiTinh,
                    NgaySinh = v.NgaySinh,
                    DiaChi = v.DiaChi,
                    SDT = v.SDT,
                    Email = v.Email,
                    NgayBatDau = v.NgayBatDau,
                    HinhAnh = tmp
                });

            });

            return Ok(nhanVienEntity.ToList());

        }

        // GET: api/NhanViens/5
        [ResponseType(typeof(NhanVien))]
        public IHttpActionResult GetNhanVien(int id)
        {
            var nhanVienList = db.NhanViens.SingleOrDefault(v => v.MaNhanVien == id);

            if (nhanVienList == null)
            {
                return NotFound();
            }

            string tmp = "";
            if (nhanVienList.HinhAnh != "")
            {
                tmp = ImageTask.GetImage(nhanVienList.HinhAnh);
                nhanVienList.HinhAnh = tmp;
            }
            var nhanVienEntity = new NhanVienViewModel()
            {
                MaNhanVien = nhanVienList.MaNhanVien,
                TenNhanVien = nhanVienList.TenNhanVien,
                GioiTinh = nhanVienList.GioiTinh,
                NgaySinh = nhanVienList.NgaySinh,
                DiaChi = nhanVienList.DiaChi,
                SDT = nhanVienList.SDT,
                Email = nhanVienList.Email,
                NgayBatDau = nhanVienList.NgayBatDau,
                HinhAnh = tmp
            };

            return Ok(nhanVienEntity);
        }

        // PUT: api/NhanViens/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNhanVien(NhanVien nhanVien)
        {
            var nhanVienCurrent = db.NhanViens.SingleOrDefault(v => v.MaNhanVien == nhanVien.MaNhanVien);
            if (nhanVienCurrent != null)
            {

                if (nhanVien.HinhAnh != null)
                {
                    byte[] bytes = Encoding.Default.GetBytes(nhanVien.HinhAnh);
                    var str = ImageTask.Write(bytes);
                    nhanVien.HinhAnh = str;
                }
                
                db.Entry(nhanVienCurrent).State = EntityState.Detached;
                db.Entry(nhanVien).State = EntityState.Modified;

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

        // POST: api/NhanViens
        [ResponseType(typeof(NhanVien))]
        public IHttpActionResult PostNhanVien(NhanVien nhanVien)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (nhanVien.HinhAnh != null)
            {
                byte[] bytes = Encoding.ASCII.GetBytes(nhanVien.HinhAnh);
                var str = ImageTask.Write(bytes);
                nhanVien.HinhAnh = str;
            }

            db.NhanViens.Add(nhanVien);
            db.SaveChanges();

            //return CreatedAtRoute("DefaultApi", new { id = nhanVien.MaNhanVien }, nhanVien);
            return Ok();
        }

        // DELETE: api/NhanViens/5
        [ResponseType(typeof(NhanVien))]
        public IHttpActionResult DeleteNhanVien(int id)
        {
            NhanVien nhanVien = db.NhanViens.Find(id);
            if (nhanVien == null)
            {
                return NotFound();
            }

            db.NhanViens.Remove(nhanVien);
            db.SaveChanges();

            return Ok(nhanVien);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NhanVienExists(int id)
        {
            return db.NhanViens.Count(e => e.MaNhanVien == id) > 0;
        }
    }
}