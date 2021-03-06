USE [master]
GO
/****** Object:  Database [JohnBookStore]    Script Date: 15-10-2021 09:37:38 ******/
CREATE DATABASE [JohnBookStore]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'JohnBookStore', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\JohnBookStore.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'JohnBookStore_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\JohnBookStore_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [JohnBookStore] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [JohnBookStore].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [JohnBookStore] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [JohnBookStore] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [JohnBookStore] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [JohnBookStore] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [JohnBookStore] SET ARITHABORT OFF 
GO
ALTER DATABASE [JohnBookStore] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [JohnBookStore] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [JohnBookStore] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [JohnBookStore] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [JohnBookStore] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [JohnBookStore] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [JohnBookStore] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [JohnBookStore] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [JohnBookStore] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [JohnBookStore] SET  DISABLE_BROKER 
GO
ALTER DATABASE [JohnBookStore] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [JohnBookStore] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [JohnBookStore] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [JohnBookStore] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [JohnBookStore] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [JohnBookStore] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [JohnBookStore] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [JohnBookStore] SET RECOVERY FULL 
GO
ALTER DATABASE [JohnBookStore] SET  MULTI_USER 
GO
ALTER DATABASE [JohnBookStore] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [JohnBookStore] SET DB_CHAINING OFF 
GO
ALTER DATABASE [JohnBookStore] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [JohnBookStore] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [JohnBookStore] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [JohnBookStore] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'JohnBookStore', N'ON'
GO
ALTER DATABASE [JohnBookStore] SET QUERY_STORE = OFF
GO
USE [JohnBookStore]
GO
/****** Object:  UserDefinedFunction [dbo].[BookMaxPrice]    Script Date: 15-10-2021 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[BookMaxPrice](
@BookID as int
) 
RETURNS int AS 

BEGIN
	RETURN ISNULL((SELECT Max(Price) from [dbo].[StockDetail] where BookId=@BookId AND InStock>0),0)
END
GO
/****** Object:  UserDefinedFunction [dbo].[BookMinimumPrice]    Script Date: 15-10-2021 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[BookMinimumPrice](
@BookID as int
) 
RETURNS int AS 

BEGIN
	RETURN ISNULL((SELECT MIN(Price) from [dbo].[StockDetail] where BookId=@BookId AND InStock>0),0)
END
GO
/****** Object:  UserDefinedFunction [dbo].[TotalBookLeftInStock]    Script Date: 15-10-2021 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[TotalBookLeftInStock](
@BookID as int
) 
RETURNS int AS 

BEGIN
	RETURN ISNULL((SELECT Sum(InStock) from [dbo].[StockDetail] where BookId=@BookId),0)
END
GO
/****** Object:  Table [dbo].[Books]    Script Date: 15-10-2021 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Books](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[BookName] [nvarchar](500) NOT NULL,
	[ISBN] [nvarchar](500) NOT NULL,
	[Author] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 15-10-2021 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[OrderID] [int] IDENTITY(1,1) NOT NULL,
	[BookID] [int] NULL,
	[ISBN] [nvarchar](500) NULL,
	[StoreID] [int] NULL,
	[ContactEmail] [nvarchar](500) NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StockDetail]    Script Date: 15-10-2021 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StockDetail](
	[StockID] [int] IDENTITY(1,1) NOT NULL,
	[BookID] [int] NOT NULL,
	[Price] [decimal](18, 2) NOT NULL,
	[InStock] [int] NULL,
	[StoreID] [int] NOT NULL,
 CONSTRAINT [PK_StockDetail] PRIMARY KEY CLUSTERED 
(
	[StockID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Store]    Script Date: 15-10-2021 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Store](
	[StoreID] [int] IDENTITY(1,1) NOT NULL,
	[Storename] [nvarchar](50) NULL,
 CONSTRAINT [PK_Store] PRIMARY KEY CLUSTERED 
(
	[StoreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Books] FOREIGN KEY([BookID])
REFERENCES [dbo].[Books] ([BookID])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Books]
GO
ALTER TABLE [dbo].[StockDetail]  WITH CHECK ADD  CONSTRAINT [FK_StockDetail_Store] FOREIGN KEY([StoreID])
REFERENCES [dbo].[Store] ([StoreID])
GO
ALTER TABLE [dbo].[StockDetail] CHECK CONSTRAINT [FK_StockDetail_Store]
GO
/****** Object:  StoredProcedure [dbo].[GetBookAvailibilityPerStore]    Script Date: 15-10-2021 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetBookAvailibilityPerStore]
@ISBN as nvarchar(500) = ''
AS
BEGIN
	declare @BookId as int
	SET  @BookId = (select bookID from books Where ISBN=@ISBN)
	Print @BookId
	SELECT S.StoreID, S.Storename, SD.Price, SD.InStock from [dbo].[StockDetail] SD
	left outer join Store S on S.StoreId =Sd.StoreId
	Where SD.BookID=@BookId
END
GO
/****** Object:  StoredProcedure [dbo].[GetBookDetails]    Script Date: 15-10-2021 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- EXE GetBookDetails @BookName= 'Trilogy'
CREATE PROCEDURE [dbo].[GetBookDetails]
@BookName as nvarchar(250)=''	
AS
BEGIN
	Select B.BookName, B.Author, B.ISBN
	from Books B
	
	where BookName like '%' + @BookName + '%'
END
GO
/****** Object:  StoredProcedure [dbo].[GetBooksAvailibilityInStocks]    Script Date: 15-10-2021 09:37:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- EXEC GetBooksAvailibilityInStocks
CREATE PROCEDURE [dbo].[GetBooksAvailibilityInStocks]	
@BookName as nvarchar(500) = ''
AS
BEGIN
IF @BookName = ''
	BEGIN
		SELECT ISBN, BookName,Author, 
		[dbo].[BookMinimumPrice](BookID) as MinPrice,
		[dbo].[BookMaxPrice](BookID) as MaxPrice,
		[dbo].[TotalBookLeftInStock](BookID) as leftInStock
		FROM Books 
	END
ELSE
	BEGIN
		SELECT ISBN, BookName,Author,
		[dbo].[BookMinimumPrice](BookID) as MinPrice,
		[dbo].[BookMaxPrice](BookID) as MaxPrice,
		[dbo].[TotalBookLeftInStock](BookID) as leftInStock
		FROM Books where BookName like '%' + @BookName + '%'
	END
END
GO
USE [master]
GO
ALTER DATABASE [JohnBookStore] SET  READ_WRITE 
GO
