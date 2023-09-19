using System.Text.RegularExpressions;
using FluentValidation;
using IdentityProj.Common.CustomExceptions;

namespace IdentityProj.Services.ApplicationUsers.Command.Update;

public class UpdateCommandValidator : AbstractValidator<UpdateCommand>
{
    public UpdateCommandValidator()
    {
        RuleFor(p => p.PhoneNumber)
            .Matches(new Regex(@"^0\d{8}$"))
            .WithMessage(ErrorMessages.InvalidPhoneNumber);

        RuleFor(p => p.FullName)
            .Matches(new Regex(@"^[A-Za-z]+$"))
            .WithMessage(ErrorMessages.InvalidFullName);

        RuleFor(p => p.Password)
            .Matches(new Regex(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*[\W_]).*$"))
            .WithMessage(ErrorMessages.InvalidPassword);
    }
}