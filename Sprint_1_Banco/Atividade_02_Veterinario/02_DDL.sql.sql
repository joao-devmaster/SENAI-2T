--Criar banco de dados 
CREATE DATABASE Veterinario;
GO
USE Veterinario;

SELECT * FROM Clinica;
-- Começando sempre com as tabelas que não possuem(FK)

--CRIAMOS A TABELA CLINICA

CREATE TABLE Clinica(
IdClinica INT PRIMARY KEY IDENTITY NOT NULL,
Nome VARCHAR (50) NOT NULL,
Endereço VARCHAR (100)NOT NULL,
);

-- Criamos a tabela Dono
CREATE TABLE Dono (
IdDono INT PRIMARY KEY IDENTITY NOT NULL,
Nome VARCHAR (50) NOT NULL,
);

--Criamos a tabela tipo pet
CREATE TABLE TipoPet(
IdTipoPet INT PRIMARY KEY IDENTITY NOT NULL,
Descricao  VARCHAR (200) NOT NULL,
);



-- agora vamos fazer as tabelas que possuem FK

-- Criamos a tabela Veterinario
CREATE TABLE Veterinario (
IdVeterinario INT PRIMARY KEY IDENTITY NOT NULL,
CRV INT NOT NULL,
Nome VARCHAR (100) NOT NULL,

-- colocamos as chaves estrangeiras
IdClinica INT FOREIGN KEY REFERENCES Clinica (IdClinica)
);

--criamos a tabela de racas
CREATE TABLE Raca (
IdRaca INT PRIMARY KEY IDENTITY NOT NULL,
Descricao VARCHAR (200) NOT NULL,

--colocamos as chaves estrangeiras
IdTipoPet INT FOREIGN KEY REFERENCES TipoPet (IdTipoPet)

);

--criamos a tabela Pet
CREATE TABLE Pet (
IdPet INT PRIMARY KEY IDENTITY NOT NULL,
Nome VARCHAR (100) NOT NULL,
DataNascimento INT NOT NULL,

--colocamos as chaves estrangeiras 
IdDono INT FOREIGN KEY REFERENCES Dono (IdDono),
IdRaca INT FOREIGN KEY REFERENCES Raca (IdRaca)
);

-- criamos a tabela atendimento
CREATE TABLE Atendimento (
IdAtendimento INT PRIMARY KEY IDENTITY NOT NULL,
Descricao VARCHAR (200) NOT NULL,
DataAtendimento INT NOT NULL,

-- Colocamos as chaves estrangeiras
IdPet INT FOREIGN KEY REFERENCES Pet (IdPet),
IdVeterinario INT FOREIGN KEY REFERENCES Veterinario (IdVeterinario)
);
