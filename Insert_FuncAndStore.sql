use QuanLyTraSua
go


 -- thong ke hoa don theo cac thang
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
go


 -- thong ke hoa don theo cac thang theo ma nhan vien
CREATE FUNCTION ThongKeHoaDonTheoCacThangByMaNhanVien(@maNhanVien int)
RETURNS @table TABLE (
    nam int,
	thang int,
	soluonghoadon int)
BEGIN
	INSERT @table
		select nam, thang, COUNT(mahoadon) as sohoadon 
		from 
		(select DISTINCT  MaHoaDon as mahoadon, nam, thang, a.manhanvien 
		from
			 (select Distinct YEAR(Ngaytao) as nam, MONTH(NgayTao) as thang, MaNhanVien as manhanvien
			  from 
				HoaDon where YEAR(NgayTao) in (select Distinct YEAR(NgayTao) as nam from HoaDon)) a , 
				HoaDon b 
				where YEAR(b.NgayTao) = nam AND MONTH(b.NgayTao) = thang) c
		Where c.manhanvien = @maNhanVien
		Group by nam, thang
		Order by nam, thang
RETURN
END
go

select * from ThongKeHoaDonTheoCacThangByMaNhanVien(1)


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
go


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
go

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
go

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
go

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
go

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
go

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
go

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
go

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
go

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
go


-----------------------------------------------------------------------------------------------------------
-- BANG HOA DON CHI TIET
-- get tat ca? du lieu bang hoa don chi tiet
CREATE FUNCTION GetAllHoaDonChiTiet()
RETURNS @table TABLE (
	MaHoaDon int,
    MaLuaChon int)
BEGIN
	insert @table
	select MaHoaDon, MaLuaChon from HoaDonChiTiet order by MaHoaDon, MaLuaChon
	Return
RETURN
END
go

---get tat ca? du lieu bang hoa don chi tiet theo ma hoa don 
CREATE FUNCTION GetAllHoaDonChiTietByMaHoaDon(@maHoaDon int)
RETURNS @table TABLE (
	MaHoaDon int,
    MaLuaChon int)
BEGIN
	insert @table
	select MaHoaDon, MaLuaChon from HoaDonChiTiet where MaHoaDon = @maHoaDon order by MaHoaDon, MaLuaChon
	Return
RETURN
END
go


---get tat ca? du lieu bang hoa don chi tiet theo ma lua chon
CREATE FUNCTION GetAllHoaDonChiTietByMaLuaChon(@maLuaChon int)
RETURNS @table TABLE (
	MaHoaDon int,
    MaLuaChon int)
BEGIN
	insert @table
	select MaHoaDon, MaLuaChon from HoaDonChiTiet where MaLuaChon = @maLuaChon order by MaHoaDon, MaLuaChon
	Return
RETURN
END
go

-- post du lieu vao bang hoa don chi tiet
CREATE PROCEDURE PostHoaDonChiTiet( @maHoaDon int, @maLuaChon int)
AS
Begin
	if(Not exists(select * from HoaDonChiTiet a where a.MaHoaDon = @maHoaDon and a.MaLuaChon = @maLuaChon))
		begin
			INSERT INTO HoaDonChiTiet( MaHoaDon, MaLuaChon)
			VALUES (@maHoaDon, @maLuaChon)
		end
end
go
