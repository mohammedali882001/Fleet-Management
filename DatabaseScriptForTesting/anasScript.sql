USE [master]
GO
/****** Object:  Database [Anas_FMS]    Script Date: 5/31/2024 1:42:19 AM ******/
CREATE DATABASE [Anas_FMS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Anas_FMS', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Anas_FMS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Anas_FMS_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Anas_FMS_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Anas_FMS] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Anas_FMS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Anas_FMS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Anas_FMS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Anas_FMS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Anas_FMS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Anas_FMS] SET ARITHABORT OFF 
GO
ALTER DATABASE [Anas_FMS] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Anas_FMS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Anas_FMS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Anas_FMS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Anas_FMS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Anas_FMS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Anas_FMS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Anas_FMS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Anas_FMS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Anas_FMS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Anas_FMS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Anas_FMS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Anas_FMS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Anas_FMS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Anas_FMS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Anas_FMS] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [Anas_FMS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Anas_FMS] SET RECOVERY FULL 
GO
ALTER DATABASE [Anas_FMS] SET  MULTI_USER 
GO
ALTER DATABASE [Anas_FMS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Anas_FMS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Anas_FMS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Anas_FMS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Anas_FMS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Anas_FMS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Anas_FMS', N'ON'
GO
ALTER DATABASE [Anas_FMS] SET QUERY_STORE = ON
GO
ALTER DATABASE [Anas_FMS] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Anas_FMS]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 5/31/2024 1:42:19 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Drivers]    Script Date: 5/31/2024 1:42:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Drivers](
	[DriverId] [bigint] IDENTITY(1,1) NOT NULL,
	[DriverName] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[PhoneNumber] [nvarchar](max) NULL,
 CONSTRAINT [PK_Drivers] PRIMARY KEY CLUSTERED 
(
	[DriverId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Geofences]    Script Date: 5/31/2024 1:42:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Geofences](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[GeofenceType] [nvarchar](max) NOT NULL,
	[AddedDate] [nvarchar](max) NOT NULL,
	[StrockColor] [nvarchar](max) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[StrockOpacity] [float] NOT NULL,
	[StrockWeight] [float] NOT NULL,
	[FillColor] [nvarchar](max) NOT NULL,
	[FillOpacity] [float] NOT NULL,
	[Discriminator] [nvarchar](21) NOT NULL,
	[Radius] [bigint] NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
	[GeofenceId] [bigint] NULL,
	[PolygonGeofence_Latitude] [float] NULL,
	[PolygonGeofence_Longitude] [float] NULL,
	[PolygonGeofence_GeofenceId] [bigint] NULL,
	[North] [float] NULL,
	[East] [float] NULL,
	[West] [float] NULL,
	[South] [float] NULL,
	[RectangleGeofence_GeofenceId] [bigint] NULL,
 CONSTRAINT [PK_Geofences] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RouteHistories]    Script Date: 5/31/2024 1:42:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RouteHistories](
	[RouteHistoryId] [bigint] IDENTITY(1,1) NOT NULL,
	[VehicleId] [bigint] NOT NULL,
	[VehicleDirection] [int] NOT NULL,
	[Status] [nvarchar](1) NOT NULL,
	[VehicleSpeed] [nvarchar](max) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
	[Epoch] [bigint] NOT NULL,
	[Latitude] [float] NOT NULL,
	[Longitude] [float] NOT NULL,
 CONSTRAINT [PK_RouteHistories] PRIMARY KEY CLUSTERED 
(
	[RouteHistoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Vehicles]    Script Date: 5/31/2024 1:42:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Vehicles](
	[VehicleId] [bigint] IDENTITY(1,1) NOT NULL,
	[VehicleNumber] [bigint] NOT NULL,
	[VehicleType] [nvarchar](max) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_Vehicles] PRIMARY KEY CLUSTERED 
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VehiclesInformations]    Script Date: 5/31/2024 1:42:20 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VehiclesInformations](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[VehicleId] [bigint] NULL,
	[DriverId] [bigint] NULL,
	[VehicleMake] [nvarchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[VehicleModel] [nvarchar](max) NOT NULL,
	[PurchaseDate] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_VehiclesInformations] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240528181557_init', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240530110601_addeddate', N'8.0.5')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240530231909_prushasedate', N'8.0.5')
