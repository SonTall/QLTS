//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QuanLyTraSua
{
    using System;
    using System.Collections.Generic;
    
    public partial class HoaDonChiTiet
    {
        public int MaHoaDon { get; set; }
        public int MaLuaChon { get; set; }
        public Nullable<int> SoLuong { get; set; }
    
        public virtual HoaDon HoaDon { get; set; }
        public virtual MaLuaChon MaLuaChon1 { get; set; }
    }
}
