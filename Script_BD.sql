CREATE DATABASE COPRODA;

USE COPRODA;

CREATE TABLE TipoDocumento (
	IdTipoDocumento NVARCHAR(6) PRIMARY KEY
	,TipoDocumento NVARCHAR(50)
	,Descripcion NVARCHAR(50)
	)

CREATE TABLE Usuario (
	Idusuario INT identity PRIMARY KEY
	,TipoUsuario NVARCHAR(50)
	,Nombre NVARCHAR(50)
	,Apellido NVARCHAR(50)
	,IdTipoDocumento NVARCHAR(6)
	,DocumentoIdentidad NVARCHAR(20)
	,Telefono NVARCHAR(10)
	,Celular NVARCHAR(10)
	,Usuario NVARCHAR(15)
	,ClaveAcceso NVARCHAR(100)
	,EstadoUsuario NVARCHAR(20)
	,CreadoPor NVARCHAR(15)
	,FechaCreacion DATETIME
	,ModificadoPor NVARCHAR(15)
	,FechaModificacion DATETIME
	,CONSTRAINT FK_TipoDocumento FOREIGN KEY (IdTipoDocumento) REFERENCES TipoDocumento(IdTipoDocumento)
	)

CREATE TABLE TipoCliente (
	IdTipoCliente NVARCHAR(6) PRIMARY KEY
	,TipoCliente NVARCHAR(50)
	,Decripcion NVARCHAR(50)
	)

CREATE TABLE Cliente (
	IdCliente INT identity PRIMARY KEY
	,IdTipoCliente NVARCHAR(6)
	,Nombre NVARCHAR(50)
	,Apellido NVARCHAR(50)
	,IdTipoDocumento NVARCHAR(6)
	,DocumentoIdentidad NVARCHAR(20)
	,RazonSocial NVARCHAR(50)
	,RUC NVARCHAR(10)
	,Telefono NVARCHAR(10)
	,Celular NVARCHAR(10)
	,Email NVARCHAR(100)
	,EstadoCliente NVARCHAR(20)
	,CreadoPor NVARCHAR(15)
	,FechaCreacion DATETIME
	,ModificadoPor NVARCHAR(15)
	,FechaModificacion DATETIME
	,CONSTRAINT FK_TipoDocumento2 FOREIGN KEY (IdTipoDocumento) REFERENCES TipoDocumento(IdTipoDocumento)
	,CONSTRAINT FK_TipoCliente FOREIGN KEY (IdTipoCliente) REFERENCES TipoCliente(IdTipoCliente)
	)

CREATE TABLE Direccion (
	IdDireccion INT identity PRIMARY KEY
	,IdCliente INT
	,NombreDireccion NVARCHAR(50)
	,Calle1 NVARCHAR(50)
	,Calle2 NVARCHAR(50)
	,Distrito NVARCHAR(50)
	,Departamento NVARCHAR(50)
	,Provincia NVARCHAR(50)
	,EstadoDireccion NVARCHAR(20)
	,CreadoPor NVARCHAR(15)
	,FechaCreacion DATETIME
	,ModificadoPor NVARCHAR(15)
	,FechaModificacion DATETIME
	,CONSTRAINT FK_Cliente FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente)
	)

CREATE TABLE Proovedor (
	IdProveedor INT identity PRIMARY KEY
	,Nombre NVARCHAR(50)
	,Apellido NVARCHAR(50)
	,RUC NVARCHAR(10)
	,IdTipoDocumento NVARCHAR(6)
	,DocumentoIdentidad NVARCHAR(20)
	,IdDireccion INT
	,Telefono NVARCHAR(10)
	,Celular NVARCHAR(10)
	,Email NVARCHAR(100)
	,EstadoProveedor NVARCHAR(20)
	,CreadoPor NVARCHAR(15)
	,FechaCreacion DATETIME
	,ModificadoPor NVARCHAR(15)
	,FechaModificacion DATETIME
	,CONSTRAINT FK_TipoDocumento3 FOREIGN KEY (IdTipoDocumento) REFERENCES TipoDocumento(IdTipoDocumento)
	,CONSTRAINT FK_Direccion FOREIGN KEY (IdDireccion) REFERENCES Direccion(IdDireccion)
	)

