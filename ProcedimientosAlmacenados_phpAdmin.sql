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

SELECT IdUsuario, Nombre, Apellido, IdTipoDocumento, DocumentoIdentidad, Telefono, Celular, Usuario, ClaveAcceso, EstadoUsuario, CreadoPor, FechaCreacion, ModificadoPor, FechaModificacion
FROM
    Usuario  where Usuario like "kminpai" and ClaveAcceso like "123" limit 1;
    

call sp_UsuarioLeer();

call sp_UsuarioValidar("kminpaia","13");