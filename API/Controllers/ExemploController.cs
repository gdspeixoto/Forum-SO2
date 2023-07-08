using Application.Filter;
using Application.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExemploController : ControllerBase
    {
        private IExemploService _exemploService;

        public ExemploController(IExemploService exemploService)
        {
            _exemploService = exemploService;
        }

        [HttpPost("obter-exemplos")]
        public async Task<IActionResult> Get([FromHeader] int pulo, [FromHeader] int limite, [FromBody] ExemploFiltroDto filtro)
        {
            try
            {
                var alunoDTO = await _exemploService.GETAllExemplo(pulo, limite, filtro);
                return Ok(alunoDTO);
            }catch(Exception erro)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, erro.Message);
            }
        }

    }
}
