using BrSolution.Application.Extensions;
using BrSolution.Application.Features.Command.App.Users;
using BrSolution.Infrastructure.Extensions;
using FluentValidation;
using System.Linq.Expressions;

namespace BrSolution.Application.Validations.FluentValidations;

public class UserCreateCommandValidator : AbstractValidator<UserCreateCommand>
{
    public UserCreateCommandValidator()
    {
        new Expression<Func<UserCreateCommand, string>>[]
        {
           x=>x.FirstName,
           x=>x.LastName,
           x=>x.Email,
           x=>x.Password,
        }.ForEach(x =>
            RuleFor(x)
            .NotEmpty()
            .CantBeNull());

        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Email address is incorrect form");

        RuleFor(x => x.Password)
            .Must(x =>
            {
                var containsDigit = false;
                var containsLetter = false;

                foreach (var ch in x)
                {
                    if (!containsDigit && char.IsDigit(ch))
                    {
                        containsDigit = true;
                    }

                    else if (!containsLetter && char.IsLetter(ch))
                    {
                        containsLetter = true;
                    }

                    if (containsDigit && containsLetter)
                    {
                        return true;
                    }
                }

                return false;
            }).WithMessage("Password is not strong");

    }
}
