--Script para SP en phpAdmn

--Crear un Nuevo Usuario
delimiter $
CREATE
PROCEDURE sp_UsuarioCrear(
     IN TipoUsuario varchar (50),
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
    INSERT
INTO
    Usuario
VALUES(
    NULL,
    TipoUsuario ,
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
CREATE
PROCEDURE sp_UsuarioLeer()
BEGIN
SELECT
    IdUsuario,TipoUsuario,Nombre, Apellido, IdTipoDocumento, DocumentoIdentidad, Telefono, Celular, Usuario, ClaveAcceso, EstadoUsuario, CreadoPor, FechaCreacion, ModificadoPor, FechaModificacion
FROM
    Usuario;
END$

--ELIMINAR USUARIO

delimiter $
create 
procedure sp_UsuarioEliminar(in idUsuario int)
begin
delete from usuario where IdUsuario = idUsuario ;
END$

--Validar Usuario

delimiter $
create procedure sp_UsuarioValidar (in Pusuario varchar (15),in Pclave varchar (100))
begin
SELECT IdUsuario,TipoUsuario, Nombre, Apellido, IdTipoDocumento, DocumentoIdentidad, Telefono, Celular, Usuario, ClaveAcceso, EstadoUsuario, CreadoPor, FechaCreacion, ModificadoPor, FechaModificacion
FROM
    Usuario  where Usuario like Pusuario and ClaveAcceso like Pclave limit 1;
    
    END $
sp_UsuarioValidar
call sp_UsuarioCrear ("Administrador","karina","Chuquizuta","DOCDNI","708576ddd7","","927107660","11","123","Activo","Adm",'2018-12-16 17:15' );
 

insert into tipodocumento values ("DOCDNI","DNI","Documento Nacional de Identidad");

SELECT 
    IdUsuario,
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
FROM
    Usuario
WHERE
    Usuario LIKE 'kminpai'
        AND ClaveAcceso LIKE '123'
LIMIT 1;
    

call sp_UsuarioLeer();

call sp_UsuarioValidar("kminpaia","13");

--EDITAR USUARIO

create proc UsuarioEditar(
    IN pIdusuario INT,
    IN pTipoUsuario varchar (50),
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
    IN pFechaCreacion DATETIME)
as
update Usuario set TipoUsuario=pTipoUsuario, Nombre=pNombre, Apellido=pApellido,
IdTipoDocumento=pIdTipoDocumento,DocumentoIdentidad=pDocumentoIdentidad,Telefono=pTelefono,Celular=pCelular,
Usuario=pUsuario,ClaveAcceso=pClaveAcceso,EstadoUsuario=pEstadoUsuario,CreadoPor=pCreadoPor,FechaCreacion=pFechaCreacion
where Idusuario=pIdusuario
go 


/* Producto procedimiento */
delimiter $

create procedure  sp_ProductoCrear (
     in Nombre VARCHAR(100)
	,in NombreCorto VARCHAR(50)
	,in Descripcion VARCHAR(50)
	,in Marca VARCHAR(50)
	,in Presentacion VARCHAR(50)
	,in UnidadMedida VARCHAR(10)
	,in PrecioUnidadMedida DECIMAL(10, 2)
	,in UnidadCompra VARCHAR(10)
	,in PrecioUnidadCompra DECIMAL(10, 2)
	,in Estado VARCHAR(20)
	,in CreadoPor VARCHAR(15)
	,in FechaCreacion DATETIME)
	
    begin 
    insert  into producto values ( 
     null
   , Nombre 
	, NombreCorto 
	, Descripcion 
	, Marca 
	, Presentacion 
	, UnidadMedida 
	, PrecioUnidadMedida
	, UnidadCompra
	, PrecioUnidadCompra 
	, Estado 
	, CreadoPor 
	, FechaCreacion,null,null);
END$

call  sp_ProductoCrear  ('Cafe Convencionales', 'ConCafe','Son los cafés cosechados con 5 a 15% de verde','Cafe Don Juan' ,'Molido ','gramos',0.02,'kilogramo',10,'Activo',
'kminpai','2018-12-31');

call  sp_ProductoCrear  ('Cafe Premium', 'PreCafe',' cosecha selectiva, máximo 1% de verde','Cafe Don Juan' ,'Instantaneo ','gramos',0.04,'kilogramo',20,'Activo',
'kminpai','2018-12-31');

call  sp_ProductoCrear  ('Cafe Especiales', 'EsCafe',' Cafe Organico','Cafe Don Juan' ,'Molido ','gramos',0.06,'kilogramo',40,'Activo',
'kminpai','2018-12-31');

select * from producto

delete  from producto  where CreadoPor='kminpai' ;

delimiter $
create procedure sp_ProductoLeer(
in PidProducto int)
begin
if (PidProducto is null) then
select  IdProducto, Nombre 
	, NombreCorto 
	, Descripcion 
	, Marca 
	, Presentacion 
	, UnidadMedida 
	, PrecioUnidadMedida
	, UnidadCompra
	, PrecioUnidadCompra 
	, Estado 
	, CreadoPor Pr
	, FechaCreacion,ModificadoPor,FechaModificacion from producto;
    else 
    select  IdProducto, Nombre 
	, NombreCorto 
	, Descripcion 
	, Marca 
	, Presentacion 
	, UnidadMedida 
	, PrecioUnidadMedida
	, UnidadCompra
	, PrecioUnidadCompra 
	, Estado 
	, CreadoPor 
	, FechaCreacion,ModificadoPor,FechaModificacion from producto where IdProducto=PidProducto;
    end if;
end $
    
    drop procedure sp_ProductoLeer
    
    call sp_ProductoLeer (null);
     
	select  distinct * from producto;
    
    /* PEDIDOS   */



	create proc PedidoEditar(
    in pIdPedido INT
	,in pDireccionFacturacion VARCHAR(50)
	,in pIdDireccionEntrega INT
	,in pTipoEntrega VARCHAR(50)
	,in pFechaEntrega DATETIME
	,in pEstadoPedido VARCHAR(20)
	,in pFechaCambioEstado DATETIME
	,in pModificadoPor VARCHAR(15)
	,in pFechaModificacion DATETIME)
as
update Pedido set DireccionFacturacion =pDireccionFacturacion, IdDireccionEntrega=pIdDireccionEntrega, TipoEntrega=pTipoEntrega,
FechaEntrega=pFechaEntrega,EstadoPedido=pEstadoPedido,FechaCambioEstado=pFechaCambioEstado,ModificadoPor=pModificadoPor,
FechaModificacion=pFechaModificacion,where IdPedido=pIdPedido
go 


    delimiter $
    create procedure sp_PedidoCrear(
    in IdUsuario INT
	,in IdCliente INT
	,in DireccionFacturacion VARCHAR(50)
	,in IdDireccionEntrega INT
	,in TipoEntrega VARCHAR(50)
	,in FechaEntrega DATETIME
	,in EstadoPedido VARCHAR(20)
	,in FechaCambioEstado DATETIME
	,in CreadoPor VARCHAR(15)
	,in FechaCreacion DATETIME)
	begin
    declare PNumeroPedido int ;
    if (select count(*) from pedido) = 0 then
    set PNumeroPedido = 1;
    else
    set PNumeroPedido = (select max(NumeroPedido) from Pedido) +1;
    end if;
    
    insert into pedido values (null,
    PNumeroPedido
    ,IdUsuario 
	,IdCliente 
	,DireccionFacturacion 
	,IdDireccionEntrega 
	,TipoEntrega
	,FechaEntrega
	,EstadoPedido
	,FechaCambioEstado
	,CreadoPor
	,FechaCreacion
	,'' 
	,'');
    end $

    call sp_PedidoCrear(26,1,'Lima Indepencia',2,'Domicilio','2019-01-01','Borrador','','robertbr','2019-01-01')
    
    drop procedure sp_PedidoLeer;
    delimiter $
    create procedure sp_PedidoLeer(
    in PIdPedido INT)
	begin
    if PIdPedido is null or PIdPedido = 0 then
    select IdPedido,
    NumeroPedido
    ,IdUsuario 
	,IdCliente 
	,DireccionFacturacion 
	,IdDireccionEntrega 
	,TipoEntrega
	,FechaEntrega
	,EstadoPedido
	,FechaCambioEstado
	,CreadoPor
	,FechaCreacion
    ,ModificadoPor
	,FechaModificacion 
	 from 
    Pedido limit 30;
    
    else
    
    select IdPedido ,
    NumeroPedido
    ,IdUsuario 
	,IdCliente 
	,DireccionFacturacion 
	,IdDireccionEntrega 
	,TipoEntrega
	,FechaEntrega
	,EstadoPedido
	,FechaCambioEstado
	,CreadoPor
	,FechaCreacion
    ,ModificadoPor
	,FechaModificacion  from 
    Pedido where IdPedido = PIdPedido limit 30;
    end if;
    end $
        
    
    /* Cliente PROCEDIMIENTO*/

delimiter $
CREATE PROCEDURE sp_ClienteLeer()
BEGIN
SELECT
	IdCliente
	,IdTipoCliente
	,Nombre
	,Apellido
	,IdTipoDocumento
	,DocumentoIdentidad 
	,RazonSocial 
	,RUC 
	,Telefono 
	,Celular 
	,Email 
	,EstadoCliente 
	,CreadoPor 
	,FechaCreacion
	,ModificadoPor 
	,FechaModificacion
FROM
    Cliente;
END$

delimiter $
CREATE PROCEDURE  ClienteEditar(
     in pIdTipoCliente VARCHAR(6)
	,in pNombre VARCHAR(50)
	,in pApellido VARCHAR(50)
	,in pIdTipoDocumento VARCHAR(6)
	,in pDocumentoIdentidad VARCHAR(20)
	,in pRazonSocial VARCHAR(50)
	,in pRUC VARCHAR(10)
	,in pTelefono VARCHAR(10)
	,in pCelular VARCHAR(10)
	,in pEmail VARCHAR(100)
	,in pEstadoCliente VARCHAR(20)
	,in pModificadoPor VARCHAR(15)
	,in pFechaModificacion DATETIME)
as
update Cliente  set  IdTipoCliente=pIdTipoCliente, Nombre=pNombre,Apellido=pApellido,IdTipoDocumento=pIdTipoDocumento,
DocumentoIdentidad=pDocumentoIdentidad, RazonSocial=pRazonSocial,RUC=pRUC,Telefono=pTelefono,Celular=pCelular,Email=pEmail,
EstadoCliente=pEstadoCliente,ModificadoPor=pModificadoPor,FechaModificacion=pFechaModificacion
where IdCliente=pIdCliente;
END$




Delimiter $
create procedure sp_ClienteCrear (
     in pIdTipoCliente VARCHAR(6)
	,in pNombre VARCHAR(50)
	,in pApellido VARCHAR(50)
	,in pIdTipoDocumento VARCHAR(6)
	,in pDocumentoIdentidad VARCHAR(20)
	,in pRazonSocial VARCHAR(50)
	,in pRUC VARCHAR(10)
	,in pTelefono VARCHAR(10)
	,in pCelular VARCHAR(10)
	,in pEmail VARCHAR(100)
	,in pEstadoCliente VARCHAR(20)
	,in pCreadoPor VARCHAR(15)
	,in pFechaCreacion DATETIME)
    begin 
    insert into cliente
    values
    (null,IdTipoCliente
	,Nombre
	,Apellido
	,IdTipoDocumento
	,DocumentoIdentidad 
	,RazonSocial 
	,RUC 
	,Telefono 
	,Celular 
	,Email 
	,EstadoCliente 
	,CreadoPor 
	,FechaCreacion,null,null);
    END$
drop procedure sp_ClienteCrear


insert into TipoCliente values ('TPCNTL','Tipo de cliente Natural','Cliente Natural');
insert into TipoCliente values ('TPCJDO','Tipo de cliente Cliente','Cliente Juridico');

select * from TipoCliente;
	cliente
  call sp_ClienteCrear  ( 'TPCNTL','Jorge','Quiroz','DOCDNI','70695867','JorgeQ','1016409058',
'01654123','921789456','jorgeq@outlook.com','Activo','kminpai','2018-12-31');
    
    select * from Cliente









-- DIRECCION PROCEDIMIENTO


delimiter $
CREATE
PROCEDURE sp_DireccionLeer()
BEGIN
SELECT
	IdDireccion
	,IdCliente 
	,NombreDireccion 
	,Calle1 
	,Calle2 
	,Distrito 
	,Departamento
	,Provincia 
	,EstadoDireccion
	,CreadoPor 
	,FechaCreacion 
	,ModificadoPor
	,FechaModificacion 
FROM
    Direccion;
END$


create proc DireccionEditar(
    in pIdCliente INT
	,in pNombreDireccion VARCHAR(50)
	,in pCalle1 VARCHAR(50)
	,in pCalle2 VARCHAR(50)
	,in pDistrito VARCHAR(50)
	,in pDepartamento VARCHAR(50)
	,in pProvincia VARCHAR(50)
	,in pEstadoDireccion VARCHAR(20)
	,in pCreadoPor VARCHAR(15)
	,in pFechaCreacion DATETIME)
as
update Direccion  set  NombreDireccion=pNombreDireccion,Calle1 =pCalle1,Calle2=pCalle2,Distrito=pDistrito,
Departamento=pDepartamento,Provincia=pProvincia,EstadoDireccion=pEstadoDireccion,CreadoPor=pCreadoPor,
FechaCreacion=pFechaCreacion
where IdCliente=pIdCliente
go



create procedure sp_DireccionCrear (
	 in IdCliente INT
	,in NombreDireccion VARCHAR(50)
	,in Calle1 VARCHAR(50)
	,in Calle2 VARCHAR(50)
	,in Distrito VARCHAR(50)
	,in Departamento VARCHAR(50)
	,in Provincia VARCHAR(50)
	,in EstadoDireccion VARCHAR(20)
	,in CreadoPor VARCHAR(15)
	,in FechaCreacion DATETIME)
    begin
    insert into Direccion
    values (
    null,
	IdCliente 
	,NombreDireccion
	,Calle1 
	,Calle2 
	,Distrito 
	,Departamento 
	,Provincia 
	,EstadoDireccion 
	,CreadoPor 
	,FechaCreacion,
    null,null);
    END$
    
    drop procedure sp_DireccionCrear
    select * from cliente
    
    call sp_DireccionCrear ('1','av. los rosales','calle 6','','La Victoria','Lima','Lima',
'Activo','kminpai','2018-12-31');
    
        call sp_DireccionCrear ('1','av. los rosales','calle 6','','La Victoria','Lima','Lima',
    'Lima','Activo','kminpai','2018-12-31');
    
select * from direccion


/*PEDIDO PRODUCTO PROC  */


delimiter $
CREATE PROCEDURE sp_PedidoProductoLeer(
IN  pIdPedido INT)
BEGIN
SELECT
	IdPedidoProducto 
	,IdPedido 
	,IdProducto 
	,Cantidad 
	,UnidadMedida 
	,PrecioUnidadMedida 
	,UnidadCompra
	,PrecioUnidadCompra 
	,CantidadEntregada 
	,CreadoPor
	,FechaCreacion 
	,ModificadoPor 
	,FechaModificacion
FROM
    PedidoProducto where IdPedido = pIdPedido;
END$

delimiter $
create PROCEDURE sp_PedidoProductoEditar(
    IN  pIdPedidoProducto INT
	,IN  pIdPedido INT
	,IN  pIdProducto INT
	,IN  pCantidad DECIMAL(10, 2)
	,IN  pUnidadMedida VARCHAR(10)
	,IN  pPrecioUnidadMedida DECIMAL(10, 2)
	,IN  pUnidadCompra VARCHAR(10)
	,IN  pPrecioUnidadCompra DECIMAL(10, 2)
	,IN  pCantidadEntregada DECIMAL(10, 2)
	,IN  pModificadoPor VARCHAR(15)
	,IN  pFechaModificacion DATETIME)
as
update PedidoProducto  set  IdProducto=pIdProducto,Cantidad=pCantidad,UnidadMedida=pUnidadMedida,
UnidadCompra=pUnidadCompra,CantidadEntregada=pCantidadEntregada,
ModificadoPor=pModificadoPor,FechaModificacion=pFechaModificacion
where IdPedidoProducto=pIdPedidoProducto;
END$


delimiter $
CREATE PROCEDURE sp_PedidoProductoCrear(
   IN  PIdPedido INT
	,IN  pIdProducto INT
	,IN  pCantidad DECIMAL(10, 2)
	,IN  pUnidadMedida VARCHAR(10)
	,IN  pPrecioUnidadMedida DECIMAL(10, 2)
	,IN  pUnidadCompra VARCHAR(10)
	,IN  pPrecioUnidadCompra DECIMAL(10, 2)
	,IN  pCantidadEntregada DECIMAL(10, 2)
	,IN  pCreadoPor VARCHAR(15)
	,IN  pFechaCreacion DATETIME
)
BEGIN
    INSERT
INTO
    PedidoProducto
VALUES(
   NULL,
    pIdPedido 
	,pIdProducto 
	,pCantidad 
	,pUnidadMedida 
	,pPrecioUnidadMedida 
	,pUnidadCompra
	,pPrecioUnidadCompra 
	,pCantidadEntregada 
	,pCreadoPor 
	,pFechaCreacion 
	,NULL
	,NULL
);
END$
--ALMACE PROCEDIMIENTO

delimiter $
CREATE PROCEDURE sp_AlmacenLeer()
BEGIN
SELECT
	IdAlmacen 
	,IdProducto 
	,Stock 
	,StockMinimo 
	,Estado
	,CreadoPor 
	,FechaCreacion 
	,ModificadoPor 
	,FechaModificacion 
FROM
    Almacen;
END$




