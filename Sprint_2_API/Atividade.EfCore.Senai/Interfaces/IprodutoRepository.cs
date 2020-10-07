using Atividade.EfCore.Senai.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.EfCore.Senai.Interfaces
{
   public interface IprodutoRepository
    {
        List<Produto> Listar();
        Produto BuscarPorId(Guid Id);
        void Adicionar(Produto Produto);
        List<Produto> BuscarPorNome(string nome);
        void Editar(Produto Produto);
        void Remover(Guid Id);

    }
}
