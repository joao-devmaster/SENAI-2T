using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.EfCore.Senai.Domains
{
    public class Pedido : BaseDomain 
    {
      
        public string Status { get; set; }
        public DateTime OrderDate { get; set; }

        public List<PedidoItem>pedidoitens { get; set; }


    }
}
