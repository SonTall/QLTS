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
            var luaChonList = db.LuaChons.Where(v => v.MaLuaChon == id).Select(n => new LuaChonViewModel
            {
                MaLuaChon = n.MaLuaChon,
                MaSanPham = n.MaSanPham,
                MaTopping = n.MaTopping
            });
            if (luaChonList == null)
            {
                return NotFound();
            }

            return Ok(luaChonList);
        }

        // PUT: api/LuaChons/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutLuaChon(LuaChon luaChon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            var luaChonCurrent = db.LuaChons.Where(v => v.MaLuaChon == luaChon.MaLuaChon);
            if (luaChonCurrent != null)
            {
                db.Entry(luaChonCurrent).State = EntityState.Detached;
                db.Entry(luaChon).State = EntityState.Modified;
            }
            else
            {
                return NotFound();
            }

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/LuaChons
        [ResponseType(typeof(LuaChon))]
        public IHttpActionResult PostLuaChon(List<LuaChon> luaChon)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            #region khai bao bien' va lay du lieu. tu` csdl
            // bien ma~ lua chon.
            int id = 1;
            // List cac lua. chon duoc select tu` csdl bang? lua. chon.
            var luaChonList = db.LuaChons.ToList();
            #endregion

            #region TH1: CSDL chua co du lieu.
            if (luaChonList.Count == 0)
            {
                // tao bien de? them ma lua chon vao bang ma lua chon  trc'
                var maLuaChon = new MaLuaChon();

                // them vao bang? ma~ lua. chon. ban? ghi dau` tien
                maLuaChon.MaLuaChon1 = id;
                db.MaLuaChons.Add(maLuaChon);
                db.SaveChanges();

                // gan ma san pham cua thang lua. chon dau` tien vao bien de? so sanh'
                int maSanPham = luaChon[0].MaSanPham;
                luaChon.ForEach(v =>
                {
                    // tang ma~ lua. chon. them 1 don vi neu ma san pham khac cai vua` them
                    if (v.MaSanPham != maSanPham)
                    {
                        id = id + 1;
                        maSanPham = v.MaSanPham;

                        // them moi 
                        var _tmp = new MaLuaChon();
                        _tmp.MaLuaChon1 = id;
                        db.MaLuaChons.Add(_tmp);
                        db.SaveChanges();
                    }

                    // gan' ma~ lua. chon cho coc'
                    v.MaLuaChon = id;
                });

                db.LuaChons.AddRange(luaChon);
                db.SaveChanges();

                return Ok(id);
            }
            #endregion

            #region TH2: csdl da~ co du~ lieu

            //gan' ma~ san pham? cua? coc' dau` tien` cho bien'
            int _maSanPham = luaChon[0].MaSanPham;

            //list maluachon return neu coc' do' co'  ton` tai. trong csdl
            List<int> listIdExist = new List<int>();

            //list maluachon return khi them moi vao csdl
            List<int> listIdAdd = new List<int>();

            // kiem soat viec. tim du~ lieu chi? tim` 1 lan` voi moi~ ma~ san pham?
            int execute = 0;

            // thuc hien for de? kiem tra coc' nay~ da co trong csdl chua
            foreach (LuaChon tmp in luaChon)
            {
                if (_maSanPham != tmp.MaSanPham)
                {
                    execute = 0;
                    _maSanPham = tmp.MaSanPham;
                }

                // so sanh theo ma~ san? pham cua? tung` coc'
                if (_maSanPham == tmp.MaSanPham && execute == 0)
                {
                    execute = 1;

                    // bien nay` de? check xem coc nay` da~ duoc. tim thay trong csdl chua?, neu = true thi` break luon khoi? for vi tim dc roi`
                    bool _checkCoc = false;

                    // countLuaChon: de? lua tong? so' lua, chon da~ select duoc voi~ ma lua. chon la id trong csdl
                    int _countLuaChon = 0;

                    // countCheck: bien de? dem so lua. chon trong hoa don va` so lua. chon trong csdl vs maluachon = id.
                    // neu bang thi` => da~ ton` tai. trong csdl
                    int _countCheck = 0;

                    // bien kiem tra xem da~ co coc' nay trong csdl chua?
                    bool _check = false;

                    // gan'  gia tri. cho bien' ma lua. chon chay. tu` san pham dau tien (= 1)
                    id = 1;

                    // vong for nay` de? chay. bien id tang dan`
                    for (int i = 0; i < luaChonList.Count() - 1; i++)
                    {
                        // select ra list coc' trong bang? lua. chon. vs ma~ lua. chon = id va masanpham = ma~ san pham cua coc'dang xet'
                        var temp = luaChonList.Where(v => v.MaLuaChon == id && v.MaSanPham == _maSanPham).ToList();
                        var length = temp.Count;

                        if (length == 0)
                        {
                            _check = false;
                            id++;
                            continue;
                        }

                        foreach (LuaChon item in luaChon)
                        {
                            // khong co san pham? thuoc ma~ nay` thi break luon.
                            if (temp.Count == 0)
                            {
                                _check = false;
                                break;
                            }

                            // loc theo ma~ san pham de? lay' lua chon. de? so sanh'
                            if (item.MaSanPham == _maSanPham)
                            {
                                // gan' tong? so list lua chon. theo ma~ id duoc select tu` csdl
                                _countLuaChon = temp.Count();

                                // so sanh xem coc. vua` tao hoa' don co to`n tai. trong list nay` khong?
                                if (!temp.Any(v => v.MaSanPham == item.MaSanPham && v.MaTopping == Convert.ToInt32(item.MaTopping)))
                                {
                                    // false: khong ton` tai. trong list
                                    _check = false;
                                    break;
                                }
                                else
                                {
                                    // co  ton` tai. 1 phan tu? trong list so sanh' thi` tang bien countCheck len 1 don vi
                                    _countCheck++;

                                    _check = true;

                                    // i++;
                                }

                                // vao day thi coc' nay co trong csdl 
                                if (_countCheck == _countLuaChon && _countCheck != 0)
                                {
                                    // luu no vao` list de? return 
                                    listIdExist.Add(id);
                                    _check = false;
                                    _checkCoc = true;
                                    break;
                                }
                            }
                            else
                            {

                            }
                        }

                        // khong ton` tai. len tang ma~ lua. chon len 1 de? soat' cac lua. chon tiep theo 
                        if (_check == false)
                        //else
                        {
                            // checkCoc = false => dang duyet. list  
                            if (_checkCoc == false)
                            {
                                _countCheck = 0;
                                id++;
                            }
                            // checkCoc = true => da~ tim thay' coc' nay` trong csdl => break;
                            else
                            {
                                _checkCoc = false;

                                _check = true;
                                break;
                            }
                        }

                        if (_check == true && _countCheck != _countLuaChon && _countCheck != 0)
                        {
                            id++;
                            _countCheck = 0;
                        }
                    }

                    if ((_check == true && _countCheck != _countLuaChon) || (_check == false))
                    {
                        // them ma~ san pham? cua coc' chua ton` tai. trong csdl giu lieu. vao` list de? ti add vao` csdl
                        listIdAdd.Add(_maSanPham);
                    }
                }
            }

            int _maLuaChon;
            List<int> listResult = new List<int>();

            //TH2.1 : Neu chua co' thi` them moi' vao` csdl va` tra? ve` ma~ lua. chon.
            if (listIdAdd.Count > 0)
            {
                // lay ra ma~ lua. chon cua? thang cuoi' cung trong csdl
                var _tmp = db.MaLuaChons.ToList().Count;

                // cong maluachon 1 don vi. de? luu gia tri tiep theo
                _maLuaChon = _tmp + 1;

                // for duyet. tung phan tu? cua list cac' coc' add vao csdl
                listIdAdd.ForEach(item =>
                {
                    // loc. ra list coc' duoc theo vao csdl
                    var list = luaChon.Where(v => v.MaSanPham == item).ToList();
                    int maSanPham = list.First().MaSanPham;
                    list.ForEach(v =>
                    {
                        v.MaLuaChon = _maLuaChon;
                        // tang ma~ lua. chon. them 1 don vi neu ma san pham khac cai vua` them
                        if (v.MaSanPham != maSanPham)
                        {
                            v.MaLuaChon = _maLuaChon + 1;
                            maSanPham = v.MaSanPham;
                        }
                    });

                    // tao bien de? them ma lua chon vao bang ma lua chon  trc'
                    var maLuaChon = new MaLuaChon();
                    maLuaChon.MaLuaChon1 = _maLuaChon;
                    db.MaLuaChons.Add(maLuaChon);
                    db.SaveChanges();

                    // lay' ra san pham de? add tu` bien dau` vao` theo ma~ san pham?
                    var _temp = luaChon.Where(n => n.MaSanPham == item);
                    db.LuaChons.AddRange(_temp);
                    db.SaveChanges();

                    //add ma lua chon vao ket qua return
                    listResult.Add(_maLuaChon);

                    //tang maluachon len 1 neu  list co nhieu phan tu?
                    if (listIdAdd.Count > 1)
                    {
                        _maLuaChon = _maLuaChon + 1;
                    }
                });
            }

            //TH2.2: Da~ ton` tai. coc' nay` roi` thi tra? ve` ma~ lua. chon cua? no' thoi
            if (listIdExist.Count > 0)
            {
                // _maLuaChon = id;
                listResult.AddRange(listIdExist);
            }
            #endregion
            return Ok(listResult);
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