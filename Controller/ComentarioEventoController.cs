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

    public class ComentarioEventoController : ControllerBase
    {
        private readonly IComentarioEventoRepository _comentarioEventoRepository;

        public ComentarioEventoController(IComentarioEventoRepository comentarioEventoRepository)
        {
            _comentarioEventoRepository = comentarioEventoRepository;
        }

        /// <summary>
        /// Endpoint para cadastrar novo comentario do evento
        /// </summary>
        [Authorize]
        [HttpPost]
        public IActionResult Post(ComentarioEvento novoComentarioEvento)
        {
            try
            {
                _comentarioEventoRepository.Cadastrar(novoComentarioEvento);
                return Created();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para deletar novo comentario do evento
        /// </summary>
        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _comentarioEventoRepository.Deletar(id);
                return NoContent();
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }
        /// <summary>
        /// Endpoint para listar comentarios do evento
        /// </summary>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                List<ComentarioEvento> listaComentarioEvento = _comentarioEventoRepository.Listar();
                return Ok(listaComentarioEvento);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }

        /// <summary>
        /// Endpoint para buscar por id o comentario do usuario do evento
        /// </summary>
        [HttpGet("BuscarPorIdUsuario/{UsuarioID},{EventoID}")]
        public IActionResult GetById(Guid UsuarioID, Guid EventoID)
        {
            try
            {
                ComentarioEvento novoComentarioEvento = _comentarioEventoRepository.BuscarPorIdUsuario(UsuarioID, EventoID);
                return Ok(novoComentarioEvento);
            }
            catch (Exception error)
            {
                return BadRequest(error.Message);
            }
        }



    }
}