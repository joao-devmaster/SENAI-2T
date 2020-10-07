-- criar o banco 
CREATE DATABASE Nyous;

-- usar efetivamente o banco
USE Nyous;


-- criamos primeiramente as tabelas sem FK

-- criamos a tabela Acesso
CREATE TABLE Acesso(
	IdAcesso INT PRIMARY KEY IDENTITY NOT NULL,
	Tipo VARCHAR(50)
);

--criamos a tabela Categoria
CREATE TABLE Categoria(
	IdCategoria INT PRIMARY KEY IDENTITY NOT NULL,
	Titulo VARCHAR(50)
);

--criamos a tabela Localizacao
CREATE TABLE Localizacao(
	IdLocalizacao INT PRIMARY KEY IDENTITY NOT NULL,
	Logradouro VARCHAR(100) NOT NULL,
	Numero VARCHAR(50),
	Complemento VARCHAR(50),
	Bairro VARCHAR(50) NOT NULL,
	Cidade VARCHAR(50) NOT NULL,
	UF CHAR(2),
	CEP VARCHAR(10)
);


--Agora criamos as tabelas com Fk

--criamos a tabela Usuario
CREATE TABLE Usuario(
	IdUsuario INT PRIMARY KEY IDENTITY NOT NULL,
	Nome VARCHAR(100) NOT NULL,
	Email VARCHAR(80) NOT NULL,
	Senha VARCHAR(150) NOT NULL,
	DataNascimento DATETIME NOT NULL,

	-- inserindo a chave estrangeiras
	IdAcesso INT FOREIGN KEY REFERENCES Acesso(IdAcesso)
);

--criamos a tabela Evento
CREATE TABLE Evento(
	IdEvento INT PRIMARY KEY IDENTITY NOT NULL,
	DataEvento DATETIME NOT NULL,
	AcessoRestrito BINARY DEFAULT 0 NOT NULL,
	Capacidade INT NOT NULL,
	Descricao VARCHAR(255),

-- inserindo a chave estrangeiras
	IdLocalizacao INT FOREIGN KEY REFERENCES Localizacao(IdLocalizacao),
	IdCategoria INT FOREIGN KEY REFERENCES Categoria(IdCategoria),
);

--criamos a tabela Presenca
CREATE TABLE Presenca(
	IdPresenca INT PRIMARY KEY IDENTITY NOT NULL,
	Confirmado BIT NOT NULL,

-- inserindo a chave estrangeiras
	IdEvento INT FOREIGN KEY REFERENCES Evento(IdEvento),
	IdUsuario INT FOREIGN KEY REFERENCES Usuario(IdUsuario)
);

--criamos a tabela Convite
CREATE TABLE Convite(
	IdConvite INT PRIMARY KEY IDENTITY NOT NULL,
	Confirmado BIT DEFAULT NULL,

	-- inserindo a chave estrangeiras
	IdEvento INT FOREIGN KEY REFERENCES Evento(IdEvento),
	IdUsuarioEmissor INT FOREIGN KEY REFERENCES Usuario(IdUsuario),
	IdUsuarioConvidado INT FOREIGN KEY REFERENCES Usuario(IdUsuario)
);