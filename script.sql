USE [qlsach]
GO
/****** Object:  Schema [qlsach]    Script Date: 6/15/2022 9:27:01 PM ******/
CREATE SCHEMA [qlsach]
GO
/****** Object:  Table [qlsach].[ctpm]    Script Date: 6/15/2022 9:27:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [qlsach].[ctpm](
	[MaCTPM] [nchar](10) NOT NULL,
	[MaPM] [nvarchar](10) NOT NULL,
	[MaSach] [nvarchar](10) NOT NULL,
	[NgayTra] [date] NULL,
	[TinhTrangSach] [int] NOT NULL,
	[TinhTrangTra] [int] NULL,
	[User] [nvarchar](10) NULL,
	[GhiChu] [nvarchar](50) NULL,
	[TienPhat] [float] NULL,
 CONSTRAINT [PK_ctpm_MaPM] PRIMARY KEY CLUSTERED 
(
	[MaCTPM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [qlsach].[docgia]    Script Date: 6/15/2022 9:27:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [qlsach].[docgia](
	[MaDG] [nvarchar](10) NOT NULL,
	[TenDG] [nvarchar](20) NOT NULL,
	[SDT] [nvarchar](20) NOT NULL,
	[DiaChi] [nvarchar](50) NOT NULL,
	[GioiTinh] [nvarchar](10) NOT NULL,
	[MatSach] [int] NOT NULL,
 CONSTRAINT [PK_docgia_MaDG] PRIMARY KEY CLUSTERED 
(
	[MaDG] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [qlsach].[phieumuon]    Script Date: 6/15/2022 9:27:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [qlsach].[phieumuon](
	[MaPM] [nvarchar](10) NOT NULL,
	[MaDG] [nvarchar](10) NOT NULL,
	[NgayMuon] [date] NOT NULL,
	[NgayHenTra] [date] NOT NULL,
	[SoLuongMuon] [int] NOT NULL,
	[User] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_phieumuon_MaPM] PRIMARY KEY CLUSTERED 
(
	[MaPM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [qlsach].[sach]    Script Date: 6/15/2022 9:27:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [qlsach].[sach](
	[MaSach] [nvarchar](10) NOT NULL,
	[TenSach] [nvarchar](500) NOT NULL,
	[TenTG] [nvarchar](500) NOT NULL,
	[NhaXB] [nvarchar](500) NOT NULL,
	[TheLoai] [nvarchar](500) NOT NULL,
	[SoLuong] [int] NOT NULL,
	[GiaTien] [float] NOT NULL,
	[ImageUrl] [nvarchar](500) NULL,
	[MieuTa] [nvarchar](2500) NULL,
 CONSTRAINT [PK_sach_MaSach] PRIMARY KEY CLUSTERED 
(
	[MaSach] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [qlsach].[taikhoan]    Script Date: 6/15/2022 9:27:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [qlsach].[taikhoan](
	[User] [nvarchar](10) NOT NULL,
	[Password] [nvarchar](20) NOT NULL,
	[PhanQuyen] [int] NOT NULL,
	[TenND] [nvarchar](20) NOT NULL,
	[SDT] [nvarchar](10) NOT NULL,
	[CMND] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_taikhoan_User] PRIMARY KEY CLUSTERED 
(
	[User] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [qlsach].[ctpm] ADD  CONSTRAINT [DF__ctpm__NgayTra__440B1D61]  DEFAULT (NULL) FOR [NgayTra]
GO
ALTER TABLE [qlsach].[ctpm] ADD  CONSTRAINT [DF__ctpm__TinhTrangT__44FF419A]  DEFAULT (NULL) FOR [TinhTrangTra]
GO
ALTER TABLE [qlsach].[ctpm] ADD  CONSTRAINT [DF__ctpm__User__45F365D3]  DEFAULT (NULL) FOR [User]
GO
ALTER TABLE [qlsach].[ctpm] ADD  CONSTRAINT [DF__ctpm__GhiChu__46E78A0C]  DEFAULT (NULL) FOR [GhiChu]
GO
ALTER TABLE [qlsach].[ctpm] ADD  CONSTRAINT [DF__ctpm__TienPhat__47DBAE45]  DEFAULT (NULL) FOR [TienPhat]
GO
ALTER TABLE [qlsach].[sach] ADD  DEFAULT (NULL) FOR [ImageUrl]
GO
ALTER TABLE [qlsach].[sach] ADD  DEFAULT (NULL) FOR [MieuTa]
GO
ALTER TABLE [qlsach].[ctpm]  WITH NOCHECK ADD  CONSTRAINT [ctpm$ctpm_ibfk_1] FOREIGN KEY([User])
REFERENCES [qlsach].[taikhoan] ([User])
GO
ALTER TABLE [qlsach].[ctpm] CHECK CONSTRAINT [ctpm$ctpm_ibfk_1]
GO
ALTER TABLE [qlsach].[ctpm]  WITH NOCHECK ADD  CONSTRAINT [ctpm$ctpm_ibfk_3] FOREIGN KEY([MaSach])
REFERENCES [qlsach].[sach] ([MaSach])
GO
ALTER TABLE [qlsach].[ctpm] CHECK CONSTRAINT [ctpm$ctpm_ibfk_3]
GO
ALTER TABLE [qlsach].[ctpm]  WITH CHECK ADD  CONSTRAINT [FK_ctpm_phieumuon] FOREIGN KEY([MaPM])
REFERENCES [qlsach].[phieumuon] ([MaPM])
GO
ALTER TABLE [qlsach].[ctpm] CHECK CONSTRAINT [FK_ctpm_phieumuon]
GO
ALTER TABLE [qlsach].[phieumuon]  WITH NOCHECK ADD  CONSTRAINT [phieumuon$fk_phieumuon_MaDG] FOREIGN KEY([MaDG])
REFERENCES [qlsach].[docgia] ([MaDG])
GO
ALTER TABLE [qlsach].[phieumuon] CHECK CONSTRAINT [phieumuon$fk_phieumuon_MaDG]
GO
ALTER TABLE [qlsach].[phieumuon]  WITH NOCHECK ADD  CONSTRAINT [phieumuon$fk_phieumuon_User] FOREIGN KEY([User])
REFERENCES [qlsach].[taikhoan] ([User])
GO
ALTER TABLE [qlsach].[phieumuon] CHECK CONSTRAINT [phieumuon$fk_phieumuon_User]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'qlsach.ctpm' , @level0type=N'SCHEMA',@level0name=N'qlsach', @level1type=N'TABLE',@level1name=N'ctpm'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'qlsach.docgia' , @level0type=N'SCHEMA',@level0name=N'qlsach', @level1type=N'TABLE',@level1name=N'docgia'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'qlsach.phieumuon' , @level0type=N'SCHEMA',@level0name=N'qlsach', @level1type=N'TABLE',@level1name=N'phieumuon'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'qlsach.sach' , @level0type=N'SCHEMA',@level0name=N'qlsach', @level1type=N'TABLE',@level1name=N'sach'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_SSMA_SOURCE', @value=N'qlsach.taikhoan' , @level0type=N'SCHEMA',@level0name=N'qlsach', @level1type=N'TABLE',@level1name=N'taikhoan'
GO
