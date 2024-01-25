namespace Colegio.Business.Models
{
    /// <summary>
    /// Classe que representa um Coordenador
    /// </summary>
    public class Coordenador : ColegioBaseEntity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }

        public Guid UnidadeEnsinoId { get; set; }

        /* EF Relations */

        /// <summary>
        /// Unidade de Ensino do Coordenador
        /// </summary>
        public UnidadeEnsino UnidadeEnsino { get; set; }
    }
}
