CREATE DATABASE EYañezHumanAccess	
USE EYañezHumanAccess

CREATE TABLE Cliente
(
	IdCliente INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50),
	ApellidoPaterno VARCHAR(50),
	ApellidoMaterno VARCHAR(50)
)

CREATE TABLE Tienda
(
	IdTienda INT IDENTITY(1,1) PRIMARY KEY,
	Sucursal VARCHAR(50)
)

CREATE TABLE Pais
(
	IdPais INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50)
)

CREATE TABLE Estado
(
	IdEstado INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50),
	IdPais INT FOREIGN KEY REFERENCES Pais(IdPais)
)

CREATE TABLE Municipio
(
	IdMunicipio INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50),
	IdEstado INT FOREIGN KEY REFERENCES Estado(IdEstado)
)

CREATE TABLE Colonia
(
	IdColonia INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50),
	CodigoPostal VARCHAR(50),
	IdMunicipio INT FOREIGN KEY REFERENCES Municipio(IdMunicipio)
)

CREATE TABLE DireccionCliente
(
	IdDireccionCliente INT IDENTITY(1,1) PRIMARY KEY,
	Calle VARCHAR(50),
	NumeroExterior VARCHAR(50),
	NumeroInterior VARCHAR(50),
	IdColonia INT FOREIGN KEY REFERENCES Colonia(IdColonia),
	IdCliente INT FOREIGN KEY REFERENCES Cliente(IdCliente)
)

CREATE TABLE DireccionTienda
(
	IdDireccionTienda INT IDENTITY(1,1) PRIMARY KEY,
	Calle VARCHAR(50),
	NumeroExterior VARCHAR(50),
	NumeroInterior VARCHAR(50),
	IdColonia INT FOREIGN KEY REFERENCES Colonia(IdColonia),
	IdTienda INT FOREIGN KEY REFERENCES Tienda(IdTienda)
)

CREATE TABLE Articulo
(
	IdArticulo INT IDENTITY(1,1) PRIMARY KEY,	
	Codigo INT,
	Descripcion VARCHAR(50),
	Precio DECIMAL,
	Imagen VARCHAR(MAX),
	Stock INT,
	Nombre VARCHAR(50)
)

CREATE TABLE ArticuloTienda
(
	IdArticuloTienda INT IDENTITY(1,1) PRIMARY KEY,
	IdArticulo INT FOREIGN KEY REFERENCES Articulo(IdArticulo),
	IdTienda INT FOREIGN KEY REFERENCES Tienda(IdTienda),
	Fecha DATE
)

CREATE TABLE ClienteArticulo
(
	IdClienteArticulo INT IDENTITY(1,1) PRIMARY KEY,
	IdCliente INT FOREIGN KEY REFERENCES Cliente(IdCliente),
	IdArticulo INT FOREIGN KEY REFERENCES Articulo(IdArticulo),
	Fecha DATE
)

CREATE TABLE Rol
(
	IdRol INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50)
)

CREATE TABLE Usuario
(
	IdUsuario INT IDENTITY(1,1) PRIMARY KEY,
	Imagen VARCHAR(MAX),
	Email VARCHAR(150) UNIQUE,
	Password VARCHAR(50) UNIQUE,
	IdRol INT FOREIGN KEY REFERENCES Rol(IdRol),
	IdCliente INT FOREIGN KEY REFERENCES Cliente(IdCliente)
)

INSERT INTO [dbo].[Cliente]([Nombre],[ApellidoPaterno],[ApellidoMaterno])VALUES('Erick','Yañez','Aguilar')
INSERT INTO [dbo].[Cliente]([Nombre],[ApellidoPaterno],[ApellidoMaterno])VALUES('Monica','Zepeda','Sanchez')
INSERT INTO [dbo].[Cliente]([Nombre],[ApellidoPaterno],[ApellidoMaterno])VALUES('Victor','Suarez','Lopez')

