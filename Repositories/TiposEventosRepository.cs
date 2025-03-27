using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Repositories
{


    /// <summary>
    /// Repositório para gerenciamento dos tipos de eventos
    /// </summary>
    public class TiposEventosRepository : ITiposEventosRepository
    {

        private readonly Context _context;

        /// <summary>
        /// Repositório para gerenciamento dos tipos de eventos
        /// </summary>
        public TiposEventosRepository(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Repositório para gerenciamento dos tipos de eventos
        /// </summary>
        public void Atualizar(Guid id, TiposEventos tipoEvento)
        {
            try
            {
                TiposEventos tipoBuscado = _context.TiposEventos.Find(id)!;

                if (tipoBuscado != null)
                {
                    tipoBuscado.TituloTipoEvento = tipoEvento.TituloTipoEvento;
                }

                _context.TiposEventos.Update(tipoBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Repositório para gerenciamento dos tipos de eventos
        /// </summary>
        public TiposEventos BuscarPorId(Guid id)
        {
            try
            {
                return _context.TiposEventos.Find(id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Repositório para gerenciamento dos tipos de eventos
        /// </summary>

        public void Cadastrar(TiposEventos tipoEvento)
        {
            try
            {
                tipoEvento.IdTipoEvento = Guid.NewGuid();

                _context.TiposEventos.Add(tipoEvento);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Repositório para gerenciamento dos tipos de eventos
        /// </summary>
        public void Deletar(Guid id)
        {
            try
            {
                TiposEventos tipoBuscado = _context.TiposEventos.Find(id)!;

                if (tipoBuscado != null)
                {
                    _context.TiposEventos.Remove(tipoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Repositório para gerenciamento dos tipos de eventos
        /// </summary>
        public List<TiposEventos> Listar()
        {
            try
            {
                return _context.TiposEventos
                    .OrderBy(tp => tp.TituloTipoEvento)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
