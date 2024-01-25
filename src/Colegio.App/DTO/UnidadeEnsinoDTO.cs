using System.ComponentModel.DataAnnotations;

namespace Colegio.App.DTO
{
    /// <summary>
    /// Classe de transformação de dados de Unidade de Ensino
    /// </summary>
    public class UnidadeEnsinoDTO
    {
        /// <summary>
        /// Id da Unidade de Ensino
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Nome da Unidade de Ensino
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        /// <summary>
        /// Endereço da Unidade de Ensino
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Endereco { get; set; }

        /// <summary>
        /// CEP da Unidade de Ensino
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(8, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 8)]
        public string CEP { get; set; }

        /// <summary>
        /// Cidade da Unidade de Ensino
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(100, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Cidade { get; set; }

        /// <summary>
        /// UF da Unidade de Ensino
        /// </summary>
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string UF { get; set; }
    }
}