INSERT INTO [dbo].[Tienda]([Sucursal])VALUES('Walmart Ecatepec')
INSERT INTO [dbo].[Tienda]([Sucursal])VALUES('Bodega Aurrera CDMX')
INSERT INTO [dbo].[Tienda]([Sucursal])VALUES('Soriana Toluca')

INSERT INTO [dbo].[Pais]([Nombre])VALUES('México')

INSERT INTO [dbo].[Estado]([Nombre],[IdPais])VALUES('CDMX',1)
INSERT INTO [dbo].[Estado]([Nombre],[IdPais])VALUES('Estado de México',1)

INSERT INTO [dbo].[Municipio]([Nombre],[IdEstado])VALUES('Gustavo A. Madero',1)
INSERT INTO [dbo].[Municipio]([Nombre],[IdEstado])VALUES('Miguel Hidalgo',1)
INSERT INTO [dbo].[Municipio]([Nombre],[IdEstado])VALUES('Ecatepec',2)
INSERT INTO [dbo].[Municipio]([Nombre],[IdEstado])VALUES('Toluca',2)

INSERT INTO [dbo].[Colonia]([Nombre],[CodigoPostal],[IdMunicipio])VALUES('Chalma de Guadalupe','55214',1)
INSERT INTO [dbo].[Colonia]([Nombre],[CodigoPostal],[IdMunicipio])VALUES('Churubusco Tepeyac Montevideo','55986',1)
INSERT INTO [dbo].[Colonia]([Nombre],[CodigoPostal],[IdMunicipio])VALUES('Lomas de chapultepec','55847',2)
INSERT INTO [dbo].[Colonia]([Nombre],[CodigoPostal],[IdMunicipio])VALUES('Polanco','52147',2)
INSERT INTO [dbo].[Colonia]([Nombre],[CodigoPostal],[IdMunicipio])VALUES('Ciudad Azteca','55147',3)
INSERT INTO [dbo].[Colonia]([Nombre],[CodigoPostal],[IdMunicipio])VALUES('San Agustin','55210',3)
INSERT INTO [dbo].[Colonia]([Nombre],[CodigoPostal],[IdMunicipio])VALUES('Altamirano','555874',4)
INSERT INTO [dbo].[Colonia]([Nombre],[CodigoPostal],[IdMunicipio])VALUES('5 de Mayo','55147',4)

INSERT INTO [dbo].[Articulo]([Codigo],[Descripcion],[Precio],[Imagen],[Stock],[Nombre])VALUES('52228','Pasta de dientes','45',NULL,20,'Pasta de dientes')
INSERT INTO [dbo].[Articulo]([Codigo],[Descripcion],[Precio],[Imagen],[Stock],[Nombre])VALUES('55484','Brocha','120',NULL,14,'Brocha')
INSERT INTO [dbo].[Articulo]([Codigo],[Descripcion],[Precio],[Imagen],[Stock],[Nombre])VALUES('53385','Balon','125',NULL,10,'Balon')
INSERT INTO [dbo].[Articulo]([Codigo],[Descripcion],[Precio],[Imagen],[Stock],[Nombre])VALUES('5518848','Control','1000',NULL,5,'Control')
INSERT INTO [dbo].[Articulo]([Codigo],[Descripcion],[Precio],[Imagen],[Stock],[Nombre])VALUES('5518848','Gitarra','1488',NULL,15,'Gitarra')

