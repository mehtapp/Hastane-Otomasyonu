USE [master]
GO
/****** Object:  Database [hastane]    Script Date: 5.06.2022 18:12:41 ******/
CREATE DATABASE [hastane]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'hastane', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\hastane.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'hastane_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\hastane_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [hastane] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [hastane].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [hastane] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [hastane] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [hastane] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [hastane] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [hastane] SET ARITHABORT OFF 
GO
ALTER DATABASE [hastane] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [hastane] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [hastane] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [hastane] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [hastane] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [hastane] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [hastane] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [hastane] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [hastane] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [hastane] SET  DISABLE_BROKER 
GO
ALTER DATABASE [hastane] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [hastane] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [hastane] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [hastane] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [hastane] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [hastane] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [hastane] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [hastane] SET RECOVERY FULL 
GO
ALTER DATABASE [hastane] SET  MULTI_USER 
GO
ALTER DATABASE [hastane] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [hastane] SET DB_CHAINING OFF 
GO
ALTER DATABASE [hastane] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [hastane] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [hastane] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [hastane] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'hastane', N'ON'
GO
ALTER DATABASE [hastane] SET QUERY_STORE = OFF
GO
USE [hastane]
GO
/****** Object:  Table [dbo].[Doktorlar]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Doktorlar](
	[DoktorNo] [int] IDENTITY(1,1) NOT NULL,
	[AdSoyad] [varchar](50) NULL,
	[TC] [char](11) NULL,
	[UzmanlikAlan] [varchar](50) NULL,
	[Unvan] [varchar](50) NULL,
	[Telefon] [char](11) NULL,
	[Adres] [varchar](50) NULL,
	[DogumTar] [varchar](50) NULL,
	[PoliklinikNo] [int] NULL,
 CONSTRAINT [PK_Doktorlar] PRIMARY KEY CLUSTERED 
(
	[DoktorNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Hastalar]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Hastalar](
	[HastaNo] [int] IDENTITY(1,1) NOT NULL,
	[AdSoyad] [varchar](50) NULL,
	[TC] [char](11) NULL,
	[DogumTarihi] [varchar](50) NULL,
	[Boy] [int] NULL,
	[Yas] [int] NULL,
	[Recete] [varchar](50) NULL,
	[RaporDurumu] [varchar](50) NULL,
	[RandevuTarih] [varchar](50) NULL,
	[DoktorNo] [int] NULL,
 CONSTRAINT [PK_Hastalar] PRIMARY KEY CLUSTERED 
(
	[HastaNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kullanicilar]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kullanicilar](
	[Kul_Id] [int] IDENTITY(1,1) NOT NULL,
	[KulAd] [varchar](50) NULL,
	[Sifre] [varchar](50) NULL,
	[mail] [varchar](50) NULL,
	[telefon] [varchar](11) NULL,
 CONSTRAINT [PK_Kullanicilar] PRIMARY KEY CLUSTERED 
(
	[Kul_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Poliklinikler]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Poliklinikler](
	[PoliklinikNo] [int] IDENTITY(1,1) NOT NULL,
	[PoliklinikAd] [varchar](50) NULL,
	[UzmanSayisi] [int] NULL,
	[BaskanAdSoyad] [varchar](50) NULL,
	[BasHemsireAdSoyad] [varchar](50) NULL,
	[YatakSayisi] [int] NULL,
 CONSTRAINT [PK_Poliklinikler] PRIMARY KEY CLUSTERED 
(
	[PoliklinikNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Doktorlar] ON 

INSERT [dbo].[Doktorlar] ([DoktorNo], [AdSoyad], [TC], [UzmanlikAlan], [Unvan], [Telefon], [Adres], [DogumTar], [PoliklinikNo]) VALUES (1, N'Zeynep Eren', N'25644411111', N'Katarakt', N'Prof', N'(343) 243-4', N'İstanbul/Şişli', N'22 Kasım 1996 Cuma', 2)
INSERT [dbo].[Doktorlar] ([DoktorNo], [AdSoyad], [TC], [UzmanlikAlan], [Unvan], [Telefon], [Adres], [DogumTar], [PoliklinikNo]) VALUES (2, N'Arda Derin', N'53353453411', N'İris', N'Dr', N'(435) 346-3', N'Ümraniye', N'11 Aralık 1998 Cuma', 2)
INSERT [dbo].[Doktorlar] ([DoktorNo], [AdSoyad], [TC], [UzmanlikAlan], [Unvan], [Telefon], [Adres], [DogumTar], [PoliklinikNo]) VALUES (3, N'Emine Mert', N'85798598111', N'İç Hastalıkları', N'Dr', N'34535345   ', N'Fatih', N'11.11.1996', 2)
INSERT [dbo].[Doktorlar] ([DoktorNo], [AdSoyad], [TC], [UzmanlikAlan], [Unvan], [Telefon], [Adres], [DogumTar], [PoliklinikNo]) VALUES (4, N'Serdar Ora', N'35434564351', N'Dahiliye Uzmanı', N'Prof', N'32423543243', N'Kadıköy', N'01.01.1976', 2)
SET IDENTITY_INSERT [dbo].[Doktorlar] OFF
GO
SET IDENTITY_INSERT [dbo].[Hastalar] ON 

INSERT [dbo].[Hastalar] ([HastaNo], [AdSoyad], [TC], [DogumTarihi], [Boy], [Yas], [Recete], [RaporDurumu], [RandevuTarih], [DoktorNo]) VALUES (1, N'Serkan Kaygusuz', N'121212     ', N'11.10.1997', 163, 32, N'ax', N'Rapor Verilmedi', N'11.03.2022', 1)
INSERT [dbo].[Hastalar] ([HastaNo], [AdSoyad], [TC], [DogumTarihi], [Boy], [Yas], [Recete], [RaporDurumu], [RandevuTarih], [DoktorNo]) VALUES (6, N'Fazıl Say', N'3242432    ', N'2 Şubat 1999 Salı', 170, 31, N'Microvit', N'3 gün Raporlu', N'1 Ocak 2022 Cumartesi', 4)
SET IDENTITY_INSERT [dbo].[Hastalar] OFF
GO
SET IDENTITY_INSERT [dbo].[Kullanicilar] ON 

INSERT [dbo].[Kullanicilar] ([Kul_Id], [KulAd], [Sifre], [mail], [telefon]) VALUES (1, N'm', N'm', N'm', N'01545646464')
INSERT [dbo].[Kullanicilar] ([Kul_Id], [KulAd], [Sifre], [mail], [telefon]) VALUES (2, N'Mehtap', N'mehtap123', N'mehtap@gmail.com', N'02126445454')
INSERT [dbo].[Kullanicilar] ([Kul_Id], [KulAd], [Sifre], [mail], [telefon]) VALUES (7, N'Deniz', N'den123', N'deniz@gmail.com', N'0212544946')
SET IDENTITY_INSERT [dbo].[Kullanicilar] OFF
GO
SET IDENTITY_INSERT [dbo].[Poliklinikler] ON 

INSERT [dbo].[Poliklinikler] ([PoliklinikNo], [PoliklinikAd], [UzmanSayisi], [BaskanAdSoyad], [BasHemsireAdSoyad], [YatakSayisi]) VALUES (1, N'Göz', 1000, N'Fikri Güzel', N'Selin Eren', 122)
INSERT [dbo].[Poliklinikler] ([PoliklinikNo], [PoliklinikAd], [UzmanSayisi], [BaskanAdSoyad], [BasHemsireAdSoyad], [YatakSayisi]) VALUES (2, N'Dahiliye', 120, N'Fatma Nur Sıyrık', N'İrem Tancan', 114)
SET IDENTITY_INSERT [dbo].[Poliklinikler] OFF
GO
ALTER TABLE [dbo].[Doktorlar]  WITH CHECK ADD  CONSTRAINT [FK_Doktorlar_Poliklinikler] FOREIGN KEY([PoliklinikNo])
REFERENCES [dbo].[Poliklinikler] ([PoliklinikNo])
GO
ALTER TABLE [dbo].[Doktorlar] CHECK CONSTRAINT [FK_Doktorlar_Poliklinikler]
GO
ALTER TABLE [dbo].[Hastalar]  WITH CHECK ADD  CONSTRAINT [FK_Hastalar_Doktorlar] FOREIGN KEY([DoktorNo])
REFERENCES [dbo].[Doktorlar] ([DoktorNo])
GO
ALTER TABLE [dbo].[Hastalar] CHECK CONSTRAINT [FK_Hastalar_Doktorlar]
GO
/****** Object:  StoredProcedure [dbo].[boyOrt7]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[boyOrt7]
as begin
Select avg(Boy) from Hastalar where Yas>30
end
GO
/****** Object:  StoredProcedure [dbo].[DokDogTarvUzAl11]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[DokDogTarvUzAl11]
as begin
Select AdSoyad as Doktor,DogumTar as [Doğum Tarihi], UzmanlikAlan as [Uzmanlık Alanı] from Doktorlar
end
GO
/****** Object:  StoredProcedure [dbo].[doktorAdd]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[doktorAdd]
@AdSoyad varchar(50),
@TC char(11),
@uzmanlikAlan varchar(50),
@Unvan varchar(50),
@telefon char(11),
@adres varchar(50),
@DogumTar varchar(50),
@PoliklinikNo int
as begin
Insert into Doktorlar(AdSoyad, TC, UzmanlikAlan, Unvan, Telefon, Adres, DogumTar, PoliklinikNo) values (@AdSoyad, @TC, 
@uzmanlikAlan, @Unvan, @telefon, @adres, @DogumTar, @PoliklinikNo)
end
GO
/****** Object:  StoredProcedure [dbo].[doktorDel]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[doktorDel]
@DoktorNo int
as begin
Delete from Doktorlar where DoktorNo=@DoktorNo
end
GO
/****** Object:  StoredProcedure [dbo].[doktorSearch]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[doktorSearch]
@AdSoyad varchar(50),
@Tc char(11)
as begin 
Select * from Doktorlar where AdSoyad=@AdSoyad or TC=@tc 
end
GO
/****** Object:  StoredProcedure [dbo].[doktorSelectAtoZ]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[doktorSelectAtoZ]
as begin
Select * from Doktorlar order by AdSoyad ASC
end
GO
/****** Object:  StoredProcedure [dbo].[doktorUpdate]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[doktorUpdate]
@doktorNo int,
@AdSoyad varchar(50),
@TC char(11),
@uzmanlikAlan varchar(50),
@Unvan varchar(50),
@telefon char(11),
@adres varchar(50),
@DogumTar varchar(50),
@PoliklinikNo int
as begin
update Doktorlar set AdSoyad=@adSoyad, TC=@TC, UzmanlikAlan=@uzmanlikAlan, Unvan=@Unvan, Telefon=@telefon, Adres=@adres, DogumTar=@DogumTar, PoliklinikNo=@PoliklinikNo where
DoktorNo=@doktorNo
end
GO
/****** Object:  StoredProcedure [dbo].[doktorZtoA]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[doktorZtoA]
as begin
Select * from Doktorlar order by AdSoyad desc
end
GO
/****** Object:  StoredProcedure [dbo].[dokUnvGoreGrup5]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[dokUnvGoreGrup5]
as begin
Select Unvan, count(*) as [Doktor Sayısı] from Doktorlar d group by d.Unvan
end
GO
/****** Object:  StoredProcedure [dbo].[hastaAdd]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[hastaAdd]
@AdSoyad varchar(50),
@TC char(11),
@DogumTarihi varchar(50),
@Boy int,
@yas int,
@recete varchar(50),
@raporDurumu varchar(50),
@RandevuTarih varchar(50),
@DoktorNo int
as begin
Insert into Hastalar(AdSoyad, TC, DogumTarihi, Boy, Yas, Recete, RaporDurumu, RandevuTarih, DoktorNo) values (@AdSoyad, @TC, 
@DogumTarihi, @Boy , @yas, @recete, @raporDurumu, @RandevuTarih, @DoktorNo)
end
GO
/****** Object:  StoredProcedure [dbo].[hastaAtoZ]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[hastaAtoZ]
as begin
Select * from Hastalar order by AdSoyad asc
end
GO
/****** Object:  StoredProcedure [dbo].[hastaDel]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[hastaDel]
@hastaNo int
as begin
Delete from Hastalar where HastaNo=@hastaNo
end
GO
/****** Object:  StoredProcedure [dbo].[hastaSearch]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE proc [dbo].[hastaSearch]
@AdSoyad varchar(50),
@Tc char(11)
as begin 
Select * from Hastalar where AdSoyad=@AdSoyad or TC=@tc 
end
GO
/****** Object:  StoredProcedure [dbo].[hastaSelect]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[hastaSelect]
as begin
Select * from Hastalar
end
GO
/****** Object:  StoredProcedure [dbo].[hastaUpdate]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[hastaUpdate]
@hastaNo int,
@adSoyad varchar(50),
@tc char(11),
@DogumTarihi varchar(50),
@Boy int, 
@Yas int,
@recete varchar(50),
@RaporDurumu varchar(50),
@RandevuTarih varchar(50),
@DoktorNo int
as begin
update Hastalar set AdSoyad=@adSoyad,TC=@tc, DogumTarihi=@DogumTarihi, Boy=@Boy, Yas=@Yas, Recete=@recete, RaporDurumu=@RaporDurumu,
RandevuTarih=@RandevuTarih, DoktorNo=@DoktorNo where HastaNo=@hastaNo
end
GO
/****** Object:  StoredProcedure [dbo].[hastaZtoA]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[hastaZtoA]
as begin
Select * from Hastalar order by AdSoyad desc
end
GO
/****** Object:  StoredProcedure [dbo].[ismGorePolUzmSayi9]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ismGorePolUzmSayi9]
as begin
Select PoliklinikAd, UzmanSayisi from Poliklinikler 
end
GO
/****** Object:  StoredProcedure [dbo].[kulKayit]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[kulKayit]
@KulAd varchar(50),
@Sifre varchar(50),
@mail varchar(50),
@telefon varchar(13)
as begin
Insert into Kullanicilar (KulAd, Sifre, mail, telefon) values (@KulAd, @sifre, @mail, @telefon )
end
GO
/****** Object:  StoredProcedure [dbo].[kullaniciList]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[kullaniciList]
@kulAd varchar(50),
@sifre varchar(50)
as begin
Select * from Kullanicilar where KulAd=@kulAd and Sifre=@sifre
end
GO
/****** Object:  StoredProcedure [dbo].[kullaniciUserNameKontrol]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[kullaniciUserNameKontrol]
@kulAd varchar(50)
as begin
Select * from Kullanicilar where KulAd=@kulAd
end
GO
/****** Object:  StoredProcedure [dbo].[OrtAlGorHasBilg3]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[OrtAlGorHasBilg3]
as begin
Select * from Hastalar 
end
exec OrtAlGorHasBilg3
GO
/****** Object:  StoredProcedure [dbo].[polAdd]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[polAdd]
@PoliklinikAd varchar(50),
@UzmanSayi int,
@baskanAdSoyad varchar(50),
@bashemsireAdSoyad varchar(50),
@yataksayisi int
as begin
Insert into Poliklinikler(PoliklinikAd, UzmanSayisi, BaskanAdSoyad, BasHemsireAdSoyad, YatakSayisi) values (@PoliklinikAd, @UzmanSayi, @baskanAdSoyad, @bashemsireAdSoyad, @yataksayisi)
End
GO
/****** Object:  StoredProcedure [dbo].[polAdGoreYatSay10]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[polAdGoreYatSay10]
as begin
Select PoliklinikAd, YatakSayisi from Poliklinikler
end
GO
/****** Object:  StoredProcedure [dbo].[polDel]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[polDel]
@poliklinikNo int
as begin
Delete from Poliklinikler where PoliklinikNo=@poliklinikNo
end
GO
/****** Object:  StoredProcedure [dbo].[polNoHasDokBilg1]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[polNoHasDokBilg1]
as begin
Select d.PoliklinikNo,* from Doktorlar d join Hastalar h on d.DoktorNo=h.DoktorNo order by d.PoliklinikNo asc
end 
GO
/****** Object:  StoredProcedure [dbo].[polSearch]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[polSearch]
@poliklinikNo int,
@poliklinikad varchar(50)
as begin 
Select * from Poliklinikler where PoliklinikNo=@poliklinikNo or PoliklinikAd=@poliklinikad
end
execute [dbo].[polSearch] 2,'dahi'
GO
/****** Object:  StoredProcedure [dbo].[polSelect]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[polSelect]
as begin
select * from Poliklinikler order by PoliklinikAd
end
GO
/****** Object:  StoredProcedure [dbo].[polTabSolSorgu2]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[polTabSolSorgu2]
as begin
Select * from Poliklinikler ORDER BY PoliklinikNo asc
end
GO
/****** Object:  StoredProcedure [dbo].[polUpdate]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[polUpdate]
@poliklinikNo int,
@PoliklinikAd varchar(50),
@UzmanSayi int,
@baskanAdSoyad varchar(50),
@bashemsireAdSoyad varchar(50),
@yataksayisi int
as begin
update Poliklinikler set PoliklinikAd=@PoliklinikAd, UzmanSayisi=@UzmanSayi, BaskanAdSoyad=@baskanAdSoyad, BasHemsireAdSoyad=@bashemsireAdSoyad,  
YatakSayisi=@yataksayisi where PoliklinikNo=@poliklinikNo
end
GO
/****** Object:  StoredProcedure [dbo].[PolveHasGorDokBilg4]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[PolveHasGorDokBilg4]
as begin
Select d.DoktorNo, d.PoliklinikNo, h.HastaNo, d.AdSoyad as Doktor, d.TC, d.Unvan, d.DogumTar, d.Telefon, d.UzmanlikAlan, d.Adres from Doktorlar d join Hastalar h on h.DoktorNo=d.DoktorNo join Poliklinikler p on p.PoliklinikNo=d.PoliklinikNo  
end
GO
/****** Object:  StoredProcedure [dbo].[polZtoA]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[polZtoA]
as begin
select * from Poliklinikler order by PoliklinikAd desc
end
GO
/****** Object:  StoredProcedure [dbo].[rapdurYasOrt6]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE proc [dbo].[rapdurYasOrt6]
as begin
Select RaporDurumu,avg(Yas) as [Yaş Ortalaması] from Hastalar group by RaporDurumu
end
GO
/****** Object:  StoredProcedure [dbo].[yasort8]    Script Date: 5.06.2022 18:12:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 create proc [dbo].[yasort8]
 as begin
 Select avg(Yas) as [Yaş Ortalaması] from Hastalar where Boy>160
 end
GO
USE [master]
GO
ALTER DATABASE [hastane] SET  READ_WRITE 
GO
