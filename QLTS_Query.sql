-- thong ke so coc tra sua ban duoc theo cac thang

select c.nam, c.thang, d.[so luong coc] from (select DISTINCT  MaHoaDon as mahoadon, nam, thang from (select YEAR(Ngaytao) as nam, MONTH(NgayTao) as thang from HoaDon where YEAR(NgayTao) in (select YEAR(NgayTao) as nam from HoaDon)) a , HoaDon b
where YEAR(b.NgayTao) = nam AND MONTH(b.NgayTao) = thang) c, (select MaHoaDon ,SUM(SoLuong) as [so luong coc] from HoaDonChiTiet
Group by MaHoaDon) d
where c.mahoadon = d.MaHoaDon
Order by nam, thang, d.[so luong coc]

--ham`
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

Select * from ThongKeSanPhamTheoCacThang()
 -- ___________________________________________________________________________________________________

 -- thong ke hoa don theo cac thang

 select nam, thang, COUNT(mahoadon) as sohoadon from (select DISTINCT  MaHoaDon as mahoadon, nam, thang from (select YEAR(Ngaytao) as nam, MONTH(NgayTao) as thang from HoaDon where YEAR(NgayTao) in (select YEAR(NgayTao) as nam from HoaDon)) a , HoaDon b
where YEAR(b.NgayTao) = nam AND MONTH(b.NgayTao) = thang) c
Group by nam, thang
Order by nam, thang

-- ham`
CREATE FUNCTION ThongKeHoaDonTheoCacThang()
RETURNS @table TABLE (
    nam int,
	thang int,
	soluonghoadon int)
BEGIN
	INSERT @table
		select nam, thang, COUNT(mahoadon) as sohoadon from (select DISTINCT  MaHoaDon as mahoadon, nam, thang from (select YEAR(Ngaytao) as nam, MONTH(NgayTao) as thang from HoaDon where YEAR(NgayTao) in (select YEAR(NgayTao) as nam from HoaDon)) a , HoaDon b
		where YEAR(b.NgayTao) = nam AND MONTH(b.NgayTao) = thang) c
		Group by nam, thang
		Order by nam, thang
RETURN
END

select * from ThongKeHoaDonTheoCacThang()


-----------------------------------------------------------------------
--thong ke tien ban duoc  theo thang

select DISTINCT e.nam, e.thang, SUM((f.tongtienluachon * e.soluong)) as tongtien from 
	(select c.MaHoaDon as mahoadon, c.MaLuaChon as maluachon, c.SoLuong as soluong,  d.nam, d.thang from HoaDonChiTiet c, (select DISTINCT  MaHoaDon as mahoadon, nam, thang from (select YEAR(Ngaytao) as nam, MONTH(NgayTao) as thang from HoaDon where YEAR(NgayTao) in (select YEAR(NgayTao) as nam from HoaDon)) a , HoaDon b
		where YEAR(b.NgayTao) = nam AND MONTH(b.NgayTao) = thang) d
	where c.MaHoaDon = d.mahoadon) e,

	(select c.maluachon,(c.dongia + d.dongia) as tongtienluachon
	from (select  b.maluachon as maluachon,  a.DonGia as dongia from Topping a, (select MaLuaChon as maluachon, MaTopping as matopping from LuaChon) b
		  where a.MaTopping = b.matopping) c,
 		 (select  b.maluachon as maluachon,  a.DonGia as dongia from SanPham a, (select MaLuaChon as maluachon, MaSanPham as masapham from LuaChon) b
		  where a.MaSanPham = b.masapham) d
	where c.maluachon = d.maluachon) f
where e.maluachon = f.maluachon
group by nam, thang
order by nam, thang, tongtien

