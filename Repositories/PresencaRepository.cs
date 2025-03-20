using EventPlus_.Context;
using EventPlus_.Domains;
using EventPlus_.Interfaces;

namespace EventPlus_.Repositories
{
    public class PresencaRepository : IPresencasRepository
    {
        private readonly Eventos_Context _context;
        public void Atualizar(Guid id, Presenca presenca)
        {
            try
            {
                Presenca presencasEvento = _context.Presencas.Find(id)!;
                if (presencasEvento != null)
                {
                    presencasEvento.Situacao = presenca.Situacao;
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Presenca BuscarPorId(Guid id)
        {
            try
            {
                Presenca presencasEvento = _context.Presencas.Find(id)!;
                return presencasEvento;
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
                Presenca presencaBuscado = _context.Presencas.Find(id)!;

                if (presencaBuscado != null)
                {
                    _context.Presencas.Remove(presencaBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Inscrever(Presenca inscreverPresenca)
        {
            try
            {
                _context.Presencas.Add(inscreverPresenca);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Presenca> Listar()
        {
            try
            {
                List<Presenca> listaPresencas = _context.Presencas.ToList();
                return listaPresencas;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Presenca> ListarMinhasPresencas(Guid id)
        {
            try
            {
                List<Presenca> listaPresenca = _context.Presencas.Where(p => p.UsuarioID == id).ToList();
                return listaPresenca;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