INSERT INTO [dbo].[ArticuloTienda]([IdArticulo],[IdTienda],[Fecha])VALUES(1,1,'2022-10-14')
INSERT INTO [dbo].[ArticuloTienda]([IdArticulo],[IdTienda],[Fecha])VALUES(3,1,'2022-11-20')
INSERT INTO [dbo].[ArticuloTienda]([IdArticulo],[IdTienda],[Fecha])VALUES(2,1,'2022-10-24')
INSERT INTO [dbo].[ArticuloTienda]([IdArticulo],[IdTienda],[Fecha])VALUES(4,2,'2022-02-15')
INSERT INTO [dbo].[ArticuloTienda]([IdArticulo],[IdTienda],[Fecha])VALUES(5,2,'2022-01-25')
INSERT INTO [dbo].[ArticuloTienda]([IdArticulo],[IdTienda],[Fecha])VALUES(2,2,'2022-03-10')
INSERT INTO [dbo].[ArticuloTienda]([IdArticulo],[IdTienda],[Fecha])VALUES(5,3,'2022-04-21')
INSERT INTO [dbo].[ArticuloTienda]([IdArticulo],[IdTienda],[Fecha])VALUES(3,3,'2022-03-02')
INSERT INTO [dbo].[ArticuloTienda]([IdArticulo],[IdTienda],[Fecha])VALUES(1,3,'2022-05-15')

INSERT INTO [dbo].[ClienteArticulo]([IdCliente],[IdArticulo],[Fecha])VALUES(1,1,'2023-01-10')
INSERT INTO [dbo].[ClienteArticulo]([IdCliente],[IdArticulo],[Fecha])VALUES(1,2,'2023-01-10')
INSERT INTO [dbo].[ClienteArticulo]([IdCliente],[IdArticulo],[Fecha])VALUES(2,3,'2023-01-11')
INSERT INTO [dbo].[ClienteArticulo]([IdCliente],[IdArticulo],[Fecha])VALUES(2,4,'2023-01-11')
INSERT INTO [dbo].[ClienteArticulo]([IdCliente],[IdArticulo],[Fecha])VALUES(3,5,'2023-01-12')
INSERT INTO [dbo].[ClienteArticulo]([IdCliente],[IdArticulo],[Fecha])VALUES(3,4,'2023-01-12')

INSERT INTO [dbo].[Rol]([Nombre])VALUES('Administrador')
INSERT INTO [dbo].[Rol]([Nombre])VALUES('Cliente')

INSERT INTO [dbo].[Usuario]([Imagen],[Email],[Password],[IdRol],[IdCliente])VALUES(NULL,'erickaguilar2d@gmail.com','Erick2000',2,1)
INSERT INTO [dbo].[Usuario]([Imagen],[Email],[Password],[IdRol],[IdCliente])VALUES(NULL,'mzepeda@gmail.com','Monica1875',2,2)
INSERT INTO [dbo].[Usuario]([Imagen],[Email],[Password],[IdRol],[IdCliente])VALUES(NULL,'vsuarez2d@gmail.com','Victor9856',2,3)
GO

CREATE PROCEDURE ClienteAdd
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@Calle VARCHAR(50),
@NumeroInterior VARCHAR(20),
@NumeroExterior VARCHAR(20),
@IdColonia INT,
@Imagen VARCHAR(MAX),
@Email VARCHAR(150),
@Password VARCHAR(50)
AS
	INSERT INTO [dbo].[Cliente]
           ([Nombre]
           ,[ApellidoPaterno]
           ,[ApellidoMaterno])
     VALUES
           (@Nombre
           ,@ApellidoPaterno
           ,@ApellidoMaterno)
	INSERT INTO [DireccionCliente]
           ([Calle]
           ,[NumeroInterior]
           ,[NumeroExterior]
           ,[IdColonia]
           ,[IdCliente])
     VALUES
           (@Calle
           ,@NumeroInterior
           ,@NumeroExterior
           ,@IdColonia
           ,@@IDENTITY)
	INSERT INTO [dbo].[Usuario]
           ([Imagen]
           ,[Email]
           ,[Password]
           ,[IdRol]
           ,[IdCliente])
     VALUES
           (@Imagen
           ,@Email
           ,@Password
           ,2
           ,@@IDENTITY)
GO

