USE [CATALOGO_WEB_DB]
GO
/****** Object:  Table [dbo].[ARTICULOS]    Script Date: 24/3/2024 14:21:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ARTICULOS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[Descripcion] [varchar](150) NULL,
	[IdMarca] [int] NULL,
	[IdCategoria] [int] NULL,
	[ImagenUrl] [varchar](1000) NULL,
	[Precio] [money] NULL,
	[Activo] [bit] NULL,
 CONSTRAINT [PK_ARTICULOS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CATEGORIAS]    Script Date: 24/3/2024 14:21:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORIAS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_CATEGORIAS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FAVORITOS]    Script Date: 24/3/2024 14:21:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FAVORITOS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdUser] [int] NOT NULL,
	[IdArticulo] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MARCAS]    Script Date: 24/3/2024 14:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MARCAS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_MARCAS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[USERS]    Script Date: 24/3/2024 14:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[USERS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[email] [varchar](100) NOT NULL,
	[pass] [varchar](20) NOT NULL,
	[nombre] [varchar](50) NULL,
	[apellido] [varchar](50) NULL,
	[urlImagenPerfil] [varchar](500) NULL,
	[admin] [bit] NOT NULL,
	[fechaNacimiento] [date] NULL
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[USERS] ADD  DEFAULT ((0)) FOR [admin]
GO
/****** Object:  StoredProcedure [dbo].[StoredAgregar]    Script Date: 24/3/2024 14:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[StoredAgregar]

@Codigo varchar(50),
@Nombre varchar(50),
@Descripcion varchar(150),
@IdMarca int,
@IdCategoria int,
@ImagenUrl varchar(1000),
@Precio money,
@Activo bit
as
Insert into ARTICULOS 
(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio, Activo) 
values
(@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio, @Activo)
GO
/****** Object:  StoredProcedure [dbo].[StoredAgregarCategoria]    Script Date: 24/3/2024 14:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[StoredAgregarCategoria]
@Categoria varchar(50)
as
Insert into CATEGORIAS
(Descripcion)
values
(@Categoria)
GO
/****** Object:  StoredProcedure [dbo].[StoredAgregarconreturn]    Script Date: 24/3/2024 14:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[StoredAgregarconreturn]

@Codigo varchar(50),
@Nombre varchar(50),
@Descripcion varchar(150),
@IdMarca int,
@IdCategoria int,
@ImagenUrl varchar(1000),
@Precio money,
@Activo bit

as
Insert into ARTICULOS 
(Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio, Activo) output inserted.id 
values
(@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio, @Activo)
GO
/****** Object:  StoredProcedure [dbo].[StoredAgregarFav]    Script Date: 24/3/2024 14:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[StoredAgregarFav]

@IdUser int,
@IdArticulo int

as
Insert into FAVORITOS
(IdUser, IdArticulo)
values
(@IdUser, @IdArticulo)
GO
/****** Object:  StoredProcedure [dbo].[StoredAgregarMarca]    Script Date: 24/3/2024 14:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create procedure [dbo].[StoredAgregarMarca]
@Marca varchar(50)
as
Insert into MARCAS
(Descripcion)
values
(@Marca)
GO
/****** Object:  StoredProcedure [dbo].[StoredAgregarUsuario]    Script Date: 24/3/2024 14:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[StoredAgregarUsuario]
@Email varchar(50),
@Pass varchar(20),
@Nombre varchar(50)
as
Insert into USERS (email, pass, nombre, apellido, urlImagenPerfil, admin, FechaNacimiento) output inserted.id values(@Email, @Pass, @Nombre, '', '',  0, '20221218 03:00:00 PM')
GO
/****** Object:  StoredProcedure [dbo].[StoredEliminar]    Script Date: 24/3/2024 14:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StoredEliminar] 
@IdUser int as 
DELETE FROM ARTICULOS WHERE Id = @IdUser;
GO
/****** Object:  StoredProcedure [dbo].[StoredEliminarCategoria]    Script Date: 24/3/2024 14:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StoredEliminarCategoria]
     @IdCategoriaEliminada int
AS   
    BEGIN    
        BEGIN  
		Update ARTICULOS SET
		IdCategoria = 1
		Where 
		IdCategoria = @IdCategoriaEliminada
        END  
        BEGIN  
		Delete From CATEGORIAS Where Id =  @IdCategoriaEliminada
       END  
    END
GO
/****** Object:  StoredProcedure [dbo].[StoredEliminarFav]    Script Date: 24/3/2024 14:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[StoredEliminarFav]
@IdUser int,
@IdArticulo int
as
DELETE FROM FAVORITOS WHERE IdUser = @IdUser And IdArticulo = @IdArticulo;
GO
/****** Object:  StoredProcedure [dbo].[StoredEliminarMarca]    Script Date: 24/3/2024 14:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StoredEliminarMarca]
    @IdMarcaEliminada int
AS   
    BEGIN    
        BEGIN  
		Update ARTICULOS SET
		IdMarca = 1
		Where 
		IdMarca = @IdMarcaEliminada
        END  
        BEGIN  
		Delete From MARCAS Where Id = @IdMarcaEliminada
       END  
    END
GO
/****** Object:  StoredProcedure [dbo].[StoredListar]    Script Date: 24/3/2024 14:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[StoredListar] as Select A.Id, Codigo, Nombre, A.Descripcion, ImagenUrl, Precio, C.Id as IdCategoria, C.Descripcion as Categoria, M.Id as IdMarca, M.Descripcion as Marca, A.Activo from 
ARTICULOS A, CATEGORIAS C, MARCAS M Where A.IdCategoria = C.Id And A.IdMarca = M.Id
GO
/****** Object:  StoredProcedure [dbo].[StoredListarActivos]    Script Date: 24/3/2024 14:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[StoredListarActivos] as
Select A.Id, Codigo, Nombre, A.Descripcion, ImagenUrl, Precio, C.Id as IdCategoria, C.Descripcion as Categoria, M.Id as IdMarca, M.Descripcion as Marca, A.Activo from 
ARTICULOS A, CATEGORIAS C, MARCAS M Where A.IdCategoria = C.Id And A.IdMarca = M.Id AND A.Activo like 1
GO
/****** Object:  StoredProcedure [dbo].[StoredListarFav]    Script Date: 24/3/2024 14:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StoredListarFav] 
@IdUser int as 
Select 
A.Id, 
Codigo, 
Nombre, 
A.Descripcion, 
ImagenUrl, 
Precio, 
C.Id as IdCategoria, 
C.Descripcion as Categoria, 
M.Id as IdMarca, 
M.Descripcion as Marca, 
A.Activo

from 
ARTICULOS A, 
CATEGORIAS C, 
MARCAS M, 
FAVORITOS F

Where 
A.IdCategoria = C.Id 
And 
A.IdMarca = M.Id
And
IdUser = @IdUser
And
A.Id = F.IdArticulo;
GO
/****** Object:  StoredProcedure [dbo].[StoredListarId]    Script Date: 24/3/2024 14:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[StoredListarId]
@id int 
as
Select A.Id, Codigo, Nombre, A.Descripcion, ImagenUrl, Precio, C.Id as IdCategoria, C.Descripcion as Categoria, M.Id as IdMarca, M.Descripcion as Marca, A.Activo from 
ARTICULOS A, CATEGORIAS C, MARCAS M Where A.IdCategoria = C.Id And A.IdMarca = M.Id And A.Id= @id;
GO
/****** Object:  StoredProcedure [dbo].[StoredListarInactivos]    Script Date: 24/3/2024 14:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create procedure [dbo].[StoredListarInactivos] as
Select A.Id, Codigo, Nombre, A.Descripcion, ImagenUrl, Precio, C.Id as IdCategoria, C.Descripcion as Categoria, M.Id as IdMarca, M.Descripcion as Marca, A.Activo from 
ARTICULOS A, CATEGORIAS C, MARCAS M Where A.IdCategoria = C.Id And A.IdMarca = M.Id AND A.Activo like 0
GO
/****** Object:  StoredProcedure [dbo].[StoredModificar]    Script Date: 24/3/2024 14:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[StoredModificar]

@Id int,
@Codigo varchar(50),
@Nombre varchar(50),
@Descripcion varchar(150),
@IdMarca int,
@IdCategoria int,
@ImagenUrl varchar(1000),
@Precio money,
@Activo bit
as
update ARTICULOS set
Codigo = @Codigo, 
Nombre = @Nombre, 
Descripcion = @Descripcion, 
IdMarca = @IdMarca, 
IdCategoria = @IdCategoria,
ImagenUrl = @ImagenUrl,
Precio = @Precio,
Activo = @Activo
Where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[StoredModificarCategoria]    Script Date: 24/3/2024 14:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[StoredModificarCategoria]
@Id int,
@Categoria varchar(50)
as
update CATEGORIAS set
Descripcion = @Categoria
Where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[StoredModificarconreturn]    Script Date: 24/3/2024 14:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[StoredModificarconreturn]

@Id int,
@Codigo varchar(50),
@Nombre varchar(50),
@Descripcion varchar(150),
@IdMarca int,
@IdCategoria int,
@ImagenUrl varchar(1000),
@Precio money,
@Activo bit
as
update ARTICULOS set
Codigo = @Codigo, 
Nombre = @Nombre, 
Descripcion = @Descripcion, 
IdMarca = @IdMarca, 
IdCategoria = @IdCategoria,
ImagenUrl = @ImagenUrl,
Precio = @Precio,
Activo = @Activo
OUTPUT inserted.Id
Where Id = @Id
GO
/****** Object:  StoredProcedure [dbo].[StoredModificarMarca]    Script Date: 24/3/2024 14:21:55 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[StoredModificarMarca]
@Id int,
@Marca varchar(50)
as
update MARCAS set
Descripcion = @Marca
Where Id = @Id
GO
