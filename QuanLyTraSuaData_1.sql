USE [QuanLyTraSua]
GO
/****** Object:  UserDefinedFunction [dbo].[ThongKeHoaDonTheoCacThang]    Script Date: 11/3/2018 9:42:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ThongKeHoaDonTheoCacThang]()
RETURNS @table TABLE (
    nam int,
	thang int,
	soluonghoadon int)
BEGIN
	INSERT @table
		select nam, thang, COUNT(mahoadon) as sohoadon from (select DISTINCT  MaHoaDon as mahoadon, nam, thang from (select YEAR(Ngaytao) as nam, MONTH(NgayTao) as thang from HoaDon where YEAR(NgayTao) in (select YEAR(NgayTao) as nam from HoaDon)) a , HoaDon b
		where YEAR(b.NgayTao) = nam AND MONTH(b.NgayTao) = thang) c
		Group by nam, thang
RETURN
END
GO
/****** Object:  UserDefinedFunction [dbo].[ThongKeSanPhamTheoCacThang]    Script Date: 11/3/2018 9:42:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ThongKeSanPhamTheoCacThang]()
RETURNS @table TABLE (
    nam int,
	thang int,
	soluong int)
BEGIN
	INSERT @table
	select c.nam, c.thang, d.[so luong coc] from (select DISTINCT  MaHoaDon as mahoadon, nam, thang from (select YEAR(Ngaytao) as nam, MONTH(NgayTao) as thang from HoaDon where YEAR(NgayTao) in (select YEAR(NgayTao) as nam from HoaDon)) a , HoaDon b
	where YEAR(b.NgayTao) = nam AND MONTH(b.NgayTao) = thang) c, (select MaHoaDon ,SUM(SoLuong) as [so luong coc] from HoaDonChiTiet
	Group by MaHoaDon) d
	where c.mahoadon = d.MaHoaDon
RETURN
END
GO
/****** Object:  UserDefinedFunction [dbo].[ThongKeTienBanDuocTheoThang]    Script Date: 11/3/2018 9:42:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[ThongKeTienBanDuocTheoThang]()
RETURNS @table TABLE (
    nam int,
	thang int,
	tongtien int)
BEGIN
	INSERT @table
		select DISTINCT e.nam, e.thang, SUM((f.tongtienluachon * e.soluong)) as tongtien 
		from (select c.MaHoaDon as mahoadon, c.MaLuaChon as maluachon, c.SoLuong as soluong,  d.nam, d.thang from HoaDonChiTiet c, (select DISTINCT  MaHoaDon as mahoadon, nam, thang from (select YEAR(Ngaytao) as nam, MONTH(NgayTao) as thang from HoaDon where YEAR(NgayTao) in (select YEAR(NgayTao) as nam from HoaDon)) a , HoaDon b
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
GO
/****** Object:  Table [dbo].[ChuDe]    Script Date: 11/3/2018 9:42:29 PM ******/
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
/****** Object:  Table [dbo].[GiamGia]    Script Date: 11/3/2018 9:42:29 PM ******/
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
/****** Object:  Table [dbo].[HoaDon]    Script Date: 11/3/2018 9:42:29 PM ******/
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
/****** Object:  Table [dbo].[HoaDonChiTiet]    Script Date: 11/3/2018 9:42:29 PM ******/
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
/****** Object:  Table [dbo].[KhachHang]    Script Date: 11/3/2018 9:42:29 PM ******/
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
/****** Object:  Table [dbo].[KhuyenMai]    Script Date: 11/3/2018 9:42:29 PM ******/
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
/****** Object:  Table [dbo].[LuaChon]    Script Date: 11/3/2018 9:42:29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LuaChon](
	[MaLuaChon] [int] IDENTITY(1,1) NOT NULL,
	[MaSanPham] [int] NULL,
	[MaTopping] [int] NULL,
 CONSTRAINT [PK_LuaChon] PRIMARY KEY CLUSTERED 
(
	[MaLuaChon] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NhanVien]    Script Date: 11/3/2018 9:42:29 PM ******/
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
/****** Object:  Table [dbo].[SanPham]    Script Date: 11/3/2018 9:42:29 PM ******/
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
/****** Object:  Table [dbo].[Topping]    Script Date: 11/3/2018 9:42:29 PM ******/
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
SET IDENTITY_INSERT [dbo].[HoaDon] ON 

INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (2, NULL, NULL, CAST(0x46350B00 AS Date), NULL)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (3, NULL, NULL, CAST(0x8E390B00 AS Date), NULL)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (4, NULL, NULL, CAST(0x26350B00 AS Date), NULL)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (5, NULL, NULL, CAST(0x45350B00 AS Date), NULL)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (6, NULL, NULL, CAST(0x62350B00 AS Date), NULL)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (7, NULL, NULL, CAST(0x81350B00 AS Date), NULL)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (8, NULL, NULL, CAST(0x9F350B00 AS Date), NULL)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (9, NULL, NULL, CAST(0xBE350B00 AS Date), NULL)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (10, NULL, NULL, CAST(0xDC350B00 AS Date), NULL)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (11, NULL, NULL, CAST(0xFB350B00 AS Date), NULL)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (12, NULL, NULL, CAST(0x1A360B00 AS Date), NULL)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (13, NULL, NULL, CAST(0x38360B00 AS Date), NULL)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (14, NULL, NULL, CAST(0x57360B00 AS Date), NULL)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (15, NULL, NULL, CAST(0x75360B00 AS Date), NULL)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (16, NULL, NULL, CAST(0x28350B00 AS Date), NULL)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (17, NULL, NULL, CAST(0x2A350B00 AS Date), NULL)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (18, NULL, NULL, CAST(0x2A350B00 AS Date), NULL)
INSERT [dbo].[HoaDon] ([MaHoaDon], [MaKhachHang], [MaNhanVien], [NgayTao], [MoTa]) VALUES (19, NULL, NULL, CAST(0x2C350B00 AS Date), NULL)
SET IDENTITY_INSERT [dbo].[HoaDon] OFF
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (2, 1, 10)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (2, 2, 10)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (3, 1, 10)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (3, 2, 10)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (3, 3, 15)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (4, 1, 2)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (4, 2, 1)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (4, 3, 1)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (5, 1, 4)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (6, 1, 4)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (7, 1, 4)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (7, 3, 4)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (8, 1, 4)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (8, 2, 4)
INSERT [dbo].[HoaDonChiTiet] ([MaHoaDon], [MaLuaChon], [SoLuong]) VALUES (8, 3, 4)
SET IDENTITY_INSERT [dbo].[KhuyenMai] ON 

INSERT [dbo].[KhuyenMai] ([MaKhuyenMai], [TenKhuyenMai], [GiaTri], [MoTa], [NgayBatDau], [NgayKetThuc]) VALUES (2, N'khuyen mai 1', 40, N'khuyen ', CAST(0x0000A97500000000 AS DateTime), CAST(0x0000A99500000000 AS DateTime))
INSERT [dbo].[KhuyenMai] ([MaKhuyenMai], [TenKhuyenMai], [GiaTri], [MoTa], [NgayBatDau], [NgayKetThuc]) VALUES (3, N'khuyen mai 2', 50, N'khuyen mai', CAST(0x0000A95600000000 AS DateTime), CAST(0x0000AAE200000000 AS DateTime))
SET IDENTITY_INSERT [dbo].[KhuyenMai] OFF
SET IDENTITY_INSERT [dbo].[LuaChon] ON 

INSERT [dbo].[LuaChon] ([MaLuaChon], [MaSanPham], [MaTopping]) VALUES (1, 1, 1)
INSERT [dbo].[LuaChon] ([MaLuaChon], [MaSanPham], [MaTopping]) VALUES (2, 1, 2)
INSERT [dbo].[LuaChon] ([MaLuaChon], [MaSanPham], [MaTopping]) VALUES (3, 1, 3)
SET IDENTITY_INSERT [dbo].[LuaChon] OFF
SET IDENTITY_INSERT [dbo].[SanPham] ON 

INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [KichCo], [MaChuDe], [HinhAnh], [DonGia]) VALUES (1, N'san pham 1', N'a ', 1, NULL, 50000,0000)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [KichCo], [MaChuDe], [HinhAnh], [DonGia]) VALUES (2, N'san pham 2 ', N'a', 2, NULL, 30000,0000)
SET IDENTITY_INSERT [dbo].[SanPham] OFF
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
ALTER TABLE [dbo].[HoaDonChiTiet]  WITH CHECK ADD  CONSTRAINT [FK_HoaDonChiTiet_LuaChon] FOREIGN KEY([MaLuaChon])
REFERENCES [dbo].[LuaChon] ([MaLuaChon])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[HoaDonChiTiet] CHECK CONSTRAINT [FK_HoaDonChiTiet_LuaChon]
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
ALTER TABLE [dbo].[SanPham]  WITH CHECK ADD  CONSTRAINT [FK_SanPham_ChuDe] FOREIGN KEY([MaChuDe])
REFERENCES [dbo].[ChuDe] ([MaChuDe])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[SanPham] CHECK CONSTRAINT [FK_SanPham_ChuDe]
GO
