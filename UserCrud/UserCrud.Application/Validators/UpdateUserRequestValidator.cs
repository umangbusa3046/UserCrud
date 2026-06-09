using FluentValidation;
using UserCrud.Application.DTOs.User;

namespace UserCrud.Application.Validators;

public sealed class UpdateUserRequestValidator
    : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .WithMessage("First Name is required.")
            .MaximumLength(100);

        RuleFor(x => x.LastName)
            .NotEmpty()
            .WithMessage("Last Name is required.")
            .MaximumLength(100);

        RuleFor(x => x.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .EmailAddress()
            .WithMessage("Invalid email format.")
            .MaximumLength(200);
    }
}