using Atividade.EfCore.Senai.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.EfCore.Senai.Interfaces
{
    public interface IPedidoRepository
    {
        List<Pedido> Listar();
        Pedido BuscarPorId(Guid Id);
        /// <summary>
        /// Adiciona um novo pedido
        /// </summary>
        /// <param name="PedidosItens">Itens do pedido</param>
        /// <returns>Pedido</returns>
        Pedido Adicionar(List<PedidoItem>PedidosItens);
    }
}
