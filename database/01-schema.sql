:On Error exit
SET QUOTED_IDENTIFIER ON;
SET ANSI_NULLS ON;
SET ANSI_PADDING ON;
SET ANSI_WARNINGS ON;
SET CONCAT_NULL_YIELDS_NULL ON;
SET ARITHABORT ON;
SET NUMERIC_ROUNDABORT OFF;
USE master;
GO
IF DB_ID(N'$(DatabaseName)') IS NOT NULL
    THROW 50001, 'La base ya existe. Use un nombre nuevo; este instalador no borra datos.', 1;
GO
CREATE DATABASE [$(DatabaseName)];
GO
USE [$(DatabaseName)];
GO
SET XACT_ABORT ON;
BEGIN TRANSACTION;
-- Tabla: Propietario
CREATE TABLE Propietario (
    DNI VARCHAR(8) NOT NULL,
    Nombre VARCHAR(60) NOT NULL,
    Telefono VARCHAR(9) NOT NULL,
	Email VARCHAR(100) NOT NULL,
	Eliminado BIT NOT NULL,
	FechaActualizacion DATETIME,
	UsuarioActualizacion VARCHAR(50),
	CONSTRAINT Propietario_pk PRIMARY KEY (DNI)
);

-- Tabla: Mascota
CREATE TABLE Mascota (
    MascotaId INT NOT NULL IDENTITY(1,1),
    Nombre VARCHAR(60) NOT NULL,
	Sexo VARCHAR(6) NOT NULL,
    Especie VARCHAR(30) NOT NULL,
    Raza VARCHAR(30) NOT NULL,
    Edad INT NOT NULL,
    Peso DECIMAL(4,2) NOT NULL,
    CodigoPropietario VARCHAR(8) NOT NULL,
	Eliminado BIT NOT NULL,
    FechaActualizacion DATETIME,
    UsuarioActualizacion VARCHAR(50),
    CONSTRAINT Mascota_pk PRIMARY KEY (MascotaId)
);

-- Tabla: Veterinario
CREATE TABLE Veterinario (
    VeterinarioId INT NOT NULL IDENTITY(1,1),
    Nombre VARCHAR(60) NOT NULL,
    Especialidad VARCHAR(30) NOT NULL,
    Telefono VARCHAR(9) NOT NULL,
	Eliminado BIT NOT NULL,
    FechaActualizacion DATETIME,
    UsuarioActualizacion VARCHAR(50),
	CONSTRAINT Veterinario_pk PRIMARY KEY (VeterinarioId)
);

-- Tabla: Medicamento
CREATE TABLE Medicamento (
    MedicamentoId INT NOT NULL IDENTITY(1,1),
    Nombre VARCHAR(60) NOT NULL,
    Descripcion VARCHAR(60),
    Stock INT NOT NULL,
    FechaCaducidad DATE NOT NULL,
    Precio DECIMAL(10,2) NOT NULL,
	Eliminado BIT NOT NULL,
    FechaActualizacion DATETIME,
    UsuarioActualizacion VARCHAR(50),
	CONSTRAINT Medicamento_pk PRIMARY KEY (MedicamentoId)
);

-- Tabla: Cita
CREATE TABLE Cita (
    CitaId INT NOT NULL IDENTITY(1,1),
    Especialidad VARCHAR(60) NOT NULL,
    Dosis VARCHAR(30) NOT NULL,
    Notas VARCHAR(120) NOT NULL,
    FechaHora DATETIME NOT NULL,
    CostoCita DECIMAL(10,2) NOT NULL,
    CostoTotal DECIMAL(10,2) NOT NULL,
    CodigoMascota INT NOT NULL,
    CodigoVeterinario INT NOT NULL,
    CodigoMedicamento INT NOT NULL,
	Activa BIT NOT NULL DEFAULT 0, -- Inicia como False
	Eliminado BIT NOT NULL,
    FechaActualizacion DATETIME,
    UsuarioActualizacion VARCHAR(50),
	CONSTRAINT Cita_pk PRIMARY KEY (CitaId)
);

-- Tabla: Usuario
CREATE TABLE Usuario (
    UsuarioID VARCHAR(50) NOT NULL,
    Contraseña VARCHAR(256) NOT NULL,
	CONSTRAINT Usuario_pk PRIMARY KEY (UsuarioID)
);

-- Tabla: LogsAcciones
CREATE TABLE LogsAcciones (
    LogId INT NOT NULL IDENTITY(1,1),
    Usuario VARCHAR(50) NOT NULL,
    Accion VARCHAR(250) NOT NULL,
    FechaHora DATETIME,
    CONSTRAINT LogsAcciones_pk PRIMARY KEY (LogId)
);

-- Relaciones
ALTER TABLE Mascota ADD CONSTRAINT FK_Mascota_Propietario
FOREIGN KEY (CodigoPropietario) REFERENCES Propietario(DNI);

ALTER TABLE Cita ADD CONSTRAINT FK_Cita_Mascota
FOREIGN KEY (CodigoMascota) REFERENCES Mascota(MascotaId);

ALTER TABLE Cita ADD CONSTRAINT FK_Cita_Veterinario
FOREIGN KEY (CodigoVeterinario) REFERENCES Veterinario(VeterinarioId);

ALTER TABLE Cita ADD CONSTRAINT FK_Cita_Medicamento
FOREIGN KEY (CodigoMedicamento) REFERENCES Medicamento(MedicamentoId);

ALTER TABLE LogsAcciones ADD CONSTRAINT FK_Logs_Usuario
FOREIGN KEY (Usuario) REFERENCES Usuario(UsuarioID); 

-- Datos de prueba

ALTER TABLE Mascota ADD CONSTRAINT CK_Mascota_Valores CHECK (Edad >= 0 AND Peso > 0);
ALTER TABLE Medicamento ADD CONSTRAINT CK_Medicamento_Valores CHECK (Stock >= 0 AND Precio >= 0);
ALTER TABLE Cita ADD CONSTRAINT CK_Cita_Costos CHECK (CostoCita >= 0 AND CostoTotal >= CostoCita);
CREATE UNIQUE INDEX UX_Cita_VeterinarioHorario ON Cita(CodigoVeterinario, FechaHora) WHERE Eliminado = 0;
CREATE UNIQUE INDEX UX_Cita_MascotaHorario ON Cita(CodigoMascota, FechaHora) WHERE Eliminado = 0;
COMMIT;
