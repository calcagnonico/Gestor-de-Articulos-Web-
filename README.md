# Gestor de Articulos Version Web

- Creado como proyecto final del curso de MaxiPrograma C# Nivel 3.
- Alumno: Nicolás Calcagno
- Profesor: Maximiliano Sar Fernandez

Se puede visitar el proyecto en:
http://gestordearticulos.somee.com/

## Consigna del trabajo
Tomando como punto de partida la aplicación creada para el trabajo final del Curso C# Nivel 2 (tranqui, sino lo hiciste luego aclaro), desarrollar una aplicación web destinada a un comercio o emprendimiento que quiera mostrar su catálogo de productos de cara a los potenciales clientes. La idea es contar con un portal al que se pueda acceder y navegar los productos ofrecidos, contando con distintos tipos de visualización como tarjetas, o listados, pantallas de detalles del producto, con un diseño ameno y pensado en la experiencia de usuario. Además el portal puede contar con filtros por descripción, marca, categoría, para mejorar la navegación dentro del sitio.

El portal debe contar con un login que permita acceder a un área de administración de productos. Esto permitirá que quien administre la aplicación pueda realizar modificaciones en los productos publicados. Desde ya que a estas pantallas solo debe tener acceso la persona que cuente con un usuario y contraseña habilitada y que el usuario sea de tipo admin.

Resumen de funcionalidades:
- Home con catálogo de productos y filtros.
- Pantalla de detalle de producto.
- Pantalla de Login.
- El resto de las funcionalidades se detallan a continuación.

Si no realizaste el TP del curso C# Nivel 2, a continuación están las especificaciones para la gestión de productos.

Las funcionalidades que deberá tener la aplicación serán:
- Listado de artículos (formato grilla).
- Búsqueda de artículos por distintos criterios.
- Agregar artículos.
- Modificar artículos.
- Eliminar artículos.
Toda ésta información deberá ser persistida en una base de datos ya existente, la cual se adjunta.

Los datos mínimos con los que deberá contar el artículo son los siguientes:
- Código de artículo.
- Nombre.
- Descripción.
- Marca (seleccionable de una lista desplegable).
- Categoría (seleccionable de una lista desplegable.
- Imagen.
- Precio.

Etapa 1: 
Construir las clases necesarias para el modelo de dicha aplicación junto a las pantallas con las que contará, menú y su navegación.

Etapa 2: 
Construir la interacción con la base de datos y validaciones correspondiente para dar vida a la funcionalidad. Primero la parte de gestión y por último la parte de Login.

Etapa 3: 
Una vez finalizadas las etapas anteriores, considerar las funcionalidades opcionales.

Consideraciones:
- la DB es distitnta a la del curso Nivel 2, solo se suman tablas, pero cambia; generá esta nueva (tiene nombre distinto).
- la app debe manejar arquitectura en capas, manejo de excepciones y validaciones cuando corresponda.
- Si hiciste el TP Nivel 2, la idea es que reutilices las capas de dominio y negocio.

Funcionalidad Adicional [OPCIONAL]
Agregar un registro de cliente que permita darse de alta como user y poder agregar productos a favoritos. 

Se deberá contar con:

- Pantalla de registro. 
- Pantalla "Mi Perfil" para gestionar datos personales.
- Pantalla "Mis Favoritos" para revisar la lista de favs y poder quitarlos si ya no los quiere en el listado.

```js
use master
go
create database CATALOGO_WEB_DB
go
use CATALOGO_WEB_DB
go
USE [CATALOGO_WEB_DB]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MARCAS](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_MARCAS] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CATEGORIAS]    Script Date: 08/09/2019 10:32:14 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CATEGORIAS](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [Descripcion] [varchar](50) NULL,
 CONSTRAINT [PK_CATEGORIAS] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ARTICULOS]    Script Date: 08/09/2019 10:32:24 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
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
 CONSTRAINT [PK_ARTICULOS] PRIMARY KEY CLUSTERED 
(
    [Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
create table USERS(
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [email] [varchar](100) NOT NULL,
    [pass] [varchar](20) NOT NULL,
    [nombre] [varchar](50) NULL,
    [apellido] [varchar](50) NULL,
    [urlImagenPerfil] [varchar](500) NULL,
    [admin] [bit] NOT NULL DEFAULT 0
)
go
create table FAVORITOS(
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [IdUser] [int] NOT NULL,
    [IdArticulo] [int] NOT NULL
)
go
insert into MARCAS values ('Samsung'), ('Apple'), ('Sony'), ('Huawei'), ('Motorola')
insert into CATEGORIAS values ('Celulares'),('Televisores'), ('Media'), ('Audio')
insert into ARTICULOS values ('S01', 'Galaxy S10', 'Una canoa cara', 1, 1, 'https://images.samsung.com/is/image/samsung/assets/ar/p6_gro2/p6_initial_mktpd/smartphones/galaxy-s10/specs/galaxy-s10-plus_specs_design_colors_prism_black.jpg?$163_346_PNG$', 69.999),
('M03', 'Moto G Play 7ma Gen', 'Ya siete de estos?', 5, 1, 'https://www.motorola.cl/arquivos/moto-g7-play-img-product.png?v=636862863804700000', 15699),
('S99', 'Play 4', 'Ya no se cuantas versiones hay', 3, 3, 'sin_imagen_para_que_de_error....muejeje', 35000),
('S56', 'Bravia 55', 'Alta tele', 3, 2, 'https://intercompras.com/product_thumb_keepratio_2.php?img=images/product/SONY_KDL-55W950A.jpg&w=650&h=450', 49500),
('A23', 'Apple TV', 'lindo loro', 2, 3, 'https://store.storeimages.cdn-apple.com/4668/as-images.apple.com/is/rfb-apple-tv-4k?wid=1144&hei=1144&fmt=jpeg&qlt=80&.v=1513897159574', 7850)
insert into USERS (email, pass, admin) values ('admin@admin.com', 'admin', 1)
insert into USERS (email, pass, admin) values ('user@user.com', 'user', 0)
select * from ARTICULOS
```
## Consideraciones finales
Se agregaron algunas funcionalidades adicionales:
- Posibilidad de ordenar listas
- Posibilidad de Agregar, Editar y Eliminar -> Marcas y Categorias
- Confirmacion de registro a traves de codigo enviado por mail
- Se adjunta entre los archivos el script para generar la base de datos final que contiene los Stored Procedures para que funcione el programa
