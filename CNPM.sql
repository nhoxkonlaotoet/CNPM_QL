use aaaaa
drop database QuanLyBanNuoc

create database QuanLyBanNuoc

use QuanLyBanNuoc


create table TaiKhoan(
	SDT nvarchar(12) primary key, 
	MatKhau nvarchar(20), 
	QuyenHan nvarchar(20), 
	TinhTrang nvarchar(50), 
	NgayKichHoat date
)

create table LoaiSanPham(
	MaLoai int identity primary key,
	TenLoai nvarchar(100),
	DungTich float, 
	Gia int,
	Hinh varbinary(MAX)
)



create table SanPham(
	MaSP int identity primary key,
	TrangThai nvarchar(50), 
	MaLoai int references LoaiSanPham(MaLoai),
	NgaySanXuat date,
	HanSuDung date
)


create table KhachHang(
	MaKH int identity primary key, 
	HoTen nvarchar(100),
	Tuoi int, 
	Nam bit, 
	DiaChi nvarchar(100), 
	Lat float,
	Lng float,
	SoDienThoai nvarchar(12), 
	Hinh varbinary(MAX)
)


create table NhanVien(
	MaNV int identity primary key, 
	HoTen nvarchar(100), 
	Tuoi int , 
	Nam bit, 
	DiaChi nvarchar(100), 
	CMND nchar(10), 
	SoDienThoai nvarchar(12), 
	Hinh varbinary(MAX),
	TrangThai nvarchar(50)
)


create table DonHang(
	MaDH int identity primary key, 
	ThoiDiemDatHang date, 
	TongSoTien int, 
	MaKH int references KhachHang(MaKH),
	TrangThai nvarchar(50)
)


create table ChiTietDonHang(
	MaDH int references DonHang(MaDH), 
	MaSP int references Sanpham(MaSP), 
	SoTien int,
	primary key (MaDH,MaSP)
)


create table GiaoHang(
	MaDH int references DonHang(MaDH), 
	MaNV int references NhanVien(MaNV), 
	ThoiDiemGiaoHang date,
	primary key (MaDH, MaNV)
)


create table HoaDon(
	MaHD int identity primary key, 
	NgayIn date, 
	TongSoTien int, 
	MaDH int references DonHang(MaDH), 
	MaNV int references NhanVien(MaNV)
)



create table ChiTietHoaDon(
	MaHD int references HoaDon(MaHD), 
	MaSP int references SanPham(MaSP), 
	SoTien int,
	primary key (MaHD, MaSP)
)


create table TienCong(
	MaNV int references NhanVien(MaNV), 
	MaHD int references HoaDon(MaHD),
	SoTien int ,
	Ngay date,
)-- sua



create table GopY(
	MaGY int identity primary key, 
	NoiDung nvarchar(500),
	MaKH int references KhachHang(MaKH)
)

DBCC CHECKIDENT ('[GopY]', RESEED, 0);




insert into TaiKhoan values('0123214989','123456',N'Khách', N'Hoạt động', '1/1/2017');
insert into TaiKhoan values('0163356565','123456',N'Khách', N'Hoạt động', '1/1/2017');
insert into TaiKhoan values('0166113213','123456',N'Khách', N'Hoạt động', '1/1/2017');
insert into TaiKhoan values('092323265','123456',N'Khách', N'Hoạt động', '1/1/2017');
insert into TaiKhoan values('090989898','123456',N'Khách', N'Hoạt động', '1/1/2017');
insert into TaiKhoan values('0167132323','123456',N'Khách', N'Hoạt động', '1/1/2017');
insert into TaiKhoan values('0169323232','123456',N'Khách', N'Hoạt động', '1/1/2017');

insert into TaiKhoan values('099999999','123456',N'Nhân viên', N'Hoạt động', '1/1/2017');
insert into TaiKhoan values('090000000','123456',N'Nhân viên', N'Hoạt động', '1/1/2017');
insert into TaiKhoan values('090000009','123456',N'Nhân viên', N'Hoạt động', '1/1/2017');

insert into TaiKhoan values('Chu','123456',N'Quản lí', N'Hoạt động', '1/1/2017');
insert into TaiKhoan values('Admin','123456',N'Admin', N'Hoạt động', '1/1/2017');


DBCC CHECKIDENT ('[LoaiSanPham]', RESEED, 0);
insert into LoaiSanPham values( N'Bình nước 20L', 20, 15000, null);
insert into LoaiSanPham values( N'Bình nước 5L', 5, 20000, null);
insert into LoaiSanPham values( N'Chai nước 1L', 1, 10000, null);
insert into LoaiSanPham values( N'Chai nước 300ml', 0.3, 3000, null);



DBCC CHECKIDENT ('[SanPham]', RESEED, 0);