GO
SET IDENTITY_INSERT [dbo].[Drivers] ON 

INSERT [dbo].[Drivers] ([DriverId], [DriverName], [IsDeleted], [PhoneNumber]) VALUES (1, N'Mohammed', 0, N'0567891011')
INSERT [dbo].[Drivers] ([DriverId], [DriverName], [IsDeleted], [PhoneNumber]) VALUES (2, N'Ahmed', 0, N'0562569841')
INSERT [dbo].[Drivers] ([DriverId], [DriverName], [IsDeleted], [PhoneNumber]) VALUES (3, N'Ali', 0, N'0562002255')
INSERT [dbo].[Drivers] ([DriverId], [DriverName], [IsDeleted], [PhoneNumber]) VALUES (4, N'Anas', 0, N'0562558877')
INSERT [dbo].[Drivers] ([DriverId], [DriverName], [IsDeleted], [PhoneNumber]) VALUES (5, N'Nasser', 0, N'0562584120')
SET IDENTITY_INSERT [dbo].[Drivers] OFF
GO
SET IDENTITY_INSERT [dbo].[Geofences] ON 

INSERT [dbo].[Geofences] ([Id], [GeofenceType], [AddedDate], [StrockColor], [IsDeleted], [StrockOpacity], [StrockWeight], [FillColor], [FillOpacity], [Discriminator], [Radius], [Latitude], [Longitude], [GeofenceId], [PolygonGeofence_Latitude], [PolygonGeofence_Longitude], [PolygonGeofence_GeofenceId], [North], [East], [West], [South], [RectangleGeofence_GeofenceId]) VALUES (1, N'circle', N'1717096215', N'#FF0000', 0, 0.8, 2, N'#FF0000', 0.4, N'CircleGeofence', 50, 37.7749, -122.4194, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Geofences] ([Id], [GeofenceType], [AddedDate], [StrockColor], [IsDeleted], [StrockOpacity], [StrockWeight], [FillColor], [FillOpacity], [Discriminator], [Radius], [Latitude], [Longitude], [GeofenceId], [PolygonGeofence_Latitude], [PolygonGeofence_Longitude], [PolygonGeofence_GeofenceId], [North], [East], [West], [South], [RectangleGeofence_GeofenceId]) VALUES (2, N'polygon', N'1708467330', N'#00FF00', 0, 0.6, 3, N'#00FF00', 0.3, N'CircleGeofence', 100, 34.0522, -118.2437, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Geofences] ([Id], [GeofenceType], [AddedDate], [StrockColor], [IsDeleted], [StrockOpacity], [StrockWeight], [FillColor], [FillOpacity], [Discriminator], [Radius], [Latitude], [Longitude], [GeofenceId], [PolygonGeofence_Latitude], [PolygonGeofence_Longitude], [PolygonGeofence_GeofenceId], [North], [East], [West], [South], [RectangleGeofence_GeofenceId]) VALUES (3, N'polygon', N'1713493845', N'#FFFF00', 0, 0.9, 4, N'#FFFF00', 0.2, N'CircleGeofence', 150, 51.5074, -0.1278, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Geofences] ([Id], [GeofenceType], [AddedDate], [StrockColor], [IsDeleted], [StrockOpacity], [StrockWeight], [FillColor], [FillOpacity], [Discriminator], [Radius], [Latitude], [Longitude], [GeofenceId], [PolygonGeofence_Latitude], [PolygonGeofence_Longitude], [PolygonGeofence_GeofenceId], [North], [East], [West], [South], [RectangleGeofence_GeofenceId]) VALUES (4, N'polygon', N'1713493845', N'#FFFF00', 0, 0.9, 4, N'#FFFF00', 0.2, N'CircleGeofence', 150, 51.5074, -0.1278, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Geofences] ([Id], [GeofenceType], [AddedDate], [StrockColor], [IsDeleted], [StrockOpacity], [StrockWeight], [FillColor], [FillOpacity], [Discriminator], [Radius], [Latitude], [Longitude], [GeofenceId], [PolygonGeofence_Latitude], [PolygonGeofence_Longitude], [PolygonGeofence_GeofenceId], [North], [East], [West], [South], [RectangleGeofence_GeofenceId]) VALUES (5, N'circle', N'1704132000', N'#FF5733', 0, 0.8, 2, N'#FF5733', 0.4, N'PolygonGeofence', NULL, NULL, NULL, NULL, 34.0522, -118.2437, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Geofences] ([Id], [GeofenceType], [AddedDate], [StrockColor], [IsDeleted], [StrockOpacity], [StrockWeight], [FillColor], [FillOpacity], [Discriminator], [Radius], [Latitude], [Longitude], [GeofenceId], [PolygonGeofence_Latitude], [PolygonGeofence_Longitude], [PolygonGeofence_GeofenceId], [North], [East], [West], [South], [RectangleGeofence_GeofenceId]) VALUES (6, N'polygon', N'1708467330', N'#33FF57', 0, 0.6, 3, N'#33FF57', 0.3, N'PolygonGeofence', NULL, NULL, NULL, NULL, 40.7128, -74.006, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Geofences] ([Id], [GeofenceType], [AddedDate], [StrockColor], [IsDeleted], [StrockOpacity], [StrockWeight], [FillColor], [FillOpacity], [Discriminator], [Radius], [Latitude], [Longitude], [GeofenceId], [PolygonGeofence_Latitude], [PolygonGeofence_Longitude], [PolygonGeofence_GeofenceId], [North], [East], [West], [South], [RectangleGeofence_GeofenceId]) VALUES (7, N'polygon', N'1713493845', N'#FF33A6', 0, 0.9, 4, N'#FF33A6', 0.2, N'PolygonGeofence', NULL, NULL, NULL, NULL, 35.6895, 139.6917, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Geofences] ([Id], [GeofenceType], [AddedDate], [StrockColor], [IsDeleted], [StrockOpacity], [StrockWeight], [FillColor], [FillOpacity], [Discriminator], [Radius], [Latitude], [Longitude], [GeofenceId], [PolygonGeofence_Latitude], [PolygonGeofence_Longitude], [PolygonGeofence_GeofenceId], [North], [East], [West], [South], [RectangleGeofence_GeofenceId]) VALUES (8, N'rectangle', N'1704132000', N'#FF5733', 0, 0.8, 2, N'#FF5733', 0.4, N'RectangleGeofence', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 40.7128, -74.006, -74.016, 40.7028, NULL)
INSERT [dbo].[Geofences] ([Id], [GeofenceType], [AddedDate], [StrockColor], [IsDeleted], [StrockOpacity], [StrockWeight], [FillColor], [FillOpacity], [Discriminator], [Radius], [Latitude], [Longitude], [GeofenceId], [PolygonGeofence_Latitude], [PolygonGeofence_Longitude], [PolygonGeofence_GeofenceId], [North], [East], [West], [South], [RectangleGeofence_GeofenceId]) VALUES (9, N'rectangle', N'1708467330', N'#33FF57', 0, 0.6, 3, N'#33FF57', 0.3, N'RectangleGeofence', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 34.0522, -118.2437, -118.2537, 34.0422, NULL)
INSERT [dbo].[Geofences] ([Id], [GeofenceType], [AddedDate], [StrockColor], [IsDeleted], [StrockOpacity], [StrockWeight], [FillColor], [FillOpacity], [Discriminator], [Radius], [Latitude], [Longitude], [GeofenceId], [PolygonGeofence_Latitude], [PolygonGeofence_Longitude], [PolygonGeofence_GeofenceId], [North], [East], [West], [South], [RectangleGeofence_GeofenceId]) VALUES (10, N'rectangle', N'1713493845', N'#FF33A6', 0, 0.9, 4, N'#FF33A6', 0.2, N'RectangleGeofence', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 35.6895, 139.6917, 139.6817, 35.6795, NULL)
SET IDENTITY_INSERT [dbo].[Geofences] OFF
GO
SET IDENTITY_INSERT [dbo].[RouteHistories] ON 

