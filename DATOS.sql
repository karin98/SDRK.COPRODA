/****INCERTAR DATOS***************************************************************************************************************************************/
use coproda;

/*LLENADO DE TABLAS PRODUCTO*/
call sp_ProductoCrear('Cafe Convencionales', 'ConCafe', 'Son los cafés cosechados con 5 a 15% de verde', 'Cafe Don Juan', 'Molido ', 'gramos', 0.02, 'kilogramo', 10, 'Activo', 'kminpai', '2018-12-31');
call sp_ProductoCrear('Cafe Premium', 'PreCafe', ' cosecha selectiva, máximo 1% de verde', 'Cafe Don Juan', 'Instantaneo ', 'gramos', 0.04, 'kilogramo', 20, 'Activo', 'kminpai', '2018-12-31');
call sp_ProductoCrear('Cafe Especiales', 'EsCafe', ' Cafe Organico', 'Cafe Don Juan', 'Molido ', 'gramos', 0.06, 'kilogramo', 40, 'Activo', 'kminpai', '2018-12-31');

INSERT INTO TipoDocumento
VALUES (
'DOCDNI'
,'DNI'
,'Documento Nacional de Identidad'
);
INSERT INTO TipoCliente
VALUES (
'TPCNTL','Cliente Natural'
,'Tipo de cliente Natural'
);

INSERT INTO TipoCliente
VALUES (
'TPCJDO','Cliente Juridico'
,'Tipo de cliente Cliente'
);

call sp_UsuarioCrear("Administrador", "Karina", "Chuquizuta", "DOCDNI", "70526645", "", "927107660", "kminpai", "123456", "Activo", "Admin", '2018-12-16 17:15');
call sp_UsuarioCrear("Administrador", "Ronert", "Carlos", "DOCDNI", "70526645", "", "927107660", "robertbr", "20182018", "Activo", "Admin", '2018-12-16 17:15');

call sp_ClienteCrear('TPCNTL', 'Jorge', 'Quiroz', 'DOCDNI', '70695867', 'JorgeQ', '1016409058', '01654123', '921789456', 'jorgeq@outlook.com', 'Activo', 'kminpai', '2018-12-31');
call sp_DireccionCrear('1', 'av. los rosales', 'calle 6', '', 'La Victoria', 'Lima', 'Lima', 'Activo', 'kminpai', '2018-12-31');

call sp_PedidoCrear(1, 1, 'Lima Indepencia', 2, 'Domicilio', '2019-01-01', 'Borrador', '', 'robertbr', '2019-01-01');

/********************************************************************************************************************************************************/
SELECT IdUsuario
	,Nombre
	,Apellido
	,IdTipoDocumento
	,DocumentoIdentidad
	,Telefono
	,Celular
	,Usuario
	,ClaveAcceso
	,EstadoUsuario
	,CreadoPor
	,FechaCreacion
	,ModificadoPor
	,FechaModificacion
FROM Usuario
WHERE Usuario LIKE 'kminpai'
	AND ClaveAcceso LIKE '123' LIMIT 1;

call sp_UsuarioLeer();

call sp_UsuarioValidar("kminpaia", "13");
	

SELECT *
FROM producto;

DELETE
FROM producto
WHERE CreadoPor = 'kminpai';



DROP PROCEDURE sp_ProductoLeer;
call sp_ProductoLeer(NULL);

SELECT DISTINCT *
FROM producto;

DROP PROCEDURE sp_PedidoLeer;
DROP PROCEDURE sp_ClienteCrear;


SELECT *
FROM TipoCliente;



SELECT *
FROM Cliente;

select * from pedido;


DROP PROCEDURE sp_DireccionCrear;

SELECT *
FROM cliente;

SELECT *
FROM direccion
