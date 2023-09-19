using System.Text.RegularExpressions;
using FluentValidation;
using IdentityProj.Common.CustomExceptions;

namespace IdentityProj.Services.ApplicationUsers.Command.Create;

public class CreateCommandValidator : AbstractValidator<CreateCommand>
{
    public CreateCommandValidator()
    {
        RuleFor(p => p.PhoneNumber)
            .NotEmpty()
            .Matches(new Regex(@"^0\d{8}$"))
            .WithMessage(ErrorMessages.InvalidPhoneNumber);

        RuleFor(p => p.FullName)
            .NotEmpty()
            .Matches(new Regex(@"^[A-Za-z]+$"))
            .WithMessage(ErrorMessages.InvalidFullName);

        RuleFor(p => p.Password)
            .NotEmpty()
            .Matches(new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[\W_]).*$"))
            .WithMessage(ErrorMessages.InvalidPassword);
    }
}