INSERT [dbo].[RouteHistories] ([RouteHistoryId], [VehicleId], [VehicleDirection], [Status], [VehicleSpeed], [IsDeleted], [Epoch], [Latitude], [Longitude]) VALUES (1, 1, 45, N'A', N'60 mph', 0, 1622505600, 37.7749, -122.4194)
INSERT [dbo].[RouteHistories] ([RouteHistoryId], [VehicleId], [VehicleDirection], [Status], [VehicleSpeed], [IsDeleted], [Epoch], [Latitude], [Longitude]) VALUES (2, 2, 90, N'B', N'40 mph', 0, 1622592000, 34.0522, -118.2437)
INSERT [dbo].[RouteHistories] ([RouteHistoryId], [VehicleId], [VehicleDirection], [Status], [VehicleSpeed], [IsDeleted], [Epoch], [Latitude], [Longitude]) VALUES (3, 3, 180, N'C', N'45 mph', 0, 1622678400, 40.7128, -74.006)
INSERT [dbo].[RouteHistories] ([RouteHistoryId], [VehicleId], [VehicleDirection], [Status], [VehicleSpeed], [IsDeleted], [Epoch], [Latitude], [Longitude]) VALUES (4, 4, 270, N'd', N'12 km/h', 0, 1622764800, 51.5074, -0.1278)
INSERT [dbo].[RouteHistories] ([RouteHistoryId], [VehicleId], [VehicleDirection], [Status], [VehicleSpeed], [IsDeleted], [Epoch], [Latitude], [Longitude]) VALUES (5, 5, 360, N'e', N'30 km/h', 0, 1622851200, 35.6895, 139.6917)
SET IDENTITY_INSERT [dbo].[RouteHistories] OFF
GO
SET IDENTITY_INSERT [dbo].[Vehicles] ON 

