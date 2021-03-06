--thong ke san pham theo cac thang
CREATE FUNCTION ThongKeSanPhamTheoCacThang()
RETURNS @table TABLE (
    nam int,
	thang int,
	soluongsanpham int)
BEGIN
	INSERT @table
		select c.nam, c.thang, d.[so luong coc] from (select DISTINCT  MaHoaDon as mahoadon, nam, thang from (select YEAR(Ngaytao) as nam, MONTH(NgayTao) as thang from HoaDon where YEAR(NgayTao) in (select YEAR(NgayTao) as nam from HoaDon)) a , HoaDon b
		where YEAR(b.NgayTao) = nam AND MONTH(b.NgayTao) = thang) c, (select MaHoaDon ,SUM(SoLuong) as [so luong coc] from HoaDonChiTiet
		Group by MaHoaDon) d
		where c.mahoadon = d.MaHoaDon
		Order by nam, thang, d.[so luong coc]
RETURN
END
go

-- thong ke tin ban duoc theo cac thang
CREATE FUNCTION ThongKeTienBanDuocTheoThang()
RETURNS @table TABLE (
    nam int,
	thang int,
	tongtien int)
BEGIN
	INSERT @table
		select DISTINCT e.nam, e.thang, SUM((f.tongtienluachon * e.soluong)) as tongtien 
		from (select c.MaHoaDon as mahoadon, c.MaLuaChon as maluachon, c.SoLuong as soluong,  d.nam, d.thang 
			  from  HoaDonChiTiet c, 
					(select DISTINCT  MaHoaDon as mahoadon, nam, thang 
					 from (select YEAR(Ngaytao) as nam, MONTH(NgayTao) as thang 
						   from HoaDon 
						   where YEAR(NgayTao) in 
								(select YEAR(NgayTao) as nam 
								 from HoaDon)) a , HoaDon b
					 where YEAR(b.NgayTao) = nam AND MONTH(b.NgayTao) = thang) d
			  where c.MaHoaDon = d.mahoadon) e,

			 (select c.maluachon,(c.dongia + d.dongia) as tongtienluachon
			  from (select  b.maluachon as maluachon,  a.DonGia as dongia from Topping a, (select MaLuaChon as maluachon, MaTopping as matopping from LuaChon) b
					 where a.MaTopping = b.matopping) c,
 				   (select DISTINCT  b.maluachon as maluachon,  a.DonGia as dongia from SanPham a, (select MaLuaChon as maluachon, MaSanPham as masapham from LuaChon) b
					 where a.MaSanPham = b.masapham) d
			  where c.maluachon = d.maluachon) f
		where e.maluachon = f.maluachon
		group by nam, thang
		order by nam, thang, tongtien
RETURN
END
go