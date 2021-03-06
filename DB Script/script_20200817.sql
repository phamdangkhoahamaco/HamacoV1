USE [master]
GO
/****** Object:  Database [HamacoV2]    Script Date: 8/17/2020 9:21:35 AM ******/
CREATE DATABASE [HamacoV2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HamacoV2', FILENAME = N'R:\HAMACO_V2\HamacoV2.mdf' , SIZE = 8192KB , MAXSIZE = 1024000KB , FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'HamacoV2_log', FILENAME = N'R:\HAMACO_V2\HamacoV2_log.ldf' , SIZE = 73728KB , MAXSIZE = 1024000KB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [HamacoV2] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HamacoV2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HamacoV2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HamacoV2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HamacoV2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HamacoV2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HamacoV2] SET ARITHABORT OFF 
GO
ALTER DATABASE [HamacoV2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HamacoV2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HamacoV2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HamacoV2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HamacoV2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HamacoV2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HamacoV2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HamacoV2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HamacoV2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HamacoV2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HamacoV2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HamacoV2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HamacoV2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HamacoV2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HamacoV2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HamacoV2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HamacoV2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HamacoV2] SET RECOVERY FULL 
GO
ALTER DATABASE [HamacoV2] SET  MULTI_USER 
GO
ALTER DATABASE [HamacoV2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HamacoV2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HamacoV2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HamacoV2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [HamacoV2] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'HamacoV2', N'ON'
GO
ALTER DATABASE [HamacoV2] SET QUERY_STORE = OFF
GO
USE [HamacoV2]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [HamacoV2]
GO
/****** Object:  Table [dbo].[AbsentType]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AbsentType](
	[ClientID] [int] NOT NULL,
	[AbsentType] [char](3) NOT NULL,
	[AbsentName] [nvarchar](100) NULL,
 CONSTRAINT [PK_AbsentType] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[AbsentType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Accounts]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Accounts](
	[ClientID] [int] NOT NULL,
	[AccountCode] [char](10) NOT NULL,
	[AccountName] [nvarchar](100) NOT NULL,
	[LevelNo] [int] NOT NULL,
	[IsLock] [bit] NOT NULL,
 CONSTRAINT [PK_Accounts] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[AccountCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssetCategory]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetCategory](
	[ClientID] [int] NOT NULL,
	[CatID] [uniqueidentifier] NOT NULL,
	[CompanyCode] [char](4) NOT NULL,
	[CatName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AssetCategory] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[CatID] ASC,
	[CompanyCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Assets]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Assets](
	[ClientID] [int] NOT NULL,
	[CompanyCode] [char](4) NOT NULL,
	[AssetID] [uniqueidentifier] NOT NULL,
	[AssetCode] [char](10) NULL,
	[AssetName] [nvarchar](100) NOT NULL,
	[AssetDescription] [nvarchar](200) NULL,
	[UserName] [varchar](50) NULL,
	[AssetStatusID] [int] NULL,
	[AssetCatID] [uniqueidentifier] NULL,
	[AssetPrice] [int] NULL,
	[InputDate] [datetime] NULL,
 CONSTRAINT [PK_Assets] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[CompanyCode] ASC,
	[AssetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssetStatus]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetStatus](
	[ClientID] [int] NOT NULL,
	[AssetStatusID] [int] NOT NULL,
	[StatusName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_AssetStatus] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[AssetStatusID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BangChamCong]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangChamCong](
	[ClientID] [int] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[CompanyCode] [char](4) NOT NULL,
	[FiscalYear] [int] NOT NULL,
	[FiscalPeriod] [int] NOT NULL,
	[MSNV] [char](10) NULL,
	[FullName] [nvarchar](255) NULL,
	[DepartmentName] [nvarchar](255) NULL,
	[N1] [char](3) NULL,
	[N2] [char](3) NULL,
	[N3] [char](3) NULL,
	[N4] [char](3) NULL,
	[N5] [char](3) NULL,
	[N6] [char](3) NULL,
	[N7] [char](3) NULL,
	[N8] [char](3) NULL,
	[N9] [char](3) NULL,
	[N10] [char](3) NULL,
	[N11] [char](3) NULL,
	[N12] [char](3) NULL,
	[N13] [char](3) NULL,
	[N14] [char](3) NULL,
	[N15] [char](3) NULL,
	[N16] [char](3) NULL,
	[N17] [char](3) NULL,
	[N18] [char](3) NULL,
	[N19] [char](3) NULL,
	[N20] [char](3) NULL,
	[N21] [char](3) NULL,
	[N22] [char](3) NULL,
	[N23] [char](3) NULL,
	[N24] [char](3) NULL,
	[N25] [char](3) NULL,
	[N26] [char](3) NULL,
	[N27] [char](3) NULL,
	[N28] [char](3) NULL,
	[N29] [char](3) NULL,
	[N30] [char](3) NULL,
	[N31] [char](3) NULL,
	[TT] [int] NULL,
	[L] [int] NULL,
	[VR] [int] NULL,
	[P] [int] NULL,
	[CT] [int] NULL,
	[NB] [int] NULL,
	[PQ] [int] NULL,
	[TongCong] [int] NULL,
 CONSTRAINT [PK_BangChamCong] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[UserName] ASC,
	[CompanyCode] ASC,
	[FiscalYear] ASC,
	[FiscalPeriod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BangChamCong_Detail]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BangChamCong_Detail](
	[ClientID] [int] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[CompanyCode] [char](4) NOT NULL,
	[FiscalYear] [int] NOT NULL,
	[FiscalPeriod] [int] NOT NULL,
	[FiscalDay] [int] NOT NULL,
	[AbsentType] [char](3) NULL,
	[IsApproved] [char](1) NULL,
 CONSTRAINT [PK_BangChamCong_Detail] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[UserName] ASC,
	[CompanyCode] ASC,
	[FiscalYear] ASC,
	[FiscalPeriod] ASC,
	[FiscalDay] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BaoCaoTongHopCongNo]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaoCaoTongHopCongNo](
	[ClientID] [int] NOT NULL,
	[CompanyCode] [char](4) NOT NULL,
	[FiscalYear] [int] NOT NULL,
	[FiscalPeriod] [int] NOT NULL,
	[AccountCode] [char](14) NOT NULL,
	[CustomerCode] [char](14) NOT NULL,
	[CustomerName] [nvarchar](100) NULL,
	[NoDK] [int] NULL,
	[CoDK] [int] NULL,
	[PSNo] [int] NULL,
	[PSCo] [int] NULL,
	[NoCK] [int] NULL,
	[CoCK] [int] NULL,
 CONSTRAINT [PK_BaoCaoTongHopCongNo] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[CompanyCode] ASC,
	[FiscalYear] ASC,
	[FiscalPeriod] ASC,
	[AccountCode] ASC,
	[CustomerCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BaoCaoTonKho]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BaoCaoTonKho](
	[ClientID] [int] NOT NULL,
	[CompanyCode] [char](4) NOT NULL,
	[FiscalYear] [int] NOT NULL,
	[FiscalPeriod] [int] NOT NULL,
	[MaterialNo] [char](14) NOT NULL,
	[Plant] [char](4) NOT NULL,
	[StorageLoc] [char](4) NOT NULL,
	[QuantityDK] [int] NULL,
	[AmountDK] [int] NULL,
	[QuantityNTK] [int] NULL,
	[AmountNTK] [int] NULL,
	[QuantityXTK] [int] NULL,
	[AmountXTK] [int] NULL,
	[QuantityCK] [int] NULL,
	[AmountCK] [int] NULL,
 CONSTRAINT [PK_BaoCaoTonKho] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[CompanyCode] ASC,
	[FiscalYear] ASC,
	[FiscalPeriod] ASC,
	[MaterialNo] ASC,
	[Plant] ASC,
	[StorageLoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[ClientID] [int] NOT NULL,
	[CompanyCode] [char](4) NOT NULL,
	[CompanyName] [nvarchar](100) NOT NULL,
	[Address] [nvarchar](200) NULL,
	[TaxCode] [varchar](50) NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[CompanyCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CorFormCategory]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CorFormCategory](
	[ClientId] [int] NOT NULL,
	[CatCode] [char](10) NOT NULL,
	[FormType] [char](10) NOT NULL,
	[CatName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_CorFormCategory] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[CatCode] ASC,
	[FormType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CorForms]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CorForms](
	[ClientId] [int] NOT NULL,
	[FormCode] [char](14) NOT NULL,
	[CompanyCode] [char](4) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[FormType] [char](10) NOT NULL,
	[FormName] [nvarchar](100) NULL,
	[FormDescription] [nvarchar](200) NULL,
	[StartDate] [datetime] NULL,
	[IsApproved1] [int] NULL,
	[ApproveDate1] [datetime] NULL,
	[IsApproved2] [int] NULL,
	[ApproveDate2] [datetime] NULL,
	[UserName1] [varchar](50) NULL,
	[UserName2] [varchar](50) NULL,
	[FormCategory] [char](10) NULL,
 CONSTRAINT [PK_CorForms] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[FormCode] ASC,
	[CompanyCode] ASC,
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[ClientID] [int] NOT NULL,
	[CompanyCode] [char](4) NOT NULL,
	[CustomerCode] [char](14) NOT NULL,
	[ObjectType] [char](2) NOT NULL,
	[CustomerName] [nvarchar](100) NULL,
	[MST] [varchar](20) NULL,
	[Address] [nvarchar](100) NULL,
	[UserName] [varchar](50) NULL,
	[CreatedDate] [date] NULL,
	[IsLock] [char](1) NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[CompanyCode] ASC,
	[CustomerCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FIDocument_Log]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FIDocument_Log](
	[ClientID] [int] NOT NULL,
	[FIDocNo] [char](14) NOT NULL,
	[DocDate] [datetime] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[ErrorString] [varchar](200) NULL,
 CONSTRAINT [PK_FIDocument_Log_1] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[FIDocNo] ASC,
	[DocDate] ASC,
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FIDocumentHeader]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FIDocumentHeader](
	[ClientID] [int] NOT NULL,
	[CompanyCode] [char](4) NOT NULL,
	[FIDocNo] [char](14) NOT NULL,
	[FiscalYear] [int] NOT NULL,
	[FiscalPeriod] [int] NULL,
	[DocDate] [date] NULL,
	[PostingDate] [date] NULL,
	[HeaderText] [nvarchar](100) NULL,
	[UserName] [varchar](50) NOT NULL,
	[Status] [char](1) NULL,
	[DocType] [char](4) NULL,
	[MMDocNo] [char](14) NULL,
	[PrintDocNo] [char](10) NULL,
 CONSTRAINT [PK_DocumentHeader] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[CompanyCode] ASC,
	[FIDocNo] ASC,
	[FiscalYear] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FIDocumentItem]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FIDocumentItem](
	[ClientID] [int] NOT NULL,
	[FIDocNo] [char](14) NOT NULL,
	[CompanyCode] [char](4) NOT NULL,
	[LineItemNo] [int] NOT NULL,
	[AccountCode] [char](10) NOT NULL,
	[DebitCreditIndicator] [char](1) NULL,
	[Amount] [int] NULL,
	[BusinessArea] [char](10) NULL,
	[ItemText] [nvarchar](100) NULL,
	[UserName] [varchar](50) NULL,
	[CustomerCode] [char](14) NULL,
	[CustomerName] [nvarchar](100) NULL,
	[MST] [varchar](20) NULL,
	[Address] [nvarchar](100) NULL,
	[FiscalYear] [int] NULL,
	[FiscalPeriod] [int] NULL,
	[Status] [char](1) NULL,
 CONSTRAINT [PK_DocumentItem_1] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[FIDocNo] ASC,
	[CompanyCode] ASC,
	[LineItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FIDocumentNo]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FIDocumentNo](
	[ClientID] [int] NOT NULL,
	[CompanyCode] [char](4) NOT NULL,
	[FIDocNo] [char](14) NOT NULL,
	[FiscalYear] [int] NOT NULL,
	[FiscalPeriod] [int] NOT NULL,
	[DocType] [char](4) NOT NULL,
	[ControlNo] [int] NULL,
	[PrintDocNo] [char](20) NULL,
	[PrintingDate] [datetime] NULL,
	[UserName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_FIDocumentNo] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[CompanyCode] ASC,
	[FIDocNo] ASC,
	[FiscalYear] ASC,
	[FiscalPeriod] ASC,
	[DocType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FIDocumentType]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FIDocumentType](
	[ClientID] [int] NOT NULL,
	[DocType] [char](4) NOT NULL,
	[TypeName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_DocumentType] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[DocType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MaterialGroup]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaterialGroup](
	[ClientID] [int] NOT NULL,
	[MaterialGroup] [char](14) NOT NULL,
	[CompanyCode] [char](4) NOT NULL,
	[GroupName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_MaterialGroup] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[MaterialGroup] ASC,
	[CompanyCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materials]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materials](
	[ClientID] [int] NOT NULL,
	[CompanyCode] [char](4) NOT NULL,
	[MaterialNo] [char](14) NOT NULL,
	[MaterialGroup] [char](14) NULL,
	[MaterialName] [nvarchar](100) NULL,
	[Unit] [nvarchar](20) NULL,
	[UnitPrice] [int] NULL,
	[TonKho] [int] NULL,
	[IsLock] [char](1) NULL,
	[UserName] [varchar](50) NULL,
	[DocDate] [date] NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_Materials] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[CompanyCode] ASC,
	[MaterialNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MMDocumentHeader]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MMDocumentHeader](
	[ClientID] [int] NOT NULL,
	[CompanyCode] [char](4) NOT NULL,
	[MMDocNo] [char](14) NOT NULL,
	[FiscalYear] [int] NOT NULL,
	[FiscalPeriod] [int] NOT NULL,
	[DocDate] [date] NULL,
	[PostingDate] [date] NULL,
	[HeaderText] [nvarchar](100) NULL,
	[UserName] [varchar](50) NOT NULL,
	[Status] [char](1) NULL,
	[MMDocType] [char](4) NULL,
	[IsPaid] [char](1) NULL,
 CONSTRAINT [PK_MMDocumentHeader] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[CompanyCode] ASC,
	[MMDocNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MMDocumentInFI]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MMDocumentInFI](
	[ClientID] [int] NOT NULL,
	[MMDocNo] [char](14) NOT NULL,
	[CompanyCode] [char](4) NOT NULL,
	[FIDocNo] [char](14) NOT NULL,
 CONSTRAINT [PK_MMDocumentInFI] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[MMDocNo] ASC,
	[CompanyCode] ASC,
	[FIDocNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MMDocumentItem]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MMDocumentItem](
	[ClientID] [int] NOT NULL,
	[MMDocNo] [char](14) NOT NULL,
	[CompanyCode] [char](4) NOT NULL,
	[LineItemNo] [int] NOT NULL,
	[MaterialNo] [char](14) NOT NULL,
	[Plant] [char](4) NOT NULL,
	[StorageLoc] [char](4) NULL,
	[DebitCreditIndicator] [char](1) NULL,
	[Quantity] [int] NULL,
	[Amount] [int] NULL,
	[Unit] [nvarchar](20) NULL,
	[UnitPrice] [int] NULL,
	[BusinessArea] [char](10) NULL,
	[ItemText] [nvarchar](100) NULL,
	[UserName] [varchar](50) NULL,
	[CustomerCode] [char](14) NULL,
	[CustomerName] [nvarchar](100) NULL,
	[MST] [varchar](20) NULL,
	[Address] [nvarchar](100) NULL,
	[FiscalYear] [int] NULL,
	[FiscalPeriod] [int] NULL,
	[DocDate] [date] NULL,
	[Status] [char](1) NULL,
 CONSTRAINT [PK_MMDocumentItem] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[MMDocNo] ASC,
	[CompanyCode] ASC,
	[LineItemNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MMDocumentType]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MMDocumentType](
	[ClientID] [int] NOT NULL,
	[DocType] [char](4) NOT NULL,
	[TypeName] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_MMDocumentType] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[DocType] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Plants]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Plants](
	[ClientID] [int] NOT NULL,
	[CompanyCode] [char](4) NOT NULL,
	[Plant] [char](4) NOT NULL,
	[PlantName] [nvarchar](50) NULL,
	[Address] [nvarchar](100) NULL,
 CONSTRAINT [PK_Plants] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[CompanyCode] ASC,
	[Plant] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RolePermissionMapping]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RolePermissionMapping](
	[ClientId] [int] NOT NULL,
	[TransactionCode] [char](4) NOT NULL,
	[RoleCode] [varchar](20) NOT NULL,
 CONSTRAINT [PK_RolePermissionMapping] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[TransactionCode] ASC,
	[RoleCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[ClientId] [int] NOT NULL,
	[RoleCode] [varchar](20) NOT NULL,
	[RoleName] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](255) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[RoleCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StorageLocation]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StorageLocation](
	[ClientID] [int] NOT NULL,
	[CompanyCode] [char](4) NOT NULL,
	[Plant] [char](4) NOT NULL,
	[StorageLoc] [char](4) NOT NULL,
	[StorageName] [nvarchar](50) NULL,
 CONSTRAINT [PK_StorageLocation] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[CompanyCode] ASC,
	[Plant] ASC,
	[StorageLoc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TransactionFav]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TransactionFav](
	[ClientId] [int] NOT NULL,
	[TransactionCode] [char](4) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TransactionFav_1] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[TransactionCode] ASC,
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Transactions]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Transactions](
	[ClientId] [int] NOT NULL,
	[TransactionCode] [char](4) NOT NULL,
	[TransactionName] [nvarchar](100) NOT NULL,
	[FormName] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Transactions] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[TransactionCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDetail]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetail](
	[ClientID] [int] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[CompanyCode] [char](4) NOT NULL,
	[MSNV] [char](10) NULL,
	[FullName] [nvarchar](255) NULL,
	[BankAccount] [char](50) NULL,
	[BankName] [char](10) NULL,
	[DepartmentName] [nvarchar](255) NULL,
	[JobTitle] [nvarchar](255) NULL,
	[GioiTinh] [nvarchar](15) NULL,
	[NgayVaoLam] [date] NULL,
	[NgaySinh] [date] NULL,
	[NoiSinh] [nvarchar](100) NULL,
	[ThamNien] [int] NULL,
	[Tuoi] [int] NULL,
	[SoCMND] [varchar](50) NULL,
	[NgayCap] [date] NULL,
	[NoiCap] [nvarchar](255) NULL,
	[DanToc] [nvarchar](15) NULL,
	[TonGiao] [nvarchar](15) NULL,
	[DiaChi] [nvarchar](255) NULL,
	[TamTru] [nvarchar](255) NULL,
	[Mobile1] [nchar](20) NULL,
	[Mobile2] [nchar](20) NULL,
	[DocThan] [char](1) NULL,
	[LapGiaDinh] [char](1) NULL,
	[LyDi] [char](1) NULL,
	[TenVoChong] [nvarchar](255) NULL,
	[NamSinhVC] [int] NULL,
	[NgheNghiepVC] [nvarchar](255) NULL,
	[TenCon1] [nvarchar](255) NULL,
	[NamSinhCon1] [int] NULL,
	[NgheNghiepCon1] [nvarchar](255) NULL,
	[TenCon2] [nvarchar](255) NULL,
	[NamSinhCon2] [int] NULL,
	[NgheNghiepCon2] [nvarchar](255) NULL,
	[TenCon3] [nvarchar](255) NULL,
	[NamSinhCon3] [int] NULL,
	[NgheNghiepCon3] [nvarchar](255) NULL,
	[DangLamViec] [nvarchar](255) NULL,
	[LuongViTri] [int] NULL,
	[PhuCapTN] [int] NULL,
	[PhuCapComTrua] [int] NULL,
	[PhuCapXangXe] [int] NULL,
	[PhuCapDT] [int] NULL,
	[PhuCapVungMien] [int] NULL,
	[PhuCapDatDo] [int] NULL,
	[LuongDongBHXH] [int] NULL,
	[SoNgayPhepTon] [int] NULL,
 CONSTRAINT [PK_UserDetail2] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[UserName] ASC,
	[CompanyCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserJoinCompany]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserJoinCompany](
	[ClientId] [int] NOT NULL,
	[CompanyCode] [char](4) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_UserJoinCompany] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[CompanyCode] ASC,
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserJoinForm]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserJoinForm](
	[ClientID] [int] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[FormCode] [char](14) NOT NULL,
 CONSTRAINT [PK_UserJoinForm] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[UserName] ASC,
	[FormCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserJoinRole]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserJoinRole](
	[ClientId] [int] NOT NULL,
	[RoleCode] [varchar](20) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_UserJoinRole] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[RoleCode] ASC,
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ClientID] [int] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[CompanyCode] [char](4) NULL,
	[Password] [nvarchar](50) NULL,
	[FullName] [nvarchar](255) NULL,
	[JobTitle] [nvarchar](255) NULL,
	[Email] [varchar](100) NULL,
	[IsLock] [char](1) NULL,
	[UserName1] [varchar](50) NULL,
	[UserName2] [varchar](50) NULL,
	[Description] [ntext] NULL,
	[FormCode] [char](14) NULL,
 CONSTRAINT [PK_Users_1] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserSalary]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSalary](
	[ClientID] [int] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[CompanyCode] [char](4) NOT NULL,
	[FiscalYear] [int] NOT NULL,
	[FiscalPeriod] [int] NOT NULL,
	[Period] [int] NOT NULL,
	[MSNV] [char](15) NULL,
	[FullName] [nvarchar](255) NULL,
	[BankAccount] [char](50) NULL,
	[BankName] [char](10) NULL,
	[DepartmentName] [nvarchar](255) NULL,
	[JobTitle] [nvarchar](255) NULL,
	[NgayVaoLam] [date] NULL,
	[NgayCong] [int] NULL,
	[LuongViTri] [int] NULL,
	[ThuongKD] [int] NULL,
	[LamThemGio] [int] NULL,
	[PhuCapTN] [int] NULL,
	[PhuCapComTrua] [int] NULL,
	[PhuCapDT] [int] NULL,
	[PhuCapXangXe] [int] NULL,
	[PhuCapVungMien] [int] NULL,
	[PhuCapDatDo] [int] NULL,
	[TongThuNhap] [int] NULL,
	[LuongDongBHXH] [int] NULL,
	[KPCD] [int] NULL,
	[BHXH] [int] NULL,
	[ThueTNCN] [int] NULL,
	[TamUng] [int] NULL,
	[LuongKy1] [int] NULL,
	[GiamTruKhac] [int] NULL,
	[LuongThucLinh] [int] NULL,
 CONSTRAINT [PK_UserSalary] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[UserName] ASC,
	[CompanyCode] ASC,
	[FiscalYear] ASC,
	[FiscalPeriod] ASC,
	[Period] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserSalaryKPI]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSalaryKPI](
	[ClientID] [int] NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[CompanyCode] [char](4) NOT NULL,
	[FiscalYear] [int] NOT NULL,
	[FiscalPeriod] [int] NOT NULL,
	[MSNV] [char](10) NULL,
	[LuongKD] [int] NULL,
	[LuongNgoaiGio] [int] NULL,
 CONSTRAINT [PK_UserSalaryDetail] PRIMARY KEY CLUSTERED 
(
	[ClientID] ASC,
	[UserName] ASC,
	[CompanyCode] ASC,
	[FiscalYear] ASC,
	[FiscalPeriod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Versions]    Script Date: 8/17/2020 9:21:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Versions](
	[ClientId] [int] NOT NULL,
	[Version] [varchar](20) NOT NULL,
	[Description] [nvarchar](100) NULL,
 CONSTRAINT [PK_Versions] PRIMARY KEY CLUSTERED 
(
	[ClientId] ASC,
	[Version] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF_Accounts_Level]  DEFAULT ((3)) FOR [LevelNo]
GO
ALTER TABLE [dbo].[Accounts] ADD  CONSTRAINT [DF_Accounts_IsLock]  DEFAULT ((0)) FOR [IsLock]
GO
ALTER TABLE [dbo].[AssetCategory] ADD  CONSTRAINT [DF_AssetCategory_ClientID]  DEFAULT ((300)) FOR [ClientID]
GO
ALTER TABLE [dbo].[Assets] ADD  CONSTRAINT [DF_Assets_AssetStatusID]  DEFAULT ((0)) FOR [AssetStatusID]
GO
ALTER TABLE [dbo].[AssetStatus] ADD  CONSTRAINT [DF_AssetStatus_ClientID]  DEFAULT ((300)) FOR [ClientID]
GO
ALTER TABLE [dbo].[AssetStatus] ADD  CONSTRAINT [DF_AssetStatus_AssetStatusID]  DEFAULT ((0)) FOR [AssetStatusID]
GO
ALTER TABLE [dbo].[BaoCaoTonKho] ADD  CONSTRAINT [DF_BaoCaoTonKho_StorageLoc]  DEFAULT ('D') FOR [StorageLoc]
GO
ALTER TABLE [dbo].[CorFormCategory] ADD  CONSTRAINT [DF_CorFormCategory_ClientId]  DEFAULT ((300)) FOR [ClientId]
GO
ALTER TABLE [dbo].[CorFormCategory] ADD  CONSTRAINT [DF_CorFormCategory_FormType]  DEFAULT ('LABOR') FOR [FormType]
GO
ALTER TABLE [dbo].[CorForms] ADD  CONSTRAINT [DF_CorForms_FormType]  DEFAULT ((1)) FOR [FormType]
GO
ALTER TABLE [dbo].[CorForms] ADD  CONSTRAINT [DF_CorForms_IsApproved1]  DEFAULT ((0)) FOR [IsApproved1]
GO
ALTER TABLE [dbo].[CorForms] ADD  CONSTRAINT [DF_CorForms_IsApproved2]  DEFAULT ((0)) FOR [IsApproved2]
GO
ALTER TABLE [dbo].[FIDocumentHeader] ADD  CONSTRAINT [DF_DocumentHeader_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[FIDocumentItem] ADD  CONSTRAINT [DF_DocumentItem_DebitCreditIndicator]  DEFAULT ('D') FOR [DebitCreditIndicator]
GO
ALTER TABLE [dbo].[FIDocumentItem] ADD  CONSTRAINT [DF_FIDocumentItem_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[MaterialGroup] ADD  CONSTRAINT [DF_MaterialGroup_ClientID]  DEFAULT ((300)) FOR [ClientID]
GO
ALTER TABLE [dbo].[Materials] ADD  CONSTRAINT [DF_Materials_TonKho]  DEFAULT ((0)) FOR [TonKho]
GO
ALTER TABLE [dbo].[Materials] ADD  CONSTRAINT [DF_Materials_IsLock]  DEFAULT ((0)) FOR [IsLock]
GO
ALTER TABLE [dbo].[MMDocumentHeader] ADD  CONSTRAINT [DF_MMDocumentHeader_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[MMDocumentHeader] ADD  CONSTRAINT [DF_MMDocumentHeader_IsPaid]  DEFAULT ((0)) FOR [IsPaid]
GO
ALTER TABLE [dbo].[MMDocumentItem] ADD  CONSTRAINT [DF_MMDocumentItem_DebitCreditIndicator]  DEFAULT ('D') FOR [StorageLoc]
GO
ALTER TABLE [dbo].[MMDocumentItem] ADD  CONSTRAINT [DF_MMDocumentItem_DebitCreditIndicator_1]  DEFAULT ('D') FOR [DebitCreditIndicator]
GO
ALTER TABLE [dbo].[MMDocumentItem] ADD  CONSTRAINT [DF_MMDocumentItem_Status]  DEFAULT ((0)) FOR [Status]
GO
ALTER TABLE [dbo].[Plants] ADD  CONSTRAINT [DF_Table_1_StorageLoc]  DEFAULT ('D') FOR [PlantName]
GO
ALTER TABLE [dbo].[StorageLocation] ADD  CONSTRAINT [DF_StorageLocation_StorageLoc]  DEFAULT ('D') FOR [StorageLoc]
GO
ALTER TABLE [dbo].[StorageLocation] ADD  CONSTRAINT [DF_Table_1_PlantName]  DEFAULT ('D') FOR [StorageName]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsLock]  DEFAULT ((0)) FOR [IsLock]
GO
USE [master]
GO
ALTER DATABASE [HamacoV2] SET  READ_WRITE 
GO