CREATE PROCEDURE ClienteGetAll '',''
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50)
AS
	SELECT Cliente.[IdCliente]
      ,Cliente.[Nombre]
      ,[ApellidoPaterno]
      ,[ApellidoMaterno]
	  ,DireccionCliente.[IdDireccionCliente]
	  ,DireccionCliente.[Calle]
      ,DireccionCliente.[NumeroInterior]
	  ,DireccionCliente.[NumeroExterior]
	  ,DireccionCliente.[IdColonia]
      ,Colonia.[Nombre] AS NombreColonia
      ,Colonia.[CodigoPostal]
      ,Colonia.[IdMunicipio]
	  ,Municipio.[Nombre] AS NombreMunicipio
	  ,Municipio.[IdEstado]
	  ,Estado.[Nombre] AS NombreEstado
	  ,Estado.[IdPais]
	  ,Pais.[Nombre] AS NombrePais
	  ,Usuario.[Email]
	  ,Usuario.[Password]
	  ,Usuario.[Imagen]
	  ,Usuario.[IdRol]
	  ,Rol.[Nombre] AS NombreRol
  FROM [dbo].[Cliente]
	INNER JOIN Usuario ON Cliente.IdCliente = Usuario.IdCliente
	INNER JOIN Rol ON Usuario.IdRol = Rol.IdRol
    INNER JOIN DireccionCliente ON Cliente.IdCliente = DireccionCliente.IdCliente
	INNER JOIN Colonia ON DireccionCliente.IdColonia = Colonia.IdColonia
	INNER JOIN Municipio ON Colonia.IdMunicipio = Municipio.IdMunicipio
	INNER JOIN Estado ON Municipio.IdEstado = Estado.IdEstado
	INNER JOIN Pais ON Estado.IdPais = Pais.IdPais
	WHERE Cliente.Nombre LIKE '%' + @Nombre + '%' AND Cliente.ApellidoPaterno LIKE '%' + @ApellidoPaterno
GO

CREATE PROCEDURE ClienteGetById 
@IdCliente INT
AS
	SELECT Cliente.[IdCliente]
      ,Cliente.[Nombre]
      ,[ApellidoPaterno]
      ,[ApellidoMaterno]
	  ,DireccionCliente.[IdDireccionCliente]
	  ,DireccionCliente.[Calle]
      ,DireccionCliente.[NumeroInterior]
	  ,DireccionCliente.[NumeroExterior]
	  ,DireccionCliente.[IdColonia]
      ,Colonia.[Nombre] AS NombreColonia
      ,Colonia.[CodigoPostal]
      ,Colonia.[IdMunicipio]
	  ,Municipio.[Nombre] AS NombreMunicipio
	  ,Municipio.[IdEstado]
	  ,Estado.[Nombre] AS NombreEstado
	  ,Estado.[IdPais]
	  ,Pais.[Nombre] AS NombrePais
	  ,Usuario.[Email]
	  ,Usuario.[Password]
	  ,Usuario.[Imagen]
	  ,Usuario.[IdRol]
	  ,Rol.[Nombre] AS NombreRol
  FROM [dbo].[Cliente]
	INNER JOIN Usuario ON Cliente.IdCliente = Usuario.IdCliente
	INNER JOIN Rol ON Usuario.IdRol = Rol.IdRol
    INNER JOIN DireccionCliente ON Cliente.IdCliente = DireccionCliente.IdCliente
	INNER JOIN Colonia ON DireccionCliente.IdColonia = Colonia.IdColonia
	INNER JOIN Municipio ON Colonia.IdMunicipio = Municipio.IdMunicipio
	INNER JOIN Estado ON Municipio.IdEstado = Estado.IdEstado
	INNER JOIN Pais ON Estado.IdPais = Pais.IdPais
		WHERE Cliente.IdCliente = @IdCliente
GO

