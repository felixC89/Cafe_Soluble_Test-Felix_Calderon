USE [master]
GO

/****** Object:  Database [Productos]    Script Date: 6/4/2022 01:48:13 ******/
CREATE DATABASE [Productos]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Productos', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLSERVER\MSSQL\DATA\Productos.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Productos_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLSERVER\MSSQL\DATA\Productos_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [Productos] SET COMPATIBILITY_LEVEL = 120
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Productos].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Productos] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Productos] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Productos] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Productos] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Productos] SET ARITHABORT OFF 
GO

ALTER DATABASE [Productos] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Productos] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Productos] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Productos] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Productos] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Productos] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Productos] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Productos] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Productos] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Productos] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Productos] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Productos] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Productos] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Productos] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Productos] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Productos] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Productos] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Productos] SET RECOVERY FULL 
GO

ALTER DATABASE [Productos] SET  MULTI_USER 
GO

ALTER DATABASE [Productos] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Productos] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Productos] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Productos] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [Productos] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Productos] SET  READ_WRITE 
GO
