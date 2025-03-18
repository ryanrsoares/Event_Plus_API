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
    public class EventoController : ControllerBase
    {
        private readonly IEventoRepository _eventoRepository;

        public EventoController(IEventoRepository eventoRepository)
        {
            _eventoRepository = eventoRepository;
        }

        /// <summary>
        /// Endpoint para cadastrar novo evento
        /// </summary>
        [Authorize]
        [HttpPost]

        public IActionResult Post (Eventos eventoRepository)
        {
            try
            {
                _eventoRepository.Cadastrar(eventoRepository);
                return Created();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete (Guid id)
        {
            try
            {
                _eventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                List<Eventos> ListarEventos = _eventoRepository.Listar();
                return Ok(ListarEventos);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("ListarProximosEventos/{id}")]

        public IActionResult Get(Guid id)
        {
            try
            {
                List<Eventos> ListarEventos = _eventoRepository.ListarProximosEventos(id);
                return Ok(ListarEventos);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [HttpGet("BuscarPorId/ {id}")]

        public IActionResult GetById (Guid id)
        {
            try
            {
                Eventos novoEvento = _eventoRepository.BuscarPorId(id);
                return Ok(novoEvento);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        [Authorize]
        [HttpPost("{id}")]

        public IActionResult Put (Guid id, Eventos novoEvento)
        {
            try
            {
                _eventoRepository.Atualizar(id, novoEvento);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
    }
}
