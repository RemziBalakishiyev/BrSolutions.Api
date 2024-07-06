using BrSolution.Application.Features.Command.App.Auth;
using FluentValidation;

namespace BrSolution.Application.Validations.FluentValidations;

public class AddUserRoleCommandValidator : AbstractValidator<AddUserRoleCommand>
{
    public AddUserRoleCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name can't null");

        RuleFor(x => x.SelectedSystemServices)
           .NotEmpty()
           .WithMessage("SystemService can't null");
    }
}
