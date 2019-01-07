use coproda;
--Script para SP en phpAdmn
/*---USUARIO */
/*---CREAR----*/
delimiter $
CREATE PROCEDURE sp_UsuarioCrear (
	IN TipoUsuario VARCHAR(50),
	IN Nombre VARCHAR(50),
	IN Apellido VARCHAR(50),
	IN IdTipoDocumento VARCHAR(6),
	IN DocumentoIdentidad VARCHAR(20),
	IN Telefono VARCHAR(10),
	IN Celular VARCHAR(10),
	IN Usuario VARCHAR(15),
	IN ClaveAcceso VARCHAR(100),
	IN EstadoUsuario VARCHAR(20),
	IN CreadoPor VARCHAR(15),
	IN FechaCreacion DATETIME
	)
BEGIN
	INSERT INTO Usuario
	VALUES (
		NULL,
		TipoUsuario,
		Nombre,
		Apellido,
		IdTipoDocumento,
		DocumentoIdentidad,
		Telefono,
		Celular,
		Usuario,
		ClaveAcceso,
		EstadoUsuario,
		CreadoPor,
		FechaCreacion,
		NULL,
		NULL
		);
END$
    
	--LEER USUARIO
delimiter $
CREATE PROCEDURE sp_UsuarioLeer ()
BEGIN
	SELECT IdUsuario,
		TipoUsuario,
		Nombre,
		Apellido,
		IdTipoDocumento,
		DocumentoIdentidad,
		Telefono,
		Celular,
		Usuario,
		ClaveAcceso,
		EstadoUsuario,
		CreadoPor,
		FechaCreacion,
		ModificadoPor,
		FechaModificacion
	FROM Usuario;
END$
        
	--ELIMINAR USUARIO
delimiter $
CREATE PROCEDURE sp_UsuarioEliminar (IN idUsuario INT)
BEGIN
	DELETE
	FROM usuario
	WHERE IdUsuario = idUsuario;
END$
				
	--Validar Usuario
	delimiter $
CREATE PROCEDURE sp_UsuarioValidar (
	IN Pusuario VARCHAR(15),
	IN Pclave VARCHAR(100)
	)
BEGIN
	SELECT IdUsuario,
		TipoUsuario,
		Nombre,
		Apellido,
		IdTipoDocumento,
		DocumentoIdentidad,
		Telefono,
		Celular,
		Usuario,
		ClaveAcceso,
		EstadoUsuario,
		CreadoPor,
		FechaCreacion,
		ModificadoPor,
		FechaModificacion
	FROM Usuario
	WHERE Usuario LIKE Pusuario
		AND ClaveAcceso LIKE Pclave limit 1;
END $


--EDITAR USUARIO
delimiter $
CREATE PROCEDURE sp_UsuarioEditar (
	IN pIdusuario INT,
	IN pTipoUsuario VARCHAR(50),
	IN pNombre VARCHAR(50),
	IN pApellido VARCHAR(50),
	IN pIdTipoDocumento VARCHAR(6),
	IN pDocumentoIdentidad VARCHAR(20),
	IN pTelefono VARCHAR(10),
	IN pCelular VARCHAR(10),
	IN pUsuario VARCHAR(15),
	IN pClaveAcceso VARCHAR(100),
	IN pPEstadoUsuario VARCHAR(20),
	IN pCreadoPor VARCHAR(15),
	IN pFechaCreacion DATETIME
	)
BEGIN
	UPDATE Usuario
	SET TipoUsuario = pTipoUsuario,
		Nombre = pNombre,
		Apellido = pApellido,
		IdTipoDocumento = pIdTipoDocumento,
		DocumentoIdentidad = pDocumentoIdentidad,
		Telefono = pTelefono,
		Celular = pCelular,
		Usuario = pUsuario,
		ClaveAcceso = pClaveAcceso,
		EstadoUsuario = pEstadoUsuario,
		CreadoPor = pCreadoPor,
		FechaCreacion = pFechaCreacion
	WHERE Idusuario = pIdusuario;
end$
			
	/* Producto procedimiento */
	/*---CREAR----*/
	delimiter $
