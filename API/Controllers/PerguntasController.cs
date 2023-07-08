using Application.Dto;
using Application.IService;
using Domain.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerguntasController : ControllerBase
    {
        private IPerguntasService _perguntasService;

        public PerguntasController(IPerguntasService perguntasService)
        {
            _perguntasService = perguntasService;
        }

        [HttpGet("todas-as-perguntas")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var perguntasDto = await _perguntasService.GETAllPerguntas();
                return Ok(perguntasDto);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, erro.Message);
            }
        }

        // GET api/<PerguntasController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPerguntasById(int id)
        {
            try
            {
                var reclamacao = await _perguntasService.GetPerguntaByIdAsync(id);
                if (reclamacao == null) return NotFound("Nenhuma pergunta encontrada");

                return Ok(reclamacao);
            }
            catch (Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, erro.Message);
            }
        }

        [HttpPost("{perguntaId}/resposta")]
        public async Task<IActionResult> AdicionarResposta(int perguntaId, [FromBody] RespostaDto resposta)
        {
            // Verificar se a pergunta existe pelo ID
            var perguntaDto = await _perguntasService.GetPerguntaByIdAsync(perguntaId);
            if (perguntaDto == null)
            {
                return NotFound(); // Retornar 404 caso a pergunta não seja encontrada
            }

            await _perguntasService.AdicionarResposta(perguntaId, resposta);

            return Ok(); // Retornar 200 para indicar que a resposta foi adicionada com sucesso
        }

        // PUT api/<PerguntasController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PerguntasController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
