using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyTraSua.Models
{
    public class ToppingViewModel
    {
        public int MaTopping { get; set; }
        public string TenTopping { get; set; }
        public string HinhAnh { get; set; }
        public Nullable<decimal> DonGia { get; set; }
    }
}