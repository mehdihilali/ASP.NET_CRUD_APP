using FluentValidation;

namespace UserManagement.Features.Commands.Create
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is required")
                .MaximumLength(100).WithMessage("First Name must not exceed 100 letters")
                .Matches("^[a-zA-ZÀ-ÿ\\s'-]+$").WithMessage("First Name must contain only letters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is required")
                .MaximumLength(100).WithMessage("Last Name must not exceed 100 letters")
                .Matches("^[a-zA-ZÀ-ÿ\\s'-]+$").WithMessage("Last Name must contain only letters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .MaximumLength(200).WithMessage("Email must not exceed 100 letters")
                .EmailAddress().WithMessage("Email must be a valid email address");

            RuleFor(x => x.Age)
                .GreaterThanOrEqualTo(6).WithMessage("Age must be at least 6 YO")
                .LessThanOrEqualTo(130).WithMessage("Age must not exceed 130 TO");
        }
    }
}
