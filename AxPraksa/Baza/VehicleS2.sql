USE [master]
GO
/****** Object:  Database [VehicleSetup]    Script Date: 04-Dec-18 10:07:09 ******/
CREATE DATABASE [VehicleSetup] ON  PRIMARY 
( NAME = N'VehicleSetup', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\DATA\VehicleSetup.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'VehicleSetup_log', FILENAME = N'C:\Program Files (x86)\Microsoft SQL Server\MSSQL10_50.SQLEXPRESS\MSSQL\Data\VehicleSetup_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [VehicleSetup] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [VehicleSetup].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [VehicleSetup] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [VehicleSetup] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [VehicleSetup] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [VehicleSetup] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [VehicleSetup] SET ARITHABORT OFF 
GO
ALTER DATABASE [VehicleSetup] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [VehicleSetup] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [VehicleSetup] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [VehicleSetup] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [VehicleSetup] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [VehicleSetup] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [VehicleSetup] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [VehicleSetup] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [VehicleSetup] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [VehicleSetup] SET  DISABLE_BROKER 
GO
ALTER DATABASE [VehicleSetup] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [VehicleSetup] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [VehicleSetup] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [VehicleSetup] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [VehicleSetup] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [VehicleSetup] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [VehicleSetup] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [VehicleSetup] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [VehicleSetup] SET  MULTI_USER 
GO
ALTER DATABASE [VehicleSetup] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [VehicleSetup] SET DB_CHAINING OFF 
GO
USE [VehicleSetup]
GO
/****** Object:  Table [dbo].[AdditionalFields]    Script Date: 04-Dec-18 10:07:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AdditionalFields](
	[ID] [int] NOT NULL,
	[FleetNo] [nvarchar](8) NOT NULL,
	[AdditionalFieldName] [nvarchar](50) NULL,
	[AdditionalFieldValue] [nvarchar](50) NULL,
 CONSTRAINT [PK_AdditionalFields_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssetSubType]    Script Date: 04-Dec-18 10:07:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetSubType](
	[ID] [int] NOT NULL,
	[SubType] [nvarchar](15) NULL,
 CONSTRAINT [PK_AssetSubType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AssetType]    Script Date: 04-Dec-18 10:07:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetType](
	[ID] [int] NOT NULL,
	[Type] [nvarchar](20) NULL,
 CONSTRAINT [PK_AssetType_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Attachments]    Script Date: 04-Dec-18 10:07:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Attachments](
	[ID] [int] NOT NULL,
	[FleetNo] [nvarchar](8) NULL,
	[Name] [nvarchar](50) NULL,
	[Extension] [nvarchar](5) NULL,
	[Size] [nvarchar](10) NULL,
	[Path] [nvarchar](200) NULL,
	[Image] [image] NULL,
 CONSTRAINT [PK_Attachments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Capacity]    Script Date: 04-Dec-18 10:07:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Capacity](
	[ID] [int] NOT NULL,
	[FleetNo] [nvarchar](8) NOT NULL,
	[Pallets] [int] NULL,
	[Spaces] [int] NULL,
	[CubicSpace] [decimal](9, 2) NULL,
	[InternalHeight] [decimal](7, 2) NULL,
	[InternalWidht] [decimal](7, 2) NULL,
	[InternalLenght] [decimal](7, 2) NULL,
	[Tare] [decimal](10, 3) NULL,
	[GVM] [decimal](10, 3) NULL,
	[GCM] [decimal](10, 3) NULL,
	[IsMainCapacity] [bit] NULL,
 CONSTRAINT [PK_Capacity] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Complience]    Script Date: 04-Dec-18 10:07:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Complience](
	[ID] [int] NOT NULL,
	[FleetNo] [nvarchar](8) NOT NULL,
	[ComplienceType] [int] NULL,
	[Type] [int] NULL,
	[LicenceClass] [nvarchar](30) NULL,
	[LicenseNo] [nvarchar](12) NOT NULL,
	[DateObtained] [date] NOT NULL,
	[ValidFromDate] [date] NULL,
	[ExpiryDate] [date] NULL,
	[AlertOperation] [nvarchar](100) NULL,
 CONSTRAINT [PK_License] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComplienceSubType]    Script Date: 04-Dec-18 10:07:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComplienceSubType](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](10) NULL,
 CONSTRAINT [PK_ComplienceSubType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ComplienceType]    Script Date: 04-Dec-18 10:07:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ComplienceType](
	[ID] [int] NOT NULL,
	[Class] [nvarchar](3) NULL,
 CONSTRAINT [PK_LiscenceClass] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FleetAsset]    Script Date: 04-Dec-18 10:07:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FleetAsset](
	[FleetNo] [nvarchar](8) NOT NULL,
	[RegistrationNo] [nvarchar](10) NULL,
	[Depot] [nvarchar](20) NULL,
	[Year] [nvarchar](4) NULL,
	[Description] [nvarchar](100) NULL,
	[FleetAssetMakeID] [int] NULL,
	[FleetAssetModelID] [int] NULL,
	[TypeID] [int] NULL,
	[SubTypeID] [int] NULL,
	[AxelWeight1] [decimal](10, 3) NULL,
	[AxelWeight2] [decimal](10, 3) NULL,
	[AxelWeight3] [decimal](10, 3) NULL,
	[FuelTypeID] [int] NULL,
	[Image] [image] NULL,
 CONSTRAINT [PK_Details] PRIMARY KEY CLUSTERED 
(
	[FleetNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FleetAssetMake]    Script Date: 04-Dec-18 10:07:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FleetAssetMake](
	[ID] [int] NOT NULL,
	[Manufacturer] [nvarchar](50) NULL,
 CONSTRAINT [PK_Specification] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FleetAssetModel]    Script Date: 04-Dec-18 10:07:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FleetAssetModel](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](20) NULL,
 CONSTRAINT [PK_FleetAssetModel] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FuelType]    Script Date: 04-Dec-18 10:07:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FuelType](
	[ID] [int] NOT NULL,
	[Fuel] [nvarchar](20) NULL,
 CONSTRAINT [PK_FuelType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[AdditionalFields]  WITH CHECK ADD  CONSTRAINT [FK_AdditionalFields_Details] FOREIGN KEY([FleetNo])
REFERENCES [dbo].[FleetAsset] ([FleetNo])
GO
ALTER TABLE [dbo].[AdditionalFields] CHECK CONSTRAINT [FK_AdditionalFields_Details]
GO
ALTER TABLE [dbo].[Attachments]  WITH CHECK ADD  CONSTRAINT [FK_Attachments_Details] FOREIGN KEY([FleetNo])
REFERENCES [dbo].[FleetAsset] ([FleetNo])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Attachments] CHECK CONSTRAINT [FK_Attachments_Details]
GO
ALTER TABLE [dbo].[Capacity]  WITH CHECK ADD  CONSTRAINT [FK_Capacity_Details] FOREIGN KEY([FleetNo])
REFERENCES [dbo].[FleetAsset] ([FleetNo])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Capacity] CHECK CONSTRAINT [FK_Capacity_Details]
GO
ALTER TABLE [dbo].[Complience]  WITH CHECK ADD  CONSTRAINT [FK_Complience_ComplienceSubType] FOREIGN KEY([Type])
REFERENCES [dbo].[ComplienceSubType] ([ID])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Complience] CHECK CONSTRAINT [FK_Complience_ComplienceSubType]
GO
ALTER TABLE [dbo].[Complience]  WITH CHECK ADD  CONSTRAINT [FK_Complience_ComplienceType] FOREIGN KEY([ComplienceType])
REFERENCES [dbo].[ComplienceType] ([ID])
ON UPDATE CASCADE
ON DELETE SET NULL
GO
ALTER TABLE [dbo].[Complience] CHECK CONSTRAINT [FK_Complience_ComplienceType]
GO
ALTER TABLE [dbo].[Complience]  WITH CHECK ADD  CONSTRAINT [FK_Complience_Details] FOREIGN KEY([FleetNo])
REFERENCES [dbo].[FleetAsset] ([FleetNo])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Complience] CHECK CONSTRAINT [FK_Complience_Details]
GO
ALTER TABLE [dbo].[FleetAsset]  WITH CHECK ADD  CONSTRAINT [FK_Details_AssetSubType] FOREIGN KEY([SubTypeID])
REFERENCES [dbo].[AssetSubType] ([ID])
GO
ALTER TABLE [dbo].[FleetAsset] CHECK CONSTRAINT [FK_Details_AssetSubType]
GO
ALTER TABLE [dbo].[FleetAsset]  WITH CHECK ADD  CONSTRAINT [FK_Details_AssetType] FOREIGN KEY([TypeID])
REFERENCES [dbo].[AssetType] ([ID])
GO
ALTER TABLE [dbo].[FleetAsset] CHECK CONSTRAINT [FK_Details_AssetType]
GO
ALTER TABLE [dbo].[FleetAsset]  WITH CHECK ADD  CONSTRAINT [FK_Details_FleetAssetMake] FOREIGN KEY([FleetAssetMakeID])
REFERENCES [dbo].[FleetAssetMake] ([ID])
GO
ALTER TABLE [dbo].[FleetAsset] CHECK CONSTRAINT [FK_Details_FleetAssetMake]
GO
ALTER TABLE [dbo].[FleetAsset]  WITH CHECK ADD  CONSTRAINT [FK_Details_FleetAssetModel] FOREIGN KEY([FleetAssetModelID])
REFERENCES [dbo].[FleetAssetModel] ([ID])
GO
ALTER TABLE [dbo].[FleetAsset] CHECK CONSTRAINT [FK_Details_FleetAssetModel]
GO
ALTER TABLE [dbo].[FleetAsset]  WITH CHECK ADD  CONSTRAINT [FK_Details_FuelType] FOREIGN KEY([FuelTypeID])
REFERENCES [dbo].[FuelType] ([ID])
GO
ALTER TABLE [dbo].[FleetAsset] CHECK CONSTRAINT [FK_Details_FuelType]
GO
USE [master]
GO
ALTER DATABASE [VehicleSetup] SET  READ_WRITE 
GO
