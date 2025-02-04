USE [master]
GO
/****** Object:  Database [QuanLyBanHang]    Script Date: 11/10/2022 3:13:04 PM ******/
CREATE DATABASE [QuanLyBanHang]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'QuanLyBanHang', FILENAME = N'D:\Workspace\DATABASE\QuanLyBanHang_Database\QuanLyBanHang.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'QuanLyBanHang_log', FILENAME = N'D:\Workspace\DATABASE\QuanLyBanHang_Database\QuanLyBanHang_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [QuanLyBanHang] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [QuanLyBanHang].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [QuanLyBanHang] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ARITHABORT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [QuanLyBanHang] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [QuanLyBanHang] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [QuanLyBanHang] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET  DISABLE_BROKER 
GO
ALTER DATABASE [QuanLyBanHang] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [QuanLyBanHang] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [QuanLyBanHang] SET  MULTI_USER 
GO
ALTER DATABASE [QuanLyBanHang] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [QuanLyBanHang] SET DB_CHAINING OFF 
GO
ALTER DATABASE [QuanLyBanHang] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [QuanLyBanHang] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [QuanLyBanHang] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [QuanLyBanHang] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [QuanLyBanHang] SET QUERY_STORE = OFF
GO
USE [QuanLyBanHang]
GO
/****** Object:  Table [dbo].[tblChiTietHDBan]    Script Date: 11/10/2022 3:13:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblChiTietHDBan](
	[MaHDBan] [nvarchar](30) NOT NULL,
	[MaHang] [nvarchar](10) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGia] [float] NOT NULL,
	[GiamGia] [float] NOT NULL,
	[ThanhTien] [float] NOT NULL,
 CONSTRAINT [PK_tblChiTietHDBan] PRIMARY KEY CLUSTERED 
(
	[MaHDBan] ASC,
	[MaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblHang]    Script Date: 11/10/2022 3:13:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHang](
	[MaHang] [nvarchar](10) NOT NULL,
	[TenHang] [nvarchar](50) NOT NULL,
	[MaLoaiHang] [nvarchar](10) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGiaNhap] [int] NOT NULL,
	[DonGiaBan] [int] NOT NULL,
	[Calo] [float] NOT NULL,
	[Anh] [nvarchar](200) NOT NULL,
	[GhiChu] [nvarchar](200) NULL,
	[PhuongAn] [int] NULL,
	[DonGia] [float] NOT NULL,
 CONSTRAINT [PK_tblHang] PRIMARY KEY CLUSTERED 
(
	[MaHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblHDBan]    Script Date: 11/10/2022 3:13:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblHDBan](
	[MaHDBan] [nvarchar](30) NOT NULL,
	[MaNhanVien] [nvarchar](10) NOT NULL,
	[NgayBan] [datetime] NOT NULL,
	[MaKhach] [nvarchar](10) NOT NULL,
	[TongTien] [int] NOT NULL,
 CONSTRAINT [PK_tblHDBan] PRIMARY KEY CLUSTERED 
(
	[MaHDBan] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblKhach]    Script Date: 11/10/2022 3:13:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblKhach](
	[MaKhach] [nvarchar](10) NOT NULL,
	[TenKhach] [nvarchar](50) NOT NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
	[DienThoai] [nvarchar](15) NOT NULL,
 CONSTRAINT [PK_tblKhach] PRIMARY KEY CLUSTERED 
(
	[MaKhach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblLoaiHang]    Script Date: 11/10/2022 3:13:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblLoaiHang](
	[MaLoaiHang] [nvarchar](10) NOT NULL,
	[TenLoaiHang] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_tblLoaiHang] PRIMARY KEY CLUSTERED 
(
	[MaLoaiHang] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblNhanVien]    Script Date: 11/10/2022 3:13:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblNhanVien](
	[MaNhanVien] [nvarchar](10) NOT NULL,
	[TenNhanVien] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](10) NOT NULL,
	[DiaChi] [nvarchar](100) NOT NULL,
	[DienThoai] [nvarchar](15) NOT NULL,
	[NgaySinh] [date] NOT NULL,
 CONSTRAINT [PK_tblNhanVien] PRIMARY KEY CLUSTERED 
(
	[MaNhanVien] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tblTaiKhoan]    Script Date: 11/10/2022 3:13:04 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tblTaiKhoan](
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[MaNhanVien] [nvarchar](10) NOT NULL,
	[Privilege] [bit] NOT NULL,
 CONSTRAINT [PK_tblTaiKhoan] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[tblChiTietHDBan] ([MaHDBan], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB4292022_224241', N'HH-0001', 5, 16000, 0, 80000)
INSERT [dbo].[tblChiTietHDBan] ([MaHDBan], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB4292022_224241', N'HH-0007', 10, 2000, 0, 20000)
INSERT [dbo].[tblChiTietHDBan] ([MaHDBan], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB5112022_204058', N'HH-0002', 2, 60000, 0, 120000)
INSERT [dbo].[tblChiTietHDBan] ([MaHDBan], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB5112022_204058', N'HH-0003', 5, 32000, 0, 160000)
INSERT [dbo].[tblChiTietHDBan] ([MaHDBan], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB5112022_204735', N'HH-0002', 3, 60000, 0, 180000)
INSERT [dbo].[tblChiTietHDBan] ([MaHDBan], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB5112022_204735', N'HH-0004', 1, 7000, 0, 7000)
INSERT [dbo].[tblChiTietHDBan] ([MaHDBan], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB5122022_142050', N'HH-0003', 2, 32000, 0, 64000)
INSERT [dbo].[tblChiTietHDBan] ([MaHDBan], [MaHang], [SoLuong], [DonGia], [GiamGia], [ThanhTien]) VALUES (N'HDB5122022_142050', N'HH-0005', 1, 15000, 0, 15000)
GO
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaLoaiHang], [SoLuong], [DonGiaNhap], [DonGiaBan], [Calo], [Anh], [GhiChu], [PhuongAn], [DonGia]) VALUES (N'HH-0001', N'Bánh Oreo', N'LH-0001', 45, 12000, 16000, 530, N'D:\Workspace\.NET\QuanLyBanHang\image\Banh\Banh_Oreo.jpg', N'', NULL, 0.033125)
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaLoaiHang], [SoLuong], [DonGiaNhap], [DonGiaBan], [Calo], [Anh], [GhiChu], [PhuongAn], [DonGia]) VALUES (N'HH-0002', N'Bánh Custas', N'LH-0001', 15, 42000, 60000, 1200, N'D:\Workspace\.NET\QuanLyBanHang\image\Banh\Banh_Custas.jpg', N'', NULL, 0.02)
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaLoaiHang], [SoLuong], [DonGiaNhap], [DonGiaBan], [Calo], [Anh], [GhiChu], [PhuongAn], [DonGia]) VALUES (N'HH-0003', N'Bánh Karo', N'LH-0001', 33, 25000, 32000, 720, N'D:\Workspace\.NET\QuanLyBanHang\image\Banh\Banh_Karo.jpg', N'', NULL, 0.0225)
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaLoaiHang], [SoLuong], [DonGiaNhap], [DonGiaBan], [Calo], [Anh], [GhiChu], [PhuongAn], [DonGia]) VALUES (N'HH-0004', N'Bánh Nabati', N'LH-0001', 99, 5000, 7000, 260, N'D:\Workspace\.NET\QuanLyBanHang\image\Banh\Banh_Nabati.jpg', N'', NULL, 0.03714286)
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaLoaiHang], [SoLuong], [DonGiaNhap], [DonGiaBan], [Calo], [Anh], [GhiChu], [PhuongAn], [DonGia]) VALUES (N'HH-0005', N'Bánh quế Cosy', N'LH-0001', 59, 11000, 15000, 570, N'D:\Workspace\.NET\QuanLyBanHang\image\Banh\Banh_Cosy.jpg', N'', NULL, 0.038)
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaLoaiHang], [SoLuong], [DonGiaNhap], [DonGiaBan], [Calo], [Anh], [GhiChu], [PhuongAn], [DonGia]) VALUES (N'HH-0006', N'Kẹo alpenliebe', N'LH-0002', 40, 3000, 5500, 210, N'D:\Workspace\.NET\QuanLyBanHang\image\Keo\Keo_alpenliebe.jpg', N'', NULL, 0.03818182)
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaLoaiHang], [SoLuong], [DonGiaNhap], [DonGiaBan], [Calo], [Anh], [GhiChu], [PhuongAn], [DonGia]) VALUES (N'HH-0007', N'Kẹo ChuppaChups', N'LH-0002', 50, 1500, 2000, 20, N'D:\Workspace\.NET\QuanLyBanHang\image\Keo\Keo_ChupaChups.jpg', N'', NULL, 0.01)
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaLoaiHang], [SoLuong], [DonGiaNhap], [DonGiaBan], [Calo], [Anh], [GhiChu], [PhuongAn], [DonGia]) VALUES (N'HH-0008', N'Kẹo CoolAir', N'LH-0002', 30, 18000, 24000, 200, N'D:\Workspace\.NET\QuanLyBanHang\image\Keo\Keo_Coolair.jpg', N'', NULL, 0.008333334)
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaLoaiHang], [SoLuong], [DonGiaNhap], [DonGiaBan], [Calo], [Anh], [GhiChu], [PhuongAn], [DonGia]) VALUES (N'HH-0009', N'KitKat', N'LH-0002', 40, 60000, 74000, 1040, N'D:\Workspace\.NET\QuanLyBanHang\image\Keo\Keo_KitKat.jpg', N'', NULL, 0.01405405)
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaLoaiHang], [SoLuong], [DonGiaNhap], [DonGiaBan], [Calo], [Anh], [GhiChu], [PhuongAn], [DonGia]) VALUES (N'HH-0010', N'Kẹo sữa Mikita', N'LH-0002', 20, 12500, 16000, 60, N'D:\Workspace\.NET\QuanLyBanHang\image\Keo\Keo_Mikita.jpg', N'', NULL, 0.00375)
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaLoaiHang], [SoLuong], [DonGiaNhap], [DonGiaBan], [Calo], [Anh], [GhiChu], [PhuongAn], [DonGia]) VALUES (N'HH-0011', N'Mirinda Soda Kem', N'LH-0003', 48, 6000, 8000, 80, N'D:\Workspace\.NET\QuanLyBanHang\image\Nuocdongchai\NuocDongChai_MirindaSodaKem.jpg', N'', NULL, 0.01)
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaLoaiHang], [SoLuong], [DonGiaNhap], [DonGiaBan], [Calo], [Anh], [GhiChu], [PhuongAn], [DonGia]) VALUES (N'HH-0012', N'Sữa trái cây Nutri Boost', N'LH-0003', 20, 16000, 25000, 620, N'D:\Workspace\.NET\QuanLyBanHang\image\Nuocdongchai\NuocDongChai_NutriBoost.jpg', N'', NULL, 0.0248)
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaLoaiHang], [SoLuong], [DonGiaNhap], [DonGiaBan], [Calo], [Anh], [GhiChu], [PhuongAn], [DonGia]) VALUES (N'HH-0013', N'Nước Revive', N'LH-0003', 20, 7000, 10000, 135, N'D:\Workspace\.NET\QuanLyBanHang\image\Nuocdongchai\NuocDongChai_Revice.jpg', N'', NULL, 0.0135)
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaLoaiHang], [SoLuong], [DonGiaNhap], [DonGiaBan], [Calo], [Anh], [GhiChu], [PhuongAn], [DonGia]) VALUES (N'HH-0014', N'Sting', N'LH-0003', 20, 6000, 8500, 240, N'D:\Workspace\.NET\QuanLyBanHang\image\Nuocdongchai\NuocDongChai_Sting.jpg', N'', NULL, 0.02823529)
INSERT [dbo].[tblHang] ([MaHang], [TenHang], [MaLoaiHang], [SoLuong], [DonGiaNhap], [DonGiaBan], [Calo], [Anh], [GhiChu], [PhuongAn], [DonGia]) VALUES (N'HH-0015', N'Warrior', N'LH-0003', 20, 7500, 10000, 480, N'D:\Workspace\.NET\QuanLyBanHang\image\Nuocdongchai\NuocDongChai_Warrior.jpg', N'', NULL, 0.048)
GO
INSERT [dbo].[tblHDBan] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhach], [TongTien]) VALUES (N'HDB4292022_224241', N'NV-0001', CAST(N'2022-04-29T00:00:00.000' AS DateTime), N'KH-0001', 100000)
INSERT [dbo].[tblHDBan] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhach], [TongTien]) VALUES (N'HDB5112022_204058', N'NV-0000', CAST(N'2022-05-11T00:00:00.000' AS DateTime), N'KH-0000', 280000)
INSERT [dbo].[tblHDBan] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhach], [TongTien]) VALUES (N'HDB5112022_204735', N'NV-0000', CAST(N'2022-05-11T00:00:00.000' AS DateTime), N'KH-0000', 187000)
INSERT [dbo].[tblHDBan] ([MaHDBan], [MaNhanVien], [NgayBan], [MaKhach], [TongTien]) VALUES (N'HDB5122022_142050', N'NV-0000', CAST(N'2022-05-12T00:00:00.000' AS DateTime), N'KH-0000', 79000)
GO
INSERT [dbo].[tblKhach] ([MaKhach], [TenKhach], [DiaChi], [DienThoai]) VALUES (N'KH-0000', N'Khách vãng lai', N'-------------------', N'0000000000')
INSERT [dbo].[tblKhach] ([MaKhach], [TenKhach], [DiaChi], [DienThoai]) VALUES (N'KH-0001', N'Nguyễn Thị Nhàn', N'Bình Thuỷ - Cần Thơ', N'0773555632')
INSERT [dbo].[tblKhach] ([MaKhach], [TenKhach], [DiaChi], [DienThoai]) VALUES (N'KH-0002', N'Trần Văn Mạnh', N'Cái Răng - Cần Thơ', N'0936581345')
INSERT [dbo].[tblKhach] ([MaKhach], [TenKhach], [DiaChi], [DienThoai]) VALUES (N'KH-0003', N'Trần Linh Nhu', N'Châu Thành - Sóc Trăng', N'0937874161')
INSERT [dbo].[tblKhach] ([MaKhach], [TenKhach], [DiaChi], [DienThoai]) VALUES (N'KH-0004', N'Nguyễn Anh Tuấn', N'Ninh Kiều - Cần Thơ', N'0861657887')
INSERT [dbo].[tblKhach] ([MaKhach], [TenKhach], [DiaChi], [DienThoai]) VALUES (N'KH-0005', N'Liễu Ánh Nguyệt', N'Hoà Bình - Bạc Liêu', N'0774544412')
GO
INSERT [dbo].[tblLoaiHang] ([MaLoaiHang], [TenLoaiHang]) VALUES (N'LH-0001', N'Bánh')
INSERT [dbo].[tblLoaiHang] ([MaLoaiHang], [TenLoaiHang]) VALUES (N'LH-0002', N'Kẹo')
INSERT [dbo].[tblLoaiHang] ([MaLoaiHang], [TenLoaiHang]) VALUES (N'LH-0003', N'Nước đóng chai')
INSERT [dbo].[tblLoaiHang] ([MaLoaiHang], [TenLoaiHang]) VALUES (N'LH-0004', N'Gạo')
INSERT [dbo].[tblLoaiHang] ([MaLoaiHang], [TenLoaiHang]) VALUES (N'LH-0005', N'Mì')
GO
INSERT [dbo].[tblNhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [DiaChi], [DienThoai], [NgaySinh]) VALUES (N'NV-0000', N'Chủ quán', N'Nam', N'Ninh Kiều - Cần Thơ', N'077357623', CAST(N'1980-02-11' AS Date))
INSERT [dbo].[tblNhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [DiaChi], [DienThoai], [NgaySinh]) VALUES (N'NV-0001', N'Nguyễn Văn Tín', N'Nam', N'Ninh Kiều - Cần Thơ', N'0941742735', CAST(N'1999-02-19' AS Date))
INSERT [dbo].[tblNhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [DiaChi], [DienThoai], [NgaySinh]) VALUES (N'NV-0002', N'Vũ Thị Liễu', N'Nữ', N'Cái Răng - Cần Thơ', N'0969643512', CAST(N'2000-04-26' AS Date))
INSERT [dbo].[tblNhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [DiaChi], [DienThoai], [NgaySinh]) VALUES (N'NV-0003', N'Trần Trung Kiên', N'Nam', N'Ô Môn - Cần Thơ', N'093687134', CAST(N'2001-12-02' AS Date))
INSERT [dbo].[tblNhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [DiaChi], [DienThoai], [NgaySinh]) VALUES (N'NV-0004', N'Đinh Mạnh Cường', N'Nam', N'Mỹ Xuyên - Sóc Trăng', N'0773571831', CAST(N'2000-02-01' AS Date))
INSERT [dbo].[tblNhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [DiaChi], [DienThoai], [NgaySinh]) VALUES (N'NV-0005', N'Nguyễn Thị Như Nguyệt', N'Nữ', N'Cái Khế - Sóc Trăng', N'0965735615', CAST(N'2022-04-29' AS Date))
INSERT [dbo].[tblNhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [DiaChi], [DienThoai], [NgaySinh]) VALUES (N'NV-0006', N'Nguyễn Ái My', N'Nữ', N'Đông Hải - Bạc Liêu', N'0946781863', CAST(N'2022-04-29' AS Date))
INSERT [dbo].[tblNhanVien] ([MaNhanVien], [TenNhanVien], [GioiTinh], [DiaChi], [DienThoai], [NgaySinh]) VALUES (N'NV-0007', N'Nguyễn Văn A', N'Nữ', N'Bình Thuỷ - Cần Thơ', N'0946785134', CAST(N'2022-05-12' AS Date))
GO
INSERT [dbo].[tblTaiKhoan] ([Username], [Password], [MaNhanVien], [Privilege]) VALUES (N'admin', N'admin123', N'NV-0000', 1)
INSERT [dbo].[tblTaiKhoan] ([Username], [Password], [MaNhanVien], [Privilege]) VALUES (N'nhanvien1', N'nhanvien1', N'NV-0001', 1)
INSERT [dbo].[tblTaiKhoan] ([Username], [Password], [MaNhanVien], [Privilege]) VALUES (N'nhanvien2', N'nhanvien2', N'NV-0002', 1)
INSERT [dbo].[tblTaiKhoan] ([Username], [Password], [MaNhanVien], [Privilege]) VALUES (N'nhanvien3', N'nhanvien3', N'NV-0003', 0)
INSERT [dbo].[tblTaiKhoan] ([Username], [Password], [MaNhanVien], [Privilege]) VALUES (N'nhanvien4', N'nhanvien4', N'NV-0004', 1)
INSERT [dbo].[tblTaiKhoan] ([Username], [Password], [MaNhanVien], [Privilege]) VALUES (N'nhanvien5', N'nhanvien5', N'NV-0005', 0)
INSERT [dbo].[tblTaiKhoan] ([Username], [Password], [MaNhanVien], [Privilege]) VALUES (N'nhanvien6', N'nhanvien6', N'NV-0006', 0)
INSERT [dbo].[tblTaiKhoan] ([Username], [Password], [MaNhanVien], [Privilege]) VALUES (N'nhanvien7', N'nhanvien7', N'NV-0007', 0)
GO
ALTER TABLE [dbo].[tblHang] ADD  CONSTRAINT [DF_tblHang_MaLoaiHang]  DEFAULT (N'LH-0000') FOR [MaLoaiHang]
GO
ALTER TABLE [dbo].[tblHDBan] ADD  CONSTRAINT [DF_tblHDBan_MaNhanVien]  DEFAULT (N'NV-0000') FOR [MaNhanVien]
GO
ALTER TABLE [dbo].[tblHDBan] ADD  CONSTRAINT [DF_tblHDBan_MaKhach]  DEFAULT (N'KH-0000') FOR [MaKhach]
GO
ALTER TABLE [dbo].[tblChiTietHDBan]  WITH CHECK ADD  CONSTRAINT [FK_tblChiTietHDBan_tblHang] FOREIGN KEY([MaHang])
REFERENCES [dbo].[tblHang] ([MaHang])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblChiTietHDBan] CHECK CONSTRAINT [FK_tblChiTietHDBan_tblHang]
GO
ALTER TABLE [dbo].[tblChiTietHDBan]  WITH CHECK ADD  CONSTRAINT [FK_tblChiTietHDBan_tblHDBan] FOREIGN KEY([MaHDBan])
REFERENCES [dbo].[tblHDBan] ([MaHDBan])
GO
ALTER TABLE [dbo].[tblChiTietHDBan] CHECK CONSTRAINT [FK_tblChiTietHDBan_tblHDBan]
GO
ALTER TABLE [dbo].[tblHang]  WITH CHECK ADD  CONSTRAINT [FK_tblHang_tblLoaiHang] FOREIGN KEY([MaLoaiHang])
REFERENCES [dbo].[tblLoaiHang] ([MaLoaiHang])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblHang] CHECK CONSTRAINT [FK_tblHang_tblLoaiHang]
GO
ALTER TABLE [dbo].[tblHDBan]  WITH CHECK ADD  CONSTRAINT [FK_tblHDBan_tblKhach] FOREIGN KEY([MaKhach])
REFERENCES [dbo].[tblKhach] ([MaKhach])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblHDBan] CHECK CONSTRAINT [FK_tblHDBan_tblKhach]
GO
ALTER TABLE [dbo].[tblHDBan]  WITH CHECK ADD  CONSTRAINT [FK_tblHDBan_tblNhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[tblNhanVien] ([MaNhanVien])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblHDBan] CHECK CONSTRAINT [FK_tblHDBan_tblNhanVien]
GO
ALTER TABLE [dbo].[tblTaiKhoan]  WITH CHECK ADD  CONSTRAINT [FK_tblTaiKhoan_tblNhanVien] FOREIGN KEY([MaNhanVien])
REFERENCES [dbo].[tblNhanVien] ([MaNhanVien])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[tblTaiKhoan] CHECK CONSTRAINT [FK_tblTaiKhoan_tblNhanVien]
GO
USE [master]
GO
ALTER DATABASE [QuanLyBanHang] SET  READ_WRITE 
GO
