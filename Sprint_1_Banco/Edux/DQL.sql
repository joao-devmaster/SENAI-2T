USE Edux;

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

SELECT
Usuario.Nome,
Usuario.Email,
Usuario.Senha,
Perfil.Permissao
FROM Usuario
RIGHT JOIN Perfil ON Usuario.IdPerfil = Perfil.IdPerfil

SELECT * FROM AlunoTurma
INNER JOIN Usuario  ON AlunoTurma.IdUsuario = Usuario.IdUsuario
INNER JOIN Turma ON AlunoTurma.IdTurma = Turma.IdTurma;