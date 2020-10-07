using System;
using System.Collections.Generic;

namespace SenaiEFCore_DbFirst.Domains
{
    public partial class Produto
    {
        public Produto()
        {
            PedidosItens = new HashSet<PedidosItens>();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }

        public virtual ICollection<PedidosItens> PedidosItens { get; set; }
    }
}
