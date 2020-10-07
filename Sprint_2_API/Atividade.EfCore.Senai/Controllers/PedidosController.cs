using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Atividade.EfCore.Senai.Domains;
using Atividade.EfCore.Senai.Interfaces;
using Atividade.EfCore.Senai.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Atividade.EfCore.Senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private readonly IPedidoRepository _PedidoRepository;

        public PedidosController()
        {
            _PedidoRepository = new PedidoRepository();

        }

        [HttpPost]
        public IActionResult Post(List<PedidoItem> PedidoItens)
        {
            try
            {   //Adiciona um pedido
                Pedido pedido = _PedidoRepository.Adicionar(PedidoItens);
                return Ok(pedido);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var pedidos = _PedidoRepository.Listar();

                if (pedidos.Count == 0)
                    return NoContent();

                return Ok(pedidos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var Pedido=_PedidoRepository.BuscarPorId(id);

                if (Pedido == null)
                    return NotFound();

                return Ok(Pedido);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
