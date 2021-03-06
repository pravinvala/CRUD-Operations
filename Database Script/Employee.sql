USE [master]
GO
/****** Object:  Database [Employee]    Script Date: 07/29/20 1:42:26 AM ******/
CREATE DATABASE [Employee]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Employee', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Employee.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Employee_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Employee_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Employee].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Employee] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Employee] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Employee] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Employee] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Employee] SET ARITHABORT OFF 
GO
ALTER DATABASE [Employee] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Employee] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Employee] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Employee] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Employee] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Employee] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Employee] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Employee] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Employee] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Employee] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Employee] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Employee] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Employee] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Employee] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Employee] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Employee] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Employee] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Employee] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Employee] SET  MULTI_USER 
GO
ALTER DATABASE [Employee] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Employee] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Employee] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Employee] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Employee] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Employee] SET QUERY_STORE = OFF
GO
USE [Employee]
GO
/****** Object:  Table [dbo].[TBL_City]    Script Date: 07/29/20 1:42:26 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_City](
	[CityID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[StateID] [int] NULL,
 CONSTRAINT [PK_TBL_City] PRIMARY KEY CLUSTERED 
(
	[CityID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_Country]    Script Date: 07/29/20 1:42:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_Country](
	[CountryID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
 CONSTRAINT [PK_TBL_Country] PRIMARY KEY CLUSTERED 
(
	[CountryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_Employee]    Script Date: 07/29/20 1:42:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_Employee](
	[EmpID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[Email] [varchar](50) NOT NULL,
	[Gender] [varchar](1) NOT NULL,
	[MaritalStatus] [bit] NOT NULL,
	[DOB] [date] NOT NULL,
	[Hobbies] [varchar](100) NOT NULL,
	[EmployeePhoto] [varchar](50) NOT NULL,
	[Salary] [decimal](10, 2) NOT NULL,
	[Address] [varchar](500) NOT NULL,
	[CountryID] [int] NOT NULL,
	[StateID] [int] NOT NULL,
	[CityID] [int] NOT NULL,
	[ZipCode] [varchar](6) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TBL_Employee] PRIMARY KEY CLUSTERED 
(
	[EmpID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TBL_State]    Script Date: 07/29/20 1:42:27 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TBL_State](
	[StateID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[CountryID] [int] NULL,
 CONSTRAINT [PK_TBL_State] PRIMARY KEY CLUSTERED 
(
	[StateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TBL_City] ON 

INSERT [dbo].[TBL_City] ([CityID], [Name], [StateID]) VALUES (1, N'Surat', 1)
INSERT [dbo].[TBL_City] ([CityID], [Name], [StateID]) VALUES (2, N'Baroda', 1)
SET IDENTITY_INSERT [dbo].[TBL_City] OFF
SET IDENTITY_INSERT [dbo].[TBL_Country] ON 

INSERT [dbo].[TBL_Country] ([CountryID], [Name]) VALUES (1, N'India')
SET IDENTITY_INSERT [dbo].[TBL_Country] OFF
SET IDENTITY_INSERT [dbo].[TBL_Employee] ON 

INSERT [dbo].[TBL_Employee] ([EmpID], [FirstName], [LastName], [Email], [Gender], [MaritalStatus], [DOB], [Hobbies], [EmployeePhoto], [Salary], [Address], [CountryID], [StateID], [CityID], [ZipCode], [Password]) VALUES (1, N'test', N'test', N'test@gmail.com', N'M', 1, CAST(N'2020-07-29' AS Date), N'Reading,Singing', N'2872020181716513.jpg', CAST(10000.00 AS Decimal(10, 2)), N'test', 1, 1, 1, N'395010', N'hello@123')
INSERT [dbo].[TBL_Employee] ([EmpID], [FirstName], [LastName], [Email], [Gender], [MaritalStatus], [DOB], [Hobbies], [EmployeePhoto], [Salary], [Address], [CountryID], [StateID], [CityID], [ZipCode], [Password]) VALUES (2, N'test', N'test', N'test@gmail.com', N'M', 1, CAST(N'2020-07-29' AS Date), N'Reading,Singing', N'2872020181716513.jpg', CAST(20000.00 AS Decimal(10, 2)), N'test', 1, 1, 1, N'395010', N'hello@123')
INSERT [dbo].[TBL_Employee] ([EmpID], [FirstName], [LastName], [Email], [Gender], [MaritalStatus], [DOB], [Hobbies], [EmployeePhoto], [Salary], [Address], [CountryID], [StateID], [CityID], [ZipCode], [Password]) VALUES (3, N'hello', N'test', N'hest@gmail.com', N'M', 1, CAST(N'2020-07-29' AS Date), N'Reading,Singing', N'2872020181716513.jpg', CAST(30000.00 AS Decimal(10, 2)), N'test', 1, 1, 1, N'395010', N'iello@123')

SET IDENTITY_INSERT [dbo].[TBL_Employee] OFF
SET IDENTITY_INSERT [dbo].[TBL_State] ON 

INSERT [dbo].[TBL_State] ([StateID], [Name], [CountryID]) VALUES (1, N'Gujarat', 1)
INSERT [dbo].[TBL_State] ([StateID], [Name], [CountryID]) VALUES (2, N'Rajsthan', 1)
SET IDENTITY_INSERT [dbo].[TBL_State] OFF
ALTER TABLE [dbo].[TBL_City]  WITH CHECK ADD  CONSTRAINT [FK_TBL_City_TBL_State] FOREIGN KEY([StateID])
REFERENCES [dbo].[TBL_State] ([StateID])
GO
ALTER TABLE [dbo].[TBL_City] CHECK CONSTRAINT [FK_TBL_City_TBL_State]
GO
ALTER TABLE [dbo].[TBL_Employee]  WITH CHECK ADD  CONSTRAINT [FK_TBL_Employee_TBL_City] FOREIGN KEY([CityID])
REFERENCES [dbo].[TBL_City] ([CityID])
GO
ALTER TABLE [dbo].[TBL_Employee] CHECK CONSTRAINT [FK_TBL_Employee_TBL_City]
GO
ALTER TABLE [dbo].[TBL_Employee]  WITH CHECK ADD  CONSTRAINT [FK_TBL_Employee_TBL_Country] FOREIGN KEY([CountryID])
REFERENCES [dbo].[TBL_Country] ([CountryID])
GO
ALTER TABLE [dbo].[TBL_Employee] CHECK CONSTRAINT [FK_TBL_Employee_TBL_Country]
GO
ALTER TABLE [dbo].[TBL_Employee]  WITH CHECK ADD  CONSTRAINT [FK_TBL_Employee_TBL_State] FOREIGN KEY([StateID])
REFERENCES [dbo].[TBL_State] ([StateID])
GO
ALTER TABLE [dbo].[TBL_Employee] CHECK CONSTRAINT [FK_TBL_Employee_TBL_State]
GO
ALTER TABLE [dbo].[TBL_State]  WITH CHECK ADD  CONSTRAINT [FK_TBL_State_TBL_Country] FOREIGN KEY([CountryID])
REFERENCES [dbo].[TBL_Country] ([CountryID])
GO
ALTER TABLE [dbo].[TBL_State] CHECK CONSTRAINT [FK_TBL_State_TBL_Country]
GO
USE [master]
GO
ALTER DATABASE [Employee] SET  READ_WRITE 
GO
