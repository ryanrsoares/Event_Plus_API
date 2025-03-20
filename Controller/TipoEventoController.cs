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
    public class TipoEventoController : ControllerBase
    {
        private readonly ITipoEventoRepository _tipoEventoRepository;

        public TipoEventoController(ITipoEventoRepository tipoEventoRepository)
        {
            _tipoEventoRepository = tipoEventoRepository;
        }

        public IActionResult Get()
        {
            try
            {
                List<TipoEvento> tipoEventos = _tipoEventoRepository.Listar();
                return Ok(tipoEventos);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }
        [HttpGet("BuscarPorId/{id}")]

        public IActionResult GetById(Guid id)
        {
            try
            {
                TipoEvento tipoEventoBuscado = _tipoEventoRepository.BuscarPorId(id);
                return Ok(tipoEventoBuscado);
            }
            catch (Exception e)
            {
                return BadRequest (e.Message);
            }
        }

        /// <summary>
        /// Deletar o tipo do evento pelo ID
        /// </summary>
        /// <returns>Deletar tipo evento</returns>
        [HttpDelete("{id}")]

        public IActionResult Delete(Guid id)
        {
            try
            {
                _tipoEventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Atualiza o tipo do evento pelo ID
        /// </summary>
        /// <returns>Atualizar tipo evento</returns>
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, TipoEvento tipoEvento)
        {
            try
            {
                _tipoEventoRepository.Atualizar(id, tipoEvento);
                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Cadastrar o tipo do evento pelo ID
        /// </summary>
        /// <returns>Cadastrar tipo evento</returns>
        [HttpPost]

        public IActionResult Post(TipoEvento novoTipoEvento)
        {
            try
            {
                _tipoEventoRepository.Cadastrar(novoTipoEvento);
                return Created();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
