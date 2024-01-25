using Colegio.Business.Interfaces;
using Colegio.Business.Models;
using Colegio.Data.Context;

namespace Colegio.Data.Repository
{
    /// <summary>
    /// Classe de Repositório para a entidade <see cref="UnidadeEnsino"/>
    /// </summary>
    public class UnidadeEnsinoRepository : Repository<UnidadeEnsino>, IUnidadeEnsinoRepository
    {
        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="db"></param>
        public UnidadeEnsinoRepository(ColegioDbContext db) : base(db)
        {

        }
    }
}
