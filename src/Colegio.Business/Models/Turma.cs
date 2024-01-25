using Colegio.Business.Models.Enums;

namespace Colegio.Business.Models
{
    /// <summary>
    /// Classe que representa uma Turma
    /// </summary>
    public class Turma : ColegioBaseEntity
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public PeriodoEnum Periodo { get; set; }

        public Guid UnidadeEnsinoId { get; set; }



        /* EF Relations */

        /// <summary>
        /// Unidade de Ensino da Turma
        /// </summary>
        public UnidadeEnsino UnidadeEnsino { get; set; }
    }
}
