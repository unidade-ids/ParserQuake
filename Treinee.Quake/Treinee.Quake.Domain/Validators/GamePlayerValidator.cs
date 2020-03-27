using FluentValidation;
using Treinee.Quake.Domain.Entity;

namespace Treinee.Quake.Domain.Validators
{
    internal class GamePlayerValidator : AbstractValidator<GamePlayer>
    {
        public GamePlayerValidator()
        {
            RuleFor(x => x.Game)
                .NotNull()
                .WithMessage("Game obrigatório");

            RuleFor(x => x.Player)
                .NotNull()
                .WithMessage("Jogador obrigatório");
        }
    }
}
