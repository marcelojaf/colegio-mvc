using FluentValidation;


namespace Colegio.Business.Models.Validations
{
    /// <summary>
    /// Classe de validação para o modelo <see cref="UnidadeEnsino"/>"/>
    /// </summary>
    public class UnidadeEnsinoValidation : AbstractValidator<UnidadeEnsino>
    {
        /// <summary>
        /// Construtor padrão
        /// </summary>
        public UnidadeEnsinoValidation()
        {
            RuleFor(e => e.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 500).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(e => e.Endereco)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(e => e.Cidade)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 200).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(e => e.UF)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2).WithMessage("O campo {PropertyName} precisa ter {ComparisonValue} caracteres e foram fornecidos {PropertyValue}");
        }
    }
}
