USE [master]
GO
/****** Object:  Database [EvernoteClone]    Script Date: 11/17/2020 7:03:14 PM ******/
CREATE DATABASE [EvernoteClone]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EvernoteClone', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL2019\MSSQL\DATA\EvernoteClone.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EvernoteClone_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQL2019\MSSQL\DATA\EvernoteClone_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EvernoteClone] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EvernoteClone].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EvernoteClone] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EvernoteClone] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EvernoteClone] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EvernoteClone] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EvernoteClone] SET ARITHABORT OFF 
GO
ALTER DATABASE [EvernoteClone] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [EvernoteClone] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EvernoteClone] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EvernoteClone] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EvernoteClone] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EvernoteClone] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EvernoteClone] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EvernoteClone] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EvernoteClone] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EvernoteClone] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EvernoteClone] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EvernoteClone] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EvernoteClone] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EvernoteClone] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EvernoteClone] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EvernoteClone] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [EvernoteClone] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EvernoteClone] SET RECOVERY FULL 
GO
ALTER DATABASE [EvernoteClone] SET  MULTI_USER 
GO
ALTER DATABASE [EvernoteClone] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EvernoteClone] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EvernoteClone] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EvernoteClone] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EvernoteClone] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'EvernoteClone', N'ON'
GO
ALTER DATABASE [EvernoteClone] SET QUERY_STORE = OFF
GO
USE [EvernoteClone]
GO
/****** Object:  Table [dbo].[__MigrationHistory]    Script Date: 11/17/2020 7:03:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__MigrationHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ContextKey] [nvarchar](300) NOT NULL,
	[Model] [varbinary](max) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC,
	[ContextKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notes]    Script Date: 11/17/2020 7:03:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedOn] [datetime2](7) NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[LastModifiedOn] [datetime2](7) NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
	[ObjectStatus] [int] NULL,
	[Status] [int] NULL,
	[UserId] [int] NULL,
 CONSTRAINT [PK_dbo.Notes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Notifications]    Script Date: 11/17/2020 7:03:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Notifications](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[NotiId] [int] NOT NULL,
	[Description] [nvarchar](max) NULL,
	[ContAction] [nvarchar](max) NULL,
	[UserId] [int] NOT NULL,
	[NotificationStatus] [int] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[LastModifiedOn] [datetime2](7) NOT NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
	[ObjectStatus] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Notifications] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserDetails]    Script Date: 11/17/2020 7:03:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SessionDate] [datetime2](7) NOT NULL,
	[SessionTime] [datetime2](7) NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_dbo.UserDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/17/2020 7:03:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Surname] [nvarchar](50) NOT NULL,
	[UserName] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](15) NOT NULL,
	[DayOfBirth] [datetime2](7) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[Department] [int] NOT NULL,
	[CreatedOn] [datetime2](7) NOT NULL,
	[CreatedBy] [nvarchar](max) NULL,
	[LastModifiedOn] [datetime2](7) NOT NULL,
	[LastModifiedBy] [nvarchar](max) NULL,
	[ObjectStatus] [int] NOT NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 11/17/2020 7:03:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Notes]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 11/17/2020 7:03:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[Notifications]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_UserId]    Script Date: 11/17/2020 7:03:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_UserId] ON [dbo].[UserDetails]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Notes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Notes_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Notes] CHECK CONSTRAINT [FK_dbo.Notes_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[Notifications]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Notifications_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Notifications] CHECK CONSTRAINT [FK_dbo.Notifications_dbo.Users_UserId]
GO
ALTER TABLE [dbo].[UserDetails]  WITH CHECK ADD  CONSTRAINT [FK_dbo.UserDetails_dbo.Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserDetails] CHECK CONSTRAINT [FK_dbo.UserDetails_dbo.Users_UserId]
GO
USE [master]
GO
ALTER DATABASE [EvernoteClone] SET  READ_WRITE 
GO