INSERT [dbo].[Vehicles] ([VehicleId], [VehicleNumber], [VehicleType], [IsDeleted]) VALUES (1, 1234, N'sedan', 0)
INSERT [dbo].[Vehicles] ([VehicleId], [VehicleNumber], [VehicleType], [IsDeleted]) VALUES (2, 5678, N'SUV', 0)
INSERT [dbo].[Vehicles] ([VehicleId], [VehicleNumber], [VehicleType], [IsDeleted]) VALUES (3, 9101, N'truck', 0)
INSERT [dbo].[Vehicles] ([VehicleId], [VehicleNumber], [VehicleType], [IsDeleted]) VALUES (4, 1121, N'motorcycle', 0)
INSERT [dbo].[Vehicles] ([VehicleId], [VehicleNumber], [VehicleType], [IsDeleted]) VALUES (5, 3141, N'van', 0)
SET IDENTITY_INSERT [dbo].[Vehicles] OFF
GO
SET IDENTITY_INSERT [dbo].[VehiclesInformations] ON 

INSERT [dbo].[VehiclesInformations] ([Id], [VehicleId], [DriverId], [VehicleMake], [IsDeleted], [VehicleModel], [PurchaseDate]) VALUES (1, 1, 1, N'Toyota', 0, N'Camry', N'1704132000')
INSERT [dbo].[VehiclesInformations] ([Id], [VehicleId], [DriverId], [VehicleMake], [IsDeleted], [VehicleModel], [PurchaseDate]) VALUES (2, 2, 2, N'Honda', 0, N'Civic', N'1708467330')
INSERT [dbo].[VehiclesInformations] ([Id], [VehicleId], [DriverId], [VehicleMake], [IsDeleted], [VehicleModel], [PurchaseDate]) VALUES (3, 3, 3, N'Ford', 0, N'F-150', N'1708467330')
INSERT [dbo].[VehiclesInformations] ([Id], [VehicleId], [DriverId], [VehicleMake], [IsDeleted], [VehicleModel], [PurchaseDate]) VALUES (4, 4, 4, N'Tesla', 0, N'Model S', N'1713493845')
INSERT [dbo].[VehiclesInformations] ([Id], [VehicleId], [DriverId], [VehicleMake], [IsDeleted], [VehicleModel], [PurchaseDate]) VALUES (5, 5, 5, N'Chevrolet', 0, N'Malibu', N'1708467330')
SET IDENTITY_INSERT [dbo].[VehiclesInformations] OFF
GO
/****** Object:  Index [IX_Geofences_GeofenceId]    Script Date: 5/31/2024 1:42:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_Geofences_GeofenceId] ON [dbo].[Geofences]
(
	[GeofenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Geofences_PolygonGeofence_GeofenceId]    Script Date: 5/31/2024 1:42:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_Geofences_PolygonGeofence_GeofenceId] ON [dbo].[Geofences]
(
	[PolygonGeofence_GeofenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Geofences_RectangleGeofence_GeofenceId]    Script Date: 5/31/2024 1:42:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_Geofences_RectangleGeofence_GeofenceId] ON [dbo].[Geofences]
(
	[RectangleGeofence_GeofenceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RouteHistories_VehicleId]    Script Date: 5/31/2024 1:42:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_RouteHistories_VehicleId] ON [dbo].[RouteHistories]
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_VehiclesInformations_DriverId]    Script Date: 5/31/2024 1:42:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_VehiclesInformations_DriverId] ON [dbo].[VehiclesInformations]
(
	[DriverId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_VehiclesInformations_VehicleId]    Script Date: 5/31/2024 1:42:20 AM ******/
