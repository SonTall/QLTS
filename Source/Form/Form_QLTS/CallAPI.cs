﻿using Form_QLTS.ViewModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Form_QLTS
{
    class CallAPI
    {
        /// <summary>
        /// lay chuoi token 
        /// </summary>
        /// <param name="tenTaiKhoan"></param>
        /// <param name="matKhau"></param>
        /// <returns></returns>
        public TaiKhoan GetToken(string tenTaiKhoan, string matKhau)
        {
            using (var client = new HttpClient())
            {
                var taiKhoan = new TaiKhoan();
                //string _toKen;

                //  var jsonStr = JsonConvert.SerializeObject(taiKhoan);
                //client.BaseAddress = new Uri("http://localhost:49365/");

                var dict = new Dictionary<string, string>();
                dict.Add("username", tenTaiKhoan.Trim());
                dict.Add("password", matKhau.Trim());
                dict.Add("grant_type", "password");

                var req = new HttpRequestMessage(HttpMethod.Post, "http://localhost:49365/token") { Content = new FormUrlEncodedContent(dict) };
                var res = client.SendAsync(req);
                res.Wait();
                var result = res.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsStringAsync();
                    JObject joResponse = JObject.Parse(readTask.Result);
                    taiKhoan.Token = joResponse["access_token"].ToString();
                    taiKhoan.UserName = joResponse["username"].ToString();
                    taiKhoan.Identity = joResponse["identity"].ToString();
                    taiKhoan.Id = Convert.ToInt32(joResponse["id"].ToString());
                }
                else
                {
                    taiKhoan = null;
                }

                return taiKhoan;
            }
        }

        /// <summary>
        /// lay thong tin cac tai khoan?
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public List<TaiKhoanViewModel> GetListTaiKhoan(string token)
        {
            IEnumerable<TaiKhoanViewModel> taiKhoanList = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49365/api/");

                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token.Trim());
                //HTTP GET
                var responseTask = client.GetAsync("TaiKhoans");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<TaiKhoanViewModel>>();
                    readTask.Wait();

                    taiKhoanList = readTask.Result;
                }
                else
                {
                    taiKhoanList = Enumerable.Empty<TaiKhoanViewModel>();
                }
                return taiKhoanList.ToList();
            }
        }

        public int GetTongHoaDonTheoNgay()
        {
            int sumHoaDon;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49365/api/ThongKe/");
                //HTTP GET
                var responseTask = client.GetAsync("TongHoaDonTheoNgay");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<int>();
                    readTask.Wait();

                    sumHoaDon = readTask.Result;
                }
                else
                {
                    sumHoaDon = 0;

                }
            }
            return sumHoaDon;
        }

        public int GetTongSanPham()
        {
            int sumSanPham;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49365/api/ThongKe/");
                //HTTP GET
                var responseTask = client.GetAsync("GetAllSanPham");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<int>();
                    readTask.Wait();

                    sumSanPham = readTask.Result;
                }
                else
                {
                    sumSanPham = 0;

                }

                return sumSanPham;
            }
        }

        public int GetTongTopping()
        {
            int sumTopping;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49365/api/ThongKe/");
                //HTTP GET
                var responseTask = client.GetAsync("GetAllTopping");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<int>();
                    readTask.Wait();

                    sumTopping = readTask.Result;
                }
                else
                {
                    sumTopping = 0;

                }

                return sumTopping;
            }
        }

        /// <summary>
        /// get tong? so lua. chon. dang co trong csdl
        /// </summary>
        /// <returns></returns>
        public int GetTongLuaChon()
        {
            int sumLuaChon;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49365/api/ThongKe/");
                //HTTP GET
                var responseTask = client.GetAsync("GetSumLuaChon");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<int>();
                    readTask.Wait();

                    sumLuaChon = readTask.Result;
                }
                else
                {
                    sumLuaChon = 0;
                }
                return sumLuaChon;
            }
        }

        public int GetTongKhuyenMaiDangApDung()
        {
            int sumKhuyenMai;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49365/api/ThongKe/");
                //HTTP GET
                var responseTask = client.GetAsync("TongKhuyenMaiApDungDangApDung");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<int>();
                    readTask.Wait();

                    sumKhuyenMai = readTask.Result;
                }
                else
                {
                    sumKhuyenMai = 0;

                }

                return sumKhuyenMai;
            }
        }

        public NhanVienViewModel GetNhanVienByMaNhanVien(string maNhanVien)
        {
            NhanVienViewModel nhanVien = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49365/api/NhanViens");
                //HTTP GET
                var responseTask = client.GetAsync("?id=" + maNhanVien);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<NhanVienViewModel>();
                    readTask.Wait();

                    nhanVien = readTask.Result;
                }
                else
                {
                    nhanVien = null;
                }
                return nhanVien;
            }
        }

        public List<KhuyenMaiViewModel> GetListKhuyenMaiDangDuocApDung()
        {
            IEnumerable<KhuyenMaiViewModel> khuyenMaiList = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49365/api/ThongKe/");
                //HTTP GET
                var responseTask = client.GetAsync("GetListKhuyenMaiDangDuocApDung");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<KhuyenMaiViewModel>>();
                    readTask.Wait();

                    khuyenMaiList = readTask.Result;
                }
                else
                {
                    khuyenMaiList = Enumerable.Empty<KhuyenMaiViewModel>();
                }
                return khuyenMaiList.ToList();
            }
        }

        /// <summary>
        /// liet ke cac san pham trong bang san pham
        /// </summary>
        /// <returns></returns>
        public List<SanPhamViewModel> GetListSanPham()
        {
            IEnumerable<SanPhamViewModel> sanPhamList = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49365/api/");

                //HTTP GET
                var responseTask = client.GetAsync("SanPhams");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<SanPhamViewModel>>();
                    readTask.Wait();

                    sanPhamList = readTask.Result;
                }
                else
                {
                    sanPhamList = Enumerable.Empty<SanPhamViewModel>();
                }
                return sanPhamList.ToList();
            }
        }

        /// <summary>
        /// liet ke cac topping
        /// </summary>
        /// <returns></returns>
        public List<ToppingViewModel> GetListTopping()
        {
            IEnumerable<ToppingViewModel> toppingList = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49365/api/");
                //HTTP GET
                var responseTask = client.GetAsync("Toppings");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ToppingViewModel>>();
                    readTask.Wait();

                    toppingList = readTask.Result;
                }
                else
                {
                    toppingList = Enumerable.Empty<ToppingViewModel>();
                }
                return toppingList.ToList();
            }
        }

        /// <summary>
        /// liet ke danh sach chu? de`
        /// </summary>
        /// <returns></returns>
        public List<ChuDeViewModel> GetListChuDe()
        {
            IEnumerable<ChuDeViewModel> chuDeList = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49365/api/ThongKe/");
                //HTTP GET
                var responseTask = client.GetAsync("GetListChuDe");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<ChuDeViewModel>>();
                    readTask.Wait();

                    chuDeList = readTask.Result;
                }
                else
                {
                    chuDeList = Enumerable.Empty<ChuDeViewModel>();
                }
                return chuDeList.ToList();
            }
        }


        /// <summary>
        /// liet ke danh sach san? pham? loc. theo ma~ chu? de`
        /// </summary>
        /// <param name="maChuDe"></param>
        /// <returns></returns>
        public List<SanPhamViewModel> GetListSanPhamByMaChuDe(int maChuDe)
        {
            IEnumerable<SanPhamViewModel> sanPhamList = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49365/api/ThongKe/GetListSanPhamByMaChuDe");
                //HTTP GET
                var responseTask = client.GetAsync("?maChuDe=" + maChuDe.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<SanPhamViewModel>>();
                    readTask.Wait();

                    sanPhamList = readTask.Result;
                }
                else
                {
                    sanPhamList = Enumerable.Empty<SanPhamViewModel>();
                }
                return sanPhamList.ToList();
            }
        }


        /// <summary>
        /// liet ke danh sach san? pham? loc. theo ma~ chu? de`
        /// </summary>
        /// <param name="maChuDe"></param>
        /// <returns></returns>
        public List<LuaChonViewModel> GetListLuaChon()
        {
            IEnumerable<LuaChonViewModel> luaChonList = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49365/api/");
                //HTTP GET
                var responseTask = client.GetAsync("LuaChons");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<LuaChonViewModel>>();
                    readTask.Wait();

                    luaChonList = readTask.Result;
                }
                else
                {
                    luaChonList = Enumerable.Empty<LuaChonViewModel>();
                }
                return luaChonList.ToList();
            }
        }


        public List<HoaDonViewModel> GetListHoaDonTrongNgayByMaNhanVien(int maNhanVien)
        {
            IEnumerable<HoaDonViewModel> hoaDonList = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49365/api/ThongKe/");

                var responseTask = client.GetAsync("GetListHoaDonTrongNgayByMaNhanVien?maNhanVien=" + maNhanVien);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<HoaDonViewModel>>();
                    readTask.Wait();

                    hoaDonList = readTask.Result;
                }
                else
                {
                    hoaDonList = Enumerable.Empty<HoaDonViewModel>();
                }
                return hoaDonList.ToList();
            }
        }


        //POST HOA DON
        /// <summary>
        /// post thong tin san? phan vs topping vao 2 bang? ma~ lua. chon vs lua. chon.
        /// </summary>
        /// <param name="luaChonList"></param>
        /// <returns></returns>
        public List<int> PostLuaChon(List<LuaChonViewModel> luaChonList)
        {
            List<int> maLuaChon = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49365/api/");

                var responseTask = client.PostAsJsonAsync("LuaChons", luaChonList);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<List<int>>();
                    readTask.Wait();

                    maLuaChon = readTask.Result;
                }
                else
                {
                    maLuaChon = null;
                }
                return maLuaChon;
            }
        }

        /// <summary>
        /// post thong tin len bang hoa don va hoa don chi tiet'
        /// </summary>
        /// <param name="thongTinHoaDon"></param>
        /// <returns></returns>
        public bool PostHoaDon(ThongTinHoaDon thongTinHoaDon)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49365/api/");
                //HTTP POST
                var responseTask = client.PostAsJsonAsync("HoaDons", thongTinHoaDon);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        //Put NHAN VIEN
        /// <summary>
        /// sua thong tin nhan vien
        /// </summary>
        /// <param name="nhanVien"></param>
        /// <returns></returns>
        public bool PutNhanVien(NhanVienViewModel nhanVien)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:49365/api/");
                //HTTP POST
                var responseTask = client.PutAsJsonAsync("NhanViens", nhanVien);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
