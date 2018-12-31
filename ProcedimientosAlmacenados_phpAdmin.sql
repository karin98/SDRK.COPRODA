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

--Leeer Usuarios
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
	,null 
	,null);
    end $
    
    /* Cliente*/
Delimiter $
create procedure sp_ClienteCrear (
     in IdTipoCliente VARCHAR(6)
	,in Nombre VARCHAR(50)
	,in Apellido VARCHAR(50)
	,in IdTipoDocumento VARCHAR(6)
	,in DocumentoIdentidad VARCHAR(20)
	,in RazonSocial VARCHAR(50)
	,in RUC VARCHAR(10)
	,in Telefono VARCHAR(10)
	,in Celular VARCHAR(10)
	,in Email VARCHAR(100)
	,in EstadoCliente VARCHAR(20)
	,in CreadoPor VARCHAR(15)
	,in FechaCreacion DATETIME)
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
Delimiter $
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