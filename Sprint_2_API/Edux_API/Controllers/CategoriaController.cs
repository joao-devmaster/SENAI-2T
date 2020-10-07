using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Edux.Contexts;
using Edux.Domains;
using Edux.Interface;
using Edux.Repositories;

namespace Edux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepository _categoriaRepository;

        public CategoriaController()
        {
            _categoriaRepository = new CategoriaRepository();
        }

        /// <summary>
        /// Lista todas as Categorias cadastrados
        /// </summary>
        /// <returns>retorna uma lista com todas as Categorias</returns>
        // GET: api/<CategoriaController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Recebe a lista de Categorias
                var Categoria = _categoriaRepository.Listar();

                // Se a variável estiver nula retorna NoContent
                if (Categoria == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(new
                    {
                        totalCount = Categoria.Count(),
                        data = Categoria
                    });
                }

            }
            catch (Exception)
            {
                return BadRequest(new
                {
                    statusCode = 400,
                    error = "Erro 400, entrar em contato com o nosso suporte técnico"
                });
            }
        }

        /// <summary>
        /// Busca a categoria com através do id
        /// </summary>
        /// <param name="id">Id da Categoria</param>
        /// <returns>Objeto Categoria</returns>
        // GET api/<CategoriaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                // Objeto do tipo Categoria que recebe um objeto do método BuscarPorId 
                Categoria user = _categoriaRepository.BuscarPorId(id);

                // Se o objeto estiver nulo retorna NotFound 
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    // Se o objeto for encontrado retorna 200
                    return Ok(user);
                }
            }
            catch (Exception ex)
            {
                // Se ocorrer alguma exceção retorna a mensagem de erro para o frontend
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Cadastra uma nova Categoria
        /// </summary>
        /// <param name="categoria">Objeto Usuario</param>
        // POST api/<CategoriaController>
        [HttpPost]
        public IActionResult Post([FromBody] Categoria categoria)
        {
            try
            {
                //Adiciona uma nova Categoria
                _categoriaRepository.Adicionar(categoria);

                //statusCode 200
                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Altera uma Categoria
        /// </summary>
        /// <param name="id">Id da Categoria que será alterada</param>
        /// <param name="categoria">Dados da Categoria que serão alterados</param>
        // PUT api/<CategoriaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Categoria categoria)
        {
            try
            {
                _categoriaRepository.Editar(id, categoria);

                return Ok(categoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Remove uma Categoria
        /// </summary>
        /// <param name="id">Id da Categoria</param>
        /// <returns></returns>
        // DELETE api/<CategoriaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Categoria categoria = _categoriaRepository.BuscarPorId(id);

                if (categoria == null)
                {
                    return NotFound();
                }
                else
                {
                    //Passa o id da Categoria que será excluído
                    _categoriaRepository.Remover(id);

                    return Ok(categoria);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
