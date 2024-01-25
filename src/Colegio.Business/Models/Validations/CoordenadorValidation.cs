using FluentValidation;

namespace Colegio.Business.Models.Validations
{
    public class CoordenadorValidation : AbstractValidator<Coordenador>
    {
        public CoordenadorValidation()
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O nome do coordenador é obrigatório.")
                .Length(2, 50).WithMessage("O nome do coordenador deve ter entre 2 e 100 caracteres.");

            RuleFor(p => p.Sobrenome)
                .NotEmpty().WithMessage("O sobrenome do coordenador é obrigatório.")
                .Length(2, 100).WithMessage("O sobrenome do coordenador deve ter entre 2 e 100 caracteres.");

            RuleFor(p => p.Email)
                .EmailAddress().WithMessage("O e-mail do coordenador está em um formato inválido.");
        }
    }
}
