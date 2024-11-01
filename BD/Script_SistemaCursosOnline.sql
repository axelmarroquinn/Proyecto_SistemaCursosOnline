USE [master]
GO
/****** Object:  Database [SistemaCursosOnline]    Script Date: 25/10/2024 17:10:57 ******/
CREATE DATABASE [SistemaCursosOnline]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SistemaCursosOnline', FILENAME = N'C:\SQLData\SistemaCursosOnline.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'SistemaCursosOnline_log', FILENAME = N'C:\SQLData\SistemaCursosOnline_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [SistemaCursosOnline] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SistemaCursosOnline].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SistemaCursosOnline] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET ARITHABORT OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [SistemaCursosOnline] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SistemaCursosOnline] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SistemaCursosOnline] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET  ENABLE_BROKER 
GO
ALTER DATABASE [SistemaCursosOnline] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SistemaCursosOnline] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SistemaCursosOnline] SET  MULTI_USER 
GO
ALTER DATABASE [SistemaCursosOnline] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SistemaCursosOnline] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SistemaCursosOnline] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SistemaCursosOnline] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [SistemaCursosOnline] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [SistemaCursosOnline] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [SistemaCursosOnline] SET QUERY_STORE = ON
GO
ALTER DATABASE [SistemaCursosOnline] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [SistemaCursosOnline]
GO
/****** Object:  Table [dbo].[Anuncio]    Script Date: 25/10/2024 17:10:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Anuncio](
	[AnuncioId] [int] IDENTITY(1,1) NOT NULL,
	[CursoId] [int] NOT NULL,
	[Titulo] [nvarchar](150) NOT NULL,
	[Contenido] [nvarchar](500) NULL,
	[FechaPublicacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[AnuncioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Curso]    Script Date: 25/10/2024 17:10:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Curso](
	[CursoId] [int] IDENTITY(1,1) NOT NULL,
	[NombreCurso] [nvarchar](150) NOT NULL,
	[Descripcion] [nvarchar](500) NULL,
	[FechaCreacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CursoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CursoUsuario]    Script Date: 25/10/2024 17:10:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CursoUsuario](
	[CursoId] [int] NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[FechaAsignacion] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CursoId] ASC,
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tarea]    Script Date: 25/10/2024 17:10:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tarea](
	[TareaId] [int] IDENTITY(1,1) NOT NULL,
	[CursoId] [int] NOT NULL,
	[NombreTarea] [nvarchar](150) NOT NULL,
	[DescripcionTarea] [nvarchar](500) NULL,
	[FechaLimite] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[TareaId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TareaCompletada]    Script Date: 25/10/2024 17:10:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TareaCompletada](
	[TareaId] [int] NOT NULL,
	[UsuarioId] [int] NOT NULL,
	[FechaEntrega] [datetime] NULL,
	[Calificacion] [decimal](5, 2) NULL,
PRIMARY KEY CLUSTERED 
(
	[TareaId] ASC,
	[UsuarioId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 25/10/2024 17:10:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [nvarchar](100) NOT NULL,
	[Apellido] [nvarchar](100) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Contraseña] [nvarchar](255) NOT NULL,
	[Rol] [nvarchar](50) NOT NULL,
	[FechaRegistro] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Curso] ON 

INSERT [dbo].[Curso] ([CursoId], [NombreCurso], [Descripcion], [FechaCreacion]) VALUES (2, N'Matemática I', N'Operaciones básicas.', CAST(N'2024-10-22T09:40:18.237' AS DateTime))
INSERT [dbo].[Curso] ([CursoId], [NombreCurso], [Descripcion], [FechaCreacion]) VALUES (3, N'Matemática II', N'Operaciones avanzadas.', CAST(N'2024-10-22T10:06:24.397' AS DateTime))
INSERT [dbo].[Curso] ([CursoId], [NombreCurso], [Descripcion], [FechaCreacion]) VALUES (4, N'Programación II', N'Programas avanzados.', CAST(N'2024-10-25T13:50:02.917' AS DateTime))
INSERT [dbo].[Curso] ([CursoId], [NombreCurso], [Descripcion], [FechaCreacion]) VALUES (5, N'Programación I', N'Programas básicos.', CAST(N'2024-10-25T13:54:23.547' AS DateTime))
SET IDENTITY_INSERT [dbo].[Curso] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [Nombre], [Apellido], [Email], [Contraseña], [Rol], [FechaRegistro]) VALUES (1, N'Admin', N'Admin', N'admin@school.com', N'admin123', N'Administrador', CAST(N'2024-10-22T08:33:46.330' AS DateTime))
INSERT [dbo].[Usuario] ([Id], [Nombre], [Apellido], [Email], [Contraseña], [Rol], [FechaRegistro]) VALUES (2, N'Catedratico', N'Catedratico', N'catedratico@school.com', N'catedratico123', N'Catedratico', CAST(N'2024-10-22T08:33:50.697' AS DateTime))
INSERT [dbo].[Usuario] ([Id], [Nombre], [Apellido], [Email], [Contraseña], [Rol], [FechaRegistro]) VALUES (3, N'Estudiante', N'Estudiante', N'estudiante@school.com', N'estudiante123', N'Estudiante', CAST(N'2024-10-22T08:33:56.347' AS DateTime))
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Usuario__A9D105343B159859]    Script Date: 25/10/2024 17:10:58 ******/
ALTER TABLE [dbo].[Usuario] ADD UNIQUE NONCLUSTERED 
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Anuncio] ADD  DEFAULT (getdate()) FOR [FechaPublicacion]
GO
ALTER TABLE [dbo].[Curso] ADD  DEFAULT (getdate()) FOR [FechaCreacion]
GO
ALTER TABLE [dbo].[CursoUsuario] ADD  DEFAULT (getdate()) FOR [FechaAsignacion]
GO
ALTER TABLE [dbo].[Usuario] ADD  DEFAULT (getdate()) FOR [FechaRegistro]
GO
ALTER TABLE [dbo].[Anuncio]  WITH NOCHECK ADD FOREIGN KEY([CursoId])
REFERENCES [dbo].[Curso] ([CursoId])
GO
ALTER TABLE [dbo].[CursoUsuario]  WITH NOCHECK ADD FOREIGN KEY([CursoId])
REFERENCES [dbo].[Curso] ([CursoId])
GO
ALTER TABLE [dbo].[CursoUsuario]  WITH NOCHECK ADD FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
ALTER TABLE [dbo].[Tarea]  WITH NOCHECK ADD FOREIGN KEY([CursoId])
REFERENCES [dbo].[Curso] ([CursoId])
GO
ALTER TABLE [dbo].[TareaCompletada]  WITH NOCHECK ADD FOREIGN KEY([TareaId])
REFERENCES [dbo].[Tarea] ([TareaId])
GO
ALTER TABLE [dbo].[TareaCompletada]  WITH NOCHECK ADD FOREIGN KEY([UsuarioId])
REFERENCES [dbo].[Usuario] ([Id])
GO
USE [master]
GO
ALTER DATABASE [SistemaCursosOnline] SET  READ_WRITE 
GO