CREATE PROCEDURE sp_ProductoCrear (
	IN Nombre VARCHAR(100),
	IN NombreCorto VARCHAR(50),
	IN Descripcion VARCHAR(50),
	IN Marca VARCHAR(50),
	IN Presentacion VARCHAR(50),
	IN UnidadMedida VARCHAR(10),
	IN PrecioUnidadMedida DECIMAL(10, 2),
	IN UnidadCompra VARCHAR(10),
	IN PrecioUnidadCompra DECIMAL(10, 2),
	IN Estado VARCHAR(20),
	IN CreadoPor VARCHAR(15),
	IN FechaCreacion DATETIME
	)
BEGIN
	INSERT INTO producto
	VALUES (
		NULL,
		Nombre,
		NombreCorto,
		Descripcion,
		Marca,
		Presentacion,
		UnidadMedida,
		PrecioUnidadMedida,
		UnidadCompra,
		PrecioUnidadCompra,
		Estado,
		CreadoPor,
		FechaCreacion,
		NULL,
		NULL
		);
END$
                    
/*-LEER-*/
delimiter $
CREATE PROCEDURE sp_ProductoLeer (IN pIdProducto INT)
BEGIN
IF (pIdProducto = 0) then
	SELECT IdProducto,
		Nombre,
		NombreCorto,
		Descripcion,
		Marca,
		Presentacion,
		UnidadMedida,
		PrecioUnidadMedida,
		UnidadCompra,
		PrecioUnidadCompra,
		Estado,
		CreadoPor,
		FechaCreacion,
		ModificadoPor,
		FechaModificacion
	FROM producto;
ELSEIF (pIdProducto != 0) then
	SELECT IdProducto,
		Nombre,
		NombreCorto,
		Descripcion,
		Marca,
		Presentacion,
		UnidadMedida,
		PrecioUnidadMedida,
		UnidadCompra,
		PrecioUnidadCompra,
		Estado,
		CreadoPor,
		FechaCreacion,
		ModificadoPor,
		FechaModificacion
	FROM producto
	WHERE IdProducto = pIdProducto;
END IF;
END $

	/* PEDIDOS   */
	/*---EDITAR */
delimiter $
CREATE PROCEDURE sp_PedidoEditar (
	IN pIdPedido INT,
	IN pDireccionFacturacion VARCHAR(50),
	IN pIdDireccionEntrega INT,
	IN pTipoEntrega VARCHAR(50),
	IN pFechaEntrega DATETIME,
	IN pEstadoPedido VARCHAR(20),
	IN pFechaCambioEstado DATETIME,
	IN pModificadoPor VARCHAR(15),
	IN pFechaModificacion DATETIME
	)
BEGIN
	UPDATE Pedido
	SET DireccionFacturacion = pDireccionFacturacion,
		IdDireccionEntrega = pIdDireccionEntrega,
		TipoEntrega = pTipoEntrega,
		FechaEntrega = pFechaEntrega,
		EstadoPedido = pEstadoPedido,
		FechaCambioEstado = pFechaCambioEstado,
		ModificadoPor = pModificadoPor,
		FechaModificacion = pFechaModificacion
	WHERE IdPedido = pIdPedido;
end$
                        
/*---CREAR----*/
delimiter $
CREATE PROCEDURE sp_PedidoCrear (
	IN pIdUsuario INT,
	IN pIdCliente INT,
	IN pDireccionFacturacion VARCHAR(50),
	IN pIdDireccionEntrega INT,
	IN pTipoEntrega VARCHAR(50),
	IN pFechaEntrega DATETIME,
	IN pEstadoPedido VARCHAR(20),
	/*IN pFechaCambioEstado DATETIME,*/
	IN pCreadoPor VARCHAR(15),
	IN pFechaCreacion DATETIME
	)
BEGIN
	DECLARE pNumeroPedido INT;
	IF (SELECT count(*)
			FROM pedido
			) = 0 then
		SET pNumeroPedido = 1;
	ELSE
		SET pNumeroPedido = (
				SELECT max(NumeroPedido)
				FROM Pedido
				) + 1;
END IF;
	INSERT INTO pedido
	VALUES (
		NULL,
		pNumeroPedido,
		pIdUsuario,
		pIdCliente,
		pDireccionFacturacion,
		pIdDireccionEntrega,
		pTipoEntrega,
		pFechaEntrega,
		pEstadoPedido,
		'',
		pCreadoPor,
		pFechaCreacion,
		'',
		''
		);
END $


