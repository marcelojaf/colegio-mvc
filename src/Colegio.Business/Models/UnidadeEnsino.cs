namespace Colegio.Business.Models
{
    /// <summary>
    /// Classe que representa uma Unidade de Ensino
    /// </summary>
    public class UnidadeEnsino : ColegioBaseEntity
    {
        public string? Nome { get; set; }
        public string? Endereco { get; set; }
        public string? CEP { get; set; }
        public string? Cidade { get; set; }
        public string? UF { get; set; }

        /* EF Relations */

        /// <summary>
        /// Lista de Turmas da Unidade de Ensino
        /// </summary>
        public IEnumerable<Turma> Turmas { get; set; }

    }
}
