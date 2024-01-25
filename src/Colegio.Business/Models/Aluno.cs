namespace Colegio.Business.Models
{
    /// <summary>
    /// Classe que representa um Aluno
    /// </summary>
    public class Aluno : ColegioBaseEntity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Matricula { get; set; }

        public Guid UnidadeEnsinoId { get; set; }

        /* EF Relations */

        /// <summary>
        /// Unidade de Ensino do Professor
        /// </summary>
        public UnidadeEnsino UnidadeEnsino { get; set; }
    }
}
