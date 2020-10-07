using Atividade.EfCore.Senai.Contexts;
using Atividade.EfCore.Senai.Domains;
using Atividade.EfCore.Senai.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Atividade.EfCore.Senai.Repositories
{
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoContext _ctx;
        public PedidoRepository()
        {
            _ctx = new PedidoContext();
        }
        public Pedido Adicionar(List<PedidoItem> PedidosItens)
        {
            try
            {
                //criação do objeto do tipo pedido passando os valores
                Pedido pedido = new Pedido
                {
                    Status = "Pedido Efetuado",
                    OrderDate = DateTime.Now
                };
                //percorre a lista de pedidositens e adiciona a lista de PedidosItens
                foreach (var item in PedidosItens)
                {
                    pedido.pedidoitens.Add(new PedidoItem
                    {
                        IdPedido = pedido.Id, //Id do objeto PEDIDO criado acima
                    });
                };
                //adiciono o pedido ao meu contexto
                _ctx.Pedidos.Add(pedido);
                //salva as alterações do contexto no banco de dados
                _ctx.SaveChanges();

                return pedido;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public Pedido BuscarPorId(Guid id)
        {
            try
            {
                return _ctx.Pedidos
                    .Include(c => c.pedidoitens)
                    .ThenInclude(c => c.Produto)
                    .FirstOrDefault(p => p.Id == id); //Inner Join
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Pedido> Listar()
        {
            try
            {
                return _ctx.Pedidos.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
