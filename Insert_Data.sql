use QuanLyTraSua
go


-- quyen`
BEGIN TRANSACTION
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (1, N'Get', N'lấy dữ liệu')
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (2, N'Post', N'thêm dữ liệu')
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (3, N'Put', N'sửa dữ liệu')
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (4, N'Delete', N'xóa dữ liệu')
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (5, N'Admin', N'quyền cao nhất')
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (6, N'NhanVien', N'nhan vien')
INSERT [dbo].[Quyen] ([MaQuyen], [TenQuyen], [MoTa]) VALUES (7, N'KhachHang', N'khách hàng, chi được xem thông tin của mình, đặt sản phẩm.')
COMMIT

-- tai khoan?
BEGIN TRANSACTION
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenTaiKhoan], [MatKhau], [MaNhanVien], [MaKhachHang]) VALUES (2, N'nhanvien1', N'1', 1, NULL)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenTaiKhoan], [MatKhau], [MaNhanVien], [MaKhachHang]) VALUES (4, N'admin1', N'1', 3, NULL)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenTaiKhoan], [MatKhau], [MaNhanVien], [MaKhachHang]) VALUES (5, N'nhanvien2', N'1', 2, NULL)
INSERT [dbo].[TaiKhoan] ([MaTaiKhoan], [TenTaiKhoan], [MatKhau], [MaNhanVien], [MaKhachHang]) VALUES (6, N'nhanvien3', N'1', 4, NULL)
COMMIT

--phan quyen`
BEGIN TRANSACTION
INSERT [dbo].[PhanQuyen] ([MaQuyen], [MaTaiKhoan]) VALUES (3, 2)
INSERT [dbo].[PhanQuyen] ([MaQuyen], [MaTaiKhoan]) VALUES (5, 4)
INSERT [dbo].[PhanQuyen] ([MaQuyen], [MaTaiKhoan]) VALUES (6, 2)
INSERT [dbo].[PhanQuyen] ([MaQuyen], [MaTaiKhoan]) VALUES (6, 5)
COMMIT

--nhan vien
BEGIN TRANSACTION
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [GioiTinh], [NgaySinh], [DiaChi], [SDT], [Email], [HinhAnh]) VALUES (1, N'x', 1, CAST(0x193F0B00 AS Date), N'x', N'x', N'x', N'x')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [GioiTinh], [NgaySinh], [DiaChi], [SDT], [Email], [HinhAnh]) VALUES (2, N'x', 1, CAST(0x193F0B00 AS Date), N'x', N'x', N'x', N'x')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [GioiTinh], [NgaySinh], [DiaChi], [SDT], [Email], [HinhAnh]) VALUES (3, N'xxx', 1, CAST(0x193F0B00 AS Date), N'x', N'x', N'x', N'x')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [GioiTinh], [NgaySinh], [DiaChi], [SDT], [Email], [HinhAnh]) VALUES (4, N'xxx', 1, CAST(0x193F0B00 AS Date), N'x', N'x', N'x', N'x')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [GioiTinh], [NgaySinh], [DiaChi], [SDT], [Email], [HinhAnh]) VALUES (5, N'aaa', 1, CAST(0x193F0B00 AS Date), N'x', N'x', N'x', N'x')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [GioiTinh], [NgaySinh], [DiaChi], [SDT], [Email], [HinhAnh]) VALUES (6, N'bb', 1, CAST(0x193F0B00 AS Date), N'x', N'x', N'x', N'x')
COMMIT

