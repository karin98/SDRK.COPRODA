CREATE DATABASE COPRODA;

USE COPRODA;

CREATE TABLE TipoDocumento (
	IdTipoDocumento VARCHAR(6) PRIMARY KEY
	,TipoDocumento VARCHAR(50)
	,Descripcion VARCHAR(50)
	);

CREATE TABLE Usuario (
	Idusuario INT AUTO_INCREMENT PRIMARY KEY
	,TipoUsuario VARCHAR(50)
	,Nombre VARCHAR(50)
	,Apellido VARCHAR(50)
	,IdTipoDocumento VARCHAR(6)
	,DocumentoIdentidad VARCHAR(20)
	,Telefono VARCHAR(10)
	,Celular VARCHAR(10)
	,Usuario VARCHAR(15)
	,ClaveAcceso VARCHAR(100)
	,EstadoUsuario VARCHAR(20)
	,CreadoPor VARCHAR(15)
	,FechaCreacion DATETIME
	,ModificadoPor VARCHAR(15)
	,FechaModificacion DATETIME
	,CONSTRAINT FK_TipoDocumento FOREIGN KEY (IdTipoDocumento) REFERENCES TipoDocumento(IdTipoDocumento)
	);

CREATE TABLE TipoCliente (
	IdTipoCliente VARCHAR(6) PRIMARY KEY
	,TipoCliente VARCHAR(50)
	,Decripcion VARCHAR(50)
	);

CREATE TABLE Cliente (
	IdCliente INT AUTO_INCREMENT PRIMARY KEY
	,IdTipoCliente VARCHAR(6)
	,Nombre VARCHAR(50)
	,Apellido VARCHAR(50)
	,IdTipoDocumento VARCHAR(6)
	,DocumentoIdentidad VARCHAR(20)
	,RazonSocial VARCHAR(50)
	,RUC VARCHAR(10)
	,Telefono VARCHAR(10)
	,Celular VARCHAR(10)
	,Email VARCHAR(100)
	,EstadoCliente VARCHAR(20)
	,CreadoPor VARCHAR(15)
	,FechaCreacion DATETIME
	,ModificadoPor VARCHAR(15)
	,FechaModificacion DATETIME
	,CONSTRAINT FK_TipoDocumento2 FOREIGN KEY (IdTipoDocumento) REFERENCES TipoDocumento(IdTipoDocumento)
	,CONSTRAINT FK_TipoCliente FOREIGN KEY (IdTipoCliente) REFERENCES TipoCliente(IdTipoCliente)
	);

CREATE TABLE Direccion (
	IdDireccion INT AUTO_INCREMENT PRIMARY KEY
	,IdCliente INT
	,NombreDireccion VARCHAR(50)
	,Calle1 VARCHAR(50)
	,Calle2 VARCHAR(50)
	,Distrito VARCHAR(50)
	,Departamento VARCHAR(50)
	,Provincia VARCHAR(50)
	,EstadoDireccion VARCHAR(20)
	,CreadoPor VARCHAR(15)
	,FechaCreacion DATETIME
	,ModificadoPor VARCHAR(15)
	,FechaModificacion DATETIME
	,CONSTRAINT FK_Cliente FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente)
	);

CREATE TABLE Proovedor (
	IdProveedor INT AUTO_INCREMENT PRIMARY KEY
	,Nombre VARCHAR(50)
	,Apellido VARCHAR(50)
	,RUC VARCHAR(10)
	,IdTipoDocumento VARCHAR(6)
	,DocumentoIdentidad VARCHAR(20)
	,IdDireccion INT
	,Telefono VARCHAR(10)
	,Celular VARCHAR(10)
	,Email VARCHAR(100)
	,EstadoProveedor VARCHAR(20)
	,CreadoPor VARCHAR(15)
	,FechaCreacion DATETIME
	,ModificadoPor VARCHAR(15)
	,FechaModificacion DATETIME
	,CONSTRAINT FK_TipoDocumento3 FOREIGN KEY (IdTipoDocumento) REFERENCES TipoDocumento(IdTipoDocumento)
	,CONSTRAINT FK_Direccion FOREIGN KEY (IdDireccion) REFERENCES Direccion(IdDireccion)
	);

