using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Edux.Contexts;
using Edux.Domains;
using Edux.Interfaces;
using Edux.Repositories;

namespace Edux.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorTurmaController : ControllerBase
    {
        private readonly IProfessorTurmaRepository _professorturmaRepository;

        public ProfessorTurmaController()
        {
            _professorturmaRepository = new ProfessorTurmaRepository();
        }

        /// <summary>
        /// Lista todos os "ProfessorTurma" cadastrados
        /// </summary>
        /// <returns>retorna uma lista com todas os "ProfessorTurma"</returns>
        // GET: api/<ProfessorTurmaController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                // Recebe a lista de "ProfessorTurma"
                var professorTurmas = _professorturmaRepository.Listar();

                // Se a variável estiver nula retorna NoContent
                if (professorTurmas == null)
                {
                    return NoContent();
                }
                else
                {
                    return Ok(new
                    {
                        totalCount = professorTurmas.Count(),
                        data = professorTurmas
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
        /// Busca os "ProfessorTurma" com o id passado
        /// </summary>
        /// <param name="id">Id do "ProfessorTurma"</param>
        /// <returns>Objeto "ProfessorTurma"</returns>
        // GET api/<ProfessorTurmaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                // Objeto do tipo "ProfessorTurma" que recebe um objeto do método BuscarPorId 
                ProfessorTurma user = _professorturmaRepository.BuscarPorId(id);

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
        /// Cadastra um novo "ProfessorTurma"
        /// </summary>
        /// <param name="profturm">Objeto "ProfessorTurma"</param>
        // POST api/<ProfessorTurmaController>
        [HttpPost]
        public IActionResult Post([FromBody] ProfessorTurma profturm)
        {
            try
            {
                //Adiciona um novo "ProfessorTurma"
                _professorturmaRepository.Adicionar(profturm);

                //statusCode 200
                return Ok(profturm);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Altera um "ProfessorTurma"
        /// </summary>
        /// <param name="id">Id do "ProfessorTurma" que será alterada</param>
        /// <param name="profturm">Dados do "ProfessorTurma" que serão alterados</param>
        // PUT api/<ProfessorTurmaController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ProfessorTurma profturm)
        {
            try
            {
                _professorturmaRepository.Editar(id, profturm);

                return Ok(profturm);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Remove um ProfessorTurma
        /// </summary>
        /// <param name="id">Id do ProfessorTurma</param>
        /// <returns></returns>
        // DELETE api/<ProfessorTurmaController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                ProfessorTurma profturm = _professorturmaRepository.BuscarPorId(id);

                if (profturm == null)
                {
                    return NotFound();
                }
                else
                {
                    //Passa o id do ProfessorTurma que será excluído
                    _professorturmaRepository.Remover(id);

                    return Ok(profturm);
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
