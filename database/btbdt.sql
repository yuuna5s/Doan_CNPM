-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 14, 2020 at 04:51 AM
-- Server version: 10.4.16-MariaDB
-- PHP Version: 7.4.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `btbdt`
--

-- --------------------------------------------------------

--
-- Table structure for table `chi_tiet_hd`
--

CREATE TABLE `chi_tiet_hd` (
  `ma_hd` varchar(10) CHARACTER SET utf8 NOT NULL,
  `ma_sp` varchar(10) CHARACTER SET utf8 NOT NULL,
  `so_luong` int(11) DEFAULT NULL,
  `thanh_tien` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `chi_tiet_pdh`
--

CREATE TABLE `chi_tiet_pdh` (
  `ma_sp` varchar(10) CHARACTER SET utf8 NOT NULL,
  `ma_pdh` varchar(10) CHARACTER SET utf8 NOT NULL,
  `soluong` int(11) DEFAULT NULL,
  `thanhtien` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `chi_tiet_pdh`
--

INSERT INTO `chi_tiet_pdh` (`ma_sp`, `ma_pdh`, `soluong`, `thanhtien`) VALUES
('SP00000003', 'PDH0000002', 1, 18990000),
('SP00000010', 'PDH0000002', 1, 41990000);

-- --------------------------------------------------------

--
-- Table structure for table `db_chi_tiet_pn`
--

CREATE TABLE `db_chi_tiet_pn` (
  `ma_phieu_nhap` varchar(10) CHARACTER SET utf8 NOT NULL,
  `ma_sp` varchar(10) CHARACTER SET utf8 NOT NULL,
  `so_luong` int(11) DEFAULT NULL,
  `gianhap` double DEFAULT NULL,
  `tong` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `db_chi_tiet_pn`
--

INSERT INTO `db_chi_tiet_pn` (`ma_phieu_nhap`, `ma_sp`, `so_luong`, `gianhap`, `tong`) VALUES
('PN00000001', 'SP00000002', 10, 20000000, 200000000),
('PN00000002', 'SP00000007', 10, 20000000, 200000000),
('PN00000002', 'SP00000010', 10, 20000000, 200000000),
('PN00000003', 'SP00000005', 10, 20000000, 200000000),
('PN00000003', 'SP00000006', 10, 20000000, 200000000);

-- --------------------------------------------------------

--
-- Table structure for table `db_chucvu`
--

CREATE TABLE `db_chucvu` (
  `ma_cv` varchar(2) CHARACTER SET utf8 NOT NULL,
  `ten_cv` varchar(20) CHARACTER SET utf8 DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `db_chucvu`
--

INSERT INTO `db_chucvu` (`ma_cv`, `ten_cv`) VALUES
('BH', 'Bán hàng'),
('NH', 'Nhập hàng'),
('QL', 'Quản lý');

-- --------------------------------------------------------

--
-- Table structure for table `db_hoa_don`
--

CREATE TABLE `db_hoa_don` (
  `ma_hd` varchar(10) CHARACTER SET utf8 NOT NULL,
  `ma_nv` varchar(10) CHARACTER SET utf8 DEFAULT NULL,
  `ma_kh` varchar(10) CHARACTER SET utf8 DEFAULT NULL,
  `ngay_lap` date DEFAULT NULL,
  `da_thanh_toan` double DEFAULT NULL,
  `con_lai` double DEFAULT NULL,
  `tonggiatri` double DEFAULT NULL,
  `thanh_toan` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `db_khach_hang`
--

CREATE TABLE `db_khach_hang` (
  `ma_kh` varchar(10) CHARACTER SET utf8 NOT NULL,
  `ten_kh` varchar(40) CHARACTER SET utf8 NOT NULL,
  `diachi` varchar(40) CHARACTER SET utf8 DEFAULT NULL,
  `sdt` varchar(11) CHARACTER SET utf8 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `db_khach_hang`
--

INSERT INTO `db_khach_hang` (`ma_kh`, `ten_kh`, `diachi`, `sdt`) VALUES
('KH00000001', 'Triệu Bích K', '66 Châu Văn Liêm', '0355460710'),
('KH00000002', 'Thái Vĩnh H', '98 abc', '0703261212'),
('KH00000003', 'Pham Duc K', '192 Ham Tu', '0355460888'),
('KH00000004', 'Pham Duc Duy', '19a', '0355560888'),
('KH00000005', 'Pham Hung Khach', '19aABC', '0355567888');

-- --------------------------------------------------------

--
-- Table structure for table `db_nhanvien`
--

CREATE TABLE `db_nhanvien` (
  `ma_nv` varchar(10) CHARACTER SET utf8 NOT NULL,
  `ten_nv` varchar(40) CHARACTER SET utf8 DEFAULT NULL,
  `ngay_sinh` date DEFAULT NULL,
  `gioi_tinh` varchar(3) CHARACTER SET utf8 DEFAULT NULL,
  `sdt_nv` varchar(11) CHARACTER SET utf8 DEFAULT NULL,
  `dia_chi_nv` varchar(40) CHARACTER SET utf8 DEFAULT NULL,
  `email` varchar(30) CHARACTER SET utf8 DEFAULT NULL,
  `ma_cv` varchar(2) CHARACTER SET utf8 DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `db_nhanvien`
--

INSERT INTO `db_nhanvien` (`ma_nv`, `ten_nv`, `ngay_sinh`, `gioi_tinh`, `sdt_nv`, `dia_chi_nv`, `email`, `ma_cv`) VALUES
('NV00000001', 'Triệu Bích Khai', '2000-09-10', 'Nam', '0355460710', '66 Châu Văn Liêm', 'tbk@gmail.com', 'QL'),
('NV00000002', 'Thái Vĩnh Hưng', '2000-03-08', 'Nam', '0165673993', '98 abc', 'tvho@gmail.com', 'BH'),
('NV00000003', 'Phạm Đức Khải', '2000-04-14', 'Nam', '0986772567', '10 xyz', 'pdk@gmail.com', 'NH'),
('NV00000004', 'Phạm Đức Kỷ', '2000-04-10', 'Nam', '0986772588', '10 qwe', 'pdky@gmail.com', 'BH'),
('NV00000005', 'Phạm Ngọc Nhi', '2000-04-01', 'Nữ', '0986772577', '10 tyg', 'PNN@gmail.com', 'NH'),
('NV00000006', 'Lý Nhi', '1999-09-07', 'Nữ', '0986772666', '10 ert', 'LN@gmail.com', 'NH'),
('NV00000007', 'Lý Khang', '1999-02-15', 'Nam', '09868872666', '10 LKha', 'LK@gmail.com', 'NH'),
('NV00000008', 'Triệu Nguyên', '1990-06-12', 'Nam', '07868872666', '10 TNa', 'TN@gmail.com', 'BH'),
('NV00000009', 'Triệu Phụng', '1990-06-12', 'Nữ', '07867872666', '10 TPA', 'TP@gmail.com', 'BH'),
('NV00000010', 'Triệu Phụng Nguyên', '1990-06-01', 'Nam', '07777872666', '10 TPNA', 'TPN@gmail.com', 'BH'),
('NV00000011', 'Triệu Khải Yến', '1987-02-02', 'Nữ', '07877872666', '10 TKYA', 'TKY@gmail.com', 'QL'),
('NV00000012', 'Triệu Khải Uyên', '1987-01-26', 'Nữ', '07877872677', '10 TKUA', 'TKU@gmail.com', 'QL'),
('NV00000013', 'Triệu Khải Như k', '1987-01-26', 'Nữ', '07866872677', '10 TKNA', 'TKN@gmail.com', 'QL'),
('NV00000014', 'Triệu Khải Phương', '1988-01-07', 'Nữ', '07855872677', '10 TKPA', 'TKP@gmail.com', 'BH'),
('NV00000015', 'Triệu Vĩnh Hằng', '1994-12-22', 'Nữ', '07855865881', '10 TVHAL', 'TVHI@gmail.com', 'BH'),
('NV00000016', 'Triệu Vĩnh Hằn', '1994-12-22', 'Nữ', '07855865881', '10 TVHAL', 'TVHI@gmail.com', 'BH'),
('NV00000017', 'Triệu Khải Như k', '1987-01-26', 'Nữ', '07866872677', '10 TKNA', 'TKN@gmail.com', 'QL');

-- --------------------------------------------------------

--
-- Table structure for table `db_nha_cung_cap`
--

CREATE TABLE `db_nha_cung_cap` (
  `ma_ncc` varchar(10) CHARACTER SET utf8 NOT NULL,
  `ten_ncc` varchar(40) CHARACTER SET utf8 DEFAULT NULL,
  `sdt_ncc` varchar(12) CHARACTER SET utf8 NOT NULL,
  `email` varchar(40) CHARACTER SET utf8 NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `db_nha_cung_cap`
--

INSERT INTO `db_nha_cung_cap` (`ma_ncc`, `ten_ncc`, `sdt_ncc`, `email`) VALUES
('NCC0000001', 'Acer VN', '01223413321', 'acer@acer.com'),
('NCC0000002', 'Dell VN', '0222031341', 'DellVN@gmail.com'),
('NCC0000003', 'Apple', '02223145511', 'Apple@apple.com'),
('NCC0000004', 'AsusTek', '0993445345', 'Asus@gmail.com'),
('NCC0000005', 'Lenovo', '0985779119', 'Lenovo@gmail.com'),
('NCC0000006', 'Kingston', '0986367819', 'KingStonVN@gmail.com'),
('NCC0000007', 'MSI', '0986888819', 'MSI@gmail.com'),
('NCC0000008', 'Logitech', '0953338819', 'Logitech@gmail.com'),
('NCC0000009', 'Razer', '0958338819', 'Razer@gmail.com');

-- --------------------------------------------------------

--
-- Table structure for table `db_nhom_sp`
--

CREATE TABLE `db_nhom_sp` (
  `ma_loai` varchar(5) CHARACTER SET utf8 NOT NULL,
  `ten_loai_sp` varchar(40) CHARACTER SET utf8 DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `db_nhom_sp`
--

INSERT INTO `db_nhom_sp` (`ma_loai`, `ten_loai_sp`) VALUES
('LT', 'Laptop'),
('PK', 'Phụ kiện');

-- --------------------------------------------------------

--
-- Table structure for table `db_phieu_dat_hang`
--

CREATE TABLE `db_phieu_dat_hang` (
  `ma_pdh` varchar(10) CHARACTER SET utf8 NOT NULL,
  `ma_nv` varchar(10) CHARACTER SET utf8 NOT NULL,
  `ma_kh` varchar(10) CHARACTER SET utf8 NOT NULL,
  `ngay_lap` date DEFAULT NULL,
  `tonggiatri` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `db_phieu_dat_hang`
--

INSERT INTO `db_phieu_dat_hang` (`ma_pdh`, `ma_nv`, `ma_kh`, `ngay_lap`, `tonggiatri`) VALUES
('PDH0000002', 'NV00000002', 'KH00000001', '2020-12-10', 60980000);

-- --------------------------------------------------------

--
-- Table structure for table `db_phieu_nhap`
--

CREATE TABLE `db_phieu_nhap` (
  `ma_phieu_nhap` varchar(10) CHARACTER SET utf8 NOT NULL,
  `ma_nv` varchar(10) CHARACTER SET utf8 DEFAULT NULL,
  `ma_ncc` varchar(10) CHARACTER SET utf8 DEFAULT NULL,
  `ngay_lap_pn` date DEFAULT NULL,
  `tong_tien` double DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `db_phieu_nhap`
--

INSERT INTO `db_phieu_nhap` (`ma_phieu_nhap`, `ma_nv`, `ma_ncc`, `ngay_lap_pn`, `tong_tien`) VALUES
('PN00000001', 'NV00000002', 'NCC0000001', '2020-12-10', 200000000),
('PN00000002', 'NV00000002', 'NCC0000002', '2020-12-10', 400000000),
('PN00000003', 'NV00000003', 'NCC0000004', '2020-12-10', 400000000);

-- --------------------------------------------------------

--
-- Table structure for table `db_sanpham`
--

CREATE TABLE `db_sanpham` (
  `ma_sp` varchar(10) CHARACTER SET utf8 NOT NULL,
  `ma_loai` varchar(5) CHARACTER SET utf8 DEFAULT NULL,
  `ten_sp` varchar(255) CHARACTER SET utf8 NOT NULL,
  `don_vi_tinh` varchar(20) CHARACTER SET utf8 DEFAULT NULL,
  `gia_sp` double DEFAULT NULL,
  `thoi_gian_bh` int(11) DEFAULT NULL,
  `soluong` int(11) DEFAULT NULL,
  `hang_san_xuat` varchar(30) CHARACTER SET utf8 DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `db_sanpham`
--

INSERT INTO `db_sanpham` (`ma_sp`, `ma_loai`, `ten_sp`, `don_vi_tinh`, `gia_sp`, `thoi_gian_bh`, `soluong`, `hang_san_xuat`) VALUES
('SP00000001', 'LT', 'Laptop ASUS ZenBook UX425EA-BM113T (i7-1165G7 | 16GB | 512GB | Intel Iris Xe Graphics | 14 FHD | Win 10)', 'Cái', 28990000, 24, 20, 'ASUS'),
('SP00000002', 'LT', 'Laptop ASUS ZenBook UX435EA-A5036T (i5-1135G7 | 8GB | 512GB | Intel Iris Xe Graphics | 14 FHD | Win 10)', 'Cái', 24990000, 24, 16, 'ASUS'),
('SP00000003', 'LT', 'Laptop ASUS VivoBook S433EA-EB100T (i5-1135G7 | 8GB | 512GB | Intel Iris Xe Graphics | 14 FHD | Win 10)', 'Cái', 18990000, 24, 15, 'ASUS'),
('SP00000004', 'LT', 'Laptop ASUS VivoBook S433EA-EB179T (i7-1165G7 | 16GB | 512GB | Intel Iris Xe Graphics | 14 FHD | Win 10)', 'Cái', 22990000, 24, 24, 'ASUS'),
('SP00000005', 'LT', 'Laptop ASUS ROG Zephyrus Duo 15 GX550LXS-HC055R (i9-10980HK | 32GB | 2TB | VGA RTX 2080 8GB Super | 15.6 UHD | Win 10)', 'Cái', 119990000, 36, 15, 'ASUS'),
('SP00000006', 'LT', 'Laptop ASUS ROG Zephyrus G14 GA401IU-HA171T (R7-4800HS | 16GB | 512GB | VGA GTX 1660Ti 6GB | 14 WQHD | Win 10 | AniMe Matrix)', 'Cái', 37990000, 36, 17, 'ASUS'),
('SP00000007', 'LT', 'Laptop Dell XPS 13 9310 (XPS_9310) (i7-1165G7 | 16GB | 512GB | Intel Iris Xe Graphics | 13.4 UHD Touch | Win 10)', 'Cái', 59990000, 24, 20, 'Dell'),
('SP00000008', 'LT', 'Laptop Dell Inspiron 7490 (N4I5106W) (i5-10210U | 8GB | 512GB | VGA MX250 2GB | 14 FHD | Win 10)', 'Cái', 26990000, 24, 10, 'Dell'),
('SP00000009', 'LT', 'Laptop Dell Inspiron 7501 (X3MRY1) (i7-10750H | 8GB | 512GB | VGA GTX 1650Ti 4GB | 15.6 FHD | Win 10)', 'Cái', 30490000, 24, 10, 'Dell'),
('SP00000010', 'LT', 'Laptop Dell Gaming G7 7500 (G7500A) (i7-10750H | 16GB | 512GB | VGA RTX 2060 6GB | 15.6 FHD 144Hz | Win 10)', 'Cái', 41990000, 24, 19, 'Dell'),
('SP00000011', 'LT', 'Laptop Dell ALIENWARE M15 R3 - i9-10980HK RTX2080 32GB SSD 1TB SSD 512GB 15.6 UHD OLED 60Hz Lunar Light', 'Cái', 99990000, 36, 9, 'Dell'),
('SP00000012', 'LT', 'Laptop Dell ALIENWARE AREA 51M R2 - I9-10900K RTX 2080 RAM 64GB 4TB SSD 17.3 FHD', 'Cái', 158000000, 36, 10, 'Dell'),
('SP00000013', 'LT', 'Laptop MSI GF63 Thin 9SCSR-846VN (i7-9750H | 8GB | 512GB | VGA GTX 1650Ti 4GB | 15.6 FHD 144Hz | Win 10)', 'Cái', 22490000, 24, 10, 'MSI'),
('SP00000014', 'LT', 'Laptop MSI GE75 Raider 10SFS-270VN (i9-10980HK | 16GB | 512GB + 1TB | VGA RTX 2070 8GB Super | 17.3 FHD 240Hz | Win 10)', 'Cái', 62990000, 24, 10, 'MSI'),
('SP00000015', 'LT', 'Laptop MSI GE66 Raider 10SF-483VN (i7-10875H | 16GB | 1TB | VGA RTX 2070 8GB | 15.6 FHD 240Hz | Win 10)', 'Cái', 56990000, 24, 10, 'MSI'),
('SP00000016', 'LT', 'Laptop MSI GS66 Stealth 10SF (i7-10870H | 16GB | 1TB | VGA RTX 2070 8GB | 15.6 FHD 300Hz | Win 10)', 'Cái', 57990000, 24, 10, 'MSI'),
('SP00000017', 'LT', 'Laptop Lenovo Legion 7 15IMHG05 (81YU007JVN) (i7-10870H | 16GB | 1TB | VGA RTX 2060 6GB | 15.6 FHD 144Hz | Win 10)', 'Cái', 54990000, 24, 10, 'Lenovo'),
('SP00000018', 'LT', 'Laptop Lenovo ThinkPad X1 Carbon Gen 8 i7-10610U 16GB SSD 512GB 14 FHD', 'Cái', 43990000, 24, 10, 'Lenovo'),
('SP00000019', 'PK', 'USB 3.0 Kingston DataTraverler 100 G3 32GB 100MB/s DT100G3/32GB', 'Cái', 99000, 60, 50, 'Kingston'),
('SP00000020', 'PK', 'USB 3.0 Kingston DataTraverler 100 G3 64GB 100MB/s DT100G3/64GB', 'Cái', 189000, 60, 50, 'Kingston'),
('SP00000021', 'PK', 'USB 3.0 Kingston DataTraverler 100 G3 128GB 100MB/s DT100G3/128G', 'Cái', 370000, 60, 50, 'Kingston'),
('SP00000022', 'PK', 'USB 3.1 Kingston DataTraveler Swivl 32GB 100MB/s DTSWIVL/32GB', 'Cái', 85000, 60, 50, 'Kingston'),
('SP00000023', 'PK', 'Chuột Logitech G502 Hero RGB', 'Cái', 990000, 24, 30, 'Logitech'),
('SP00000024', 'PK', 'Chuột Logitech G Pro Wireless RGB', 'Cái', 2890000, 24, 30, 'Logitech'),
('SP00000025', 'PK', 'Bàn phím cơ không dây Logitech G913 TKL Wireless', 'Cái', 5490000, 24, 30, 'Logitech'),
('SP00000026', 'PK', 'Bàn phím cơ Logitech G813 LIGHTSYNC RGB Low-profile GL Switch', 'Cái', 3490000, 24, 30, 'Logitech'),
('SP00000027', 'PK', 'Bàn phím cơ Razer Huntsman Mini Mercury', 'Cái', 3490000, 24, 30, 'Razer'),
('SP00000028', 'PK', 'Bàn phím cơ Razer Huntsman Elite', 'Cái', 4990000, 24, 30, 'Razer'),
('SP00000029', 'PK', 'Chuột Razer Viper', 'Cái', 1590000, 24, 30, 'Razer'),
('SP00000030', 'PK', 'Chuột Razer Viper Ultimate', 'Cái', 2990000, 24, 30, 'Razer'),
('SP00000031', 'PK', 'Chuột Razer Viper Mini', 'Cái', 1190000, 24, 29, 'Razer');

-- --------------------------------------------------------

--
-- Table structure for table `db_taikhoan`
--

CREATE TABLE `db_taikhoan` (
  `ID` int(10) NOT NULL,
  `username` varchar(40) CHARACTER SET utf8 DEFAULT NULL,
  `pass` varchar(40) CHARACTER SET utf8 DEFAULT NULL,
  `ma_cv` varchar(2) CHARACTER SET utf8 DEFAULT NULL,
  `trang_thai` tinyint(1) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `db_taikhoan`
--

INSERT INTO `db_taikhoan` (`ID`, `username`, `pass`, `ma_cv`, `trang_thai`) VALUES
(1, 'admin', '123456', 'QL', 0),
(2, 'banhang', '123456', 'BH', 0),
(3, 'nhaphang', '123456', 'NH', 0),
(8, 'banhang1', '123456', 'BH', 0),
(9, 'nhaphang1', '123456', 'NH', 0),
(10, 'admin1', '123456', 'QL', 0),
(11, 'banhang2', '123456', 'BH', 0),
(12, 'nhaphang2', '123456', 'NH', 0),
(13, 'admin2', '123456', 'QL', 0),
(14, 'banhang3', '123456', 'BH', 0),
(15, 'nhaphang3', '123456', 'NH', 0),
(16, 'banhang4', '123456', 'BH', 0),
(17, 'nhaphang4', '123456', 'NH', 0),
(18, 'bh', '123456', 'BH', 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `chi_tiet_hd`
--
ALTER TABLE `chi_tiet_hd`
  ADD PRIMARY KEY (`ma_hd`,`ma_sp`),
  ADD KEY `ma_sp` (`ma_sp`),
  ADD KEY `ma_hd` (`ma_hd`);

--
-- Indexes for table `chi_tiet_pdh`
--
ALTER TABLE `chi_tiet_pdh`
  ADD PRIMARY KEY (`ma_sp`,`ma_pdh`),
  ADD KEY `ma_sp` (`ma_sp`),
  ADD KEY `ma_pdh` (`ma_pdh`);

--
-- Indexes for table `db_chi_tiet_pn`
--
ALTER TABLE `db_chi_tiet_pn`
  ADD PRIMARY KEY (`ma_phieu_nhap`,`ma_sp`),
  ADD KEY `ma_sp` (`ma_sp`),
  ADD KEY `ma_phieu_nhap` (`ma_phieu_nhap`);

--
-- Indexes for table `db_chucvu`
--
ALTER TABLE `db_chucvu`
  ADD PRIMARY KEY (`ma_cv`);

--
-- Indexes for table `db_hoa_don`
--
ALTER TABLE `db_hoa_don`
  ADD PRIMARY KEY (`ma_hd`),
  ADD KEY `ma_nv` (`ma_nv`),
  ADD KEY `ma_kh` (`ma_kh`);

--
-- Indexes for table `db_khach_hang`
--
ALTER TABLE `db_khach_hang`
  ADD PRIMARY KEY (`ma_kh`);

--
-- Indexes for table `db_nhanvien`
--
ALTER TABLE `db_nhanvien`
  ADD PRIMARY KEY (`ma_nv`),
  ADD KEY `ma_cv` (`ma_cv`);

--
-- Indexes for table `db_nha_cung_cap`
--
ALTER TABLE `db_nha_cung_cap`
  ADD PRIMARY KEY (`ma_ncc`);

--
-- Indexes for table `db_nhom_sp`
--
ALTER TABLE `db_nhom_sp`
  ADD PRIMARY KEY (`ma_loai`);

--
-- Indexes for table `db_phieu_dat_hang`
--
ALTER TABLE `db_phieu_dat_hang`
  ADD PRIMARY KEY (`ma_pdh`),
  ADD KEY `ma_nv` (`ma_nv`),
  ADD KEY `db_phieu_dat_hang_ibfk_2` (`ma_kh`);

--
-- Indexes for table `db_phieu_nhap`
--
ALTER TABLE `db_phieu_nhap`
  ADD PRIMARY KEY (`ma_phieu_nhap`),
  ADD KEY `ma_nv` (`ma_nv`),
  ADD KEY `ma_ncc` (`ma_ncc`);

--
-- Indexes for table `db_sanpham`
--
ALTER TABLE `db_sanpham`
  ADD PRIMARY KEY (`ma_sp`),
  ADD KEY `ma_loai` (`ma_loai`);

--
-- Indexes for table `db_taikhoan`
--
ALTER TABLE `db_taikhoan`
  ADD PRIMARY KEY (`ID`),
  ADD KEY `ma_cv` (`ma_cv`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `db_taikhoan`
--
ALTER TABLE `db_taikhoan`
  MODIFY `ID` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `chi_tiet_hd`
--
ALTER TABLE `chi_tiet_hd`
  ADD CONSTRAINT `chi_tiet_hd_ibfk_1` FOREIGN KEY (`ma_sp`) REFERENCES `db_sanpham` (`ma_sp`),
  ADD CONSTRAINT `chi_tiet_hd_ibfk_2` FOREIGN KEY (`ma_hd`) REFERENCES `db_hoa_don` (`ma_hd`);

--
-- Constraints for table `chi_tiet_pdh`
--
ALTER TABLE `chi_tiet_pdh`
  ADD CONSTRAINT `chi_tiet_pdh_ibfk_1` FOREIGN KEY (`ma_sp`) REFERENCES `db_sanpham` (`ma_sp`),
  ADD CONSTRAINT `chi_tiet_pdh_ibfk_2` FOREIGN KEY (`ma_pdh`) REFERENCES `db_phieu_dat_hang` (`ma_pdh`);

--
-- Constraints for table `db_chi_tiet_pn`
--
ALTER TABLE `db_chi_tiet_pn`
  ADD CONSTRAINT `db_chi_tiet_pn_ibfk_1` FOREIGN KEY (`ma_sp`) REFERENCES `db_sanpham` (`ma_sp`),
  ADD CONSTRAINT `db_chi_tiet_pn_ibfk_2` FOREIGN KEY (`ma_phieu_nhap`) REFERENCES `db_phieu_nhap` (`ma_phieu_nhap`);

--
-- Constraints for table `db_hoa_don`
--
ALTER TABLE `db_hoa_don`
  ADD CONSTRAINT `db_hoa_don_ibfk_1` FOREIGN KEY (`ma_nv`) REFERENCES `db_nhanvien` (`ma_nv`),
  ADD CONSTRAINT `db_hoa_don_ibfk_2` FOREIGN KEY (`ma_kh`) REFERENCES `db_khach_hang` (`ma_kh`);

--
-- Constraints for table `db_nhanvien`
--
ALTER TABLE `db_nhanvien`
  ADD CONSTRAINT `db_nhanvien_ibfk_1` FOREIGN KEY (`ma_cv`) REFERENCES `db_chucvu` (`ma_cv`);

--
-- Constraints for table `db_phieu_dat_hang`
--
ALTER TABLE `db_phieu_dat_hang`
  ADD CONSTRAINT `db_phieu_dat_hang_ibfk_1` FOREIGN KEY (`ma_nv`) REFERENCES `db_nhanvien` (`ma_nv`),
  ADD CONSTRAINT `db_phieu_dat_hang_ibfk_2` FOREIGN KEY (`ma_kh`) REFERENCES `db_khach_hang` (`ma_kh`);

--
-- Constraints for table `db_phieu_nhap`
--
ALTER TABLE `db_phieu_nhap`
  ADD CONSTRAINT `db_phieu_nhap_ibfk_1` FOREIGN KEY (`ma_nv`) REFERENCES `db_nhanvien` (`ma_nv`),
  ADD CONSTRAINT `db_phieu_nhap_ibfk_2` FOREIGN KEY (`ma_ncc`) REFERENCES `db_nha_cung_cap` (`ma_ncc`);

--
-- Constraints for table `db_sanpham`
--
ALTER TABLE `db_sanpham`
  ADD CONSTRAINT `db_sanpham_ibfk_1` FOREIGN KEY (`ma_loai`) REFERENCES `db_nhom_sp` (`ma_loai`);

--
-- Constraints for table `db_taikhoan`
--
ALTER TABLE `db_taikhoan`
  ADD CONSTRAINT `db_taikhoan_ibfk_1` FOREIGN KEY (`ma_cv`) REFERENCES `db_chucvu` (`ma_cv`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
