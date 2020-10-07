USE Veterinario;

SELECT Atendimento.DataAtendimento,
Atendimento.Descricao,
Pet.Nome,
Raca.Descricao






FROM Atendimento
INNER JOIN Pet ON Atendimento.IdPet = Pet.IdPet
INNER JOIN Raca ON Pet.IdRaca = Raca.IdRaca





;
