USE Veterinario;
GO

-- DML - Data Manipulation Language
-- Parecido com o CRUD, temos Insert, Delete e Update
-- Mas antes para observarmos esses dados temos que usar uma DQL
SELECT * FROM Dono;
SELECT * FROM Veterinario;
SELECT * FROM Pet;
SELECT * FROM Raca;
SELECT * FROM Atendimento;
SELECT * FROM Clinica;

-- Insert = Inserir dados
-- COM PK's primeiro
INSERT INTO Dono 
	(Nome) 
	VALUES
	('Samara');

INSERT INTO Clinica
	(Nome, Endereco)
	VALUES
	('DogShow','Rua dos planetas, 316');

INSERT INTO Raca
	(Raca)
	VALUES
	('Pastor Alem�o');

-- UPDATE = Alterar dados

/* UPDATE entidade SET
	Atributo = novo dado
WHERE atributo de apoio para mudar;
*/
UPDATE Raca SET
	Raca = 'Rottweiler'
WHERE IdRaca = 2;

--DELETE = Excluir dados
DELETE FROM Dono WHERE IdDono = 7;

-- Com FK's agora
INSERT INTO Veterinario
	(IdClinica, Nome, CRV)
	VALUES
	(3, 'Heitor', 'KL6129WQ');

INSERT INTO Pet 
	(Nome, IdDono, IdRaca)
	VALUES
	('Rex', 3, 2);

-- Adicionando coluna esquecida
ALTER TABLE Atendimento ADD IdPet INT FOREIGN KEY REFERENCES Pet (IdPet)

-- Removendo coluna errada
ALTER TABLE Atendimento DROP IdDono

INSERT INTO Atendimento
	(Descricao, IdVeterinario, IdPet)
	VALUES
	('Enfermo, precisar� de cirurgia na pata', 3, 3);
