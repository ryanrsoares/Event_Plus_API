using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Repositories
{

    /// <summary>
    /// Repositório para gerenciamento dos tipos de usuários
    /// </summary>
    public class TiposUsuariosRepository : ITiposUsuariosRepository
    {
        private readonly Context _context;

        /// <summary>
        /// Repositório para gerenciamento dos tipos de usuários
        /// </summary>
        public TiposUsuariosRepository(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Repositório para gerenciamento dos tipos de usuários
        /// </summary>
        public void Atualizar(Guid id, TiposUsuarios tipoUsuario)
        {
            try
            {
                TiposUsuarios tipoBuscado = _context.TiposUsuarios.Find(id)!;

                if (tipoBuscado != null)
                {
                    tipoBuscado.TituloTipoUsuario = tipoUsuario.TituloTipoUsuario;
                }

                _context.TiposUsuarios.Update(tipoBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Repositório para gerenciamento dos tipos de usuários
        /// </summary>
        public TiposUsuarios BuscarPorId(Guid id)
        {
            try
            {
                return _context.TiposUsuarios.Find(id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Repositório para gerenciamento dos tipos de usuários
        /// </summary>
        public void Cadastrar(TiposUsuarios tipoUsuario)
        {
            try
            {
                tipoUsuario.IdTipoUsuario = Guid.NewGuid();

                _context.TiposUsuarios.Add(tipoUsuario);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Repositório para gerenciamento dos tipos de usuários
        /// </summary>
        public void Deletar(Guid id)
        {
            try
            {
                TiposUsuarios tipoBuscado = _context.TiposUsuarios.Find(id)!;

                if (tipoBuscado != null)
                {
                    _context.TiposUsuarios.Remove(tipoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Repositório para gerenciamento dos tipos de usuários
        /// </summary>
        public List<TiposUsuarios> Listar()
        {
            try
            {
                return _context.TiposUsuarios.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
