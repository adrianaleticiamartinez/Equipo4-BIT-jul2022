USE [master]
GO
/****** Object:  Database [CLIENTES]    Script Date: 14/07/2022 01:57:58 p. m. ******/
CREATE DATABASE [CLIENTES]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BVVA', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BVVA.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BVVA_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\BVVA_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [CLIENTES] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [CLIENTES].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [CLIENTES] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [CLIENTES] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [CLIENTES] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [CLIENTES] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [CLIENTES] SET ARITHABORT OFF 
GO
ALTER DATABASE [CLIENTES] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [CLIENTES] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [CLIENTES] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [CLIENTES] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [CLIENTES] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [CLIENTES] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [CLIENTES] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [CLIENTES] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [CLIENTES] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [CLIENTES] SET  DISABLE_BROKER 
GO
ALTER DATABASE [CLIENTES] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [CLIENTES] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [CLIENTES] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [CLIENTES] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [CLIENTES] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [CLIENTES] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [CLIENTES] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [CLIENTES] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [CLIENTES] SET  MULTI_USER 
GO
ALTER DATABASE [CLIENTES] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [CLIENTES] SET DB_CHAINING OFF 
GO
ALTER DATABASE [CLIENTES] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [CLIENTES] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [CLIENTES] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [CLIENTES] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [CLIENTES] SET QUERY_STORE = OFF
GO
USE [CLIENTES]
GO
/****** Object:  Table [dbo].[infoclientes]    Script Date: 14/07/2022 01:57:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[infoclientes](
	[idCliente] [varchar](11) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[apellidoPaterno] [varchar](50) NOT NULL,
	[apellidoMaterno] [varchar](50) NULL,
	[fechaNacimiento] [varchar](50) NOT NULL,
	[sexo] [varchar](50) NOT NULL,
	[segmento] [char](10) NOT NULL,
	[nacionalidad] [varchar](50) NOT NULL,
	[rfc] [varchar](50) NULL,
	[tipoId] [varchar](50) NOT NULL,
	[numeroId] [varchar](50) NOT NULL,
	[cuenta] [varchar](50) NOT NULL,
	[email] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[usuarios]    Script Date: 14/07/2022 01:57:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[usuarios](
	[usuario] [varchar](50) NULL,
	[auth] [varchar](50) NULL,
	[nombreCompleto] [varchar](50) NULL,
	[area] [varchar](50) NULL,
	[ubicacion] [varchar](50) NULL,
	[segmento] [varchar](50) NULL,
	[perfil] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[sp_manager]    Script Date: 14/07/2022 01:57:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_manager]@id VARCHAR(50)ASBEGIN	SELECT * FROM infoclientes	WHERE idCliente = @id;END
GO
/****** Object:  StoredProcedure [dbo].[sp_restringido]    Script Date: 14/07/2022 01:57:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_restringido]@id VARCHAR(50)ASBEGIN	SELECT idCliente, nombre, sexo, segmento, cuenta,numeroId FROM infoclientes	WHERE idCliente = @id;END
GO
/****** Object:  StoredProcedure [dbo].[sp_usuario]    Script Date: 14/07/2022 01:57:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_usuario]@us VARCHAR(50),@pass VARCHAR(50)ASBEGIN	SELECT * FROM usuarios	WHERE usuario = @us AND auth = @pass;END
GO
/****** Object:  StoredProcedure [dbo].[sp_validador]    Script Date: 14/07/2022 01:57:59 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_validador]@id VARCHAR(50)ASBEGIN	SELECT	idCliente, 			nombre, 			(SUBSTRING(apellidoPaterno,1,3)+'**********') AS apellidoPaterno,			(SUBSTRING(apellidoMaterno,1,3)+'**********') AS apellidoMaterno, 			(SUBSTRING(fechaNacimiento,1,3)+'**********') AS fechaNacimiento,			sexo, 			segmento,			(SUBSTRING(nacionalidad,1,3)+'**********') AS nacionalidad,			(SUBSTRING(rfc,1,3)+'**********') AS rfc,			(SUBSTRING(tipoId,1,3)+'**********') AS tipoId,			(SUBSTRING(numeroId,1,3)+'**********') AS numeroId,			cuenta,			(SUBSTRING(email,1,3)+'**********') AS email	FROM infoclientes	WHERE idCliente = @id;END
GO
USE [master]
GO
ALTER DATABASE [CLIENTES] SET  READ_WRITE 
GO