--khach hang`
BEGIN TRANSACTION
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [GioiTinh], [NgaySinh], [DiaChi], [SDT], [Email], [HinhAnh]) VALUES (1, N'x', 1, CAST(0x193F0B00 AS Date), N'x', N'x', N'x', N'x')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [GioiTinh], [NgaySinh], [DiaChi], [SDT], [Email], [HinhAnh]) VALUES (2, N'x', 1, CAST(0x193F0B00 AS Date), N'x', N'x', N'x', N'x')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [GioiTinh], [NgaySinh], [DiaChi], [SDT], [Email], [HinhAnh]) VALUES (3, N'xxx', 1, CAST(0x193F0B00 AS Date), N'x', N'x', N'x', N'x')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [GioiTinh], [NgaySinh], [DiaChi], [SDT], [Email], [HinhAnh]) VALUES (4, N'xxx', 1, CAST(0x193F0B00 AS Date), N'x', N'x', N'x', N'x')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [GioiTinh], [NgaySinh], [DiaChi], [SDT], [Email], [HinhAnh]) VALUES (5, N'aaa', 1, CAST(0x193F0B00 AS Date), N'x', N'x', N'x', N'x')
INSERT [dbo].[KhachHang] ([MaKhachHang], [TenKhachHang], [GioiTinh], [NgaySinh], [DiaChi], [SDT], [Email], [HinhAnh]) VALUES (6, N'bb', 1, CAST(0x193F0B00 AS Date), N'x', N'x', N'x', N'x')
COMMIT

--khuyen mai~
BEGIN TRANSACTION
INSERT [dbo].[KhuyenMai] ([MaKhuyenMai], [TenKhuyenMai], [GiaTri], [MoTa], [NgayBatDau], [NgayKetThuc]) VALUES (5, N'test1', 10, N'test khuyen mai', CAST(0x0000A97500000000 AS DateTime), CAST(0x0000AAE200000000 AS DateTime))
INSERT [dbo].[KhuyenMai] ([MaKhuyenMai], [TenKhuyenMai], [GiaTri], [MoTa], [NgayBatDau], [NgayKetThuc]) VALUES (6, N'test2', 5, N'test khuyen mai 2', CAST(0x0000A97500000000 AS DateTime), CAST(0x0000A9B400000000 AS DateTime))
COMMIT

--giam gia'
BEGIN TRANSACTION
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
COMMIT

--chu? de`
BEGIN TRANSACTION
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [MoTa]) VALUES (1, N'do uong', N'do uong haha')
INSERT [dbo].[ChuDe] ([MaChuDe], [TenChuDe], [MoTa]) VALUES (2, N'do an', N'do an haha')
COMMIT

--san? pham?
BEGIN TRANSACTION
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [KichCo], [MaChuDe], [HinhAnh], [DonGia]) VALUES (1, N'do uong 1', N'a ', 1, N'636789677032111303.jpg', 50000,0000)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [KichCo], [MaChuDe], [HinhAnh], [DonGia]) VALUES (2, N'do an 1', N'a', 2, N'636789677032111303.jpg', 30000,0000)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [KichCo], [MaChuDe], [HinhAnh], [DonGia]) VALUES (3, N'do uong 2', N'a ', 1, N'636789677032111303.jpg', 20000,0000)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [KichCo], [MaChuDe], [HinhAnh], [DonGia]) VALUES (4, N'do uong 3', N'a ', 1, N'636789677032111303.jpg', 20000,0000)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [KichCo], [MaChuDe], [HinhAnh], [DonGia]) VALUES (5, N'do uong 4', N'a', 1, N'636789677032111303.jpg', 20000,0000)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [KichCo], [MaChuDe], [HinhAnh], [DonGia]) VALUES (6, N'do an 2', N'a', 2, N'636789677032111303.jpg', 20000,0000)
INSERT [dbo].[SanPham] ([MaSanPham], [TenSanPham], [KichCo], [MaChuDe], [HinhAnh], [DonGia]) VALUES (7, N'do an 3', N'a', 2, N'636789677032111303.jpg', 20000,0000)
COMMIT

--topping
BEGIN TRANSACTION
INSERT [dbo].[Topping] ([MaTopping], [TenTopping], [HinhAnh], [DonGia]) VALUES (1, N'tran chau trang', NULL, 10000,0000)
INSERT [dbo].[Topping] ([MaTopping], [TenTopping], [HinhAnh], [DonGia]) VALUES (2, N'tran chau den', NULL, 20000,0000)
INSERT [dbo].[Topping] ([MaTopping], [TenTopping], [HinhAnh], [DonGia]) VALUES (3, N'tran chau cam', NULL, 25555,0000)
COMMIT

-- lua. chon.
BEGIN TRANSACTION
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
COMMIT


-- ma lua chon
BEGIN TRANSACTION
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
COMMIT


-- hoa' don
BEGIN TRANSACTION
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
COMMIT


-- hoa don chi tiet
BEGIN TRANSACTION
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
COMMIT