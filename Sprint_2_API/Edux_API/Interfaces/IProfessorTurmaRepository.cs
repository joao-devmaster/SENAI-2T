using Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux.Interfaces
{
    public interface IProfessorTurmaRepository
    {
        List<ProfessorTurma> Listar();

        ProfessorTurma BuscarPorId(int id);

        void Adicionar(ProfessorTurma profturm);

        void Editar(int id, ProfessorTurma profturm);

        void Remover(int id);
    }
}
