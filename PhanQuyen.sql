USE quanlycosovatchatcs;
GO

ALTER TABLE TaiKhoan
ADD VaiTro NVARCHAR(20) NOT NULL
    CONSTRAINT DF_TaiKhoan_VaiTro DEFAULT N'User';
GO

ALTER TABLE TaiKhoan
ADD CONSTRAINT CK_TaiKhoan_VaiTro CHECK (VaiTro IN (N'Admin', N'User'));
GO

UPDATE TaiKhoan SET VaiTro = N'Admin' WHERE TenDangNhap = N'admin';
UPDATE TaiKhoan SET VaiTro = N'User'  WHERE TenDangNhap = N'thanh';

INSERT INTO TaiKhoan (TenDangNhap, MatKhau, VaiTro)
VALUES (N'user', N'user123', N'User');
GO