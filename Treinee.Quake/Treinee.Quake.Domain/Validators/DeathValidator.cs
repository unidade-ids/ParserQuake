using FluentValidation;
using Treinee.Quake.Domain.Entity;

namespace Treinee.Quake.Domain.Validators
{
    internal class DeathValidator : AbstractValidator<Death>
    {
        public DeathValidator()
        {
            RuleFor(x => x.Killer)
                .NotNull()
                .WithMessage("Killer obrigatório para mortes");

            RuleFor(x => x.Killed)
                .NotNull()
                .WithMessage("Killed obrigatório para mortes");

            RuleFor(x => x.Game)
                .NotNull()
                .WithMessage("Game obrigatório para mortes");

            RuleFor(x => x.Armor)
                .NotNull()
                .WithMessage("Armor obrigatório para mortes");
        }
    }
}
