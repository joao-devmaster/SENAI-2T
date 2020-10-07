using Edux.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Edux.Interface
{
    public interface ICategoriaRepository
    {
        List<Categoria> Listar();

        Categoria BuscarPorId(int id);

        void Adicionar(Categoria categoria);

        void Editar(int id, Categoria categoria);

        void Remover(int id);

    }
}
