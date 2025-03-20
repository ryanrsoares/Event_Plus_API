using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;

namespace EventPlus_.Repositories
{
    public class ComentarioEventosRepository : IComentarioEventoRepository
    {
        private readonly Eventos_Context _context;

        public ComentarioEventosRepository(Eventos_Context context)
        {
            _context = context;
        }
        public ComentarioEvento BuscarPorIdUsuario(Guid UsuarioID, Guid EventosID)
        {
            try
            {
                ComentarioEvento comentarioEventoBuscado = _context.ComentarioEvento.Find(UsuarioID, EventosID)!;
                return comentarioEventoBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(ComentarioEvento comentarioEvento)
        {
            try
            {
                _context.ComentarioEvento.Add(comentarioEvento);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                ComentarioEvento comentarioEventoBuscado = _context.ComentarioEvento.Find(id)!;
                if (comentarioEventoBuscado != null)
                {
                    _context.ComentarioEvento.Remove(comentarioEventoBuscado);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<ComentarioEvento> Listar()
        {
            try
            {
                List<ComentarioEvento> listaComentarioEvento = _context.ComentarioEvento.ToList();
                return listaComentarioEvento;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
