using webapi.event_.Contexts;
using webapi.event_.Domains;
using webapi.event_.Interfaces;

namespace webapi.event_.Repositories
{

    /// <summary>
    /// Repositório para gerenciamento das presenças dos eventos
    /// </summary>
    public class PresencasEventosRepository : IPresencasEventosRepository
    {
        private readonly Context _context;


        /// <summary>
        /// Repositório para gerenciamento das presenças dos eventos
        /// </summary>
        public PresencasEventosRepository(Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Repositório para gerenciamento das presenças dos eventos
        /// </summary>
        public void Atualizar(Guid id, PresencasEventos presencaEvento)
        {
            try
            {
                PresencasEventos presencaEventoBuscado = _context.PresencasEventos.Find(id)!;

                if (presencaEventoBuscado != null)
                {
                    if (presencaEventoBuscado.Situacao)
                    {
                        presencaEventoBuscado.Situacao = false;
                    }
                    else
                    {
                        presencaEventoBuscado.Situacao = true;
                    }

                }

                _context.PresencasEventos.Update(presencaEventoBuscado!);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Repositório para gerenciamento das presenças dos eventos
        /// </summary>
        public PresencasEventos BuscarPorId(Guid id)
        {
            try
            {
                return _context.PresencasEventos
                    .Select(p => new PresencasEventos
                    {
                        IdPresencaEvento = p.IdPresencaEvento,
                        Situacao = p.Situacao,

                        Evento = new Eventos
                        {
                            IdEvento = p.IdEvento!,
                            DataEvento = p.Evento!.DataEvento,
                            NomeEvento = p.Evento.NomeEvento,
                            Descricao = p.Evento.Descricao,

                            Instituicao = new Instituicoes
                            {
                                IdInstituicao = p.Evento.Instituicao!.IdInstituicao,
                                NomeFantasia = p.Evento.Instituicao!.NomeFantasia
                            }
                        }

                    }).FirstOrDefault(p => p.IdPresencaEvento == id)!;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Repositório para gerenciamento das presenças dos eventos
        /// </summary>
        public void Deletar(Guid id)
        {
            try
            {
                PresencasEventos presencaEventoBuscado = _context.PresencasEventos.Find(id)!;

                if (presencaEventoBuscado != null)
                {
                    _context.PresencasEventos.Remove(presencaEventoBuscado);
                }

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Repositório para gerenciamento das presenças dos eventos
        /// </summary>
        public void Inscrever(PresencasEventos inscricao)
        {
            try
            {
                inscricao.IdPresencaEvento = Guid.NewGuid();

                _context.PresencasEventos.Add(inscricao);

                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Repositório para gerenciamento das presenças dos eventos
        /// </summary>
        public List<PresencasEventos> Listar()
        {

            try
            {
                return _context.PresencasEventos
                    .Select(p => new PresencasEventos
                    {
                        IdPresencaEvento = p.IdPresencaEvento,
                        Situacao = p.Situacao,

                        Evento = new Eventos
                        {
                            IdEvento = p.IdEvento,
                            DataEvento = p.Evento!.DataEvento,
                            NomeEvento = p.Evento.NomeEvento,
                            Descricao = p.Evento.Descricao,

                            Instituicao = new Instituicoes
                            {
                                IdInstituicao = p.Evento.Instituicao!.IdInstituicao,
                                NomeFantasia = p.Evento.Instituicao!.NomeFantasia
                            }
                        }

                    }).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Repositório para gerenciamento das presenças dos eventos
        /// </summary>
        public List<PresencasEventos> ListarMinhas(Guid id)
        {
            return _context.PresencasEventos
                .Select(p => new PresencasEventos
                {
                    IdPresencaEvento = p.IdPresencaEvento,
                    Situacao = p.Situacao,
                    IdUsuario = p.IdUsuario,
                    IdEvento = p.IdEvento,

                    Evento = new Eventos
                    {
                        IdEvento = p.IdEvento,
                        DataEvento = p.Evento!.DataEvento,
                        NomeEvento = p.Evento!.NomeEvento,
                        Descricao = p.Evento!.Descricao,

                        Instituicao = new Instituicoes
                        {
                            IdInstituicao = p.Evento!.IdInstituicao,
                        }
                    }
                })
                .Where(p => p.IdUsuario == id)
                .ToList();
        }
    }
}