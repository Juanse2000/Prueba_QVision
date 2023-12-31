
-- CREACION BASE DE DATOS
CREATE DATABASE LIBRERIA_QVISION

-- USAMOS LA BASE DE DATOS
USE LIBRERIA_QVISION

-- CREACION DE TABLAS
CREATE TABLE EDITORIALES
(ID_EDITORIAL INT PRIMARY KEY IDENTITY(1,1),
NOMBRE varchar(45),
SEDE VARCHAR(45),
)

CREATE TABLE AUTORES
(ID_AUTOR INT PRIMARY KEY IDENTITY(1,1),
NOMBRE varchar(45),
APELLIDO VARCHAR(45),
)

CREATE TABLE LIBROS
(ID_LIBRO INT PRIMARY KEY IDENTITY(1,1),
TITULO varchar(45),
SINOPSIS TEXT,
N_PAGINAS VARCHAR(45),
ID_EDITORIAL INT, 
CONSTRAINT FK_EDITORIALES FOREIGN KEY (ID_EDITORIAL)  REFERENCES EDITORIALES(ID_EDITORIAL)
)

CREATE TABLE AUTORES_HAS_LIBROS
(ID_AUTOR_LIBRO INT PRIMARY KEY IDENTITY(1,1),
ID_AUTOR INT,
ID_LIBRO INT,
CONSTRAINT FK_AUTORES FOREIGN KEY (ID_AUTOR)  REFERENCES AUTORES(ID_AUTOR),
CONSTRAINT FK_LIBROS FOREIGN KEY (ID_LIBRO)  REFERENCES LIBROS(ID_LIBRO))

-- POBLAMOS LA TABLA EDITORIALES Y AUTORES

insert into EDITORIALES values
('Planeta', 'Bogota'),
('Alba', 'Medellin')

insert into AUTORES values
('Mario', 'Mendoza'),
('Stephen', 'King')