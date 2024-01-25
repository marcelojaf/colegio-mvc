using System.ComponentModel.DataAnnotations;

namespace Colegio.App.DTO
{
    /// <summary>
    /// Classe de transformação de dados de Turma
    /// </summary>
    public class TurmaDTO
    {
        /// <summary>
        /// Id da Turma
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nome da Turma
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        /// <summary>
        /// Descrição da Turma
        /// </summary>
        public string Descricao { get; set; }

        /// <summary>
        /// Período da Turma
        /// </summary>
        public int Periodo { get; set; }

        /// <summary>
        /// Nome do Período da Turma
        /// </summary>
        public string PeriodoNome { get; set; }

        /// <summary>
        /// Id da Unidade de Ensino
        /// </summary>
        public Guid UnidadeEnsinoId { get; set; }

        /// <summary>
        /// Nome da Unidade de Ensino
        /// </summary>
        public string NomeUnidadeEnsino { get; set; }
    }
}