CREATE TABLE Pedido (
	IdPedido INT identity PRIMARY KEY
	,NumeroPedido INT
	,IdUsuario INT
	,IdCliente INT
	,DireccionFacturacion NVARCHAR(50)
	,IdDireccionEntrega INT
	,TipoEntrega NVARCHAR(50)
	,FechaEntrega DATETIME
	,EstadoPedido NVARCHAR(20)
	,FechaCambioEstado DATETIME
	,CreadoPor NVARCHAR(15)
	,FechaCreacion DATETIME
	,ModificadoPor NVARCHAR(15)
	,FechaModificacion DATETIME
	,CONSTRAINT FK_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
	,CONSTRAINT FK_Cliente2 FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente)
	,CONSTRAINT FK_DireccionEntrega FOREIGN KEY (IdDireccionEntrega) REFERENCES Direccion(IdDireccion)
	)

CREATE TABLE TipoComprobante (
	IdTipoComprobante NVARCHAR(6) PRIMARY KEY
	,TipoComprobante NVARCHAR(50)
	,Descripcion NVARCHAR(50)
	)

CREATE TABLE TipoTransaccion (
	IdTipoTransaccion NVARCHAR(6) PRIMARY KEY
	,TipoTransaccion NVARCHAR(50)
	,Descripcion NVARCHAR(50)
	)

CREATE TABLE ComprobantePago (
	IdComprobantePago INT identity PRIMARY KEY
	,IdPedido INT
	,IdCliente INT
	,IdTipoComprobantePago NVARCHAR(6)
	,IdTipoTransaccion NVARCHAR(6)
	,FechaEmision DATETIME
	,FechaVencimiente DATETIME
	,FormaPago NVARCHAR(50)
	,Estado NVARCHAR(20)
	,Monto MONEY
	,CreadoPor NVARCHAR(15)
	,FechaCreacion DATETIME
	,ModificadoPor NVARCHAR(15)
	,FechaModificacion DATETIME
	,CONSTRAINT FK_Pedido FOREIGN KEY (IdPedido) REFERENCES Pedido(IdPedido)
	,CONSTRAINT FK_Cliente4 FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente)
	,CONSTRAINT FK_TipoComprobantePago FOREIGN KEY (IdTipoComprobantePago) REFERENCES TipoComprobante(IdTipoComprobante)
	,CONSTRAINT FK_TipoTransaccion FOREIGN KEY (IdTipoTransaccion) REFERENCES TipoTransaccion(IdTipoTransaccion)
	)

CREATE TABLE Producto (
	IdProducto INT identity PRIMARY KEY
	,ImagenProducto IMAGE
	,Nombre NVARCHAR(100)
	,NombreCorto NVARCHAR(50)
	,Descripcion NVARCHAR(50)
	,Marca NVARCHAR(50)
	,Presentacion NVARCHAR(50)
	,UnidadMedida NVARCHAR(10)
	,PrecioUnidadMedida MONEY
	,UnidadCompra NVARCHAR(10)
	,PrecioUnidadCompra MONEY
	,Estado NVARCHAR(20)
	,CreadoPor NVARCHAR(15)
	,FechaCreacion DATETIME
	,ModificadoPor NVARCHAR(15)
	,FechaModificacion DATETIME
	)

CREATE TABLE PedidoProducto (
	IdPedidoProducto INT identity PRIMARY KEY
	,IdPedido INT
	,IdProducto INT
	,Cantidad DECIMAL(10, 2)
	,UnidadMedida NVARCHAR(10)
	,PrecioUnidadMedida MONEY
	,UnidadCompra NVARCHAR(10)
	,PrecioUnidadCompra MONEY
	,CantidadEntregada DECIMAL(10, 2)
	,CreadoPor NVARCHAR(15)
	,FechaCreacion DATETIME
	,ModificadoPor NVARCHAR(15)
	,FechaModificacion DATETIME
	,CONSTRAINT FK_Producto FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto)
	)

CREATE TABLE Almacen (
	IdAlmacen INT identity PRIMARY KEY
	,IdProducto INT
	,Stock DECIMAL(10, 2)
	,StockMinimo DECIMAL(10, 2)
	,Estado NVARCHAR(20)
	,CreadoPor NVARCHAR(15)
	,FechaCreacion DATETIME
	,ModificadoPor NVARCHAR(15)
	,FechaModificacion DATETIME
	,CONSTRAINT FK_Producto2 FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto)
	)