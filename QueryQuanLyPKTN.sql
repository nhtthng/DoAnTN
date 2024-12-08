CREATE TABLE ChuyenKhoa (
    MaCK INT PRIMARY KEY IDENTITY(1,1),
    TenCK NVARCHAR(255) NOT NULL
);

CREATE TABLE BacSi (
    MaBS INT PRIMARY KEY IDENTITY(1,1),
    TenBS NVARCHAR(255) NOT NULL,
    GioiTinh NVARCHAR(10),
    Email NVARCHAR(255),
    SoDT NVARCHAR(15),
    KinhNghiem INT,
    MatKhau NVARCHAR(255),
    MaCK INT,
    Quyen INT
);

CREATE TABLE PhongKham (
    MaPK INT PRIMARY KEY IDENTITY(1,1),
    TenPK NVARCHAR(255) NOT NULL,
    MaCK INT
);

CREATE TABLE BenhNhan (
    MaBN INT PRIMARY KEY IDENTITY(1,1),
    HoTenBN NVARCHAR(255) NOT NULL,
    NgaySinh DATE,
    GioiTinh NVARCHAR(10),
    Email NVARCHAR(255),
    SoBHYT NVARCHAR(20),
    SoDT NVARCHAR(15),
    DiaChi NVARCHAR(255)
);

CREATE TABLE LichSuKhamBenh (
    MaLSKB INT PRIMARY KEY IDENTITY(1,1),
    MaBS INT,
    MaBN INT,
    NgayKham DATE,
    ChuanDoan NVARCHAR(255),
    MaPK INT
);

CREATE TABLE LichHen (
    MaLH INT PRIMARY KEY IDENTITY(1,1),
    MaBS INT,
    MaBN INT,
    ThoiGianHen DATETIME,
    NgayHen DATE,
    TinhTrang NVARCHAR(50)
);

CREATE TABLE PhongBan (
    MaPB INT PRIMARY KEY IDENTITY(1,1),
    TenPB NVARCHAR(255) NOT NULL
);

CREATE TABLE NhanVien (
    MaNV INT PRIMARY KEY IDENTITY(1,1),
    HoTen NVARCHAR(255) NOT NULL,
    GioiTinh NVARCHAR(10),
    NgaySinh DATE,
    SoDT NVARCHAR(15),
    MaPB INT,
    Quyen INT
);

CREATE TABLE DichVu (
    MaDV INT PRIMARY KEY IDENTITY(1,1),
    TenDV NVARCHAR(255) NOT NULL,
    Gia DECIMAL(18, 2)
);

CREATE TABLE HoaDon (
    MaHD INT PRIMARY KEY IDENTITY(1,1),
    NgayLapHD DATE,
    MaNV INT,
    MaDV INT,
    MaBN INT,
    TongTien DECIMAL(18, 2),
    TrangThai NVARCHAR(50),
    GiamGia INT
);

CREATE TABLE CTSDDV (
    MaHD INT,
    MaDV INT,
    SoLuong INT,
    Gia DECIMAL(18, 2),
    ThanhTien DECIMAL(18, 2),
    MaBN INT,
    NgayLap DATE,
    MaBS INT,
    PRIMARY KEY (MaHD, MaDV)
);

CREATE TABLE ToaThuoc (
    MaTT INT PRIMARY KEY IDENTITY(1,1),
    MaLSKB INT,
    NgayKeToa DATE,
    LoiDanBS NVARCHAR(255)
);

CREATE TABLE CTHD (
    MaTT INT,
    MaHD INT,
    MaThuoc INT,
    SoLuong INT,
    DonGia DECIMAL(18, 2),
    PRIMARY KEY (MaTT, MaHD, MaThuoc)
);

CREATE TABLE ChiTietToaThuoc (
    MaTT INT,
    MaThuoc INT,
    MaBS INT,
    CachDung NVARCHAR(255),
    LieuLuong NVARCHAR(255),
    MaBN INT,
    MaLSKB INT,
    PRIMARY KEY (MaTT, MaThuoc)
);

CREATE TABLE Thuoc (
    MaThuoc INT PRIMARY KEY IDENTITY(1,1),
    TenThuoc NVARCHAR(255) NOT NULL,
    BietDuoc NVARCHAR(255),
    CongDung NVARCHAR(255),
    LuuY NVARCHAR(255),
    DonGia DECIMAL(18, 2),
    DonViTinh NVARCHAR(50)
);

ALTER TABLE BacSi
ADD FOREIGN KEY (MaCK) REFERENCES ChuyenKhoa(MaCK);

ALTER TABLE PhongKham
ADD FOREIGN KEY (MaCK) REFERENCES ChuyenKhoa(MaCK);

ALTER TABLE LichSuKhamBenh
ADD FOREIGN KEY (MaBS) REFERENCES BacSi(MaBS),
    FOREIGN KEY (MaBN) REFERENCES BenhNhan(MaBN),
    FOREIGN KEY (MaPK) REFERENCES PhongKham(MaPK);

ALTER TABLE LichHen
ADD FOREIGN KEY (MaBS) REFERENCES BacSi(MaBS),
    FOREIGN KEY (MaBN) REFERENCES BenhNhan(MaBN);

ALTER TABLE NhanVien
ADD FOREIGN KEY (MaPB) REFERENCES PhongBan(MaPB);

ALTER TABLE HoaDon
ADD FOREIGN KEY (MaNV) REFERENCES NhanVien(MaNV),
    FOREIGN KEY (MaDV) REFERENCES DichVu(MaDV),
    FOREIGN KEY (MaBN) REFERENCES BenhNhan(MaBN);

ALTER TABLE CTSDDV
ADD FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD),
    FOREIGN KEY (MaDV) REFERENCES DichVu(MaDV),
    FOREIGN KEY (MaBN) REFERENCES BenhNhan(MaBN),
    FOREIGN KEY (MaBS) REFERENCES BacSi(MaBS);

ALTER TABLE ToaThuoc
ADD FOREIGN KEY (MaLSKB) REFERENCES LichSuKhamBenh(MaLSKB);

ALTER TABLE CTHD
ADD FOREIGN KEY (MaTT) REFERENCES ToaThuoc(MaTT),
    FOREIGN KEY (MaHD) REFERENCES HoaDon(MaHD),
    FOREIGN KEY (MaThuoc) REFERENCES Thuoc(MaThuoc);

ALTER TABLE ChiTietToaThuoc
ADD FOREIGN KEY (MaTT) REFERENCES ToaThuoc(MaTT),
    FOREIGN KEY (MaThuoc) REFERENCES Thuoc(MaThuoc),
    FOREIGN KEY (MaBS) REFERENCES BacSi(MaBS),
    FOREIGN KEY (MaBN) REFERENCES BenhNhan(MaBN),
    FOREIGN KEY (MaLSKB) REFERENCES LichSuKhamBenh(MaLSKB);