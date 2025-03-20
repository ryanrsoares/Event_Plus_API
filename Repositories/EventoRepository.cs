using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;

namespace EventPlus_.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly Eventos_Context _context;

        public EventoRepository(Eventos_Context context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, Eventos evento)
        {
            try
            {
                Eventos eventoBuscado = _context.Eventos.Find(id)!;

                if (eventoBuscado != null)
                {
                    eventoBuscado.NomeEvento = evento.NomeEvento;
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Eventos BuscarPorId(Guid id)
        {
            try
            {
                Eventos eventoBuscado = _context.Eventos.Find(id)!;
                return eventoBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Eventos evento)
        {
            try
            {
                _context.Eventos.Add(evento);
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
                Eventos eventoBuscado = _context.Eventos.Find(id)!;
                if(eventoBuscado != null)
                {
                    _context.Eventos.Remove(eventoBuscado);
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Eventos> Listar()
        {
            try
            {
                List<Eventos> listaEvento = _context.Eventos.ToList();
                return listaEvento;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Eventos> ListarPorId(Guid id)
        {
            try
            {
                List<Eventos> listaEvento = _context.Eventos.Where(p => p.EventosID == id).ToList();
                return listaEvento;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Eventos> ListarProximosEventos(Guid id)
        {
            try
            {
                List<Eventos> listarEventosProximos = _context.Eventos.Where(e => e.DataEvento > DateTime.Now).OrderBy(e => e.DataEvento).ToList();
                return listarEventosProximos;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
