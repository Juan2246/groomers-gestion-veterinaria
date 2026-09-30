-- Datos ficticios para demostración local. No contienen información de clientes.
:On Error exit
USE [$(DatabaseName)];
GO
SET XACT_ABORT ON;
BEGIN TRANSACTION;
IF EXISTS(SELECT 1 FROM Usuario) THROW 50002, 'La demo requiere una base recién creada.', 1;
INSERT INTO Usuario(UsuarioID, Contraseña) VALUES ('admin', 'PBKDF2-SHA256$600000$52PU7DT7BBwPjG/hJ+3U2w==$+Q5Gn46pnszH6YO/F8C8335L5Y0BUgUpQnRyByCBQm4=');
INSERT INTO Propietario(DNI,Nombre,Telefono,Email,Eliminado,FechaActualizacion,UsuarioActualizacion) VALUES
('00000001','Propietario Demo A','000000001','demo.a@example.invalid',0,GETDATE(),'admin'),
('00000002','Propietario Demo B','000000002','demo.b@example.invalid',0,GETDATE(),'admin');
INSERT INTO Mascota(Nombre,Sexo,Especie,Raza,Edad,Peso,CodigoPropietario,Eliminado,FechaActualizacion,UsuarioActualizacion) VALUES
('Luna','Hembra','Perro','Mestizo',3,12.50,'00000001',0,GETDATE(),'admin'),
('Milo','Macho','Gato','Mestizo',2,4.20,'00000002',0,GETDATE(),'admin');
INSERT INTO Veterinario(Nombre,Especialidad,Telefono,Eliminado,FechaActualizacion,UsuarioActualizacion) VALUES
('Veterinario Demo A','Consulta General','000000003',0,GETDATE(),'admin'),
('Veterinario Demo B','Cirugía','000000004',0,GETDATE(),'admin');
INSERT INTO Medicamento(Nombre,Descripcion,Stock,FechaCaducidad,Precio,Eliminado,FechaActualizacion,UsuarioActualizacion) VALUES
('Producto Demo A','Insumo ficticio de prueba',20,DATEADD(year,2,GETDATE()),25,0,GETDATE(),'admin'),
('Producto Demo B','Insumo ficticio de prueba',30,DATEADD(year,2,GETDATE()),15,0,GETDATE(),'admin');
INSERT INTO Cita(Especialidad,Dosis,Notas,FechaHora,CostoCita,CostoTotal,CodigoMascota,CodigoVeterinario,CodigoMedicamento,Activa,Eliminado,FechaActualizacion,UsuarioActualizacion) VALUES
('Consulta General','Demo','Registro de demostración',DATEADD(hour,9,CONVERT(datetime,CONVERT(date,GETDATE()))),60,85,1,1,1,1,0,GETDATE(),'admin'),
('Cirugía','Demo','Registro de demostración',DATEADD(hour,23,CONVERT(datetime,CONVERT(date,GETDATE()))),120,135,2,2,2,1,0,GETDATE(),'admin');
INSERT INTO LogsAcciones(Usuario,Accion,FechaHora) VALUES('admin','Inicializó datos ficticios de demostración',GETDATE());
COMMIT;
GO
