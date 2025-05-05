using FluentValidation;
using PromomashTest.Server.Domain.Models;

namespace PromomashTest.Server.Validation;

public class UserValidator : AbstractValidator<CreateUserRequest>
{
    public UserValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Invalid email format.");

        RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required.")
            .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]")
            .WithMessage("Password must contain at least one uppercase letter, one lowercase letter, and one number.");

        RuleFor(x => x.ConfirmationGiven)
            .NotNull()
            .WithMessage("Confirmation is required.");

        RuleFor(x => x.CountryId)
            .GreaterThan(0)
            .WithMessage("Country ID must be greater than 0.");

        RuleFor(x => x.ProvinceId)
            .GreaterThan(0)
            .WithMessage("Province ID must be greater than 0.");
    }
}
