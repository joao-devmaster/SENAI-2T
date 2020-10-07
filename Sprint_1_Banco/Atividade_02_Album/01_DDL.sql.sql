-- criar o banco 
CREATE DATABASE Album;
go
-- usar efetivamente o banco
USE Album;
GO

-- criamos primeiramente as tabelas sem FK

-- criamos a tabela usuarios

CREATE TABLE Usuario (
IdUsuario INT PRIMARY KEY IDENTITY NOT NULL,
Nome VARCHAR (100) NOT NULL,
Permissao VARCHAR (150),
senha VARCHAR (150) NOT NULL , -- talvez, no lugar do varchar pode ser outra nomenclatura para ocutar os caracteres
email VARCHAR (200) NOT NULL 
);

--criamos a tabela estilo
CREATE TABLE Estilo (
IdEstilo INT PRIMARY KEY IDENTITY NOT NULL,
Nome VARCHAR (150) NOT NULL
);

--Agora criamos as tabelas com Fk

--criamos a tabela Album

CREATE TABLE Album (
IdAlbum INT PRIMARY KEY IDENTITY NOT NULL,
Nome VARCHAR (100) NOT NULL,
DataLancamento INT NOT NULL,
Localizacao VARCHAR (150),
QtdMinutos INT NOT NULL,
Ativo VARCHAR (50),  -- Poderia ser algum tipo de BOLEANO (sim ou não)

-- inserindo a chave estrangeiras
IdArtista INT FOREIGN KEY REFERENCES Artista (IdArtista)

);

-- criamos a tabela Artista 
CREATE TABLE Artista (
IdArtista INT PRIMARY KEY IDENTITY NOT NULL,
Nome VARCHAR (150),

-- inserindo a chave estrangeira
IdEstilo INT FOREIGN KEY REFERENCES Estilo (IdEstilo)

);

-- criamos a tabela estilo album 
CREATE TABLE EstiloAlbum (
IdEstiloAlbum INT PRIMARY KEY IDENTITY NOT NULL,

-- inserimos as chaves estrangeiras
IdAlbum INT FOREIGN KEY REFERENCES Album (IdAlbum),
IdEstilo INT FOREIGN KEY REFERENCES Estilo (IdEstilo) 
);