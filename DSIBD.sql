USE [master]
GO
/****** Object:  Database [DSI]    Script Date: 5/11/2022 19:07:57 ******/
CREATE DATABASE [DSI]
 CONTAINMENT = NONE

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
/****** Object:  Table [dbo].[AsignacionCientificoCI]    Script Date: 5/11/2022 19:07:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsignacionCientificoCI](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fechaHoraDesde] [date] NULL,
	[fechaHoraHasta] [date] NULL,
	[idPersonalCientifico] [int] NULL,
 CONSTRAINT [PK__Asignaci__3213E83FC0D13BB3] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AsignacionResponsableTecnicoRT]    Script Date: 5/11/2022 19:07:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AsignacionResponsableTecnicoRT](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FechaHoraDesde] [datetime] NULL,
	[FechaHoraHasta] [datetime] NULL,
	[IdRecursoTecnologico] [int] NOT NULL,
	[IdPersonalCientifico] [int] NULL,
 CONSTRAINT [PK_AsignacionResponsableTecnicoRT] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CambioEstadoRT]    Script Date: 5/11/2022 19:07:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CambioEstadoRT](
	[id] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[CambioEstadoTurno]    Script Date: 5/11/2022 19:07:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CambioEstadoTurno](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[fechaHoraDesde] [date] NULL,
	[fechaHoraHasta] [date] NULL,
	[idTurno] [int] NULL,
	[idEstado] [int] NULL,
 CONSTRAINT [PK__CambioEs__3213E83FC0D1C21F] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Estado]    Script Date: 5/11/2022 19:07:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Estado](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ambito] [nchar](10) NULL,
	[descripcion] [nchar](10) NULL,
	[esCancelable] [bit] NULL,
	[esReservable] [bit] NULL,
	[nombre] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Estado] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mantenimiento]    Script Date: 5/11/2022 19:07:58 ******/
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
/****** Object:  Table [dbo].[Marca]    Script Date: 5/11/2022 19:07:58 ******/
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
/****** Object:  Table [dbo].[Modelo]    Script Date: 5/11/2022 19:07:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Modelo](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [nchar](10) NULL,
	[idMarca] [int] NULL,
 CONSTRAINT [PK_Modelo] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PersonalCientifico]    Script Date: 5/11/2022 19:07:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PersonalCientifico](
	[legajo] [int] IDENTITY(1,1) NOT NULL,
	[apellido] [varchar](50) NULL,
	[correoElectronicoInstitucional] [varchar](50) NULL,
	[correoElectronicoPersonal] [varchar](50) NULL,
	[nombre] [varchar](50) NULL,
	[numeroDocumento] [int] NULL,
	[telefonoCelular] [varchar](50) NULL,
 CONSTRAINT [PK__Personal__818C9F86D298D638] PRIMARY KEY CLUSTERED 
(
	[legajo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecursoTecnologico]    Script Date: 5/11/2022 19:07:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecursoTecnologico](
	[numero] [int] IDENTITY(1,1) NOT NULL,
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
/****** Object:  Table [dbo].[Sesion]    Script Date: 5/11/2022 19:07:58 ******/
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
/****** Object:  Table [dbo].[TipoRecursoTecnologico]    Script Date: 5/11/2022 19:07:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoRecursoTecnologico](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[descripción] [nchar](10) NULL,
	[nombre] [nchar](10) NULL,
 CONSTRAINT [PK_TipoRecursoTecnologico] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Turno]    Script Date: 5/11/2022 19:07:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Turno](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[diasemana] [int] NULL,
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
/****** Object:  Table [dbo].[Usuario]    Script Date: 5/11/2022 19:07:58 ******/
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
SET IDENTITY_INSERT [dbo].[Modelo] OFF
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
