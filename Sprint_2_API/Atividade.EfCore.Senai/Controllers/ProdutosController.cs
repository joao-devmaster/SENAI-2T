using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Atividade.EfCore.Senai.Domains;
using Atividade.EfCore.Senai.Interfaces;
using Atividade.EfCore.Senai.Repositories;
using Atividade.EfCore.Senai.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Atividade.EfCore.Senai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IprodutoRepository _ProdutoRepository;

        public ProdutosController()
        {
            _ProdutoRepository = new ProdutoRepository();
        }
        /// <summary>
        /// mostra todos os produtos cadastrados 
        /// </summary>
        /// <returns>lista com todos os produtos</returns>  
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Lista os produtos
                var produtos = _ProdutoRepository.Listar();

                //Verifico se existe produto cadastrado
                //Caso não exista eu retorno NoContent
                if (produtos.Count == 0)
                    return NoContent();

                //Caso exista retorno Ok e os produtos cadastrados
                return Ok(new
                {
                    totalCount = produtos.Count,
                    data = produtos
                });
            }
            catch (Exception ex)
            {
                //TODO : Cadastrar mensagem de erro no dominio logErro
                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Ocorreu um erro no endpoint Get/produtos, envie um e-mail para email@251.com informando"
                });
            }
        }

        // GET api/produtos
        /// <summary>
        /// mostra um unico produto
        /// </summary>
        /// <param name="id">Id do produto</param>  
        /// <returns>um produto</returns>
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                //faz uma Busca pelos produtos atraves do Id
                Produto produto = _ProdutoRepository.BuscarPorId(id);

                //Verifica se o produto foi encontrado
                //Caso não exista retorno NotFounf
                if (produto == null)
                    return NotFound();
                Moeda dolar = new Moeda();

                //Caso exista retorno Ok e os dados do produto
                return Ok(new
                {
                    produto,
                    ValorDolar = produto.preco / dolar.GetDolarValue()


                });
                   
            }
            catch (Exception ex)
            {
                //Caso ocorra algum erro retorno BadRequest e a mensagem da exception
                return BadRequest(ex.Message);
            }
        }

        // POST api/produtos
        /// <summary>
        /// cadastra um novo produto
        /// </summary>
        /// <param name="produto"> objeto completo do produto</param>  
        /// <returns>produto cadastrado</returns>
        [HttpPost] //FromForm recebe dados do produto via Form-Data
        public IActionResult Post([FromForm]Produto produto)
        {
            try
            {
                if(produto.Imagem != null)
                {
                    var UrlImagem = Upload.Local(produto.Imagem);

                    produto.UrlImagem = UrlImagem;  
                }


                //Adiciona um novo produto
                _ProdutoRepository.Adicionar(produto);

                //Retorna Ok caso o produto tenha sido cadastrado
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/produtos
        /// <summary>
        /// altera determionado produto
        /// </summary>
        /// <param name="id"> Id do produto</param> 
        /// <param name="produto"> objeto produto alterado</param> 
        /// <returns>produto alterado</returns> 
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Produto produto)
        {
            try
            {
                //Edita o produto
                _ProdutoRepository.Editar(produto);

                //Retorna Ok com os dados do produto
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // DELETE api/produtos
        /// <summary>
        /// Exclui um produto
        /// </summary>
        /// <param name="id">Id do produto</param> 
        /// <returns>Id Excluido</returns> 
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                //faz uma Busca pelos produtos atraves do Id
                var produto = _ProdutoRepository.BuscarPorId(id);

                //Verifica se produto existe
                //Caso não exista retorna NotFound
                if (produto == null)
                    return NotFound();

                //Caso exista remove o produto
                _ProdutoRepository.Remover(id);
                //Retorna Ok
                return Ok(id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
