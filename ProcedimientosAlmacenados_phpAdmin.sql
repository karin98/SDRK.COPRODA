--Script para SP en phpAdmn
--Crear un Nuevo Usuario
CREATE
PROCEDURE sp_UsuarioCrear(
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
END