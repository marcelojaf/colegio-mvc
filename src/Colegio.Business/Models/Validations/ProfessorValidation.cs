using FluentValidation;

namespace Colegio.Business.Models.Validations
{
    public class ProfessorValidation : AbstractValidator<Professor>
    {
        public ProfessorValidation()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O nome do professor é obrigatório.")
                .Length(2, 50).WithMessage("O nome do professor deve ter entre 2 e 100 caracteres.");

            RuleFor(p => p.Sobrenome)
                .NotEmpty().WithMessage("O sobrenome do professor é obrigatório.")
                .Length(2, 100).WithMessage("O sobrenome do professor deve ter entre 2 e 100 caracteres.");

            RuleFor(p => p.Email)
                .EmailAddress().WithMessage("O e-mail do professor está em um formato inválido.");
        }
    }
}
