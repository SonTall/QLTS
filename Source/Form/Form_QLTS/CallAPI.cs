using Form_QLTS.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Form_QLTS
{
    class CallAPI
    {
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
    }
}
