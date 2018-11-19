using QuanLyTraSua.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuanLyTraSua.Controllers
{
    public class GiamGiasController : ApiController
    {
        [HttpGet]
        public IHttpActionResult GetGiamsGia()
        {
            using (QuanLyTraSuaEntities db = new QuanLyTraSuaEntities())
            {
                var giamGiaList = db.GetAllGiamGia().Select(v => new GiamGiaViewModel { MaHoaDon = (int)v.MaHoaDon, MaKhuyenMai = (int)v.MaKhuyenMai });
                if(giamGiaList != null)
                {
                    return Ok(giamGiaList.ToList());
                }
                else
                {
                    return BadRequest();
                }
            }
        }
    }
}
