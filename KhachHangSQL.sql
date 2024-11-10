USE master
GO

CREATE DATABASE TaiKhoan
GO

USE TaiKhoan
GO

CREATE TABLE TaiKhoanKhachHang (
  AccID int primary key,
  Password nvarchar(90) not null,
  EmailAddress nvarchar(90) unique, 
  Description nvarchar(140) not null,
  Role int
)
GO

INSERT INTO TaiKhoanKhachHang VALUES(551 ,N'123','Nguyenledaiphi@gmail.com', N'System Admin', 1);
INSERT INTO TaiKhoanKhachHang VALUES(552 ,N'12345','NamHai@gmail.com', N'Staff', 2);
INSERT INTO TaiKhoanKhachHang VALUES(553 ,N'123456','QuocBao@gmail.com', N'Manager', 3);
INSERT INTO TaiKhoanKhachHang VALUES(554 ,N'1234567','NguyenToan@gmail.com', N'Member', 4);
GO

