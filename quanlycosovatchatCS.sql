create database quanlycosovatchatcs
use  quanlycosovatchatcs



CREATE TABLE LoaiCoSoVatChat
(
    MaLoai varchar(30) PRIMARY KEY,
    TenLoai NVARCHAR(100) NOT NULL UNIQUE
	
);
INSERT INTO LoaiCoSoVatChat (MaLoai, TenLoai)
VALUES
('LOAI001', N'Thiết bị điện tử'),
('LOAI002', N'Bàn ghế'),
('LOAI003', N'Thiết bị phòng học'),
('LOAI004', N'Thiết bị thể thao');
DELETE FROM LoaiCoSoVatChat;
select * from LoaiCoSoVatChat
create table cosovatchat(
	ma VARCHAR(30)  primary key,
	ten nvarchar(200) not null,
	maloai varchar(30) not null,
	phongkhuvuc nvarchar(200),
	soluong int not null default 0,
	tinhtrang nvarchar(100),
	ngaynhap date,
	ghichu nvarchar(500),
       CONSTRAINT FK_CoSoVatChat_LoaiCoSoVatChat
        FOREIGN KEY (MaLoai)
        REFERENCES LoaiCoSoVatChat(MaLoai)
)
INSERT INTO CoSoVatChat
    (Ma, Ten, MaLoai, PhongKhuVuc, SoLuong,
     TinhTrang, NgayNhap, GhiChu)
VALUES
(
    '20261022090000001',
    N'Máy tính Dell',
    (SELECT MaLoai FROM LoaiCoSoVatChat
     WHERE TenLoai = N'Thiết bị điện tử'),
    N'Phòng máy 1', 30, N'Tốt',
    '2026-09-01', N'Máy tính phục vụ thực hành'
),
(
    '20261022090000002',
    N'Máy chiếu Epson',
    (SELECT MaLoai FROM LoaiCoSoVatChat
     WHERE TenLoai = N'Thiết bị điện tử'),
    N'Phòng học A101', 5, N'Tốt',
    '2026-09-05', N'Dùng cho giảng dạy'
),
(
    '20261022090000003',
    N'Bàn học sinh',
    (SELECT MaLoai FROM LoaiCoSoVatChat
     WHERE TenLoai = N'Bàn ghế'),
    N'Phòng học A102', 40, N'Tốt',
    '2026-08-20', N'Bàn học hai chỗ ngồi'
),
(
    '20261022090000004',
    N'Ghế phòng học',
    (SELECT MaLoai FROM LoaiCoSoVatChat
     WHERE TenLoai = N'Bàn ghế'),
    N'Phòng học A102', 80, N'Tốt',
    '2026-08-20', N'Ghế nhựa'
);
     select *
     from cosovatchat
      select *
     from LoaiCoSoVatChat
     drop table cosovatchat
     drop table LoaiCoSoVatChat
     DBCC CHECKIDENT ('CoSoVatChat', RESEED, 3);
     CREATE TABLE TaiKhoan
(
    MaTaiKhoan INT IDENTITY(1,1) PRIMARY KEY,
    TenDangNhap NVARCHAR(50) NOT NULL UNIQUE,
    MatKhau NVARCHAR(255) NOT NULL,
    VaiTro NVARCHAR(20) NOT NULL
        CHECK (VaiTro IN ('Admin', 'User'))
);
GO

INSERT INTO TaiKhoan (TenDangNhap, MatKhau, VaiTro)
VALUES
    (N'admin', N'12345', N'Admin'),
    (N'user', N'12345', N'User');
GO
drop table taikhoan