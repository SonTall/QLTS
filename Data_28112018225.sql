USE [QuanLyTraSua]
GO
/****** Object:  StoredProcedure [dbo].[DeletePhanQuyen]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeletePhanQuyen](@maTaiKhoan int, @maQuyen int)
AS
Begin
	if(exists(select * from PhanQuyen a where a.MaTaiKhoan = @maTaiKhoan and a.MaQuyen = @maQuyen))
		begin
			delete from PhanQuyen 
			where MaTaiKhoan = @maTaiKhoan and MaQuyen = @maQuyen
		end
--RETURN SCOPE_IDENTITY()
end
GO
/****** Object:  StoredProcedure [dbo].[DeletePhanQuyenByMaQuyen]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeletePhanQuyenByMaQuyen](@maQuyen int)
AS
Begin
	if(exists(select * from PhanQuyen a where a.MaQuyen = @maQuyen))
		begin
			delete from PhanQuyen 
			where MaQuyen = @maQuyen
		end
--RETURN SCOPE_IDENTITY()
end
GO
/****** Object:  StoredProcedure [dbo].[DeletePhanQuyenByMaTaiKhoan]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeletePhanQuyenByMaTaiKhoan](@maTaiKhoan int)
AS
Begin
	if(exists(select * from PhanQuyen a where a.MaTaiKhoan = @maTaiKhoan))
		begin
			delete from PhanQuyen 
			where MaTaiKhoan = @maTaiKhoan
		end
--RETURN SCOPE_IDENTITY()
end
GO
/****** Object:  StoredProcedure [dbo].[PostGiamGia]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PostGiamGia]( @maKhuyenMai int, @maHoaDon int)
AS
Begin
	if(Not exists(select * from GiamGia a where a.MaKhuyenMai = @maKhuyenMai and a.MaHoaDon = @maHoaDon))
		begin
			INSERT INTO GiamGia( MaKhuyenMai, MaHoaDon )
			VALUES ( @maKhuyenMai, @maHoaDon )
		end
--RETURN SCOPE_IDENTITY()
end
GO
/****** Object:  StoredProcedure [dbo].[PostHoaDonChiTiet]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PostHoaDonChiTiet]( @maHoaDon int, @maLuaChon int)
AS
Begin
	if(Not exists(select * from HoaDonChiTiet a where a.MaHoaDon = @maHoaDon and a.MaLuaChon = @maLuaChon))
		begin
			INSERT INTO HoaDonChiTiet( MaHoaDon, MaLuaChon)
			VALUES (@maHoaDon, @maLuaChon)
		end
end
GO
/****** Object:  StoredProcedure [dbo].[PostPhanQuyen]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[PostPhanQuyen]( @maTaiKhoan int, @maQuyen int)
AS
Begin
	if(Not exists(select * from PhanQuyen a where a.MaTaiKhoan = @maTaiKhoan and a.MaQuyen = @maQuyen))
		begin
			INSERT INTO PhanQuyen( MaTaiKhoan, MaQuyen)
			VALUES ( @maTaiKhoan, @maQuyen )
		end
--RETURN SCOPE_IDENTITY()
end
GO
/****** Object:  UserDefinedFunction [dbo].[GetAllGiamGia]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE FUNCTION [dbo].[GetAllGiamGia]()
RETURNS @table TABLE (
    MaKhuyenMai int,
	MaHoaDon int)
BEGIN
	insert @table
	select MaKhuyenMai, MaHoaDon from GiamGia order by MaHoaDon, MaKhuyenMai
	Return
RETURN
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetAllGiamGiaByTenKhuyenMai]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE FUNCTION [dbo].[GetAllGiamGiaByTenKhuyenMai]()
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
GO
/****** Object:  UserDefinedFunction [dbo].[GetAllHoaDonChiTiet]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetAllHoaDonChiTiet]()
RETURNS @table TABLE (
	MaHoaDon int,
    MaLuaChon int)
BEGIN
	insert @table
	select MaHoaDon, MaLuaChon from HoaDonChiTiet order by MaHoaDon, MaLuaChon
	Return
RETURN
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetAllHoaDonChiTietByMaHoaDon]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetAllHoaDonChiTietByMaHoaDon](@maHoaDon int)
RETURNS @table TABLE (
	MaHoaDon int,
    MaLuaChon int)
BEGIN
	insert @table
	select MaHoaDon, MaLuaChon from HoaDonChiTiet where MaHoaDon = @maHoaDon order by MaHoaDon, MaLuaChon
	Return
RETURN
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetAllHoaDonChiTietByMaLuaChon]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetAllHoaDonChiTietByMaLuaChon](@maLuaChon int)
RETURNS @table TABLE (
	MaHoaDon int,
    MaLuaChon int)
BEGIN
	insert @table
	select MaHoaDon, MaLuaChon from HoaDonChiTiet where MaLuaChon = @maLuaChon order by MaHoaDon, MaLuaChon
	Return
RETURN
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetAllPhanQuyen]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetAllPhanQuyen]()
RETURNS @table TABLE (
	MaTaiKhoan int,
    MaQuyen int)
BEGIN
	insert @table
	select MaTaiKhoan, MaQuyen from PhanQuyen order by MaTaiKhoan, MaQuyen
	Return
RETURN
END
GO
/****** Object:  UserDefinedFunction [dbo].[GetGiamGiaByMaHoaDon]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetGiamGiaByMaHoaDon](@maHoaDon int)
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
GO
/****** Object:  UserDefinedFunction [dbo].[GetPhanQuyenByMaTaiKhoan]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetPhanQuyenByMaTaiKhoan](@maTaiKhoan int)
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
GO
/****** Object:  Table [dbo].[ChuDe]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ChuDe](
	[MaChuDe] [int] IDENTITY(1,1) NOT NULL,
	[TenChuDe] [nvarchar](200) NULL,
	[MoTa] [nvarchar](200) NULL,
 CONSTRAINT [PK_ChuDe] PRIMARY KEY CLUSTERED 
(
	[MaChuDe] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GiamGia]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GiamGia](
	[MaKhuyenMai] [int] NOT NULL,
	[MaHoaDon] [int] NOT NULL,
 CONSTRAINT [PK_GiamGia] PRIMARY KEY CLUSTERED 
(
	[MaKhuyenMai] ASC,
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDon]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDon](
	[MaHoaDon] [int] IDENTITY(1,1) NOT NULL,
	[MaKhachHang] [int] NULL,
	[MaNhanVien] [int] NULL,
	[NgayTao] [date] NULL,
	[MoTa] [nvarchar](200) NULL,
 CONSTRAINT [PK_HoaDon] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HoaDonChiTiet]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HoaDonChiTiet](
	[MaHoaDon] [int] NOT NULL,
	[MaLuaChon] [int] NOT NULL,
	[SoLuong] [int] NULL,
 CONSTRAINT [PK_HoaDonChiTiet_1] PRIMARY KEY CLUSTERED 
(
	[MaHoaDon] ASC,
	[MaLuaChon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhachHang]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhachHang](
	[MaKhachHang] [int] IDENTITY(1,1) NOT NULL,
	[TenKhachHang] [nvarchar](200) NULL,
	[GioiTinh] [bit] NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](200) NULL,
	[SDT] [nvarchar](100) NULL,
	[Email] [nvarchar](200) NULL,
	[HinhAnh] [nvarchar](200) NULL,
 CONSTRAINT [PK_KhachHang] PRIMARY KEY CLUSTERED 
(
	[MaKhachHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[KhuyenMai]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[KhuyenMai](
	[MaKhuyenMai] [int] IDENTITY(1,1) NOT NULL,
	[TenKhuyenMai] [nvarchar](200) NULL,
	[GiaTri] [float] NULL,
	[MoTa] [nvarchar](200) NULL,
	[NgayBatDau] [datetime] NULL,
	[NgayKetThuc] [datetime] NULL,
 CONSTRAINT [PK_KhuyenMai] PRIMARY KEY CLUSTERED 
(
	[MaKhuyenMai] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LuaChon]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LuaChon](
	[MaLuaChon] [int] NOT NULL,
	[MaSanPham] [int] NOT NULL,
	[MaTopping] [int] NOT NULL,
 CONSTRAINT [PK_LuaChon] PRIMARY KEY CLUSTERED 
(
	[MaLuaChon] ASC,
	[MaSanPham] ASC,
	[MaTopping] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MaLuaChon]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaLuaChon](
	[MaLuaChon] [int] NOT NULL,
 CONSTRAINT [PK_MaLuaChon] PRIMARY KEY CLUSTERED 
(
	[MaLuaChon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NhanVien](
	[MaNhanVien] [int] IDENTITY(1,1) NOT NULL,
	[TenNhanVien] [nvarchar](200) NULL,
	[GioiTinh] [bit] NULL,
	[NgaySinh] [date] NULL,
	[DiaChi] [nvarchar](200) NULL,
	[SDT] [nvarchar](100) NULL,
	[Email] [nvarchar](200) NULL,
	[HinhAnh] [nvarchar](200) NULL,
	[NgayBatDau] [date] NULL,
 CONSTRAINT [PK_NhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PhanQuyen]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PhanQuyen](
	[MaQuyen] [int] NOT NULL,
	[MaTaiKhoan] [int] NOT NULL,
 CONSTRAINT [PK_PhanQuyen] PRIMARY KEY CLUSTERED 
(
	[MaQuyen] ASC,
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Quyen]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Quyen](
	[MaQuyen] [int] IDENTITY(1,1) NOT NULL,
	[TenQuyen] [nvarchar](200) NULL,
	[MoTa] [nvarchar](200) NULL,
 CONSTRAINT [PK_Quyen] PRIMARY KEY CLUSTERED 
(
	[MaQuyen] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[SanPham]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SanPham](
	[MaSanPham] [int] IDENTITY(1,1) NOT NULL,
	[TenSanPham] [nvarchar](200) NULL,
	[KichCo] [nvarchar](200) NULL,
	[MaChuDe] [int] NULL,
	[HinhAnh] [nvarchar](200) NULL,
	[DonGia] [money] NULL,
 CONSTRAINT [PK_SanPham] PRIMARY KEY CLUSTERED 
(
	[MaSanPham] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[TaiKhoan]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaiKhoan](
	[MaTaiKhoan] [int] IDENTITY(1,1) NOT NULL,
	[TenTaiKhoan] [nvarchar](200) NOT NULL,
	[MatKhau] [nvarchar](500) NOT NULL,
	[MaNhanVien] [int] NULL,
	[MaKhachHang] [int] NULL,
 CONSTRAINT [PK_TaiKhoan] PRIMARY KEY CLUSTERED 
(
	[MaTaiKhoan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Topping]    Script Date: 11/28/2018 2:26:14 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topping](
	[MaTopping] [int] IDENTITY(1,1) NOT NULL,
	[TenTopping] [nvarchar](200) NULL,
	[HinhAnh] [nvarchar](200) NULL,
	[DonGia] [money] NULL,
 CONSTRAINT [PK_Topping] PRIMARY KEY CLUSTERED 
(
	[MaTopping] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[ChuDe] ON 

INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [MoTa]) VALUES (1, N'do uong', N'do uong haha')
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [MoTa]) VALUES (2, N'do an', N'do an haha')
SET IDENTITY_INSERT [dbo].[ChuDe] OFF
INSERT [dbo].[GiamGia] ([MaKhuyenMai], [MaHoaDon]) VALUES (5, 27)
INSERT [dbo].[GiamGia] ([MaKhuyenMai], [MaHoaDon]) VALUES (5, 28)
INSERT [dbo].[GiamGia] ([MaKhuyenMai], [MaHoaDon]) VALUES (5, 29)
INSERT [dbo].[GiamGia] ([MaKhuyenMai], [MaHoaDon]) VALUES (5, 30)
INSERT [dbo].[GiamGia] ([MaKhuyenMai], [MaHoaDon]) VALUES (5, 31)
INSERT [dbo].[GiamGia] ([MaKhuyenMai], [MaHoaDon]) VALUES (5, 32)
INSERT [dbo].[GiamGia] ([MaKhuyenMai], [MaHoaDon]) VALUES (5, 33)
INSERT [dbo].[GiamGia] ([MaKhuyenMai], [MaHoaDon]) VALUES (5, 34)
INSERT [dbo].[GiamGia] ([MaKhuyenMai], [MaHoaDon]) VALUES (5, 35)
INSERT [dbo].[GiamGia] ([MaKhuyenMai], [MaHoaDon]) VALUES (5, 36)
INSERT [dbo].[GiamGia] ([MaKhuyenMai], [MaHoaDon]) VALUES (5, 37)
INSERT [dbo].[GiamGia] ([MaKhuyenMai], [MaHoaDon]) VALUES (5, 38)
INSERT [dbo].[GiamGia] ([MaKhuyenMai], [MaHoaDon]) VALUES (5, 39)
INSERT [dbo].[GiamGia] ([MaKhuyenMai], [MaHoaDon]) VALUES (6, 39)
SET IDENTITY_INSERT [dbo].[HoaDon] ON 

INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (23, NULL, 3, CAST(0xFE3E0B00 AS Date), N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (24, NULL, 3, CAST(0xFE3E0B00 AS Date), N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (25, NULL, 3, CAST(0xFE3E0B00 AS Date), N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (26, NULL, 3, CAST(0xFE3E0B00 AS Date), N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (27, NULL, 3, CAST(0xFF3E0B00 AS Date), N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (28, NULL, 3, CAST(0xFF3E0B00 AS Date), N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (29, NULL, 3, CAST(0xFF3E0B00 AS Date), N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (30, NULL, 3, CAST(0xFF3E0B00 AS Date), N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (31, NULL, 3, CAST(0xFF3E0B00 AS Date), N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (32, NULL, 3, CAST(0xFF3E0B00 AS Date), N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (33, NULL, 3, CAST(0xFF3E0B00 AS Date), N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (34, NULL, 3, CAST(0xFF3E0B00 AS Date), N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (35, NULL, 3, CAST(0xFF3E0B00 AS Date), N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (36, NULL, 3, CAST(0xFF3E0B00 AS Date), N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (37, NULL, 3, CAST(0xFF3E0B00 AS Date), N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (38, NULL, 3, CAST(0xFF3E0B00 AS Date), N'')
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (39, NULL, 3, CAST(0xFF3E0B00 AS Date), N'')
SET IDENTITY_INSERT [dbo].[HoaDon] OFF
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (24, 1, 15)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (25, 1, 10000)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (27, 1, 100)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (27, 2, 12)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (28, 3, 1000)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (29, 4, 1)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (30, 5, 1)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (30, 6, 1)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (30, 7, 1)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (31, 8, 1)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (32, 9, 1)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (33, 10, 1)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (34, 13, 1)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (35, 14, 1)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (36, 3, 1)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (37, 3, 1)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (39, 3, 11)
SET IDENTITY_INSERT [dbo].[KhuyenMai] ON 

INSERT [dbo].[KhuyenMai] ([MaKhuyenMai], [TenKhuyenMai], [GiaTri], [MoTa], [NgayBatDau], [NgayKetThuc]) VALUES (5, N'test1', 10, N'test khuyen mai', CAST(0x0000A97500000000 AS DateTime), CAST(0x0000AAE200000000 AS DateTime))
INSERT [dbo].[KhuyenMai] ([MaKhuyenMai], [TenKhuyenMai], [GiaTri], [MoTa], [NgayBatDau], [NgayKetThuc]) VALUES (6, N'test2', 5, N'test khuyen mai 2', CAST(0x0000A97500000000 AS DateTime), CAST(0x0000A9B400000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[KhuyenMai] OFF
INSERT [dbo].[LuaChon] ([MaLuaChon], [MaSanPham], [MaTopping]) VALUES (1, 2, 1)
INSERT [dbo].[LuaChon] ([MaLuaChon], [MaSanPham], [MaTopping]) VALUES (1, 2, 2)
INSERT [dbo].[LuaChon] ([MaLuaChon], [MaSanPham], [MaTopping]) VALUES (1, 2, 3)
INSERT [dbo].[LuaChon] ([MaLuaChon], [MaSanPham], [MaTopping]) VALUES (2, 6, 1)
INSERT [dbo].[LuaChon] ([MaLuaChon], [MaSanPham], [MaTopping]) VALUES (2, 6, 2)
INSERT [dbo].[LuaChon] ([MaLuaChon], [MaSanPham], [MaTopping]) VALUES (2, 6, 3)
INSERT [dbo].[LuaChon] ([MaLuaChon], [MaSanPham], [MaTopping]) VALUES (3, 2, 1)
INSERT [dbo].[LuaChon] ([MaLuaChon], [MaSanPham], [MaTopping]) VALUES (4, 1, 3)
INSERT [dbo].[LuaChon] ([MaLuaChon], [MaSanPham], [MaTopping]) VALUES (5, 2, 1)
INSERT [dbo].[LuaChon] ([MaLuaChon], [MaSanPham], [MaTopping]) VALUES (6, 6, 1)
INSERT [dbo].[LuaChon] ([MaLuaChon], [MaSanPham], [MaTopping]) VALUES (7, 7, 1)
INSERT [dbo].[LuaChon] ([MaLuaChon], [MaSanPham], [MaTopping]) VALUES (8, 2, 1)
INSERT [dbo].[LuaChon] ([MaLuaChon], [MaSanPham], [MaTopping]) VALUES (9, 2, 1)
INSERT [dbo].[LuaChon] ([MaLuaChon], [MaSanPham], [MaTopping]) VALUES (10, 2, 1)
INSERT [dbo].[LuaChon] ([MaLuaChon], [MaSanPham], [MaTopping]) VALUES (11, 2, 1)
INSERT [dbo].[LuaChon] ([MaLuaChon], [MaSanPham], [MaTopping]) VALUES (12, 2, 1)
INSERT [dbo].[LuaChon] ([MaLuaChon], [MaSanPham], [MaTopping]) VALUES (13, 2, 1)
INSERT [dbo].[LuaChon] ([MaLuaChon], [MaSanPham], [MaTopping]) VALUES (14, 2, 1)
INSERT [dbo].[MaLuaChon] ([MaLuaChon]) VALUES (1)
INSERT [dbo].[MaLuaChon] ([MaLuaChon]) VALUES (2)
INSERT [dbo].[MaLuaChon] ([MaLuaChon]) VALUES (3)
INSERT [dbo].[MaLuaChon] ([MaLuaChon]) VALUES (4)
INSERT [dbo].[MaLuaChon] ([MaLuaChon]) VALUES (5)
INSERT [dbo].[MaLuaChon] ([MaLuaChon]) VALUES (6)
INSERT [dbo].[MaLuaChon] ([MaLuaChon]) VALUES (7)
INSERT [dbo].[MaLuaChon] ([MaLuaChon]) VALUES (8)
INSERT [dbo].[MaLuaChon] ([MaLuaChon]) VALUES (9)
INSERT [dbo].[MaLuaChon] ([MaLuaChon]) VALUES (10)
INSERT [dbo].[MaLuaChon] ([MaLuaChon]) VALUES (11)
INSERT [dbo].[MaLuaChon] ([MaLuaChon]) VALUES (12)
INSERT [dbo].[MaLuaChon] ([MaLuaChon]) VALUES (13)
INSERT [dbo].[MaLuaChon] ([MaLuaChon]) VALUES (14)
SET IDENTITY_INSERT [dbo].[NhanVien] ON 

INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [NgaySinh], [DiaChi], [SDT], [Email], [HinhAnh], [NgayBatDau]) VALUES (1, N'haha', 1, CAST(0xD03E0B00 AS Date), N'haha', N'haaha', N'HAHA', N'AHA ', CAST(0xD03E0B00 AS Date))
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [NgaySinh], [DiaChi], [SDT], [Email], [HinhAnh], [NgayBatDau]) VALUES (2, N'cao xuan son', 1, CAST(0xF73E0B00 AS Date), N'1', N'1', N'1', N'1', CAST(0xD03E0B00 AS Date))
INSERT [dbo].[NhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [NgaySinh], [DiaChi], [SDT], [Email], [HinhAnh], [NgayBatDau]) VALUES (3, N'đặng minh hòa', 0, CAST(0xFD220B00 AS Date), N'hà nội', N'xx', N'MOn Lon Ton', N'636789677032111303.jpg', CAST(0xF03E0B00 AS Date))
SET IDENTITY_INSERT [dbo].[NhanVien] OFF
INSERT [dbo].[PhanQuyen] ([MaQuyen], [MaTaiKhoan]) VALUES (3, 2)
INSERT [dbo].[PhanQuyen] ([MaQuyen], [MaTaiKhoan]) VALUES (5, 4)
INSERT [dbo].[PhanQuyen] ([MaQuyen], [MaTaiKhoan]) VALUES (6, 2)
INSERT [dbo].[PhanQuyen] ([MaQuyen], [MaTaiKhoan]) VALUES (6, 5)
SET IDENTITY_INSERT [dbo].[Quyen] ON 

INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (1, N'Get', N'lấy dữ liệu')
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (2, N'Post', N'thêm dữ liệu')
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (3, N'Put', N'sửa dữ liệu')
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (4, N'Delete', N'xóa dữ liệu')
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (5, N'Admin', N'quyền cao nhất')
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (6, N'NhanVien', N'nhan vien')
SET IDENTITY_INSERT [dbo].[Quyen] OFF
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [KichCo], [MaChuDe], [HinhAnh], [DonGia]) VALUES (1, N'do uong 1', N'a ', 1, NULL, 50000,0000)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [KichCo], [MaChuDe], [HinhAnh], [DonGia]) VALUES (2, N'do an 1', N'a', 2, NULL, 30000,0000)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [KichCo], [MaChuDe], [HinhAnh], [DonGia]) VALUES (3, N'do uong 2', N'a ', 1, NULL, NULL)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [KichCo], [MaChuDe], [HinhAnh], [DonGia]) VALUES (4, N'do uong 3', N'a ', 1, NULL, NULL)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [KichCo], [MaChuDe], [HinhAnh], [DonGia]) VALUES (5, N'do uong 4', N'a', 1, NULL, NULL)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [KichCo], [MaChuDe], [HinhAnh], [DonGia]) VALUES (6, N'do an 2', N'a', 2, NULL, NULL)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [KichCo], [MaChuDe], [HinhAnh], [DonGia]) VALUES (7, N'do an 3', N'a', 2, NULL, NULL)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
SET IDENTITY_INSERT [dbo].[TaiKhoan] ON 

INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenTaiKhoan], [MatKhau], [MaNhanVien], [MaKhachHang]) VALUES (2, N'nhanvien1', N'1', 1, NULL)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenTaiKhoan], [MatKhau], [MaNhanVien], [MaKhachHang]) VALUES (4, N'admin1', N'1', 3, NULL)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenTaiKhoan], [MatKhau], [MaNhanVien], [MaKhachHang]) VALUES (5, N'nhanvien2', N'1', 2, NULL)
SET IDENTITY_INSERT [dbo].[TaiKhoan] OFF
SET IDENTITY_INSERT [dbo].[Topping] ON 

INSERT [dbo].[Topping] ([MaTopping], [TenTopping], [HinhAnh], [DonGia]) VALUES (1, N'tran chau trang', NULL, 10000,0000)
INSERT [dbo].[Topping] ([MaTopping], [TenTopping], [HinhAnh], [DonGia]) VALUES (2, N'tran chau den', NULL, 20000,0000)
INSERT [dbo].[Topping] ([MaTopping], [TenTopping], [HinhAnh], [DonGia]) VALUES (3, N'tran chau cam', NULL, 25555,0000)
SET IDENTITY_INSERT [dbo].[Topping] OFF
ALTER TABLE [dbo].[HoaDon] ADD  CONSTRAINT [DF_HoaDon_NgayTao]  DEFAULT (getdate()) FOR [NgayTao]
GO
ALTER TABLE [dbo].[KhuyenMai] ADD  CONSTRAINT [DF_KhuyenMai_NgayBatDau]  DEFAULT (getdate()) FOR [NgayBatDau]
GO
ALTER TABLE [dbo].[KhuyenMai] ADD  CONSTRAINT [DF_KhuyenMai_NgayKetThuc]  DEFAULT (getdate()) FOR [NgayKetThuc]
GO
ALTER TABLE [dbo].[NhanVien] ADD  CONSTRAINT [DF_NhanVien_NgaySinh]  DEFAULT (getdate()) FOR [NgaySinh]
GO
ALTER TABLE [dbo].[NhanVien] ADD  CONSTRAINT [DF_NhanVien_NgayBatDau]  DEFAULT (getdate()) FOR [NgayBatDau]
GO
ALTER TABLE [dbo].[GiamGia]  WITH CHECK ADD  CONSTRAINT [FK_GiamGia_HoaDon] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GiamGia] CHECK CONSTRAINT [FK_GiamGia_HoaDon]
GO
ALTER TABLE [dbo].[GiamGia]  WITH CHECK ADD  CONSTRAINT [FK_GiamGia_KhuyenMai] FOREIGN KEY([MaKhuyenMai])
REFERENCES [dbo].[KhuyenMai] ([MaKhuyenMai])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[GiamGia] CHECK CONSTRAINT [FK_GiamGia_KhuyenMai]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_KhachHang]
GO
ALTER TABLE [dbo].[HoaDon]  WITH CHECK ADD  CONSTRAINT [FK_HoaDon_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HoaDon] CHECK CONSTRAINT [FK_HoaDon_NhanVien]
GO
ALTER TABLE [dbo].[HoaDonChiTiet]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonChiTiet_HoaDon1] FOREIGN KEY([MaHoaDon])
REFERENCES [dbo].[HoaDon] ([MaHoaDon])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HoaDonChiTiet] CHECK CONSTRAINT [FK_HoaDonChiTiet_HoaDon1]
GO
ALTER TABLE [dbo].[HoaDonChiTiet]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonChiTiet_MaLuaChon] FOREIGN KEY([MaLuaChon])
REFERENCES [dbo].[MaLuaChon] ([MaLuaChon])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HoaDonChiTiet] CHECK CONSTRAINT [FK_HoaDonChiTiet_MaLuaChon]
GO
ALTER TABLE [dbo].[LuaChon]  WITH CHECK ADD  CONSTRAINT [FK_LuaChon_MaLuaChon] FOREIGN KEY([MaLuaChon])
REFERENCES [dbo].[MaLuaChon] ([MaLuaChon])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LuaChon] CHECK CONSTRAINT [FK_LuaChon_MaLuaChon]
GO
ALTER TABLE [dbo].[LuaChon]  WITH CHECK ADD  CONSTRAINT [FK_LuaChon_SanPham] FOREIGN KEY([MaSanPham])
REFERENCES [dbo].[SanPham] ([MaSanPham])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LuaChon] CHECK CONSTRAINT [FK_LuaChon_SanPham]
GO
ALTER TABLE [dbo].[LuaChon]  WITH CHECK ADD  CONSTRAINT [FK_LuaChon_Topping] FOREIGN KEY([MaTopping])
REFERENCES [dbo].[Topping] ([MaTopping])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LuaChon] CHECK CONSTRAINT [FK_LuaChon_Topping]
GO
ALTER TABLE [dbo].[PhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_PhanQuyen_Quyen] FOREIGN KEY([MaQuyen])
REFERENCES [dbo].[Quyen] ([MaQuyen])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PhanQuyen] CHECK CONSTRAINT [FK_PhanQuyen_Quyen]
GO
ALTER TABLE [dbo].[PhanQuyen]  WITH CHECK ADD  CONSTRAINT [FK_PhanQuyen_TaiKhoan] FOREIGN KEY([MaTaiKhoan])
REFERENCES [dbo].[TaiKhoan] ([MaTaiKhoan])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PhanQuyen] CHECK CONSTRAINT [FK_PhanQuyen_TaiKhoan]
GO
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_ChuDe] FOREIGN KEY([MaChuDe])
REFERENCES [dbo].[ChuDe] ([MaChuDe])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_ChuDe]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_KhachHang] FOREIGN KEY([MaKhachHang])
REFERENCES [dbo].[KhachHang] ([MaKhachHang])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_KhachHang]
GO
ALTER TABLE [dbo].[TaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_TaiKhoan_NhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[NhanVien] ([MaNhanVien])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TaiKhoan] CHECK CONSTRAINT [FK_TaiKhoan_NhanVien]
GO