CREATE NONCLUSTERED INDEX [IX_VehiclesInformations_VehicleId] ON [dbo].[VehiclesInformations]
(
	[VehicleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Geofences]  WITH CHECK ADD  CONSTRAINT [FK_Geofences_Geofences_GeofenceId] FOREIGN KEY([GeofenceId])
REFERENCES [dbo].[Geofences] ([Id])
GO
ALTER TABLE [dbo].[Geofences] CHECK CONSTRAINT [FK_Geofences_Geofences_GeofenceId]
GO
ALTER TABLE [dbo].[Geofences]  WITH CHECK ADD  CONSTRAINT [FK_Geofences_Geofences_PolygonGeofence_GeofenceId] FOREIGN KEY([PolygonGeofence_GeofenceId])
REFERENCES [dbo].[Geofences] ([Id])
GO
ALTER TABLE [dbo].[Geofences] CHECK CONSTRAINT [FK_Geofences_Geofences_PolygonGeofence_GeofenceId]
GO
ALTER TABLE [dbo].[Geofences]  WITH CHECK ADD  CONSTRAINT [FK_Geofences_Geofences_RectangleGeofence_GeofenceId] FOREIGN KEY([RectangleGeofence_GeofenceId])
REFERENCES [dbo].[Geofences] ([Id])
GO
ALTER TABLE [dbo].[Geofences] CHECK CONSTRAINT [FK_Geofences_Geofences_RectangleGeofence_GeofenceId]
GO
ALTER TABLE [dbo].[RouteHistories]  WITH CHECK ADD  CONSTRAINT [FK_RouteHistories_Vehicles_VehicleId] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([VehicleId])
GO
ALTER TABLE [dbo].[RouteHistories] CHECK CONSTRAINT [FK_RouteHistories_Vehicles_VehicleId]
GO
ALTER TABLE [dbo].[VehiclesInformations]  WITH CHECK ADD  CONSTRAINT [FK_VehiclesInformations_Drivers_DriverId] FOREIGN KEY([DriverId])
REFERENCES [dbo].[Drivers] ([DriverId])
GO
ALTER TABLE [dbo].[VehiclesInformations] CHECK CONSTRAINT [FK_VehiclesInformations_Drivers_DriverId]
GO
ALTER TABLE [dbo].[VehiclesInformations]  WITH CHECK ADD  CONSTRAINT [FK_VehiclesInformations_Vehicles_VehicleId] FOREIGN KEY([VehicleId])
REFERENCES [dbo].[Vehicles] ([VehicleId])
GO
ALTER TABLE [dbo].[VehiclesInformations] CHECK CONSTRAINT [FK_VehiclesInformations_Vehicles_VehicleId]
GO
USE [master]
GO
ALTER DATABASE [Anas_FMS] SET  READ_WRITE 
GO
