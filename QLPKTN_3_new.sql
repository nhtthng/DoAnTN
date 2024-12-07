DROP DATABASE QuanLyPKTN_Final_4

Create database QuanLyPKTN_Final_4
use QuanLyPKTN_Final_4

-- Bảng ChuyenKhoa
CREATE TABLE ChuyenKhoa (
    MaCK INT PRIMARY KEY IDENTITY(1,1),
    TenCK NVARCHAR(255) NOT NULL
);

-- Bảng PhongKham
CREATE TABLE PhongKham (
    MaPK INT PRIMARY KEY IDENTITY(1,1),
    TenPK NVARCHAR(255) NOT NULL,
    MaCK INT,
    FOREIGN KEY (MaCK) REFERENCES ChuyenKhoa(MaCK)
);

-- Bảng BacSi
CREATE TABLE BacSi (
    MaBS INT PRIMARY KEY IDENTITY(1,1),
    TenBS NVARCHAR(255) NOT NULL,
    GioiTinh NVARCHAR(10),
    Email NVARCHAR(255),
    SoDT NVARCHAR(15),
    KinhNghiem INT,
    MatKhau NVARCHAR(255),
    MaCK INT,
    MaPK INT,
    FOREIGN KEY (MaCK) REFERENCES ChuyenKhoa(MaCK),
    FOREIGN KEY (MaPK) REFERENCES PhongKham(MaPK)
);

-- Bảng BenhNhan
CREATE TABLE BenhNhan (
    MaBN INT PRIMARY KEY IDENTITY(1,1),
    HoTenBN NVARCHAR(255) NOT NULL,
    NgaySinh DATE,
    GioiTinh NVARCHAR(10),
    Email NVARCHAR(255),
    SoBHYT NVARCHAR(20),
    SoDT NVARCHAR(15),
    DiaChi NVARCHAR(255),
    MaPK INT,
    FOREIGN KEY (MaPK) REFERENCES PhongKham(MaPK)
);

-- Tạo bảng TiepNhanBenhNhan
CREATE TABLE TiepNhanBenhNhan (
    MaTiepNhan INT PRIMARY KEY IDENTITY(1,1),
    MaBenhNhan INT NOT NULL,
    NgayTiepNhan DATE NOT NULL,
    GioTiepNhan TIME(7) NOT NULL,
    TrangThai NVARCHAR(50) NOT NULL,
    TrieuChung NVARCHAR(255) NULL,
	MaPK int NOT NULL,
	FOREIGN KEY (MaPK) REFERENCES PhongKham(MaPK),
    FOREIGN KEY (MaBenhNhan) REFERENCES BenhNhan(MaBN)
);

-- Bảng PhongBan
CREATE TABLE PhongBan (
    MaPB INT PRIMARY KEY IDENTITY(1,1),
    TenPB NVARCHAR(255) NOT NULL
);

-- Bảng NhanVien
CREATE TABLE NhanVien (
    MaNV INT PRIMARY KEY IDENTITY(1,1),
    HoTen NVARCHAR(255) NOT NULL,
    GioiTinh NVARCHAR(10),
    NgaySinh DATE,
    SoDT NVARCHAR(15),
    MaPB INT,
	MatKhau NVARCHAR(255),
    FOREIGN KEY (MaPB) REFERENCES PhongBan(MaPB)
);

-- Bảng LichSuKhamBenh
CREATE TABLE LichSuKhamBenh (
    MaLSKB INT PRIMARY KEY IDENTITY(1,1),
    MaBS INT,
    MaBN INT,
    NgayKham DATE,
    ChuanDoan NVARCHAR(255),
    MaPK INT,
    FOREIGN KEY (MaBS) REFERENCES BacSi(MaBS),
    FOREIGN KEY (MaBN) REFERENCES BenhNhan(MaBN),
    FOREIGN KEY (MaPK) REFERENCES PhongKham(MaPK)
);

-- Bảng DichVu
CREATE TABLE DichVu (
    MaDV INT PRIMARY KEY IDENTITY(1,1),
    TenDV NVARCHAR(255) NOT NULL,
    Gia DECIMAL(18, 0)
);

-- Bảng HoaDon
CREATE TABLE HoaDon (
    MaHD INT PRIMARY KEY IDENTITY(1,1),
    MaLSKB INT,
    MaBN INT,
    NgayLapHD DATETIME,
    MaNV INT,
    TongTien DECIMAL(18, 0),
    TrangThai NVARCHAR(50),
    GiamGia DECIMAL(18, 0),
    PhuongThucThanhToan NVARCHAR(50),
    FOREIGN KEY (MaLSKB) REFERENCES LichSuKhamBenh(MaLSKB),
    FOREIGN KEY (MaBN) REFERENCES BenhNhan(MaBN),
    FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV)
);

-- Bảng CTSDDV (Chi Tiết Sử Dụng Dịch Vụ)
CREATE TABLE CTSDDV (
    MaChiTietSDDV INT PRIMARY KEY IDENTITY(1,1),
    MaLSKB INT,
    MaDV INT,
    SoLuong INT,
    Gia DECIMAL(18, 0),
    ThanhTien AS (SoLuong * Gia) PERSISTED,
    NgayLap DATETIME,
    FOREIGN KEY (MaLSKB) REFERENCES LichSuKhamBenh(MaLSKB),
    FOREIGN KEY (MaDV) REFERENCES DichVu(MaDV)
);

-- Bảng Thuoc
CREATE TABLE Thuoc (
    MaThuoc INT PRIMARY KEY IDENTITY(1,1),
    TenThuoc NVARCHAR(255) NOT NULL,
    BietDuoc NVARCHAR(255),
    CongDung NVARCHAR(255),
    LuuY NVARCHAR(255),
    DonGia DECIMAL(18, 0),
    DonViTinh NVARCHAR(50),
	SoLuong int
);

-- Bảng CTHD (Chi Tiết Hóa Đơn)
CREATE TABLE CTHD (
    MaChiTietHD INT PRIMARY KEY IDENTITY(1,1),
    MaLSKB INT,
    MaThuoc INT,
    SoLuong INT,
    DonGia DECIMAL(18, 0),
    ThanhTien AS (SoLuong * DonGia) PERSISTED,
    CachDung NVARCHAR(255),
    FOREIGN KEY (MaLSKB) REFERENCES LichSuKhamBenh(MaLSKB),
    FOREIGN KEY (MaThuoc) REFERENCES Thuoc(MaThuoc)
);

-- Bảng LichHen
CREATE TABLE LichHen (
    MaLH INT PRIMARY KEY IDENTITY(1,1),
    MaBS INT,
    MaBN INT,
    ThoiGianHen DATETIME,
    NgayHen DATE,
    TinhTrang NVARCHAR(50),
    FOREIGN KEY (MaBS) REFERENCES BacSi(MaBS),
    FOREIGN KEY (MaBN) REFERENCES BenhNhan(MaBN)
);


-- Bảng ChiTietToaThuoc
CREATE TABLE ChiTietToaThuoc (
    MaThuoc INT,
    MaBS INT,
    CachDung NVARCHAR(255),
    LieuLuong NVARCHAR(255),
    MaLSKB INT,
	NgayKeToa Date,
	LoiDanBS Nvarchar(255),
    PRIMARY KEY (MaLSKB, MaThuoc),
    FOREIGN KEY (MaThuoc) REFERENCES Thuoc(MaThuoc),
    FOREIGN KEY (MaBS) REFERENCES BacSi(MaBS),
    FOREIGN KEY (MaLSKB) REFERENCES LichSuKhamBenh(MaLSKB)
);
