USE Edux;

INSERT INTO Perfil (Permissao) VALUES ('Administrador'),('Professor'),('Aluno');
INSERT INTO Instituicao(Nome, UF, Logradouro, Cidade, Complemento, Bairro, Numero, CEP) 
VALUES ('Senai', 'SP', 'Alameda Barão de Limeira', 'Sao Paulo', '', 'Santa Cecilia', '539', '01202-001');
INSERT INTO Categoria(Tipo) VALUES ('Critico'),('Desejavel'),('Oculto');
INSERT INTO Curso(Titulo, IdInstituicao) VALUES ('Desenvolvimento de sistemas', 1);
INSERT INTO Turma(Descricao, IdCurso) VALUES ('1DT_DEV', 1), ('2DT_DEV', 1), ('3DT_DEV', 1);
INSERT INTO Usuario(Nome, Email, Senha, IdPerfil) 
VALUES 
('Fernando','Fernando@senai.com.br', 'Antonio232',3),
('Joao','Joao@senai.com.br', 'Dani69', 2),
('Kaique','Kaique@senai.com.br', '7624', 1);
INSERT INTO ProfessorTurma(Descricao, IdUsuario, IdTurma) VALUES ('Banco de dados', 2, 2);
INSERT INTO Dica(Texto, IdUsuario)
VALUES ('Para desenvolvedores em geral, a função tem uma parte importante em qualquer ponto do produto. 
Deve-se levar em consideração quão simples é executar uma tarefa, ou pensar em tarefas que demandem muito tempo. ', 2);
INSERT INTO Curtida(IdUsuario, IdDica) VALUES (1, 1);
INSERT INTO AlunoTurma(Matricula, IdUsuario, IdTurma) VALUES ('141425pf', 1, 3);
INSERT INTO Objetivo(Descricao, IdCategoria) VALUES 
('Desenvolver API (web services) para integração de dados entre plataformas', 1),
('Desenvolver sistemas web de acordo com as regras de negócio estabelecidas
Tipo: Formativa', 2),
('Desenvolver sistemas web', 3);

INSERT INTO AlunoObjetivo(IdObjetivo, IdAlunoTurma) VALUES (1, 1);

ALTER TABLE Dica ALTER COLUMN Imagem VARCHAR(255)

SELECT * FROM Perfil;
SELECT * FROM Instituicao;
SELECT * FROM Categoria;
SELECT * FROM Curso;
SELECT * FROM Turma;
SELECT * FROM Usuario;
SELECT * FROM ProfessorTurma;
SELECT * FROM Dica;
SELECT * FROM Curtida;
SELECT * FROM AlunoTurma;
SELECT * FROM Objetivo;
SELECT * FROM AlunoObjetivo;