CREATE TABLE Pedido (
	IdPedido INT AUTO_INCREMENT PRIMARY KEY
	,NumeroPedido INT
	,IdUsuario INT
	,IdCliente INT
	,DireccionFacturacion VARCHAR(50)
	,IdDireccionEntrega INT
	,TipoEntrega VARCHAR(50)
	,FechaEntrega DATETIME
	,EstadoPedido VARCHAR(20)
	,FechaCambioEstado DATETIME
	,CreadoPor VARCHAR(15)
	,FechaCreacion DATETIME
	,ModificadoPor VARCHAR(15)
	,FechaModificacion DATETIME
	,CONSTRAINT FK_Usuario FOREIGN KEY (IdUsuario) REFERENCES Usuario(IdUsuario)
	,CONSTRAINT FK_Cliente2 FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente)
	,CONSTRAINT FK_DireccionEntrega FOREIGN KEY (IdDireccionEntrega) REFERENCES Direccion(IdDireccion)
	);

CREATE TABLE TipoComprobante (
	IdTipoComprobante VARCHAR(6) PRIMARY KEY
	,TipoComprobante VARCHAR(50)
	,Descripcion VARCHAR(50)
	);

CREATE TABLE TipoTransaccion (
	IdTipoTransaccion VARCHAR(6) PRIMARY KEY
	,TipoTransaccion VARCHAR(50)
	,Descripcion VARCHAR(50)
	);

CREATE TABLE ComprobantePago (
	IdComprobantePago INT AUTO_INCREMENT PRIMARY KEY
	,IdPedido INT
	,IdCliente INT
	,IdTipoComprobantePago VARCHAR(6)
	,IdTipoTransaccion VARCHAR(6)
	,FechaEmision DATETIME
	,FechaVencimiente DATETIME
	,FormaPago VARCHAR(50)
	,Estado VARCHAR(20)
	,Monto DECIMAL(10, 2)
	,CreadoPor VARCHAR(15)
	,FechaCreacion DATETIME
	,ModificadoPor VARCHAR(15)
	,FechaModificacion DATETIME
	,CONSTRAINT FK_Pedido FOREIGN KEY (IdPedido) REFERENCES Pedido(IdPedido)
	,CONSTRAINT FK_Cliente4 FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente)
	,CONSTRAINT FK_TipoComprobantePago FOREIGN KEY (IdTipoComprobantePago) REFERENCES TipoComprobante(IdTipoComprobante)
	,CONSTRAINT FK_TipoTransaccion FOREIGN KEY (IdTipoTransaccion) REFERENCES TipoTransaccion(IdTipoTransaccion)
	);

CREATE TABLE Producto (
	IdProducto INT AUTO_INCREMENT PRIMARY KEY
	,Nombre VARCHAR(100)
	,NombreCorto VARCHAR(50)
	,Descripcion VARCHAR(50)
	,Marca VARCHAR(50)
	,Presentacion VARCHAR(50)
	,UnidadMedida VARCHAR(10)
	,PrecioUnidadMedida DECIMAL(10, 2)
	,UnidadCompra VARCHAR(10)
	,PrecioUnidadCompra DECIMAL(10, 2)
	,Estado VARCHAR(20)
	,CreadoPor VARCHAR(15)
	,FechaCreacion DATETIME
	,ModificadoPor VARCHAR(15)
	,FechaModificacion DATETIME
	);

CREATE TABLE PedidoProducto (
	IdPedidoProducto INT AUTO_INCREMENT PRIMARY KEY
	,IdPedido INT
	,IdProducto INT
	,Cantidad DECIMAL(10, 2)
	,UnidadMedida VARCHAR(10)
	,PrecioUnidadMedida DECIMAL(10, 2)
	,UnidadCompra VARCHAR(10)
	,PrecioUnidadCompra DECIMAL(10, 2)
	,CantidadEntregada DECIMAL(10, 2)
	,CreadoPor VARCHAR(15)
	,FechaCreacion DATETIME
	,ModificadoPor VARCHAR(15)
	,FechaModificacion DATETIME
	,CONSTRAINT FK_Producto FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto)
	);

CREATE TABLE Almacen (
	IdAlmacen INT AUTO_INCREMENT PRIMARY KEY
	,IdProducto INT
	,Stock DECIMAL(10, 2)
	,StockMinimo DECIMAL(10, 2)
	,Estado VARCHAR(20)
	,CreadoPor VARCHAR(15)
	,FechaCreacion DATETIME
	,ModificadoPor VARCHAR(15)
	,FechaModificacion DATETIME
	,CONSTRAINT FK_Producto2 FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto)
	);