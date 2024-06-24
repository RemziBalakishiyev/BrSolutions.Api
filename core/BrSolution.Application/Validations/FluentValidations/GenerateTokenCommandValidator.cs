using BrSolution.Application.Extensions;
using BrSolution.Application.Features.Command.App.Auth;
using FluentValidation;

namespace BrSolution.Application.Validations.FluentValidations
{
    public class GenerateTokenCommandValidator : AbstractValidator<GenerateTokenCommand>
    {
        public GenerateTokenCommandValidator()
        {
            RuleFor(c => c.Email)
                .NotEmpty()
                .CantBeNull();
            RuleFor(x => x.Email)
                .EmailAddress()
                .WithMessage("Email is incorrect form");

            RuleFor(x => x.Password)
                .NotEmpty()
                .CantBeNull();
        }
    }
}