CREATE PROCEDURE ClienteUpdate
@IdCliente INT,
@Nombre VARCHAR(50),
@ApellidoPaterno VARCHAR(50),
@ApellidoMaterno VARCHAR(50),
@Calle VARCHAR(50),
@NumeroInterior VARCHAR(20),
@NumeroExterior VARCHAR(20),
@IdColonia INT,
@Imagen VARCHAR(MAX),
@Email VARCHAR(150),
@Password VARCHAR(50)
AS
	UPDATE [dbo].[Cliente]
   SET [Nombre] = @Nombre
      ,[ApellidoPaterno] = @ApellidoPaterno
      ,[ApellidoMaterno] = @ApellidoMaterno
	  WHERE Cliente.IdCliente = @IdCliente

	UPDATE [dbo].[DireccionCliente]
   SET [Calle] = @Calle
      ,[NumeroExterior] = @NumeroExterior
      ,[NumeroInterior] = @NumeroInterior
      ,[IdColonia] = @IdColonia
	WHERE DireccionCliente.IdCliente = @IdCliente

	UPDATE [dbo].[Usuario]
   SET [Imagen] = @Imagen
      ,[Email] = @Email
      ,[Password] = @Password
      ,[IdRol] = 2
	WHERE Usuario.IdCliente = @IdCliente
GO

CREATE PROCEDURE ClienteDelete
@IdCliente INT
AS
	DELETE FROM [dbo].[Cliente]
	WHERE Cliente.IdCliente = @IdCliente
	DELETE FROM [dbo].[DireccionCliente]
    WHERE DireccionCliente.IdCliente = @IdCliente
	DELETE FROM [dbo].[Usuario]
      WHERE Usuario.IdCliente = @IdCliente
GO

CREATE PROCEDURE PaisGetAll
AS
	SELECT [IdPais]
		  ,[Nombre]
	FROM [Pais]
GO

CREATE PROCEDURE EstadoGetByIdPais
@IdPais INT
AS
	SELECT [IdEstado]
      ,[Nombre]
      ,[IdPais]
  FROM [Estado]
  WHERE Estado.[IdPais] = @IdPais
GO

CREATE PROCEDURE MunicipioGetByIdEstado
@IdEstado INT
AS
	SELECT [IdMunicipio]
      ,[Nombre]
      ,[IdEstado]
  FROM [Municipio]
  WHERE Municipio.[IdEstado] = @IdEstado
GO

CREATE PROCEDURE ColoniaGetByIdMunicipio
@IdMunicipio INT
AS
	SELECT [IdColonia]
      ,[Nombre]
      ,[CodigoPostal]
      ,[IdMunicipio]
  FROM [Colonia]
  WHERE Colonia.[IdMunicipio] = @IdMunicipio
GO

CREATE PROCEDURE TiendaAdd
@Sucursal VARCHAR(50),
@Calle VARCHAR(50),
@NumeroInterior VARCHAR(20),
@NumeroExterior VARCHAR(20),
@IdColonia INT
AS
	INSERT INTO [dbo].[Tienda]
           ([Sucursal])
     VALUES
           (@Sucursal)
	INSERT INTO [DireccionTienda]
           ([Calle]
           ,[NumeroInterior]
           ,[NumeroExterior]
           ,[IdColonia]
           ,[IdTienda])
     VALUES
           (@Calle
           ,@NumeroInterior
           ,@NumeroExterior
           ,@IdColonia
           ,@@IDENTITY)
GO

CREATE PROCEDURE TiendaGetAll 
@Sucursal VARCHAR(50)
AS
	SELECT Tienda.[IdTienda]
      ,[Sucursal]
	  ,DireccionTienda.[IdDireccionTienda]
	  ,DireccionTienda.[Calle]
      ,DireccionTienda.[NumeroInterior]
	  ,DireccionTienda.[NumeroExterior]
	  ,DireccionTienda.[IdColonia]
      ,Colonia.[Nombre] AS NombreColonia
      ,Colonia.[CodigoPostal]
      ,Colonia.[IdMunicipio]
	  ,Municipio.[Nombre] AS NombreMunicipio
	  ,Municipio.[IdEstado]
	  ,Estado.[Nombre] AS NombreEstado
	  ,Estado.[IdPais]
	  ,Pais.[Nombre] AS NombrePais
  FROM [dbo].[Tienda]
    INNER JOIN DireccionTienda ON Tienda.IdTienda = DireccionTienda.IdTienda
	INNER JOIN Colonia ON DireccionTienda.IdColonia = Colonia.IdColonia
	INNER JOIN Municipio ON Colonia.IdMunicipio = Municipio.IdMunicipio
	INNER JOIN Estado ON Municipio.IdEstado = Estado.IdEstado
	INNER JOIN Pais ON Estado.IdPais = Pais.IdPais
	WHERE Tienda.Sucursal LIKE '%' + @Sucursal + '%' 
