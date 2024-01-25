namespace Colegio.Business.Models
{
    /// <summary>
    /// Classe que representa um Professor
    /// </summary>
    public class Professor : ColegioBaseEntity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }

        public Guid UnidadeEnsinoId { get; set; }

        /* EF Relations */

        /// <summary>
        /// Unidade de Ensino do Professor
        /// </summary>
        public UnidadeEnsino UnidadeEnsino { get; set; }
    }
}