/*---LEER-*/
delimiter $
CREATE PROCEDURE sp_PedidoLeer (IN PIdPedido INT)
BEGIN
	IF PIdPedido IS NULL
		OR PIdPedido = 0 then
		SELECT IdPedido,
			NumeroPedido,
			P.IdUsuario,
			P.IdCliente,
            C.Nombre,
            C.Apellido,
			P.DireccionFacturacion,
			P.IdDireccionEntrega,
            D.NombreDireccion,
			P.TipoEntrega,
			P.FechaEntrega,
			P.EstadoPedido,
			P.FechaCambioEstado,
			P.CreadoPor,
			P.FechaCreacion,
			P.ModificadoPor,
			P.FechaModificacion
		FROM Pedido P
        inner join Cliente C on P.IdCliente=C.IdCliente
        inner join Direccion D on P.IdDireccionEntrega= D.IdDireccion;
	ELSE
		SELECT IdPedido,
			NumeroPedido,
			P.IdUsuario,
			P.IdCliente,
            C.Nombre,
            C.Apellido,
			P.DireccionFacturacion,
			P.IdDireccionEntrega,
            D.NombreDireccion,
			P.TipoEntrega,
			P.FechaEntrega,
			P.EstadoPedido,
			P.FechaCambioEstado,
			P.CreadoPor,
			P.FechaCreacion,
			P.ModificadoPor,
			P.FechaModificacion
		FROM Pedido P
        inner join Cliente C on P.IdCliente=C.IdCliente
        inner join Direccion D on P.IdDireccionEntrega= D.IdDireccion
		WHERE IdPedido = PIdPedido;
	END IF;
END $

	/* Cliente PROCEDIMIENTO*/
	/*---LEER-*/
delimiter $
CREATE PROCEDURE sp_ClienteLeer (in pIdCliente int)
BEGIN
IF pIdCliente IS NULL
		OR pIdCliente = 0 then
	SELECT 
		IdCliente,
        IdTipoCliente,
		Nombre,
		Apellido,
		IdTipoDocumento,
		DocumentoIdentidad,
		RazonSocial,
		RUC,
		Telefono,
		Celular,
		Email,
		EstadoCliente,
		CreadoPor,
		FechaCreacion,
        ModificadoPor,
        FechaModificacion
	FROM Cliente;
    else
    SELECT 
		IdCliente,
        IdTipoCliente,
		Nombre,
		Apellido,
		IdTipoDocumento,
		DocumentoIdentidad,
		RazonSocial,
		RUC,
		Telefono,
		Celular,
		Email,
		EstadoCliente,
		CreadoPor,
		FechaCreacion,
        ModificadoPor,
        FechaModificacion
	FROM Cliente
    where Idcliente=pIdCliente;
    end if;
END$ 

delimiter $
CREATE PROCEDURE sp_TipoClienteLeer()
BEGIN
	SELECT 
		IdTipoCliente,
        TipoCliente,
        Descripcion
	FROM TipoCliente;
END$ 

delimiter $
CREATE PROCEDURE sp_TipoDocumentoLeer()
BEGIN
	SELECT 
		IdTipoDocumento,
        TipoDocumento,
        Descripcion
	FROM TipoDocumento;
END$ 

                        
delimiter $
CREATE PROCEDURE sp_ClienteEditar (
    in pIdCliente int,
	IN pIdTipoCliente VARCHAR(6),
	IN pNombre VARCHAR(50),
	IN pApellido VARCHAR(50),
	IN pIdTipoDocumento VARCHAR(6),
	IN pDocumentoIdentidad VARCHAR(20),
	IN pRazonSocial VARCHAR(50),
	IN pRUC VARCHAR(10),
	IN pTelefono VARCHAR(10),
	IN pCelular VARCHAR(10),
	IN pEmail VARCHAR(100),
	IN pEstadoCliente VARCHAR(20),
	IN pModificadoPor VARCHAR(15),
	IN pFechaModificacion DATETIME
	)
BEGIN
	UPDATE Cliente
	SET IdTipoCliente = pIdTipoCliente,
		Nombre = pNombre,
		Apellido = pApellido,
		IdTipoDocumento = pIdTipoDocumento,
		DocumentoIdentidad = pDocumentoIdentidad,
		RazonSocial = pRazonSocial,
		RUC = pRUC,
		Telefono = pTelefono,
		Celular = pCelular,
		Email = pEmail,
		EstadoCliente = pEstadoCliente,
		ModificadoPor = pModificadoPor,
		FechaModificacion = pFechaModificacion
	WHERE IdCliente = pIdCliente;