GO

CREATE PROCEDURE TiendaGetById 
@IdTienda INT
AS
	SELECT Tienda.[IdTienda]
      ,[Sucursal]
	  ,DireccionTienda.[IdDireccionTienda]
	  ,DireccionTienda.[Calle]
      ,DireccionTienda.[NumeroInterior]
	  ,DireccionTienda.[NumeroExterior]
	  ,DireccionTienda.[IdColonia]
      ,Colonia.[Nombre] AS NombreColonia
      ,Colonia.[CodigoPostal]
      ,Colonia.[IdMunicipio]
	  ,Municipio.[Nombre] AS NombreMunicipio
	  ,Municipio.[IdEstado]
	  ,Estado.[Nombre] AS NombreEstado
	  ,Estado.[IdPais]
	  ,Pais.[Nombre] AS NombrePais
  FROM [dbo].[Tienda]
    INNER JOIN DireccionTienda ON Tienda.IdTienda = DireccionTienda.IdTienda
	INNER JOIN Colonia ON DireccionTienda.IdColonia = Colonia.IdColonia
	INNER JOIN Municipio ON Colonia.IdMunicipio = Municipio.IdMunicipio
	INNER JOIN Estado ON Municipio.IdEstado = Estado.IdEstado
	INNER JOIN Pais ON Estado.IdPais = Pais.IdPais
		WHERE Tienda.IdTienda = @IdTienda
GO

CREATE PROCEDURE TiendaUpdate
@IdTienda INT,
@Sucursal VARCHAR(50),
@Calle VARCHAR(50),
@NumeroInterior VARCHAR(20),
@NumeroExterior VARCHAR(20),
@IdColonia INT
AS
	UPDATE [dbo].[Tienda]
   SET [Sucursal] = @Sucursal
	WHERE Tienda.IdTienda = @IdTienda

	UPDATE [dbo].[DireccionTienda]
   SET [Calle] = @Calle
      ,[NumeroExterior] = @NumeroExterior
      ,[NumeroInterior] = @NumeroInterior
      ,[IdColonia] = @IdColonia
	WHERE DireccionTienda.IdTienda = @IdTienda
GO

CREATE PROCEDURE TiendaDelete
@IdTienda INT
AS
	DELETE FROM [dbo].[Tienda]
	WHERE Tienda.IdTienda = @IdTienda
	DELETE FROM [dbo].[DireccionTienda]
    WHERE DireccionTienda.IdTienda = @IdTienda
	DELETE FROM [dbo].[Usuario]
GO

CREATE PROCEDURE ArticuloAdd
@Nombre VARCHAR(50),
@Codigo INT,
@Descripcion VARCHAR(50),
@Precio DECIMAL,
@Imagen VARCHAR(MAX),
@Stock INT
AS
	INSERT INTO [dbo].[Articulo]
           ([Codigo]
           ,[Descripcion]
           ,[Precio]
           ,[Imagen]
           ,[Stock]
		   ,[Nombre])
     VALUES
           (@Nombre
		   ,@Codigo
           ,@Descripcion
           ,@Precio
           ,@Imagen
           ,@Stock)
GO

ALTER PROCEDURE ArticuloGetAll
@Nombre VARCHAR(50)
AS
	SELECT [IdArticulo]
	  ,[Nombre]
      ,[Codigo]
      ,[Descripcion]
      ,[Precio]
      ,[Imagen]
      ,[Stock]
	  ,0 AS IdTienda
	  ,'' AS Sucursal
  FROM [dbo].[Articulo]
  WHERE Articulo.Nombre LIKE '%' + @Nombre + '%' 
