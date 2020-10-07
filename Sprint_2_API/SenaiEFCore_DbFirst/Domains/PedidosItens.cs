using System;
using System.Collections.Generic;

namespace SenaiEFCore_DbFirst.Domains
{
    public partial class PedidosItens
    {
        public Guid Id { get; set; }
        public Guid IdPedido { get; set; }
        public Guid IdProduto { get; set; }
        public int Quantidade { get; set; }

        public virtual Pedidos IdPedidoNavigation { get; set; }
        public virtual Produto IdProdutoNavigation { get; set; }
    }
}
