using API_Boletim.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Boletim.Interfaces
{
    interface IAluno
    {
        Aluno Cadastrar(IAluno a);
        List<Aluno> LerTodos();
        Aluno BuscarPorId(int id);
        IAluno Alterar(Aluno a);
        IAluno Excluir(IAluno a);
    }
}
