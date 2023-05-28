create database NganHang
go

use NganHang
go

create table KhachHang
(
MaKH int IDENTITY(1,1),
HoTen nvarchar(1000),
DiaChi nvarchar(1000),
SDT char(1000),
CMND char(1000) unique,
primary key(MaKH)
)
go


create table LoaiTaiKhoan
(
MaLoai int IDENTITY(1,1),
TenLoai nvarchar(1000),
primary key(MaLoai)
)
go



create table TaiKhoan
(
STK int IDENTITY(1000, 1),
MaKH int references KhachHang(MaKH),
MaLoai int references LoaiTaiKhoan(MaLoai),
SoDu int,
LaiSuat float,
NgayBD datetime
)
go





insert into KhachHang (HoTen, DiaChi, SDT, CMND) values (N'Lâm Lục Long', N'Mỹ Thor', '0915927019', 251883018)
insert into KhachHang (HoTen, DiaChi, SDT, CMND) values (N'Đinh Đặng Đình', N'Long An', '0908205191', 251883019)
insert into KhachHang (HoTen, DiaChi, SDT, CMND) values (N'Tống Tăng Tiến', N'Tiền Giang', '0983029682', 251883020)
insert into KhachHang (HoTen, DiaChi, SDT, CMND) values (N'Nguyễn Ngọc Ngui', N'Tứ Xuyên', '0932911009', 251883021)
insert into KhachHang (HoTen, DiaChi, SDT, CMND) values (N'Trần Trung Trịnh', N'Hà Lội', '0909090909', 251883022)
insert into KhachHang (HoTen, DiaChi, SDT, CMND) values (N'Lâm Mỹ Tho', N'Phước Thọ', '0932131123', 645312221)
insert into KhachHang (HoTen, DiaChi, SDT, CMND) values (N'Nguyễn Anh Thư', N'Gia Lai', '013987328', 312546413)
insert into KhachHang (HoTen, DiaChi, SDT, CMND) values (N'Lương Như Y Bình', N'Tiền Giang', '0782340987', 869446962)
insert into KhachHang (HoTen, DiaChi, SDT, CMND) values (N'Nguyễn Ngọc My', N'Tứ Xuyên', '0732376812', 785654231)
insert into KhachHang (HoTen, DiaChi, SDT, CMND) values (N'Trần Đức Trọng', N'Hà Lội', '0212987123', 232109767)

insert into LoaiTaiKhoan (TenLoai) values (N'Thanh toán')
insert into LoaiTaiKhoan (TenLoai) values (N'Tiết kiệm')
insert into LoaiTaiKhoan (TenLoai) values (N'Vay vốn')

insert into TaiKhoan (MaKH, MaLoai, SoDu, LaiSuat, NgayBD) values (1, 1, 5032100, 0.4, '05/11/2023')
insert into TaiKhoan (MaKH, MaLoai, SoDu, LaiSuat, NgayBD) values (2, 2, 3200320, 0.1, '07/15/2023')
insert into TaiKhoan (MaKH, MaLoai, SoDu, LaiSuat, NgayBD) values (3, 1, 9218000, 1.4, '04/21/2023')
insert into TaiKhoan (MaKH, MaLoai, SoDu, LaiSuat, NgayBD) values (4, 3, 7832023, 0.6, '06/21/2023')
insert into TaiKhoan (MaKH, MaLoai, SoDu, LaiSuat, NgayBD) values (5, 2, 5672023, 0.3, '07/15/2023')
insert into TaiKhoan (MaKH, MaLoai, SoDu, LaiSuat, NgayBD) values (1, 2, 5032100, 0.4, '05/11/2023')

insert into TaiKhoan (MaKH, MaLoai, SoDu, LaiSuat, NgayBD) values (6, 1, 8003210, 0.1, '07/24/2023')
insert into TaiKhoan (MaKH, MaLoai, SoDu, LaiSuat, NgayBD) values (7, 3, 6004420, 0.4, '08/30/2023')
insert into TaiKhoan (MaKH, MaLoai, SoDu, LaiSuat, NgayBD) values (8, 2, 4300535, 0.5, '05/15/2023')
insert into TaiKhoan (MaKH, MaLoai, SoDu, LaiSuat, NgayBD) values (9, 3, 89067500, 0.7, '01/03/2023')
insert into TaiKhoan (MaKH, MaLoai, SoDu, LaiSuat, NgayBD) values (10, 1, 3507500, 1.3, '09/11/2023')




select STK, KhachHang.MaKH, HoTen, DiaChi, SDT, CMND, MaLoai, SoDu, LaiSuat, NgayBD 
from TaiKhoan, KhachHang where TaiKhoan.MaKH = KhachHang.MaKH 

select * from KhachHang
select * from TaiKhoan



select a.HoTen, MaLoai
from TaiKhoan a,KhachHang b
where a.MaKH = b.MaKH and a.MaKH = 2
group by a.HoTen, MaLoai