--ham`

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
 				   (select  b.maluachon as maluachon,  a.DonGia as dongia from SanPham a, (select MaLuaChon as maluachon, MaSanPham as masapham from LuaChon) b
					 where a.MaSanPham = b.masapham) d
			  where c.maluachon = d.maluachon) f
		where e.maluachon = f.maluachon
		group by nam, thang
		order by nam, thang, tongtien
RETURN
END

select * from ThongKeTienBanDuocTheoThang()


----------------------------------------------------------------------------------
 --them sua xong bang? giam? gia'

 -- get tat' du~ lieu.
 CREATE FUNCTION GetAllGiamGia()
RETURNS @table TABLE (
    MaKhuyenMai int,
	MaHoaDon int)
BEGIN
	insert @table
	select MaKhuyenMai, MaHoaDon from GiamGia order by MaHoaDon, MaKhuyenMai
	Return
RETURN
END

select * from GetAllGiamGia()


-- get theo ten khuyen mai
 CREATE FUNCTION GetAllGiamGiaByTenKhuyenMai()
RETURNS @table TABLE (
	MaHoaDon int,
    TenKhuyenMai nvarchar(200))
BEGIN
	insert @table
	select b.MaHoaDon, a.TenKhuyenMai from KhuyenMai a, 
	(select MaKhuyenMai, MaHoaDon from GiamGia) b
	where a.MaKhuyenMai = b.MaKhuyenMai
	order by b.MaHoaDon, a.TenKhuyenMai
	Return
RETURN
END

select * from GetAllGiamGiaByTenKhuyenMai()

-- get hoa don by ma hoa don
CREATE FUNCTION GetGiamGiaByMaHoaDon(@maHoaDon int)
RETURNS @table TABLE (
	MaHoaDon int,
    TenKhuyenMai nvarchar(200))
BEGIN
	insert @table
	select b.MaHoaDon, a.TenKhuyenMai from KhuyenMai a, 
	(select MaKhuyenMai, MaHoaDon from GiamGia where MaHoaDon = @maHoaDon) b
	where a.MaKhuyenMai = b.MaKhuyenMai
	order by b.MaHoaDon, a.TenKhuyenMai
	Return
RETURN
END

select * from GetGiamGiaByMaHoaDon(2)

-- them du lieu vao bang giam gia
CREATE PROCEDURE PostGiamGia( @maKhuyenMai int, @maHoaDon int)
AS
Begin
	if(Not exists(select * from GiamGia a where a.MaKhuyenMai = @maKhuyenMai and a.MaHoaDon = @maHoaDon))
		begin
			INSERT INTO GiamGia( MaKhuyenMai, MaHoaDon )
			VALUES ( @maKhuyenMai, @maHoaDon )
		end
--RETURN SCOPE_IDENTITY()
end


execute PostGiamGia 3, 3

-------------------------------------------------------------------------------------------------------
-- get tat ca? du lieu bang phan quyen`
CREATE FUNCTION GetAllPhanQuyen()
RETURNS @table TABLE (
	MaTaiKhoan int,
    MaQuyen int)
BEGIN
	insert @table
	select MaTaiKhoan, MaQuyen from PhanQuyen order by MaTaiKhoan, MaQuyen
	Return
RETURN
END

select * from GetAllPhanQuyen()

-- get du~ lieu bang? phan quyen` theo ma tai khoan?
CREATE FUNCTION GetPhanQuyenByMaTaiKhoan(@maTaiKhoan int)
RETURNS @table TABLE (
	MaTaiKhoan int,
    MaQuyen int)
BEGIN
	insert @table
	select MaTaiKhoan, MaQuyen
	from PhanQuyen
	where MaTaiKhoan = @maTaiKhoan
	order by MaTaiKhoan, MaQuyen
	Return
RETURN
END

select * from GetAllPhanQuyen()

-- them du lieu vao bang? phan quyen`
CREATE PROCEDURE PostPhanQuyen( @maTaiKhoan int, @maQuyen int)
AS
Begin
	if(Not exists(select * from PhanQuyen a where a.MaTaiKhoan = @maTaiKhoan and a.MaQuyen = @maQuyen))
		begin
			INSERT INTO PhanQuyen( MaTaiKhoan, MaQuyen)
			VALUES ( @maTaiKhoan, @maQuyen )
		end
--RETURN SCOPE_IDENTITY()
end

execute PostPhanQuyen 2,2

--- xoa' du~ lieu. bang? phan quyen` theo ma~ quyen`
CREATE PROCEDURE DeletePhanQuyenByMaQuyen(@maQuyen int)
AS
Begin
	if(exists(select * from PhanQuyen a where a.MaQuyen = @maQuyen))
		begin
			delete from PhanQuyen 
			where MaQuyen = @maQuyen
		end
--RETURN SCOPE_IDENTITY()
end

execute DeletePhanQuyenByMaQuyen 2

--- xoa' du~ lieu. bang? phan quyen` theo ma~ tai khoan?
CREATE PROCEDURE DeletePhanQuyenByMaTaiKhoan(@maTaiKhoan int)
AS
Begin
	if(exists(select * from PhanQuyen a where a.MaTaiKhoan = @maTaiKhoan))
		begin
			delete from PhanQuyen 
			where MaTaiKhoan = @maTaiKhoan
		end
--RETURN SCOPE_IDENTITY()
end

execute DeletePhanQuyenByMaTaiKhoan 2

--- xoa' du~ lieu. bang? phan quyen` theo ca? 2 cai'
CREATE PROCEDURE DeletePhanQuyen(@maTaiKhoan int, @maQuyen int)
AS
Begin
	if(exists(select * from PhanQuyen a where a.MaTaiKhoan = @maTaiKhoan and a.MaQuyen = @maQuyen))
		begin
			delete from PhanQuyen 
			where MaTaiKhoan = @maTaiKhoan and MaQuyen = @maQuyen
		end
--RETURN SCOPE_IDENTITY()
end

execute DeletePhanQuyen 2, 1