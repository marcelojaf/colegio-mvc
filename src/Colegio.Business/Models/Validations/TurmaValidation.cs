using FluentValidation;

namespace Colegio.Business.Models.Validations
{
    /// <summary>
    /// Classe de validação para o modelo <see cref="Turma"/>
    /// </summary>
    public class TurmaValidation : AbstractValidator<Turma>
    {
        public TurmaValidation()
        {
            RuleFor(e => e.Nome)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 50).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

        }
    }
}
