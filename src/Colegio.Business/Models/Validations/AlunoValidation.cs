using FluentValidation;

namespace Colegio.Business.Models.Validations
{
    public class AlunoValidation : AbstractValidator<Aluno>
    {
        public AlunoValidation()
        {
            RuleFor(a => a.Nome)
                .NotEmpty().WithMessage("O nome do aluno é obrigatório.")
                .Length(2, 50).WithMessage("O nome do aluno deve ter entre 2 e 100 caracteres.");

            RuleFor(a => a.Sobrenome)
                .NotEmpty().WithMessage("O sobrenome do aluno é obrigatório.")
                .Length(2, 100).WithMessage("O sobrenome do aluno deve ter entre 2 e 100 caracteres.");

            RuleFor(a => a.Email)
                .EmailAddress().WithMessage("O e-mail do aluno está em um formato inválido.");
        }
    }
}
