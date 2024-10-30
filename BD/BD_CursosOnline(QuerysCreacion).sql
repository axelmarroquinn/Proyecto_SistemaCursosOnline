CREATE DATABASE SistemaCursosOnline;
GO
USE SistemaCursosOnline;
GO

CREATE TABLE Usuario (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nombre NVARCHAR(100) NOT NULL,
    Apellido NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    Contraseña NVARCHAR(255) NOT NULL, 
    Rol NVARCHAR(50) NOT NULL,  
    FechaRegistro DATETIME DEFAULT GETDATE()
);

-- Insertar Administrador
INSERT INTO Usuario (Nombre, Apellido, Email, Contraseña, Rol)
VALUES ('Admin', 'Admin', 'admin@school.com', 'admin123', 'Administrador');

-- Insertar Catedrático
INSERT INTO Usuario (Nombre, Apellido, Email, Contraseña, Rol)
VALUES ('Catedratico', 'Catedratico', 'catedratico@school.com', 'catedratico123', 'Catedratico');

-- Insertar Estudiante
INSERT INTO Usuario (Nombre, Apellido, Email, Contraseña, Rol)
VALUES ('Estudiante', 'Estudiante', 'estudiante@school.com', 'estudiante123', 'Estudiante');


CREATE TABLE Curso (
    CursoId INT PRIMARY KEY IDENTITY(1,1),
    NombreCurso NVARCHAR(150) NOT NULL,
    Descripcion NVARCHAR(500),
    FechaCreacion DATETIME DEFAULT GETDATE()
);

CREATE TABLE CursoUsuario (
    CursoId INT NOT NULL,                     
    UsuarioId INT NOT NULL,                   
    FechaAsignacion DATETIME DEFAULT GETDATE(),
    PRIMARY KEY (CursoId, UsuarioId),         
    FOREIGN KEY (CursoId) REFERENCES Curso(CursoId),
    FOREIGN KEY (UsuarioId) REFERENCES Usuario(Id)
);


SELECT * FROM Usuario;
SELECT * FROM Curso;
SELECT * FROM CursoUsuario;


CREATE TABLE Tarea (
    TareaId INT PRIMARY KEY IDENTITY(1,1),
    CursoId INT NOT NULL,  -- Relación con el curso
    NombreTarea NVARCHAR(150) NOT NULL,
    DescripcionTarea NVARCHAR(500),
    FechaLimite DATETIME NOT NULL,
    FOREIGN KEY (CursoId) REFERENCES Curso(CursoId)
);

CREATE TABLE TareaCompletada (
    TareaId INT NOT NULL,  
    UsuarioId INT NOT NULL,
    FechaEntrega DATETIME,
    Calificacion DECIMAL(5, 2) NULL,
    PRIMARY KEY (TareaId, UsuarioId),
    FOREIGN KEY (TareaId) REFERENCES Tarea(TareaId),
    FOREIGN KEY (UsuarioId) REFERENCES Usuario(Id)
);


SELECT * FROM Curso;
SELECT * FROM Usuario;
SELECT * FROM Tarea;
SELECT * FROM TareaCompletada;


CREATE TABLE Anuncio (
    AnuncioId INT PRIMARY KEY IDENTITY(1,1),
    CursoId INT NOT NULL,  -- Relación con el curso
    Titulo NVARCHAR(150) NOT NULL,
    Contenido NVARCHAR(500),
    FechaPublicacion DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (CursoId) REFERENCES Curso(CursoId)
);

SELECT * FROM Anuncio;


-- Limpieza de tablas (Excluyendo Usuario & Curso)

USE SistemaCursosOnline;

-- Deshabilitar temporalmente las restricciones de clave externa para poder realizar las eliminaciones.
ALTER TABLE CursoUsuario NOCHECK CONSTRAINT ALL;
ALTER TABLE Tarea NOCHECK CONSTRAINT ALL;
ALTER TABLE TareaCompletada NOCHECK CONSTRAINT ALL;
ALTER TABLE Anuncio NOCHECK CONSTRAINT ALL;
ALTER TABLE Curso NOCHECK CONSTRAINT ALL;

-- Eliminar datos de las tablas.
DELETE FROM TareaCompletada;
DELETE FROM Tarea;
DELETE FROM CursoUsuario;
DELETE FROM Anuncio;
DELETE FROM Curso;

-- Restablecer los contadores de identidad en cada tabla.
DBCC CHECKIDENT ('Curso', RESEED, 0);
DBCC CHECKIDENT ('CursoUsuario', RESEED, 0);
DBCC CHECKIDENT ('Tarea', RESEED, 0);
DBCC CHECKIDENT ('TareaCompletada', RESEED, 0);
DBCC CHECKIDENT ('Anuncio', RESEED, 0);

-- Volver a habilitar las restricciones de clave externa.
ALTER TABLE CursoUsuario CHECK CONSTRAINT ALL;
ALTER TABLE Tarea CHECK CONSTRAINT ALL;
ALTER TABLE TareaCompletada CHECK CONSTRAINT ALL;
ALTER TABLE Anuncio CHECK CONSTRAINT ALL;
ALTER TABLE Curso CHECK CONSTRAINT ALL;


-- Verificación de tablas vacías.
SELECT * FROM Usuario;
SELECT * FROM Curso;
SELECT * FROM CursoUsuario;
SELECT * FROM Tarea;
SELECT * FROM TareaCompletada;
SELECT * FROM Anuncio;