insert into SanPham values(N'Đã bán', 0, '1/1/2017', '1/1/2018');
insert into SanPham values(N'Đã bán', 0, '1/1/2017', '1/1/2018');
insert into SanPham values(N'Còn', 0, '1/1/2017', '1/1/2018');
insert into SanPham values(N'Còn', 0, '1/1/2017', '1/1/2018');
insert into SanPham values(N'Còn', 0, '1/1/2017', '1/1/2018');
insert into SanPham values(N'Đã bán', 1, '1/1/2017', '1/1/2018');
insert into SanPham values(N'Còn', 1, '1/1/2017', '1/1/2018');
insert into SanPham values(N'Còn', 1, '1/1/2017', '1/1/2018');
insert into SanPham values(N'Còn', 1, '1/1/2017', '1/1/2018');
insert into SanPham values(N'Còn', 2, '1/1/2017', '1/1/2018');
insert into SanPham values(N'Còn', 2, '1/1/2017', '1/1/2018');
insert into SanPham values(N'Còn', 2, '1/1/2017', '1/1/2018');
insert into SanPham values(N'Đã bán', 3, '1/1/2017', '1/1/2018');
insert into SanPham values(N'Đã bán', 3, '1/1/2017', '1/1/2018');
insert into SanPham values(N'Đã bán', 3, '1/1/2017', '1/1/2018');
insert into SanPham values(N'Còn', 0, '1/1/2017', '1/1/2018');
insert into SanPham values(N'Còn', 0, '1/1/2017', '1/1/2018');




DBCC CHECKIDENT ('[KhachHang]', RESEED, 0);

insert into KhachHang values(N'Phan Nguyễn A', 20, 1, N'Hẻm 3 Đường số 10 Linh Trung, Thủ Đức, Hồ Chí Minh, Việt Nam', 10.856587, 106.772296, '0123214989', null);
insert into KhachHang values(N'Phạm Nguyễn B', 20, 1, N'Linh Chiểu Thủ Đức, Hồ Chí Minh, Việt Nam',10.854297, 106.760040, '0163356565', null);
insert into KhachHang values(N'Nguyễn Trần C', 20, 1, N'33-27 Đường số 9 Trường Thọ, Thủ Đức, Hồ Chí Minh, Việt Nam',10.847131, 106.757508, '0166113213', null);
insert into KhachHang values(N'Nguyễn Văn D', 20, 1, N'10/240B Lê Văn Việt Hiệp Phú, Quận 9, Hồ Chí Minh, Việt Nam',10.846319, 106.778575, '092323265', null);
insert into KhachHang values(N'Nguyễn E', 20, 0, N'A749 Trương Văn Thành Hiệp Phú, Quận 9, Hồ Chí Minh, Việt Nam',10.845352, 106.782373, '090989898', null);
insert into KhachHang values(N'Lý Thị F', 20, 0, N'Lê Lợi Hiệp Phú, Quận 9, Hồ Chí Minh, Việt Nam', 10.845596, 106.774662, '0167132323', null);
insert into KhachHang values(N'Nguyễn Thị G', 20, 0, N'204-230 Đặng Văn Bi Bình Thọ, Thủ Đức, Hồ Chí Minh, Việt Nam', 10.848941, 106.759572, '0169323232', null);


DBCC CHECKIDENT ('[NhanVien]', RESEED, 0);

insert into NhanVien values(N'Phạm Nhân Viên', 20, 1, N'Quận 9', '123456789', '099999999', null, N'Rảnh');
insert into NhanVien values(N'Nguyên Văn Lính', 20, 1, N'Quận Thủ Đức', '456789123', '090000000', null, N'Rảnh'); 
insert into NhanVien values(N'Phan Giao Hàng', 20, 1, N'Quận Thủ Đức', '123789456', '090000009', null, N'Rảnh'); 
 

 DBCC CHECKIDENT ('[DonHang]', RESEED, 0);

insert into DonHang values('10/20/2017', 15000, 0, N'Đã nhận');
insert into DonHang values('10/20/2017', 9000, 1, N'Đã nhận');
insert into DonHang values('10/20/2017', 20000, 1, N'Đã nhận');
insert into DonHang values('10/20/2017', 15000, 2, N'Đã nhận');



insert into ChiTietDonHang values(0,0,15000);
insert into ChiTietDonHang values(1,12,3000);
insert into ChiTietDonHang values(1,13,3000);
insert into ChiTietDonHang values(1,14,3000);
insert into ChiTietDonHang values(2,5,20000);
insert into ChiTietDonHang values(3,1,15000);



insert into GiaoHang values(0,0,'10/20/2017');
insert into GiaoHang values(1,2,'10/20/2017');
insert into GiaoHang values(2,1,'10/20/2017');
insert into GiaoHang values(3,0,'10/20/2017');


DBCC CHECKIDENT ('[HoaDon]', RESEED, 0);

insert into HoaDon values('10/20/2017',15000, 0, 0);
insert into HoaDon values('10/20/2017',9000, 1,2);
insert into HoaDon values('10/20/2017',20000, 2, 1);
insert into HoaDon values('10/20/2017',15000, 3, 0);



insert into ChiTietHoaDon values(0,0,15000);
insert into ChiTietHoaDon values(1,12,3000);
insert into ChiTietHoaDon values(1,13,3000);
insert into ChiTietHoaDon values(1,14,3000);
insert into ChiTietHoaDon values(2,5,20000);
insert into ChiTietHoaDon values(3,1,15000);


insert into TienCong values(0, 0, 3000, '10/20/2017');
insert into TienCong values(2, 1, 1800, '10/20/2017');
insert into TienCong values(1, 2, 4000, '10/20/2017');
insert into TienCong values(0, 3, 3000, '10/20/2017');