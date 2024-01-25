using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Colegio.App.DTO
{
    /// <summary>
    /// Classe de transformação de dados de Aluno
    /// </summary>
    public class AlunoDTO
    {
        /// <summary>
        /// Id do Aluno
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nome do Aluno
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        /// <summary>
        /// Sobrenome do Aluno
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(150, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Sobrenome { get; set; }

        /// <summary>
        /// Email do Aluno
        /// </summary>
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Email { get; set; }

        /// <summary>
        /// Matricula do Aluno
        /// </summary>
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Matricula { get; set; }

        /// <summary>
        /// Id da Unidade de Ensino
        /// </summary>
        [DisplayName("Unidade de Ensino")]
        public Guid UnidadeEnsinoId { get; set; }

        /// <summary>
        /// Nome da Unidade de Ensino
        /// </summary>
        [DisplayName("Unidade de Ensino")]
        public string NomeUnidadeEnsino { get; set; }

        public IEnumerable<UnidadeEnsinoDTO> UnidadesEnsino { get; set; }
    }
}
