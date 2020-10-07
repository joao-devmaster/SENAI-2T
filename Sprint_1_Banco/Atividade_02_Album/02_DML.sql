USE Atividade2;
GO

SELECT * FROM Album;
SELECT * FROM Artista;
SELECT * FROM Estilo;
SELECT * FROM Permissao;
SELECT * FROM Usuario;

INSERT INTO Permissao
	(TipoPermissao)
	VALUES
	('Gerente'), ('Comum');

INSERT INTO Estilo
	(Estilo)
	VALUES
	('Funk'), ('Rap'), ('Pop'), ('Sertanejo');

-- FK's
INSERT INTO Usuario
	(Nome, Email, Senha, IdPermissao)
	VALUES
	('Paulo', 'plo@gmail.com', 'pppaulo', 3),
	('Christian', 'chrisfuchs@hotmail.com', 'lnadoos', 3),
	('Zeze', '0178@roubanao.com', 'зћву', 1);

INSERT INTO Artista
	(Nome, IdEstilo)
	VALUES
	('Travis Scott', 2),
	('Mc Hariel', 1),
	('Drake', 2);

-- DROP TABLE EstiloAlbum

ALTER TABLE Album ADD IdEstilo INT FOREIGN KEY REFERENCES Estilo (IdEstilo)

INSERT INTO Album
	(IdArtista, Nome, QtdMinutos, DataLancamento, IdEstilo)
	VALUES
	(3, 'Hot', 34, '2018-06-13T09:21:53', 2);
