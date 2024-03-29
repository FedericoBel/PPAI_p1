USE [master]
GO
/****** Object:  Database [DSI]    Script Date: 8/11/2022 00:22:47 ******/
CREATE DATABASE [DSI]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DSI', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DSI.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'DSI_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\DSI_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DSI] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DSI].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DSI] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DSI] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DSI] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DSI] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DSI] SET ARITHABORT OFF 
GO
ALTER DATABASE [DSI] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DSI] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DSI] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DSI] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DSI] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DSI] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DSI] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DSI] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DSI] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DSI] SET  DISABLE_BROKER 
GO
ALTER DATABASE [DSI] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DSI] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DSI] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DSI] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DSI] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DSI] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DSI] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DSI] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DSI] SET  MULTI_USER 
GO
ALTER DATABASE [DSI] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DSI] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DSI] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DSI] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DSI] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DSI] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [DSI] SET QUERY_STORE = OFF
GO
USE [DSI]
GO
/****** Object:  Table [dbo].[AsignacionCientificoCI]    Script Date: 8/11/2022 00:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsignacionCientificoCI](
	[id] [int] NOT NULL,
	[fechaHoraDesde] [date] NULL,
	[fechaHoraHasta] [date] NULL,
	[idPersonalCientifico] [int] NOT NULL,
 CONSTRAINT [PK__Asignaci__3213E83FC0D13BB3] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AsignacionResponsableTecnicoRT]    Script Date: 8/11/2022 00:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsignacionResponsableTecnicoRT](
	[id] [int] NOT NULL,
	[FechaHoraDesde] [datetime] NULL,
	[FechaHoraHasta] [datetime] NULL,
	[IdRecursoTecnologico] [int] NOT NULL,
	[IdPersonalCientifico] [int] NOT NULL,
 CONSTRAINT [PK_AsignacionResponsableTecnicoRT] PRIMARY KEY CLUSTERED 
(
	[id] ASC,
	[IdRecursoTecnologico] ASC,
	[IdPersonalCientifico] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CambioEstadoRT]    Script Date: 8/11/2022 00:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CambioEstadoRT](
	[id] [int] NOT NULL,
	[fechaHoraDesde] [datetime] NULL,
	[fechaHoraHasta] [datetime] NULL,
	[idEstado] [int] NULL,
	[idRecursoTecnologico] [int] NULL,
 CONSTRAINT [PK_CambioEstadoRT] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CambioEstadoTurno]    Script Date: 8/11/2022 00:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CambioEstadoTurno](
	[id] [int] NOT NULL,
	[fechaHoraDesde] [date] NULL,
	[fechaHoraHasta] [date] NULL,
	[idTurno] [int] NOT NULL,
	[idEstado] [int] NOT NULL,
 CONSTRAINT [PK__CambioEs__3213E83FC0D1C21F] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 8/11/2022 00:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ambito] [varchar](50) NULL,
	[descripcion] [varchar](50) NULL,
	[esCancelable] [bit] NULL,
	[esReservable] [bit] NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mantenimiento]    Script Date: 8/11/2022 00:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mantenimiento](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fechaInicio] [datetime] NULL,
	[fechaFin] [datetime] NULL,
	[fechaInicioPrevista] [datetime] NULL,
	[motivoMantenimiento] [nchar](10) NULL,
	[idRecursoTecnologico] [int] NULL,
 CONSTRAINT [PK_Mantenimiento] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Marca]    Script Date: 8/11/2022 00:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Marca](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Marca] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Modelo]    Script Date: 8/11/2022 00:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modelo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[idMarca] [int] NULL,
 CONSTRAINT [PK_Modelo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalCientifico]    Script Date: 8/11/2022 00:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalCientifico](
	[legajo] [int] NOT NULL,
	[apellido] [varchar](50) NULL,
	[correoElectronicoInstitucional] [varchar](50) NULL,
	[correoElectronicoPersonal] [varchar](50) NULL,
	[nombre] [varchar](50) NULL,
	[numeroDocumento] [int] NULL,
	[telefonoCelular] [int] NULL,
 CONSTRAINT [PK__Personal__818C9F86D298D638] PRIMARY KEY CLUSTERED 
(
	[legajo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecursoTecnologico]    Script Date: 8/11/2022 00:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecursoTecnologico](
	[numero] [int] NOT NULL,
	[duracionMantenimientoPrev] [int] NULL,
	[fechaAlta] [datetime] NULL,
	[fraccionHorariosTurnos] [int] NULL,
	[idTipoRT] [int] NULL,
	[modelo] [int] NULL,
	[imagenes] [int] NULL,
	[periodicidadMantenimientoPrev] [int] NULL,
 CONSTRAINT [PK_RecursoTecnologico] PRIMARY KEY CLUSTERED 
(
	[numero] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sesion]    Script Date: 8/11/2022 00:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sesion](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fechaHoraInicio] [datetime] NULL,
	[fechaHoraFin] [datetime] NULL,
	[idUsuario] [int] NULL,
 CONSTRAINT [PK__Sesion__3213E83F9D97F677] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoRecursoTecnologico]    Script Date: 8/11/2022 00:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoRecursoTecnologico](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripción] [varchar](50) NULL,
	[nombre] [varchar](50) NULL,
 CONSTRAINT [PK_TipoRecursoTecnologico] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turno]    Script Date: 8/11/2022 00:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turno](
	[id] [int] NOT NULL,
	[diasemana] [varchar](50) NULL,
	[fechaGeneracion] [datetime] NULL,
	[fechaHoraFin] [datetime] NULL,
	[fechaHoraInicio] [datetime] NULL,
	[IdAsignacionCientifico] [int] NULL,
	[IdRecursoTecnologico] [int] NULL,
 CONSTRAINT [PK__Turno__3213E83F0D5B1514] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 8/11/2022 00:22:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[clave] [varchar](50) NULL,
	[habilitado] [bit] NULL,
	[usuario] [varchar](50) NULL,
	[idPersonalCientifico] [int] NULL,
 CONSTRAINT [PK__Usuario__3213E83F4DF2F908] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[AsignacionCientificoCI] ([id], [fechaHoraDesde], [fechaHoraHasta], [idPersonalCientifico]) VALUES (0, CAST(N'2022-06-05' AS Date), CAST(N'2022-06-20' AS Date), 123)
INSERT [dbo].[AsignacionCientificoCI] ([id], [fechaHoraDesde], [fechaHoraHasta], [idPersonalCientifico]) VALUES (1, CAST(N'2022-06-05' AS Date), CAST(N'2022-06-20' AS Date), 456)
INSERT [dbo].[AsignacionCientificoCI] ([id], [fechaHoraDesde], [fechaHoraHasta], [idPersonalCientifico]) VALUES (2, CAST(N'2022-06-05' AS Date), CAST(N'2022-06-20' AS Date), 789)
GO
INSERT [dbo].[AsignacionResponsableTecnicoRT] ([id], [FechaHoraDesde], [FechaHoraHasta], [IdRecursoTecnologico], [IdPersonalCientifico]) VALUES (1, CAST(N'2022-06-09T00:00:00.000' AS DateTime), NULL, 1, 123)
INSERT [dbo].[AsignacionResponsableTecnicoRT] ([id], [FechaHoraDesde], [FechaHoraHasta], [IdRecursoTecnologico], [IdPersonalCientifico]) VALUES (1, CAST(N'2022-06-09T00:00:00.000' AS DateTime), NULL, 2, 123)
INSERT [dbo].[AsignacionResponsableTecnicoRT] ([id], [FechaHoraDesde], [FechaHoraHasta], [IdRecursoTecnologico], [IdPersonalCientifico]) VALUES (2, CAST(N'2022-06-09T00:00:00.000' AS DateTime), CAST(N'2022-06-10T00:00:00.000' AS DateTime), 1, 123)
INSERT [dbo].[AsignacionResponsableTecnicoRT] ([id], [FechaHoraDesde], [FechaHoraHasta], [IdRecursoTecnologico], [IdPersonalCientifico]) VALUES (2, CAST(N'2022-06-09T00:00:00.000' AS DateTime), CAST(N'2022-06-10T00:00:00.000' AS DateTime), 2, 123)
GO
INSERT [dbo].[CambioEstadoRT] ([id], [fechaHoraDesde], [fechaHoraHasta], [idEstado], [idRecursoTecnologico]) VALUES (56, CAST(N'2022-06-06T00:00:00.000' AS DateTime), CAST(N'2022-06-07T00:00:00.000' AS DateTime), 5, 1)
INSERT [dbo].[CambioEstadoRT] ([id], [fechaHoraDesde], [fechaHoraHasta], [idEstado], [idRecursoTecnologico]) VALUES (57, CAST(N'2022-06-06T00:00:00.000' AS DateTime), NULL, 5, 1)
INSERT [dbo].[CambioEstadoRT] ([id], [fechaHoraDesde], [fechaHoraHasta], [idEstado], [idRecursoTecnologico]) VALUES (58, CAST(N'2022-06-06T00:00:00.000' AS DateTime), CAST(N'2022-06-07T00:00:00.000' AS DateTime), 5, 2)
INSERT [dbo].[CambioEstadoRT] ([id], [fechaHoraDesde], [fechaHoraHasta], [idEstado], [idRecursoTecnologico]) VALUES (59, CAST(N'2022-06-06T00:00:00.000' AS DateTime), NULL, 5, 2)
GO
INSERT [dbo].[CambioEstadoTurno] ([id], [fechaHoraDesde], [fechaHoraHasta], [idTurno], [idEstado]) VALUES (37, CAST(N'2022-06-07' AS Date), CAST(N'2022-06-09' AS Date), 1, 4)
INSERT [dbo].[CambioEstadoTurno] ([id], [fechaHoraDesde], [fechaHoraHasta], [idTurno], [idEstado]) VALUES (38, CAST(N'2022-06-10' AS Date), NULL, 1, 3)
INSERT [dbo].[CambioEstadoTurno] ([id], [fechaHoraDesde], [fechaHoraHasta], [idTurno], [idEstado]) VALUES (39, CAST(N'2022-06-07' AS Date), CAST(N'2022-06-09' AS Date), 2, 4)
INSERT [dbo].[CambioEstadoTurno] ([id], [fechaHoraDesde], [fechaHoraHasta], [idTurno], [idEstado]) VALUES (40, CAST(N'2022-06-10' AS Date), NULL, 2, 3)
INSERT [dbo].[CambioEstadoTurno] ([id], [fechaHoraDesde], [fechaHoraHasta], [idTurno], [idEstado]) VALUES (41, CAST(N'2022-06-07' AS Date), CAST(N'2022-06-09' AS Date), 3, 4)
INSERT [dbo].[CambioEstadoTurno] ([id], [fechaHoraDesde], [fechaHoraHasta], [idTurno], [idEstado]) VALUES (42, CAST(N'2022-06-10' AS Date), NULL, 3, 3)
INSERT [dbo].[CambioEstadoTurno] ([id], [fechaHoraDesde], [fechaHoraHasta], [idTurno], [idEstado]) VALUES (43, CAST(N'2022-06-07' AS Date), CAST(N'2022-06-09' AS Date), 4, 4)
INSERT [dbo].[CambioEstadoTurno] ([id], [fechaHoraDesde], [fechaHoraHasta], [idTurno], [idEstado]) VALUES (44, CAST(N'2022-06-10' AS Date), NULL, 4, 3)
INSERT [dbo].[CambioEstadoTurno] ([id], [fechaHoraDesde], [fechaHoraHasta], [idTurno], [idEstado]) VALUES (45, CAST(N'2022-06-07' AS Date), CAST(N'2022-06-09' AS Date), 5, 4)
INSERT [dbo].[CambioEstadoTurno] ([id], [fechaHoraDesde], [fechaHoraHasta], [idTurno], [idEstado]) VALUES (46, CAST(N'2022-06-10' AS Date), NULL, 5, 3)
INSERT [dbo].[CambioEstadoTurno] ([id], [fechaHoraDesde], [fechaHoraHasta], [idTurno], [idEstado]) VALUES (47, CAST(N'2022-06-07' AS Date), CAST(N'2022-06-09' AS Date), 6, 4)
INSERT [dbo].[CambioEstadoTurno] ([id], [fechaHoraDesde], [fechaHoraHasta], [idTurno], [idEstado]) VALUES (48, CAST(N'2022-06-10' AS Date), NULL, 6, 3)
GO
SET IDENTITY_INSERT [dbo].[Estado] ON 

INSERT [dbo].[Estado] ([id], [ambito], [descripcion], [esCancelable], [esReservable], [nombre]) VALUES (1, N'CambioEstadoRT', N'Un estado en mantenimiento', 1, 0, N'Con ingreso en mantenimiento correctivo')
INSERT [dbo].[Estado] ([id], [ambito], [descripcion], [esCancelable], [esReservable], [nombre]) VALUES (2, N'CambioEstadoTurno', N'Un estado cancelado por MC', 1, 0, N'Cancelado por manteniemto correctivo')
INSERT [dbo].[Estado] ([id], [ambito], [descripcion], [esCancelable], [esReservable], [nombre]) VALUES (3, N'CambioEstadoTurno', N'Un estado confirmado', 1, 1, N'Confirmado')
INSERT [dbo].[Estado] ([id], [ambito], [descripcion], [esCancelable], [esReservable], [nombre]) VALUES (4, N'CambioEstadoTurno', N'Un estado pendiente', 1, 1, N'Pendiente de confirmacion')
INSERT [dbo].[Estado] ([id], [ambito], [descripcion], [esCancelable], [esReservable], [nombre]) VALUES (5, N'CambioEstadoRT', N'Un estado disponible', 1, 1, N'Disponible')
SET IDENTITY_INSERT [dbo].[Estado] OFF
GO
SET IDENTITY_INSERT [dbo].[Mantenimiento] ON 

INSERT [dbo].[Mantenimiento] ([id], [fechaInicio], [fechaFin], [fechaInicioPrevista], [motivoMantenimiento], [idRecursoTecnologico]) VALUES (1, CAST(N'2022-11-07T22:28:11.333' AS DateTime), CAST(N'2022-06-30T00:00:00.000' AS DateTime), CAST(N'2022-11-07T22:28:23.400' AS DateTime), N'          ', 1)
INSERT [dbo].[Mantenimiento] ([id], [fechaInicio], [fechaFin], [fechaInicioPrevista], [motivoMantenimiento], [idRecursoTecnologico]) VALUES (2, CAST(N'2022-11-07T22:29:56.993' AS DateTime), CAST(N'2022-06-30T00:00:00.000' AS DateTime), CAST(N'2022-11-07T22:30:06.250' AS DateTime), N'          ', 1)
INSERT [dbo].[Mantenimiento] ([id], [fechaInicio], [fechaFin], [fechaInicioPrevista], [motivoMantenimiento], [idRecursoTecnologico]) VALUES (3, CAST(N'2022-11-07T22:33:43.687' AS DateTime), CAST(N'2022-06-30T00:00:00.000' AS DateTime), CAST(N'2022-11-07T22:33:47.127' AS DateTime), N'          ', 1)
INSERT [dbo].[Mantenimiento] ([id], [fechaInicio], [fechaFin], [fechaInicioPrevista], [motivoMantenimiento], [idRecursoTecnologico]) VALUES (4, CAST(N'2022-11-07T22:43:11.380' AS DateTime), CAST(N'2022-06-30T00:00:00.000' AS DateTime), CAST(N'2022-11-07T22:43:17.633' AS DateTime), N'          ', 1)
INSERT [dbo].[Mantenimiento] ([id], [fechaInicio], [fechaFin], [fechaInicioPrevista], [motivoMantenimiento], [idRecursoTecnologico]) VALUES (5, CAST(N'2022-11-07T22:45:18.433' AS DateTime), CAST(N'2022-06-30T00:00:00.000' AS DateTime), CAST(N'2022-11-07T22:45:21.500' AS DateTime), N'          ', 1)
INSERT [dbo].[Mantenimiento] ([id], [fechaInicio], [fechaFin], [fechaInicioPrevista], [motivoMantenimiento], [idRecursoTecnologico]) VALUES (6, CAST(N'2022-11-07T22:58:49.317' AS DateTime), CAST(N'2022-06-30T00:00:00.000' AS DateTime), CAST(N'2022-11-07T22:58:53.443' AS DateTime), N'          ', 2)
INSERT [dbo].[Mantenimiento] ([id], [fechaInicio], [fechaFin], [fechaInicioPrevista], [motivoMantenimiento], [idRecursoTecnologico]) VALUES (7, CAST(N'2022-11-07T23:32:33.957' AS DateTime), CAST(N'2022-06-30T00:00:00.000' AS DateTime), CAST(N'2022-11-07T23:32:39.717' AS DateTime), N'          ', 1)
INSERT [dbo].[Mantenimiento] ([id], [fechaInicio], [fechaFin], [fechaInicioPrevista], [motivoMantenimiento], [idRecursoTecnologico]) VALUES (8, CAST(N'2022-11-07T23:36:55.363' AS DateTime), CAST(N'2022-06-30T00:00:00.000' AS DateTime), CAST(N'2022-11-07T23:36:57.180' AS DateTime), N'asdfasfsdg', 1)
INSERT [dbo].[Mantenimiento] ([id], [fechaInicio], [fechaFin], [fechaInicioPrevista], [motivoMantenimiento], [idRecursoTecnologico]) VALUES (9, CAST(N'2022-11-07T23:39:17.347' AS DateTime), CAST(N'2022-06-30T00:00:00.000' AS DateTime), CAST(N'2022-11-07T23:39:20.180' AS DateTime), N'          ', 1)
INSERT [dbo].[Mantenimiento] ([id], [fechaInicio], [fechaFin], [fechaInicioPrevista], [motivoMantenimiento], [idRecursoTecnologico]) VALUES (10, CAST(N'2022-11-07T23:42:33.650' AS DateTime), CAST(N'2022-06-30T00:00:00.000' AS DateTime), CAST(N'2022-11-07T23:42:36.623' AS DateTime), N'xgdsgsdf  ', 1)
INSERT [dbo].[Mantenimiento] ([id], [fechaInicio], [fechaFin], [fechaInicioPrevista], [motivoMantenimiento], [idRecursoTecnologico]) VALUES (11, CAST(N'2022-11-07T23:53:23.803' AS DateTime), CAST(N'2022-06-30T00:00:00.000' AS DateTime), CAST(N'2022-11-07T23:53:27.690' AS DateTime), N'          ', 1)
INSERT [dbo].[Mantenimiento] ([id], [fechaInicio], [fechaFin], [fechaInicioPrevista], [motivoMantenimiento], [idRecursoTecnologico]) VALUES (12, CAST(N'2022-11-08T00:09:04.780' AS DateTime), CAST(N'2022-06-30T00:00:00.000' AS DateTime), CAST(N'2022-11-08T00:09:08.273' AS DateTime), N'no spam :)', 1)
SET IDENTITY_INSERT [dbo].[Mantenimiento] OFF
GO
SET IDENTITY_INSERT [dbo].[Marca] ON 

INSERT [dbo].[Marca] ([id], [Nombre]) VALUES (1, N'Sony      ')
INSERT [dbo].[Marca] ([id], [Nombre]) VALUES (2, N'MicroCien ')
INSERT [dbo].[Marca] ([id], [Nombre]) VALUES (3, N'Shidmazu ')
INSERT [dbo].[Marca] ([id], [Nombre]) VALUES (4, N'Nikon')
SET IDENTITY_INSERT [dbo].[Marca] OFF
GO
SET IDENTITY_INSERT [dbo].[Modelo] ON 

INSERT [dbo].[Modelo] ([id], [nombre], [idMarca]) VALUES (1, N'MICROx7   ', 1)
INSERT [dbo].[Modelo] ([id], [nombre], [idMarca]) VALUES (2, N'MICRO100  ', 1)
INSERT [dbo].[Modelo] ([id], [nombre], [idMarca]) VALUES (3, N'TXB622L', 3)
INSERT [dbo].[Modelo] ([id], [nombre], [idMarca]) VALUES (4, N'MM-400/800 ', 4)
SET IDENTITY_INSERT [dbo].[Modelo] OFF
GO
INSERT [dbo].[PersonalCientifico] ([legajo], [apellido], [correoElectronicoInstitucional], [correoElectronicoPersonal], [nombre], [numeroDocumento], [telefonoCelular]) VALUES (123, N'Polta', N'franciscobegliardo@gmail.com', N'Franciscopolta@gmail.com', N'Francisco', 44123, 123456)
INSERT [dbo].[PersonalCientifico] ([legajo], [apellido], [correoElectronicoInstitucional], [correoElectronicoPersonal], [nombre], [numeroDocumento], [telefonoCelular]) VALUES (456, N'Fernadez', N'federicobeluzzo02@gmail.com', N'Fedefernandez@gmail.com', N'Fede', 44159, 123456)
INSERT [dbo].[PersonalCientifico] ([legajo], [apellido], [correoElectronicoInstitucional], [correoElectronicoPersonal], [nombre], [numeroDocumento], [telefonoCelular]) VALUES (789, N'Salva', N'erikshalva@gmail.com', N'erikshalva@gmail.com', N'Erik', 85488, 123456)
GO
INSERT [dbo].[RecursoTecnologico] ([numero], [duracionMantenimientoPrev], [fechaAlta], [fraccionHorariosTurnos], [idTipoRT], [modelo], [imagenes], [periodicidadMantenimientoPrev]) VALUES (1, 1, CAST(N'2022-11-07T06:36:11.827' AS DateTime), 1, 1, 3, 1, 1)
INSERT [dbo].[RecursoTecnologico] ([numero], [duracionMantenimientoPrev], [fechaAlta], [fraccionHorariosTurnos], [idTipoRT], [modelo], [imagenes], [periodicidadMantenimientoPrev]) VALUES (2, 2, CAST(N'2022-11-07T06:36:11.847' AS DateTime), 2, 2, 4, 2, 2)
GO
SET IDENTITY_INSERT [dbo].[Sesion] ON 

INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (2, CAST(N'2022-11-07T08:53:44.797' AS DateTime), NULL, 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (3, CAST(N'2022-11-07T08:54:44.797' AS DateTime), NULL, 2)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (4, CAST(N'2022-11-07T09:02:20.833' AS DateTime), NULL, 2)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (5, CAST(N'2022-11-07T09:04:56.183' AS DateTime), NULL, 2)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (6, CAST(N'2022-11-07T09:06:01.163' AS DateTime), NULL, 2)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (7, CAST(N'2022-11-07T09:08:24.960' AS DateTime), NULL, 2)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (8, CAST(N'2022-11-07T09:09:19.797' AS DateTime), NULL, 2)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (9, CAST(N'2022-11-07T09:10:53.247' AS DateTime), NULL, 2)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (10, CAST(N'2022-11-07T09:16:57.687' AS DateTime), NULL, 2)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (11, CAST(N'2022-11-07T09:22:38.643' AS DateTime), NULL, 2)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (12, CAST(N'2022-11-07T09:24:06.717' AS DateTime), NULL, 2)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (13, CAST(N'2022-11-07T09:27:28.453' AS DateTime), NULL, 2)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (14, CAST(N'2022-11-07T09:29:27.143' AS DateTime), NULL, 2)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (15, CAST(N'2022-11-07T09:31:23.493' AS DateTime), NULL, 2)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (16, CAST(N'2022-11-07T09:33:07.073' AS DateTime), NULL, 2)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (17, CAST(N'2022-11-07T09:35:35.023' AS DateTime), NULL, 2)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (18, CAST(N'2022-11-07T09:38:05.807' AS DateTime), NULL, 2)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (19, CAST(N'2022-11-07T09:43:37.463' AS DateTime), NULL, 2)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (20, CAST(N'2022-11-07T09:46:20.590' AS DateTime), NULL, 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (21, CAST(N'2022-11-07T09:47:43.717' AS DateTime), NULL, 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (22, CAST(N'2022-11-07T09:52:57.977' AS DateTime), NULL, 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (23, CAST(N'2022-11-07T09:54:21.813' AS DateTime), NULL, 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (24, CAST(N'2022-11-07T09:55:09.437' AS DateTime), NULL, 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (25, CAST(N'2022-11-07T09:58:03.870' AS DateTime), NULL, 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (26, CAST(N'2022-11-07T10:01:34.377' AS DateTime), NULL, 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (27, CAST(N'2022-11-07T10:04:51.777' AS DateTime), NULL, 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (28, CAST(N'2022-11-07T10:07:00.447' AS DateTime), NULL, 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (29, CAST(N'2022-11-07T10:10:09.763' AS DateTime), NULL, 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (30, CAST(N'2022-11-07T10:12:35.717' AS DateTime), NULL, 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (31, CAST(N'2022-11-07T10:18:54.237' AS DateTime), CAST(N'2022-11-07T11:18:54.237' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (32, CAST(N'2022-11-07T10:20:20.380' AS DateTime), CAST(N'2022-11-07T11:20:20.380' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (33, CAST(N'2022-11-07T10:22:30.853' AS DateTime), CAST(N'2022-11-07T11:22:30.853' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (34, CAST(N'2022-11-07T10:25:34.850' AS DateTime), CAST(N'2022-11-07T11:25:34.850' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (35, CAST(N'2022-11-07T10:28:24.397' AS DateTime), CAST(N'2022-11-07T11:28:24.397' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (36, CAST(N'2022-11-07T10:31:36.943' AS DateTime), CAST(N'2022-11-07T11:31:36.943' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (37, CAST(N'2022-11-07T10:32:56.250' AS DateTime), CAST(N'2022-11-07T11:32:56.250' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (38, CAST(N'2022-11-07T11:20:16.403' AS DateTime), CAST(N'2022-11-07T12:20:16.403' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (39, CAST(N'2022-11-07T11:21:08.920' AS DateTime), CAST(N'2022-11-07T12:21:08.920' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (40, CAST(N'2022-11-07T11:28:39.337' AS DateTime), CAST(N'2022-11-07T12:28:39.337' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (41, CAST(N'2022-11-07T11:48:38.037' AS DateTime), CAST(N'2022-11-07T12:48:38.037' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (42, CAST(N'2022-11-07T11:52:26.647' AS DateTime), CAST(N'2022-11-07T12:52:26.647' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (43, CAST(N'2022-11-07T11:53:53.837' AS DateTime), CAST(N'2022-11-07T12:53:53.837' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (44, CAST(N'2022-11-07T11:56:30.277' AS DateTime), CAST(N'2022-11-07T12:56:30.277' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (45, CAST(N'2022-11-07T11:57:49.947' AS DateTime), CAST(N'2022-11-07T12:57:49.947' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (46, CAST(N'2022-11-07T11:59:17.797' AS DateTime), CAST(N'2022-11-07T12:59:17.797' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (47, CAST(N'2022-11-07T12:02:37.123' AS DateTime), CAST(N'2022-11-07T13:02:37.123' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (48, CAST(N'2022-11-07T12:05:57.787' AS DateTime), CAST(N'2022-11-07T13:05:57.787' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (49, CAST(N'2022-11-07T12:07:32.517' AS DateTime), CAST(N'2022-11-07T13:07:32.517' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (50, CAST(N'2022-11-07T12:09:24.377' AS DateTime), CAST(N'2022-11-07T13:09:24.377' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (51, CAST(N'2022-11-07T12:11:11.133' AS DateTime), CAST(N'2022-11-07T13:11:11.133' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (52, CAST(N'2022-11-07T12:13:05.243' AS DateTime), CAST(N'2022-11-07T13:13:05.243' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (53, CAST(N'2022-11-07T12:15:27.710' AS DateTime), CAST(N'2022-11-07T13:15:27.710' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (54, CAST(N'2022-11-07T12:18:32.480' AS DateTime), CAST(N'2022-11-07T13:18:32.480' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (55, CAST(N'2022-11-07T12:20:24.963' AS DateTime), CAST(N'2022-11-07T13:20:24.963' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (56, CAST(N'2022-11-07T12:27:31.843' AS DateTime), CAST(N'2022-11-07T13:27:31.843' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (57, CAST(N'2022-11-07T12:29:06.330' AS DateTime), CAST(N'2022-11-07T13:29:06.330' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (58, CAST(N'2022-11-07T12:34:15.023' AS DateTime), CAST(N'2022-11-07T13:34:15.023' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (59, CAST(N'2022-11-07T12:38:21.730' AS DateTime), CAST(N'2022-11-07T13:38:21.730' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (60, CAST(N'2022-11-07T12:41:59.350' AS DateTime), CAST(N'2022-11-07T13:41:59.350' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (61, CAST(N'2022-11-07T12:43:59.157' AS DateTime), CAST(N'2022-11-07T13:43:59.157' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (62, CAST(N'2022-11-07T12:49:43.333' AS DateTime), CAST(N'2022-11-07T13:49:43.333' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (63, CAST(N'2022-11-07T12:55:09.547' AS DateTime), CAST(N'2022-11-07T13:55:09.547' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (64, CAST(N'2022-11-07T12:59:04.470' AS DateTime), CAST(N'2022-11-07T13:59:04.470' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (65, CAST(N'2022-11-07T13:01:26.537' AS DateTime), CAST(N'2022-11-07T14:01:26.537' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (66, CAST(N'2022-11-07T13:09:38.553' AS DateTime), CAST(N'2022-11-07T14:09:38.557' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (67, CAST(N'2022-11-07T13:12:29.363' AS DateTime), CAST(N'2022-11-07T14:12:29.363' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (68, CAST(N'2022-11-07T13:13:28.590' AS DateTime), CAST(N'2022-11-07T14:13:28.590' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (69, CAST(N'2022-11-07T13:19:12.057' AS DateTime), CAST(N'2022-11-07T14:19:12.057' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (70, CAST(N'2022-11-07T13:26:08.853' AS DateTime), CAST(N'2022-11-07T14:26:08.853' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (71, CAST(N'2022-11-07T13:28:42.060' AS DateTime), CAST(N'2022-11-07T14:28:42.060' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (72, CAST(N'2022-11-07T13:31:23.743' AS DateTime), CAST(N'2022-11-07T14:31:23.743' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (73, CAST(N'2022-11-07T13:41:13.617' AS DateTime), CAST(N'2022-11-07T14:41:13.617' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (74, CAST(N'2022-11-07T14:00:49.970' AS DateTime), CAST(N'2022-11-07T15:00:49.970' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (75, CAST(N'2022-11-07T14:17:43.610' AS DateTime), CAST(N'2022-11-07T15:17:43.610' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (76, CAST(N'2022-11-07T14:19:44.717' AS DateTime), CAST(N'2022-11-07T15:19:44.717' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (77, CAST(N'2022-11-07T14:21:09.473' AS DateTime), CAST(N'2022-11-07T15:21:09.473' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (78, CAST(N'2022-11-07T14:23:13.063' AS DateTime), CAST(N'2022-11-07T15:23:13.063' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (79, CAST(N'2022-11-07T14:24:09.650' AS DateTime), CAST(N'2022-11-07T15:24:09.650' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (80, CAST(N'2022-11-07T14:25:27.877' AS DateTime), CAST(N'2022-11-07T15:25:27.877' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (81, CAST(N'2022-11-07T14:57:16.440' AS DateTime), CAST(N'2022-11-07T15:57:16.440' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (82, CAST(N'2022-11-07T14:58:58.203' AS DateTime), CAST(N'2022-11-07T15:58:58.203' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (83, CAST(N'2022-11-07T15:15:11.283' AS DateTime), CAST(N'2022-11-07T16:15:11.283' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (84, CAST(N'2022-11-07T15:17:17.230' AS DateTime), CAST(N'2022-11-07T16:17:17.230' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (85, CAST(N'2022-11-07T15:18:08.000' AS DateTime), CAST(N'2022-11-07T16:18:08.000' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (86, CAST(N'2022-11-07T15:46:19.490' AS DateTime), CAST(N'2022-11-07T16:46:19.490' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (87, CAST(N'2022-11-07T16:24:25.937' AS DateTime), CAST(N'2022-11-07T17:24:25.937' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (88, CAST(N'2022-11-07T16:26:30.760' AS DateTime), CAST(N'2022-11-07T17:26:30.760' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (89, CAST(N'2022-11-07T16:31:19.060' AS DateTime), CAST(N'2022-11-07T17:31:19.060' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (90, CAST(N'2022-11-07T18:12:22.117' AS DateTime), CAST(N'2022-11-07T19:12:22.117' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (91, CAST(N'2022-11-07T18:22:27.623' AS DateTime), CAST(N'2022-11-07T19:22:27.623' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (92, CAST(N'2022-11-07T18:25:34.720' AS DateTime), CAST(N'2022-11-07T19:25:34.720' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (93, CAST(N'2022-11-07T18:28:47.763' AS DateTime), CAST(N'2022-11-07T19:28:47.763' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (94, CAST(N'2022-11-07T18:33:47.037' AS DateTime), CAST(N'2022-11-07T19:33:47.037' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (95, CAST(N'2022-11-07T18:52:19.407' AS DateTime), CAST(N'2022-11-07T19:52:19.407' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (96, CAST(N'2022-11-07T18:55:08.990' AS DateTime), CAST(N'2022-11-07T19:55:08.990' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (97, CAST(N'2022-11-07T18:56:34.263' AS DateTime), CAST(N'2022-11-07T19:56:34.263' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (98, CAST(N'2022-11-07T19:18:55.807' AS DateTime), CAST(N'2022-11-07T20:18:55.807' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (99, CAST(N'2022-11-07T19:25:43.077' AS DateTime), CAST(N'2022-11-07T20:25:43.077' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (100, CAST(N'2022-11-07T22:25:13.713' AS DateTime), CAST(N'2022-11-07T23:25:13.713' AS DateTime), 1)
GO
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (101, CAST(N'2022-11-07T22:27:58.667' AS DateTime), CAST(N'2022-11-07T23:27:58.667' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (102, CAST(N'2022-11-07T22:29:46.673' AS DateTime), CAST(N'2022-11-07T23:29:46.673' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (103, CAST(N'2022-11-07T22:33:36.593' AS DateTime), CAST(N'2022-11-07T23:33:36.593' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (104, CAST(N'2022-11-07T22:42:59.940' AS DateTime), CAST(N'2022-11-07T23:42:59.940' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (105, CAST(N'2022-11-07T22:45:12.163' AS DateTime), CAST(N'2022-11-07T23:45:12.163' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (106, CAST(N'2022-11-07T22:57:51.000' AS DateTime), CAST(N'2022-11-07T23:57:51.000' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (107, CAST(N'2022-11-07T23:02:18.827' AS DateTime), CAST(N'2022-11-08T00:02:18.827' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (108, CAST(N'2022-11-07T23:04:35.117' AS DateTime), CAST(N'2022-11-08T00:04:35.117' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (109, CAST(N'2022-11-07T23:07:39.607' AS DateTime), CAST(N'2022-11-08T00:07:39.607' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (110, CAST(N'2022-11-07T23:09:23.153' AS DateTime), CAST(N'2022-11-08T00:09:23.153' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (111, CAST(N'2022-11-07T23:15:46.920' AS DateTime), CAST(N'2022-11-08T00:15:46.920' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (112, CAST(N'2022-11-07T23:20:50.783' AS DateTime), CAST(N'2022-11-08T00:20:50.783' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (113, CAST(N'2022-11-07T23:32:05.473' AS DateTime), CAST(N'2022-11-08T00:32:05.473' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (114, CAST(N'2022-11-07T23:36:45.903' AS DateTime), CAST(N'2022-11-08T00:36:45.903' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (115, CAST(N'2022-11-07T23:39:11.443' AS DateTime), CAST(N'2022-11-08T00:39:11.443' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (116, CAST(N'2022-11-07T23:42:22.403' AS DateTime), CAST(N'2022-11-08T00:42:22.403' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (117, CAST(N'2022-11-07T23:53:14.487' AS DateTime), CAST(N'2022-11-08T00:53:14.487' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (118, CAST(N'2022-11-07T23:58:07.927' AS DateTime), CAST(N'2022-11-08T00:58:07.927' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (119, CAST(N'2022-11-08T00:08:47.857' AS DateTime), CAST(N'2022-11-08T01:08:47.857' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (120, CAST(N'2022-11-08T00:12:27.590' AS DateTime), CAST(N'2022-11-08T01:12:27.590' AS DateTime), 1)
INSERT [dbo].[Sesion] ([id], [fechaHoraInicio], [fechaHoraFin], [idUsuario]) VALUES (121, CAST(N'2022-11-08T00:18:31.240' AS DateTime), CAST(N'2022-11-08T01:18:31.240' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[Sesion] OFF
GO
SET IDENTITY_INSERT [dbo].[TipoRecursoTecnologico] ON 

INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (1, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (2, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (3, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (4, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (5, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (6, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (7, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (8, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (9, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (10, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (11, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (12, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (13, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (14, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (15, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (16, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (17, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (18, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (19, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (20, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (21, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (22, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (23, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (24, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (25, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (26, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (27, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (28, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (29, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (30, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (31, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (32, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (33, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (34, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (35, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (36, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (37, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (38, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (39, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (40, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (41, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (42, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (43, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (44, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (45, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (46, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (47, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (48, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (49, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (50, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (51, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (52, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (53, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (54, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (55, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (56, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (57, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (58, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (59, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (60, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (61, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (62, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (63, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (64, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (65, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (66, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (67, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (68, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (69, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (70, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (71, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (72, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (73, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (74, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (75, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (76, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (77, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (78, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (79, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (80, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (81, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (82, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (83, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (84, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (85, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (86, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (87, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (88, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (89, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (90, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (91, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (92, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (93, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (94, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (95, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (96, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (97, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (98, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (99, N'Balanza de precisión', N'recurso1fede')
GO
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (100, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (101, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (102, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (103, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (104, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (105, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (106, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (107, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (108, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (109, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (110, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (111, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (112, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (113, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (114, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (115, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (116, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (117, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (118, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (119, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (120, N'Microscopio de medición', N'recurso2erik')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (121, N'Balanza de precisión', N'recurso1fede')
INSERT [dbo].[TipoRecursoTecnologico] ([id], [descripción], [nombre]) VALUES (122, N'Microscopio de medición', N'recurso2erik')
SET IDENTITY_INSERT [dbo].[TipoRecursoTecnologico] OFF
GO
INSERT [dbo].[Turno] ([id], [diasemana], [fechaGeneracion], [fechaHoraFin], [fechaHoraInicio], [IdAsignacionCientifico], [IdRecursoTecnologico]) VALUES (1, N'martes', CAST(N'2022-06-07T00:00:00.000' AS DateTime), CAST(N'2022-06-29T00:00:00.000' AS DateTime), CAST(N'2022-06-27T00:00:00.000' AS DateTime), 0, 1)
INSERT [dbo].[Turno] ([id], [diasemana], [fechaGeneracion], [fechaHoraFin], [fechaHoraInicio], [IdAsignacionCientifico], [IdRecursoTecnologico]) VALUES (2, N'miercoles', CAST(N'2022-06-07T00:00:00.000' AS DateTime), CAST(N'2022-06-18T00:00:00.000' AS DateTime), CAST(N'2022-06-15T00:00:00.000' AS DateTime), 0, 1)
INSERT [dbo].[Turno] ([id], [diasemana], [fechaGeneracion], [fechaHoraFin], [fechaHoraInicio], [IdAsignacionCientifico], [IdRecursoTecnologico]) VALUES (3, N'martes', CAST(N'2022-06-07T00:00:00.000' AS DateTime), CAST(N'2022-06-18T00:00:00.000' AS DateTime), CAST(N'2022-06-17T00:00:00.000' AS DateTime), 1, 2)
INSERT [dbo].[Turno] ([id], [diasemana], [fechaGeneracion], [fechaHoraFin], [fechaHoraInicio], [IdAsignacionCientifico], [IdRecursoTecnologico]) VALUES (4, N'miercoles', CAST(N'2022-06-07T00:00:00.000' AS DateTime), CAST(N'2022-06-25T00:00:00.000' AS DateTime), CAST(N'2022-06-19T00:00:00.000' AS DateTime), 1, 2)
INSERT [dbo].[Turno] ([id], [diasemana], [fechaGeneracion], [fechaHoraFin], [fechaHoraInicio], [IdAsignacionCientifico], [IdRecursoTecnologico]) VALUES (5, N'martes', CAST(N'2022-06-10T00:00:00.000' AS DateTime), CAST(N'2022-06-28T00:00:00.000' AS DateTime), CAST(N'2022-06-23T00:00:00.000' AS DateTime), 2, 2)
INSERT [dbo].[Turno] ([id], [diasemana], [fechaGeneracion], [fechaHoraFin], [fechaHoraInicio], [IdAsignacionCientifico], [IdRecursoTecnologico]) VALUES (6, N'miercoles', CAST(N'2022-06-13T00:00:00.000' AS DateTime), CAST(N'2022-06-29T00:00:00.000' AS DateTime), CAST(N'2022-06-25T00:00:00.000' AS DateTime), 2, 2)
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([id], [clave], [habilitado], [usuario], [idPersonalCientifico]) VALUES (1, N'123', 1, N'ppai', 123)
INSERT [dbo].[Usuario] ([id], [clave], [habilitado], [usuario], [idPersonalCientifico]) VALUES (2, N'123', 1, N'erik', 456)
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
ALTER TABLE [dbo].[AsignacionCientificoCI]  WITH CHECK ADD  CONSTRAINT [FK_AsignacionCientificoCI_PersonalCientifico] FOREIGN KEY([idPersonalCientifico])
REFERENCES [dbo].[PersonalCientifico] ([legajo])
GO
ALTER TABLE [dbo].[AsignacionCientificoCI] CHECK CONSTRAINT [FK_AsignacionCientificoCI_PersonalCientifico]
GO
ALTER TABLE [dbo].[AsignacionResponsableTecnicoRT]  WITH CHECK ADD  CONSTRAINT [FK_AsignacionResponsableTecnicoRT_PersonalCientifico] FOREIGN KEY([IdPersonalCientifico])
REFERENCES [dbo].[PersonalCientifico] ([legajo])
GO
ALTER TABLE [dbo].[AsignacionResponsableTecnicoRT] CHECK CONSTRAINT [FK_AsignacionResponsableTecnicoRT_PersonalCientifico]
GO
ALTER TABLE [dbo].[AsignacionResponsableTecnicoRT]  WITH CHECK ADD  CONSTRAINT [FK_AsignacionResponsableTecnicoRT_RecursoTecnologico] FOREIGN KEY([IdRecursoTecnologico])
REFERENCES [dbo].[RecursoTecnologico] ([numero])
GO
ALTER TABLE [dbo].[AsignacionResponsableTecnicoRT] CHECK CONSTRAINT [FK_AsignacionResponsableTecnicoRT_RecursoTecnologico]
GO
ALTER TABLE [dbo].[CambioEstadoRT]  WITH CHECK ADD  CONSTRAINT [FK_CambioEstadoRT_Estado] FOREIGN KEY([idEstado])
REFERENCES [dbo].[Estado] ([id])
GO
ALTER TABLE [dbo].[CambioEstadoRT] CHECK CONSTRAINT [FK_CambioEstadoRT_Estado]
GO
ALTER TABLE [dbo].[CambioEstadoRT]  WITH CHECK ADD  CONSTRAINT [FK_CambioEstadoRT_RecursoTecnologico] FOREIGN KEY([idRecursoTecnologico])
REFERENCES [dbo].[RecursoTecnologico] ([numero])
GO
ALTER TABLE [dbo].[CambioEstadoRT] CHECK CONSTRAINT [FK_CambioEstadoRT_RecursoTecnologico]
GO
ALTER TABLE [dbo].[CambioEstadoTurno]  WITH CHECK ADD  CONSTRAINT [FK__CambioEst__idEst__4AB81AF0] FOREIGN KEY([idEstado])
REFERENCES [dbo].[Estado] ([id])
GO
ALTER TABLE [dbo].[CambioEstadoTurno] CHECK CONSTRAINT [FK__CambioEst__idEst__4AB81AF0]
GO
ALTER TABLE [dbo].[Mantenimiento]  WITH CHECK ADD  CONSTRAINT [FK_Mantenimiento_RecursoTecnologico] FOREIGN KEY([id])
REFERENCES [dbo].[Mantenimiento] ([id])
GO
ALTER TABLE [dbo].[Mantenimiento] CHECK CONSTRAINT [FK_Mantenimiento_RecursoTecnologico]
GO
ALTER TABLE [dbo].[Modelo]  WITH CHECK ADD  CONSTRAINT [FK_Modelo_Marca] FOREIGN KEY([idMarca])
REFERENCES [dbo].[Marca] ([id])
GO
ALTER TABLE [dbo].[Modelo] CHECK CONSTRAINT [FK_Modelo_Marca]
GO
ALTER TABLE [dbo].[RecursoTecnologico]  WITH CHECK ADD  CONSTRAINT [FK_RecursoTecnologico_Modelo] FOREIGN KEY([modelo])
REFERENCES [dbo].[Modelo] ([id])
GO
ALTER TABLE [dbo].[RecursoTecnologico] CHECK CONSTRAINT [FK_RecursoTecnologico_Modelo]
GO
ALTER TABLE [dbo].[RecursoTecnologico]  WITH CHECK ADD  CONSTRAINT [FK_RecursoTecnologico_TipoRT] FOREIGN KEY([idTipoRT])
REFERENCES [dbo].[TipoRecursoTecnologico] ([id])
GO
ALTER TABLE [dbo].[RecursoTecnologico] CHECK CONSTRAINT [FK_RecursoTecnologico_TipoRT]
GO
ALTER TABLE [dbo].[Sesion]  WITH CHECK ADD  CONSTRAINT [FK__Sesion__idUsuari__4222D4EF] FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuario] ([id])
GO
ALTER TABLE [dbo].[Sesion] CHECK CONSTRAINT [FK__Sesion__idUsuari__4222D4EF]
GO
ALTER TABLE [dbo].[Turno]  WITH CHECK ADD  CONSTRAINT [FK_Turno_AsignacionCientificoDelCI] FOREIGN KEY([IdAsignacionCientifico])
REFERENCES [dbo].[AsignacionCientificoCI] ([id])
GO
ALTER TABLE [dbo].[Turno] CHECK CONSTRAINT [FK_Turno_AsignacionCientificoDelCI]
GO
ALTER TABLE [dbo].[Turno]  WITH CHECK ADD  CONSTRAINT [FK_Turno_RecursoTecnologico] FOREIGN KEY([IdRecursoTecnologico])
REFERENCES [dbo].[RecursoTecnologico] ([numero])
GO
ALTER TABLE [dbo].[Turno] CHECK CONSTRAINT [FK_Turno_RecursoTecnologico]
GO
ALTER TABLE [dbo].[Usuario]  WITH CHECK ADD  CONSTRAINT [FK__Usuario__idPerso__3F466844] FOREIGN KEY([idPersonalCientifico])
REFERENCES [dbo].[PersonalCientifico] ([legajo])
GO
ALTER TABLE [dbo].[Usuario] CHECK CONSTRAINT [FK__Usuario__idPerso__3F466844]
GO
USE [master]
GO
ALTER DATABASE [DSI] SET  READ_WRITE 
GO
