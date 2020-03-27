using FluentValidation;
using Treinee.Quake.Domain.Entity;

namespace Treinee.Quake.Domain.Validators
{
    internal class PlayerValidator : AbstractValidator<Player>
    {
        public PlayerValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("Informe o nome do jogador")
                .Length(3, 100)
                .WithMessage("O nome deve possuir no mínimo 3 caracters");
        }
    }
}
