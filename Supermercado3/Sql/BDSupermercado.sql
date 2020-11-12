USE [master]
GO
/****** Object:  Database [BDSupermercado]    Script Date: 12/11/2020 02:30:50 ******/
CREATE DATABASE [BDSupermercado]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BDSupermercado', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BDSupermercado.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'BDSupermercado_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\BDSupermercado_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [BDSupermercado] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDSupermercado].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BDSupermercado] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BDSupermercado] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BDSupermercado] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BDSupermercado] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BDSupermercado] SET ARITHABORT OFF 
GO
ALTER DATABASE [BDSupermercado] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BDSupermercado] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BDSupermercado] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BDSupermercado] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BDSupermercado] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BDSupermercado] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BDSupermercado] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BDSupermercado] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BDSupermercado] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BDSupermercado] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BDSupermercado] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BDSupermercado] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BDSupermercado] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BDSupermercado] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BDSupermercado] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BDSupermercado] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BDSupermercado] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BDSupermercado] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BDSupermercado] SET  MULTI_USER 
GO
ALTER DATABASE [BDSupermercado] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BDSupermercado] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BDSupermercado] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BDSupermercado] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BDSupermercado] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BDSupermercado] SET QUERY_STORE = OFF
GO
USE [BDSupermercado]
GO
/****** Object:  Table [dbo].[Pessoa]    Script Date: 12/11/2020 02:30:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pessoa](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](60) NOT NULL,
	[Idade] [int] NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Login] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produto]    Script Date: 12/11/2020 02:30:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](60) NOT NULL,
	[Categoria] [varchar](100) NOT NULL,
	[Marca] [varchar](100) NOT NULL,
	[Preco] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[uspPessoaInserir]    Script Date: 12/11/2020 02:30:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspPessoaInserir]

@Nome as varchar(60),
@Idade as int,
@Email as varchar(100),
@Login as varchar(11)

as
begin
	insert into Pessoa
	(Nome,Idade,Email,Login)
	values
	(@Nome,@Idade,@Email,@Login)

	select @@IDENTITY as retorno

end
GO
/****** Object:  StoredProcedure [dbo].[uspPessoaListar]    Script Date: 12/11/2020 02:30:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[uspPessoaListar]
as
begin

	select Pessoa.Id, Pessoa.Nome, Pessoa.Idade, Pessoa.Email, Pessoa.Login
	from dbo.Pessoa
	order by Pessoa.Id
end
GO
/****** Object:  StoredProcedure [dbo].[uspProdutoInserir]    Script Date: 12/11/2020 02:30:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[uspProdutoInserir]

@Nome as varchar(60),
@Categoria as varchar(100),
@Marca as varchar(100),
@Preco as varchar(11)

as
begin
	insert into Produto
	(Nome,Categoria,Marca,Preco)
	values
	(@Nome,@Categoria,@Marca,@Preco)

	select @@IDENTITY as retorno

end
GO
/****** Object:  StoredProcedure [dbo].[uspProdutoListar]    Script Date: 12/11/2020 02:30:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[uspProdutoListar]
as
begin

	select Produto.Id, Produto.Nome, Produto.Categoria, Produto.Marca, Produto.Preco
	from dbo.Produto
	order by Produto.Id
end
GO
USE [master]
GO
ALTER DATABASE [BDSupermercado] SET  READ_WRITE 
GO
