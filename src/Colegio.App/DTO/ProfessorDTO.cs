using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Colegio.App.DTO
{
    /// <summary>
    /// Classe de transformação de dados de Professor
    /// </summary>
    public class ProfessorDTO
    {
        /// <summary>
        /// Id do Professor
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nome do Professor
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        /// <summary>
        /// Sobrenome do Professor
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(150, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Sobrenome { get; set; }

        /// <summary>
        /// Email do Professor
        /// </summary>
        [StringLength(150, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Email { get; set; }

        /// <summary>
        /// Senha do Usuário
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(20, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Senha { get; set; }

        /// <summary>
        /// Id da Unidade de Ensino
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
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