end$
                            
	/*---CREAR----*/
Delimiter $
CREATE PROCEDURE sp_ClienteCrear (
	IN pIdTipoCliente VARCHAR(6),
	IN pNombre VARCHAR(50),
	IN pApellido VARCHAR(50),
	IN pIdTipoDocumento VARCHAR(6),
	IN pDocumentoIdentidad VARCHAR(20),
	IN pRazonSocial VARCHAR(50),
	IN pRUC VARCHAR(10),
	IN pTelefono VARCHAR(10),
	IN pCelular VARCHAR(10),
	IN pEmail VARCHAR(100),
	IN pEstadoCliente VARCHAR(20),
	IN pCreadoPor VARCHAR(15),
	IN pFechaCreacion DATETIME
	)
BEGIN
	INSERT INTO cliente
	VALUES (
		NULL,
		pIdTipoCliente,
		pNombre,
		pApellido,
		pIdTipoDocumento,
		pDocumentoIdentidad,
		pRazonSocial,
		pRUC,
		pTelefono,
		pCelular,
		pEmail,
		pEstadoCliente,
		pCreadoPor,
		pFechaCreacion,
		NULL,
		NULL
		);
END$
                                
	-- DIRECCION PROCEDIMIENTO
	/*---LEER-*/
delimiter $
CREATE PROCEDURE sp_DireccionLeer (in pIdDireccion int,in pIdCliente int)
BEGIN
IF (pIdCliente IS NULL
		OR pIdCliente = 0)and (pIdDireccion = 0) then
     SELECT IdDireccion,
		IdCliente,
		NombreDireccion,
		Calle1,
		Calle2,
		Distrito,
		Departamento,
		Provincia,
		EstadoDireccion,
		CreadoPor,
		FechaCreacion,
		ModificadoPor,
		FechaModificacion
	FROM Direccion;   
        elseif(pIdCliente != 0)and (pIdDireccion = 0) then
           SELECT IdDireccion,
		IdCliente,
		NombreDireccion,
		Calle1,
		Calle2,
		Distrito,
		Departamento,
		Provincia,
		EstadoDireccion,
		CreadoPor,
		FechaCreacion,
		ModificadoPor,
		FechaModificacion
	FROM Direccion
    where IdCliente = pIdCliente;  
     elseif(pIdDireccion != 0) then
	SELECT IdDireccion,
		IdCliente,
		NombreDireccion,
		Calle1,
		Calle2,
		Distrito,
		Departamento,
		Provincia,
		EstadoDireccion,
		CreadoPor,
		FechaCreacion,
		ModificadoPor,
		FechaModificacion
	FROM Direccion
    where IdDireccion=pIdDireccion;
    end if;
END$
                                    
	/*---EDITA*/
delimiter $
CREATE PROCEDURE sp_DireccionEditar (
	in pIdDireccion int,
	IN pNombreDireccion VARCHAR(50),
	IN pCalle1 VARCHAR(50),
	IN pCalle2 VARCHAR(50),
	IN pDistrito VARCHAR(50),
	IN pDepartamento VARCHAR(50),
	IN pProvincia VARCHAR(50),
	IN pEstadoDireccion VARCHAR(20),
	IN pModificadoPor VARCHAR(15),
	IN pFechaModificacion DATETIME
	)

BEGIN
	UPDATE Direccion
	SET NombreDireccion = pNombreDireccion,
		Calle1 = pCalle1,
		Calle2 = pCalle2,
		Distrito = pDistrito,
		Departamento = pDepartamento,
		Provincia = pProvincia,
		EstadoDireccion = pEstadoDireccion,
		ModificadoPor = pModificadoPor,
		FechaModificacion = pFechaModificacion
	WHERE IdDireccion = pIdDireccion;
end$ 
                                        
delimiter $
CREATE PROCEDURE sp_DireccionCrear (
	IN pIdCliente INT,
	IN pNombreDireccion VARCHAR(50),
	IN pCalle1 VARCHAR(50),
	IN pCalle2 VARCHAR(50),
	IN pDistrito VARCHAR(50),
	IN pDepartamento VARCHAR(50),
	IN pProvincia VARCHAR(50),
	IN pEstadoDireccion VARCHAR(20),
	IN pCreadoPor VARCHAR(15),
	IN pFechaCreacion DATETIME
	)