GO

ALTER PROCEDURE ArticuloGetById
@IdArticulo INT
AS
	SELECT [IdArticulo]
	  ,[Nombre]
      ,[Codigo]
      ,[Descripcion]
      ,[Precio]
      ,[Imagen]
      ,[Stock]
	   ,0 AS IdTienda
	  ,'' AS Sucursal
  FROM [dbo].[Articulo]
  WHERE IdArticulo = @IdArticulo
GO

CREATE PROCEDURE ArticuloUpdate
@IdArticulo INT,
@Nombre VARCHAR(50),
@Codigo INT,
@Descripcion VARCHAR(50),
@Precio DECIMAL,
@Imagen VARCHAR(MAX),
@Stock INT
AS
	UPDATE [dbo].[Articulo]
   SET [Codigo] = @Codigo
      ,[Descripcion] = @Descripcion
      ,[Precio] = @Precio
      ,[Imagen] = @Imagen
      ,[Stock] = @Stock
	  ,[Nombre] = @Nombre
	WHERE IdArticulo = @IdArticulo
GO

CREATE PROCEDURE ArticuloDelete
@IdArticulo INT
AS
	DELETE FROM [dbo].[Articulo]
      WHERE IdArticulo = @IdArticulo
GO

CREATE PROCEDURE ArticulosTiendaAgregados 1
@IdTienda INT
AS
	SELECT [IdArticuloTienda]
      ,ArticuloTienda.[IdArticulo]
	  ,[Nombre]
      ,[Codigo]
      ,[Descripcion]
      ,[Precio]
      ,[Imagen]
      ,[Stock]
      ,ArticuloTienda.[IdTienda]
	  ,Tienda.[Sucursal]
      ,[Fecha]
	FROM [dbo].[ArticuloTienda]
	INNER JOIN Articulo ON ArticuloTienda.IdArticulo = Articulo.IdArticulo
	INNER JOIN Tienda ON ArticuloTienda.IdTienda = Tienda.IdTienda
	WHERE Tienda.IdTienda = @IdTienda
GO

AlTER PROCEDURE ArticulosTiendaNoAgregados 1
@IdTienda INT
AS
	SELECT [IdArticulo]
	  ,[Nombre]
      ,[Codigo]
      ,[Descripcion]
      ,[Precio]
      ,[Imagen]
      ,[Stock]
	  ,0 AS IdArticuloTienda
	  ,NULL AS Fecha
	  ,0 AS IdTienda
	  ,'' AS Sucursal
  FROM [dbo].[Articulo]
  where Articulo.IdArticulo NOT IN 
		   (SELECT ArticuloTienda.IdArticulo
		     FROM ArticuloTienda
			 WHERE ArticuloTienda.IdTienda = @IdTienda)
GO	   

CREATE PROCEDURE ArticuloTiendaAdd
@IdTienda INT,
@IdArticulo INT
AS
     INSERT INTO [dbo].[ArticuloTienda]
           ([IdArticulo]
           ,[IdTienda]
           ,[Fecha])
     VALUES
           (@IdArticulo
           ,@IdTienda
           ,GETDATE())
GO

ALTER PROCEDURE ArticuloTiendaDelete 
@IdTienda INT,
@IdArticulo INT
AS
    DELETE FROM ArticuloTienda
      WHERE IdTienda = @IdTienda AND IdArticulo = @IdArticulo
GO

CREATE PROCEDURE LoginUser 
@Email VARCHAR(50)
AS
	SELECT [IdUsuario]
      ,[Imagen]
      ,[Email]
      ,[Password]
      ,Rol.[IdRol]
	  ,Rol.[Nombre]
      ,[IdCliente]
  FROM [dbo].[Usuario]
	  INNER JOIN Rol ON Usuario.IdRol = Rol.IdRol	  
	WHERE Email = @Email 
GO