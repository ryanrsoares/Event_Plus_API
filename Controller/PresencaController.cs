using EventPlus_.Domains;
using EventPlus_.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus_.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class PresencaController : ControllerBase
    {
        private readonly IPresencasRepository _presencaRepository;

        public PresencaController(IPresencasRepository presencaRepository)
        {
            _presencaRepository = presencaRepository;
        }
        /// <summary>
        /// Endpoint para deletar a presença
        /// </summary>
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _presencaRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para buscar por Id a presença
        /// </summary>
        [HttpGet("BuscarPorId/{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                Presenca novaPresenca = _presencaRepository.BuscarPorId(id);
                return Ok(novaPresenca);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para atualizar as presenças
        /// </summary>
        [Authorize]
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Presenca presenca)
        {
            try
            {
                _presencaRepository.Atualizar(id, presenca);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para fazer uma lista das presenças
        /// </summary>
        [HttpGet("ListarPresencas")]
        public IActionResult Get()
        {
            try
            {
                List<Presenca> listaPresencas = _presencaRepository.Listar();
                return Ok(listaPresencas);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para fazer uma lista das minhas presenças
        /// </summary>
        [HttpGet("ListarMinhasPresencas/{id}")]
        public IActionResult Get(Guid id)
        {
            try
            {
                List<Presenca> listaMinhasPresencas = _presencaRepository.ListarMinhasPresencas(id);
                return Ok(listaMinhasPresencas);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