BEGIN
	INSERT INTO Direccion
	VALUES (
		NULL,
		pIdCliente,
		pNombreDireccion,
		pCalle1,
		pCalle2,
		pDistrito,
		pDepartamento,
		pProvincia,
		pEstadoDireccion,
		pCreadoPor,
		pFechaCreacion,
		NULL,
		NULL
		);
END$
                                            
/*PEDIDO PRODUCTO PROC  */
/*---ELIMINAR----*/
delimiter $
CREATE PROCEDURE sp_PedidoProductoEliminar (in pIdPedido int ,in pIdPedidoProducto INT)
BEGIN
	DELETE
	FROM PedidoProducto
	WHERE IdPedido= pIdPedido and IdPedidoProducto = pIdPedidoProducto;
end$
                                                
/*---LEER----*/
delimiter $
CREATE PROCEDURE sp_PedidoProductoLeer (in pIdPedido int)
BEGIN
	SELECT IdPedidoProducto,
		PP.IdPedido,
		PP.IdProducto,
        P.Nombre,
		PP.Cantidad,
		PP.UnidadMedida,
		PP.PrecioUnidadMedida,
		PP.UnidadCompra,
		PP.PrecioUnidadCompra,
		PP.CantidadEntregada,
		PP.CreadoPor,
		PP.FechaCreacion,
		PP.ModificadoPor,
		PP.FechaModificacion
	FROM PedidoProducto PP
    inner join Producto P on PP.IdProducto = P.IdProducto
    where IdPedido=pIdPedido;
END$
                                                    
/*---EDITAR----*/
delimiter $
CREATE PROCEDURE sp_PedidoProductoEditar (
	IN pIdPedido INT,
	IN pIdProducto INT,
	IN pCantidad DECIMAL(10, 2),
	IN pUnidadMedida VARCHAR(10),
	IN pPrecioUnidadMedida DECIMAL(10, 2),
	IN pUnidadCompra VARCHAR(10),
	IN pPrecioUnidadCompra DECIMAL(10, 2),
	IN pCantidadEntregada DECIMAL(10, 2),
	IN pCreadoPor VARCHAR(15),
	IN pFechaCreacion DATETIME,
	IN pModificadoPor VARCHAR(15),
	IN pFechaModificacion DATETIME
	)
BEGIN
	UPDATE PedidoProducto
	SET IdProducto = pIdProducto,
		Cantidad = pCantidad,
		UnidadMedida = pUnidadMedida,
		UnidadCompra = pUnidadCompra,
		CantidadEntregada = pCantidadEntregada,
		CreadoPor = pCreadoPor,
		FechaCreacion = pFechaCreacion,
		ModificadoPor = pModificadoPor,
		FechaModificacion = pFechaModificacion
	WHERE IdPedido = pIdPedido;
	END$
    
/*---CREAR----*/
delimiter $
CREATE PROCEDURE sp_PedidoProductoCrear (
	IN pIdPedido INT,
	IN pIdProducto INT,
	IN pCantidad DECIMAL(10, 2),
	IN pUnidadMedida VARCHAR(10),
	IN pPrecioUnidadMedida DECIMAL(10, 2),
	IN pUnidadCompra VARCHAR(10),
	IN pPrecioUnidadCompra DECIMAL(10, 2),
	IN pCantidadEntregada DECIMAL(10, 2),
	IN pCreadoPor VARCHAR(15),
	IN pFechaCreacion DATETIME/*,
	IN pModificadoPor VARCHAR(15),
	IN pFechaModificacion DATETIME*/
	)

BEGIN
	INSERT INTO PedidoProducto
	VALUES (
		NULL,
		pIdPedido,
		pIdProducto,
		pCantidad,
		pUnidadMedida,
		pPrecioUnidadMedida,
		pUnidadCompra,
		pPrecioUnidadCompra,
		pCantidadEntregada,
		pCreadoPor,
		pFechaCreacion,
		NULL,
		NULL
		);
	END$
    
--ALMACE PROCEDIMIENTO
/*---LEER----*/
delimiter $
CREATE PROCEDURE sp_AlmacenLeer ()
BEGIN
	SELECT IdAlmacen,
		IdProducto,
		Stock,
		StockMinimo,
		Estado,
		CreadoPor,
		FechaCreacion,
		ModificadoPor,
		FechaModificacion
	FROM Almacen;
END$