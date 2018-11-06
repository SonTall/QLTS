using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Form_QLTS
{
    class RESTful
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

    }
}
