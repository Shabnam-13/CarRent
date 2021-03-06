USE [master]
GO
/****** Object:  Database [CarRent]    Script Date: 5/27/2020 11:01:08 AM ******/
CREATE DATABASE [CarRent]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'CarRent', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CarRent.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'CarRent_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\CarRent_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CarRent] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CarRent].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CarRent] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CarRent] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CarRent] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CarRent] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CarRent] SET ARITHABORT OFF 
GO
ALTER DATABASE [CarRent] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CarRent] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CarRent] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CarRent] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CarRent] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CarRent] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CarRent] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CarRent] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CarRent] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CarRent] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CarRent] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CarRent] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CarRent] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CarRent] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CarRent] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CarRent] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CarRent] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CarRent] SET RECOVERY FULL 
GO
ALTER DATABASE [CarRent] SET  MULTI_USER 
GO
ALTER DATABASE [CarRent] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CarRent] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CarRent] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CarRent] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CarRent] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'CarRent', N'ON'
GO
ALTER DATABASE [CarRent] SET QUERY_STORE = OFF
GO
USE [CarRent]
GO
/****** Object:  Table [dbo].[carColors]    Script Date: 5/27/2020 11:01:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[carColors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NULL,
 CONSTRAINT [PK_Colors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[carMarks]    Script Date: 5/27/2020 11:01:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[carMarks](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NULL,
 CONSTRAINT [PK_carMarks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[carModels]    Script Date: 5/27/2020 11:01:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[carModels](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NULL,
	[MarkId] [int] NULL,
 CONSTRAINT [PK_carModels] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cars]    Script Date: 5/27/2020 11:01:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cars](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MarkId] [int] NULL,
	[ModelId] [int] NULL,
	[TypeId] [int] NULL,
	[Year] [int] NULL,
	[SeatCapacity] [int] NULL,
	[Rate] [money] NULL,
	[Plate] [nvarchar](10) NULL,
	[AddedDate] [datetime] NULL,
	[IsAviable] [bit] NULL,
	[ColorId] [int] NULL,
	[Note] [nvarchar](100) NULL,
 CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[carTypes]    Script Date: 5/27/2020 11:01:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[carTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NULL,
 CONSTRAINT [PK_carTypes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Customers]    Script Date: 5/27/2020 11:01:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NULL,
	[LastName] [nvarchar](20) NULL,
	[Phone] [nvarchar](10) NULL,
	[Identification] [nvarchar](20) NULL,
	[Email] [nvarchar](30) NULL,
	[Address] [nvarchar](50) NULL,
	[AddedDate] [datetime] NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Employees]    Script Date: 5/27/2020 11:01:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](20) NULL,
	[LastName] [nvarchar](20) NULL,
	[UserName] [nvarchar](20) NULL,
	[Password] [nvarchar](30) NULL,
	[Age] [int] NULL,
	[Phone] [nvarchar](10) NULL,
	[Position] [nvarchar](20) NULL,
	[Email] [nvarchar](30) NULL,
	[Address] [nvarchar](50) NULL,
	[AddedDate] [datetime] NULL,
 CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 5/27/2020 11:01:08 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CarId] [int] NULL,
	[CustomerId] [int] NULL,
	[OutDate] [datetime] NULL,
	[ReturnedDate] [datetime] NULL,
	[TotalPrice] [money] NULL,
	[ReserveDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[carColors] ON 

INSERT [dbo].[carColors] ([Id], [Name]) VALUES (1, N'balck')
INSERT [dbo].[carColors] ([Id], [Name]) VALUES (2, N'silver')
INSERT [dbo].[carColors] ([Id], [Name]) VALUES (3, N'blue')
INSERT [dbo].[carColors] ([Id], [Name]) VALUES (4, N'red')
INSERT [dbo].[carColors] ([Id], [Name]) VALUES (5, N'brown')
INSERT [dbo].[carColors] ([Id], [Name]) VALUES (6, N'Black')
INSERT [dbo].[carColors] ([Id], [Name]) VALUES (7, N'White')
SET IDENTITY_INSERT [dbo].[carColors] OFF
SET IDENTITY_INSERT [dbo].[carMarks] ON 

INSERT [dbo].[carMarks] ([Id], [Name]) VALUES (1, N'Audi')
INSERT [dbo].[carMarks] ([Id], [Name]) VALUES (2, N'Mercedes-Benz')
INSERT [dbo].[carMarks] ([Id], [Name]) VALUES (3, N'Mitsubishi')
INSERT [dbo].[carMarks] ([Id], [Name]) VALUES (4, N'Volkswagen')
INSERT [dbo].[carMarks] ([Id], [Name]) VALUES (5, N'Kia')
INSERT [dbo].[carMarks] ([Id], [Name]) VALUES (6, N'Ford')
INSERT [dbo].[carMarks] ([Id], [Name]) VALUES (7, N'Fiat')
INSERT [dbo].[carMarks] ([Id], [Name]) VALUES (8, N'BMW')
INSERT [dbo].[carMarks] ([Id], [Name]) VALUES (9, N'Bentley')
SET IDENTITY_INSERT [dbo].[carMarks] OFF
SET IDENTITY_INSERT [dbo].[carModels] ON 

INSERT [dbo].[carModels] ([Id], [Name], [MarkId]) VALUES (17, N'A3', 1)
INSERT [dbo].[carModels] ([Id], [Name], [MarkId]) VALUES (19, N'A7', 1)
INSERT [dbo].[carModels] ([Id], [Name], [MarkId]) VALUES (20, N'R8', 1)
INSERT [dbo].[carModels] ([Id], [Name], [MarkId]) VALUES (21, N'Q7', 1)
INSERT [dbo].[carModels] ([Id], [Name], [MarkId]) VALUES (22, N'Continental GT', 9)
INSERT [dbo].[carModels] ([Id], [Name], [MarkId]) VALUES (23, N'M4', 8)
INSERT [dbo].[carModels] ([Id], [Name], [MarkId]) VALUES (24, N'X6', 8)
INSERT [dbo].[carModels] ([Id], [Name], [MarkId]) VALUES (25, N'Active Hybrid7', 8)
INSERT [dbo].[carModels] ([Id], [Name], [MarkId]) VALUES (26, N'Doblo', 7)
INSERT [dbo].[carModels] ([Id], [Name], [MarkId]) VALUES (27, N'F-350', 6)
INSERT [dbo].[carModels] ([Id], [Name], [MarkId]) VALUES (28, N'Focus', 6)
INSERT [dbo].[carModels] ([Id], [Name], [MarkId]) VALUES (29, N'2.0', 4)
INSERT [dbo].[carModels] ([Id], [Name], [MarkId]) VALUES (1016, N'Soul', 5)
INSERT [dbo].[carModels] ([Id], [Name], [MarkId]) VALUES (1017, N'ASX', 3)
INSERT [dbo].[carModels] ([Id], [Name], [MarkId]) VALUES (1018, N'A5', 1)
INSERT [dbo].[carModels] ([Id], [Name], [MarkId]) VALUES (1019, N'S-Class Coupe', 2)
INSERT [dbo].[carModels] ([Id], [Name], [MarkId]) VALUES (1020, N'ActiveHybrid 3', 8)
SET IDENTITY_INSERT [dbo].[carModels] OFF
SET IDENTITY_INSERT [dbo].[Cars] ON 

INSERT [dbo].[Cars] ([Id], [MarkId], [ModelId], [TypeId], [Year], [SeatCapacity], [Rate], [Plate], [AddedDate], [IsAviable], [ColorId], [Note]) VALUES (11, 6, 28, 1, 2015, 4, 30.0000, N'99 DD 334', CAST(N'2020-02-02T00:00:00.000' AS DateTime), 0, 2, NULL)
INSERT [dbo].[Cars] ([Id], [MarkId], [ModelId], [TypeId], [Year], [SeatCapacity], [Rate], [Plate], [AddedDate], [IsAviable], [ColorId], [Note]) VALUES (15, 6, 17, 1, 2014, 3, 25.0000, N'10 DC 225', CAST(N'2020-03-03T00:00:00.000' AS DateTime), 0, 1, NULL)
INSERT [dbo].[Cars] ([Id], [MarkId], [ModelId], [TypeId], [Year], [SeatCapacity], [Rate], [Plate], [AddedDate], [IsAviable], [ColorId], [Note]) VALUES (16, 4, 29, 3, 2010, 6, 20.0000, N'90 VV 566', CAST(N'2020-05-14T16:49:38.117' AS DateTime), 0, 4, N'')
INSERT [dbo].[Cars] ([Id], [MarkId], [ModelId], [TypeId], [Year], [SeatCapacity], [Rate], [Plate], [AddedDate], [IsAviable], [ColorId], [Note]) VALUES (1016, 5, 1016, 6, 2014, 4, 15.0000, N'10 SS 222', CAST(N'2020-05-16T02:15:17.597' AS DateTime), 1, 3, N'')
INSERT [dbo].[Cars] ([Id], [MarkId], [ModelId], [TypeId], [Year], [SeatCapacity], [Rate], [Plate], [AddedDate], [IsAviable], [ColorId], [Note]) VALUES (1017, 3, 1017, 2, 2013, 4, 15.0000, N'10 QQ 366', CAST(N'2020-05-16T02:16:54.127' AS DateTime), 1, 5, N'')
INSERT [dbo].[Cars] ([Id], [MarkId], [ModelId], [TypeId], [Year], [SeatCapacity], [Rate], [Plate], [AddedDate], [IsAviable], [ColorId], [Note]) VALUES (1018, 1, 21, 1, 2015, 4, 20.0000, N'99 NN 522', CAST(N'2020-05-16T18:25:59.137' AS DateTime), 0, 2, N'')
INSERT [dbo].[Cars] ([Id], [MarkId], [ModelId], [TypeId], [Year], [SeatCapacity], [Rate], [Plate], [AddedDate], [IsAviable], [ColorId], [Note]) VALUES (1019, 1, 1018, 6, 2016, 2, 20.0000, N'90 MN 666', CAST(N'2020-05-16T18:26:58.690' AS DateTime), 0, 6, N'')
INSERT [dbo].[Cars] ([Id], [MarkId], [ModelId], [TypeId], [Year], [SeatCapacity], [Rate], [Plate], [AddedDate], [IsAviable], [ColorId], [Note]) VALUES (1020, 2, 1019, 6, 2015, 4, 20.0000, N'10 MM 910', CAST(N'2020-05-17T16:42:29.107' AS DateTime), 1, 7, N'')
INSERT [dbo].[Cars] ([Id], [MarkId], [ModelId], [TypeId], [Year], [SeatCapacity], [Rate], [Plate], [AddedDate], [IsAviable], [ColorId], [Note]) VALUES (1021, 8, 1020, 1, 2014, 4, 15.0000, N'99 MN 333', CAST(N'2020-05-17T16:45:25.897' AS DateTime), 1, 7, N'')
SET IDENTITY_INSERT [dbo].[Cars] OFF
SET IDENTITY_INSERT [dbo].[carTypes] ON 

INSERT [dbo].[carTypes] ([Id], [Name]) VALUES (1, N'Sedan')
INSERT [dbo].[carTypes] ([Id], [Name]) VALUES (2, N'Suv')
INSERT [dbo].[carTypes] ([Id], [Name]) VALUES (3, N'Campervan')
INSERT [dbo].[carTypes] ([Id], [Name]) VALUES (5, N'Cabriolet')
INSERT [dbo].[carTypes] ([Id], [Name]) VALUES (6, N'Coupe')
INSERT [dbo].[carTypes] ([Id], [Name]) VALUES (9, N'Truck')
SET IDENTITY_INSERT [dbo].[carTypes] OFF
SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [Phone], [Identification], [Email], [Address], [AddedDate]) VALUES (1, N'Elxan', N'Zeynalov', N'776421545', N'15648955', N'elxan.zeynal@gmail.com', N'', CAST(N'2019-01-12T00:00:00.000' AS DateTime))
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [Phone], [Identification], [Email], [Address], [AddedDate]) VALUES (2, N'Asim', N'Niyazov', N'502462588', N'25648771', N'asim.niyaz@gmail.com', NULL, CAST(N'2020-04-01T00:00:00.000' AS DateTime))
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [Phone], [Identification], [Email], [Address], [AddedDate]) VALUES (3, N'Lale', N'Agayeva', N'505656223', N'45897623', N'lale.aga@gmail.com', NULL, CAST(N'2020-05-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [Phone], [Identification], [Email], [Address], [AddedDate]) VALUES (1012, N'Alim', N'Mirzeyev', N'0556234555', N'45687912', N'', N'', CAST(N'2020-05-16T02:18:14.057' AS DateTime))
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [Phone], [Identification], [Email], [Address], [AddedDate]) VALUES (1020, N'Sahil', N'Ehmedov', N'0704568910', N'00236546', N'', N'', CAST(N'2020-05-16T17:16:25.413' AS DateTime))
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [Phone], [Identification], [Email], [Address], [AddedDate]) VALUES (1021, N'Murad', N'Quliyev', N'0512562022', N'56230145', N'', N'', CAST(N'2020-05-16T17:19:44.613' AS DateTime))
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [Phone], [Identification], [Email], [Address], [AddedDate]) VALUES (1022, N'Aqil', N'Celilov', N'0554612389', N'09192654', N'', N'', CAST(N'2020-05-16T17:50:06.603' AS DateTime))
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [Phone], [Identification], [Email], [Address], [AddedDate]) VALUES (1024, N'Kamil', N'Elizade', N'0554268974', N'05632145', N'', N'', CAST(N'2020-05-16T18:21:40.677' AS DateTime))
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [Phone], [Identification], [Email], [Address], [AddedDate]) VALUES (1025, N'Aytac', N'Abbasova', N'0554621350', N'56002341', N'', N'', CAST(N'2020-05-17T15:43:33.323' AS DateTime))
INSERT [dbo].[Customers] ([Id], [FirstName], [LastName], [Phone], [Identification], [Email], [Address], [AddedDate]) VALUES (1026, N'Sevil', N'Celebiyeva', N'0554612389', N'30012478', N'', N'', CAST(N'2020-05-17T16:06:36.057' AS DateTime))
SET IDENTITY_INSERT [dbo].[Customers] OFF
SET IDENTITY_INSERT [dbo].[Employees] ON 

INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [UserName], [Password], [Age], [Phone], [Position], [Email], [Address], [AddedDate]) VALUES (6, N'Nicat', N'Qurbanov', N'qnicat', N'1234', 25, N'0554689751', N'IT manager', N'', N'', CAST(N'2020-05-14T14:05:37.313' AS DateTime))
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [UserName], [Password], [Age], [Phone], [Position], [Email], [Address], [AddedDate]) VALUES (1006, N'Turkan', N'Melikova', N'mturkan', N'123', 23, N'0705648792', N'Reception', NULL, NULL, CAST(N'2020-05-05T00:00:00.000' AS DateTime))
INSERT [dbo].[Employees] ([Id], [FirstName], [LastName], [UserName], [Password], [Age], [Phone], [Position], [Email], [Address], [AddedDate]) VALUES (1007, N'Aygun', N'Melikova', N'maygun', N'1234', 20, N'0504062610', N'Reception', N'', N'', CAST(N'2020-05-17T17:08:20.517' AS DateTime))
SET IDENTITY_INSERT [dbo].[Employees] OFF
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [CarId], [CustomerId], [OutDate], [ReturnedDate], [TotalPrice], [ReserveDate], [IsActive]) VALUES (1, 16, 1, CAST(N'2020-05-15T00:00:00.000' AS DateTime), CAST(N'2020-05-30T00:00:00.000' AS DateTime), 248.0000, CAST(N'2020-05-15T19:31:41.817' AS DateTime), 0)
INSERT [dbo].[Orders] ([Id], [CarId], [CustomerId], [OutDate], [ReturnedDate], [TotalPrice], [ReserveDate], [IsActive]) VALUES (2, 1017, 1012, CAST(N'2020-05-18T00:00:00.000' AS DateTime), CAST(N'2020-05-25T00:00:00.000' AS DateTime), 105.0000, CAST(N'2020-05-16T02:18:58.087' AS DateTime), 0)
INSERT [dbo].[Orders] ([Id], [CarId], [CustomerId], [OutDate], [ReturnedDate], [TotalPrice], [ReserveDate], [IsActive]) VALUES (4, 1016, 2, CAST(N'2020-05-17T00:00:00.000' AS DateTime), CAST(N'2020-05-24T00:00:00.000' AS DateTime), 105.0000, CAST(N'2020-05-16T12:38:22.410' AS DateTime), 0)
INSERT [dbo].[Orders] ([Id], [CarId], [CustomerId], [OutDate], [ReturnedDate], [TotalPrice], [ReserveDate], [IsActive]) VALUES (8, 11, 3, CAST(N'2020-05-16T00:00:00.000' AS DateTime), CAST(N'2020-05-17T00:00:00.000' AS DateTime), 24.0000, CAST(N'2020-05-16T14:03:01.873' AS DateTime), 0)
INSERT [dbo].[Orders] ([Id], [CarId], [CustomerId], [OutDate], [ReturnedDate], [TotalPrice], [ReserveDate], [IsActive]) VALUES (10, 1016, 1020, CAST(N'2020-05-11T00:00:00.000' AS DateTime), CAST(N'2020-05-14T00:00:00.000' AS DateTime), 54.0000, CAST(N'2020-05-16T17:18:11.877' AS DateTime), 0)
INSERT [dbo].[Orders] ([Id], [CarId], [CustomerId], [OutDate], [ReturnedDate], [TotalPrice], [ReserveDate], [IsActive]) VALUES (12, 15, 1021, CAST(N'2020-05-16T00:00:00.000' AS DateTime), CAST(N'2020-05-18T00:00:00.000' AS DateTime), 40.0000, CAST(N'2020-05-16T17:23:50.563' AS DateTime), 0)
INSERT [dbo].[Orders] ([Id], [CarId], [CustomerId], [OutDate], [ReturnedDate], [TotalPrice], [ReserveDate], [IsActive]) VALUES (17, 16, 1025, CAST(N'2020-05-17T16:05:10.397' AS DateTime), CAST(N'2020-05-21T16:05:10.000' AS DateTime), 80.0000, CAST(N'2020-05-17T16:05:20.583' AS DateTime), 1)
INSERT [dbo].[Orders] ([Id], [CarId], [CustomerId], [OutDate], [ReturnedDate], [TotalPrice], [ReserveDate], [IsActive]) VALUES (21, 1018, 1026, CAST(N'2020-05-11T16:08:59.000' AS DateTime), CAST(N'2020-05-15T16:08:59.000' AS DateTime), 84.0000, CAST(N'2020-05-17T16:09:08.780' AS DateTime), 1)
INSERT [dbo].[Orders] ([Id], [CarId], [CustomerId], [OutDate], [ReturnedDate], [TotalPrice], [ReserveDate], [IsActive]) VALUES (22, 1019, 1024, CAST(N'2020-05-17T18:22:16.000' AS DateTime), CAST(N'2020-05-20T18:22:16.000' AS DateTime), 60.0000, CAST(N'2020-05-17T18:22:32.390' AS DateTime), 1)
INSERT [dbo].[Orders] ([Id], [CarId], [CustomerId], [OutDate], [ReturnedDate], [TotalPrice], [ReserveDate], [IsActive]) VALUES (23, 11, 1022, CAST(N'2020-05-18T18:26:34.000' AS DateTime), CAST(N'2020-05-22T18:26:34.000' AS DateTime), 120.0000, CAST(N'2020-05-17T18:26:42.783' AS DateTime), 1)
INSERT [dbo].[Orders] ([Id], [CarId], [CustomerId], [OutDate], [ReturnedDate], [TotalPrice], [ReserveDate], [IsActive]) VALUES (24, 15, 2, CAST(N'2020-05-18T18:27:39.000' AS DateTime), CAST(N'2020-05-20T18:27:39.000' AS DateTime), 50.0000, CAST(N'2020-05-17T18:27:51.997' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Orders] OFF
ALTER TABLE [dbo].[Cars] ADD  CONSTRAINT [DF_Cars_IsAviable]  DEFAULT ((1)) FOR [IsAviable]
GO
ALTER TABLE [dbo].[Orders] ADD  CONSTRAINT [DF_Orders_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[carModels]  WITH CHECK ADD  CONSTRAINT [FK_carModels_carMarks] FOREIGN KEY([MarkId])
REFERENCES [dbo].[carMarks] ([Id])
GO
ALTER TABLE [dbo].[carModels] CHECK CONSTRAINT [FK_carModels_carMarks]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_carMarks] FOREIGN KEY([MarkId])
REFERENCES [dbo].[carMarks] ([Id])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_carMarks]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_carModels] FOREIGN KEY([ModelId])
REFERENCES [dbo].[carModels] ([Id])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_carModels]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_carTypes] FOREIGN KEY([TypeId])
REFERENCES [dbo].[carTypes] ([Id])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_carTypes]
GO
ALTER TABLE [dbo].[Cars]  WITH CHECK ADD  CONSTRAINT [FK_Cars_Colors] FOREIGN KEY([ColorId])
REFERENCES [dbo].[carColors] ([Id])
GO
ALTER TABLE [dbo].[Cars] CHECK CONSTRAINT [FK_Cars_Colors]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Cars] FOREIGN KEY([CarId])
REFERENCES [dbo].[Cars] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Cars]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Customers] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Customers]
GO
USE [master]
GO
ALTER DATABASE [CarRent] SET  READ_WRITE 
GO
