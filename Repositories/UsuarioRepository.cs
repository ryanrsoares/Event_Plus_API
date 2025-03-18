using EventPlus_.Domains;
using EventPlus_.Interfaces;

namespace EventPlus_.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Usuario _context;
        public UsuarioRepository( UsuarioRepository context)
        {
            _context = context;
        }
        public Usuario BuscarPorEmailESenha(string email, string senha)
        {
            try
            {
                Usuario usuarioBsucado = _context.UsuarioID.FistOrDefault(u => u.Email == email)!;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Usuario BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Usuario novoUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
