USE [master]
GO

/****** Object:  Database [LibraryConsoleApp]    Script Date: 4/26/2022 2:01:11 AM ******/
CREATE DATABASE [LibraryConsoleApp]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'LibraryConsoleApp', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\LibraryConsoleApp.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'LibraryConsoleApp_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\LibraryConsoleApp_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LibraryConsoleApp].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [LibraryConsoleApp] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [LibraryConsoleApp] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [LibraryConsoleApp] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [LibraryConsoleApp] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [LibraryConsoleApp] SET ARITHABORT OFF 
GO

ALTER DATABASE [LibraryConsoleApp] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [LibraryConsoleApp] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [LibraryConsoleApp] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [LibraryConsoleApp] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [LibraryConsoleApp] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [LibraryConsoleApp] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [LibraryConsoleApp] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [LibraryConsoleApp] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [LibraryConsoleApp] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [LibraryConsoleApp] SET  DISABLE_BROKER 
GO

ALTER DATABASE [LibraryConsoleApp] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [LibraryConsoleApp] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [LibraryConsoleApp] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [LibraryConsoleApp] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [LibraryConsoleApp] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [LibraryConsoleApp] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [LibraryConsoleApp] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [LibraryConsoleApp] SET RECOVERY FULL 
GO

ALTER DATABASE [LibraryConsoleApp] SET  MULTI_USER 
GO

ALTER DATABASE [LibraryConsoleApp] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [LibraryConsoleApp] SET DB_CHAINING OFF 
GO

ALTER DATABASE [LibraryConsoleApp] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [LibraryConsoleApp] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [LibraryConsoleApp] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [LibraryConsoleApp] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [LibraryConsoleApp] SET QUERY_STORE = OFF
GO

ALTER DATABASE [LibraryConsoleApp] SET  READ_WRITE 
GO

USE LibraryConsoleApp
GO

CREATE TABLE [dbo].[Author]
(
	[AuthorId] INT NOT NULL PRIMARY KEY IDENTITY,
	[FirstName] varchar(50) not null,
	[LastName] varchar(50) not null,
	[DateOfBirth] date not null,
	[BirthLocation] varchar(50) not null,
	[Bio] varchar(max) NOT NULL
)

CREATE TABLE [dbo].[Genre]
(
	[GenreId] INT NOT NULL PRIMARY KEY,
	[Description] VARCHAR(MAX),
	[IsFiction] bit not null,
	[Name] varchar(50) NOT NULL
)

CREATE TABLE [dbo].[Publisher]
(
	[PublisherID] INT NOT NULL PRIMARY KEY IDENTITY,
	[Name] varchar(50) not null,
	[Address] varchar(50) not null,
	[City] varchar(50) not null,
	[State] varchar(2) not null,
	[Zip] varchar(10) not null
)

CREATE TABLE [dbo].[Book]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Title] varchar(50) not null,
	[Description] varchar(250) not null,
	[Price] money not null,
	[IsPaperBack] bit not null,
	[PublishDate] Date,
	[Author] INT FOREIGN KEY REFERENCES [dbo].[Author](AuthorId),
	[Genre] int FOREIGN KEY REFERENCES [dbo].[Genre](GenreId),
	[Publisher] INT FOREIGN KEY REFERENCES [dbo].[Publisher](PublisherID)
)

CREATE TABLE [dbo].[Role]
(
	[RoleId] INT NOT NULL PRIMARY KEY IDENTITY,
	[RoleName] varchar(20) not null
)

CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY,
	[Role] INT FOREIGN KEY REFERENCES [dbo].[Role](RoleID),
	[FirstName] varchar(50) NOT NULL,
	[LastName] varchar(50) NOT NULL,
	[UserName] varchar(50) NOT NULL,
	[Password] varchar(64) NOT NULL,
	[Salt] varchar(64) not null
	
)