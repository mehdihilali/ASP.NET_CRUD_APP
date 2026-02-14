using FluentValidation;
using UserManagement.DTO;

namespace UserManagement.Validators
{
    public class UpdateUserValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserValidator()
        {
            // Mêmes règles que CreateUserValidator
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .Matches("^[a-zA-ZÀ-ÿ\\s'-]+$").WithMessage("First Name must contain only letters")
                .MaximumLength(100).WithMessage("First name must not exceed 100 characters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required")
                .Matches("^[a-zA-ZÀ-ÿ\\s'-]+$").WithMessage("Last Name must contain only letters")
                .MaximumLength(100).WithMessage("Last name must not exceed 100 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email must be a valid email address")
                .MaximumLength(200).WithMessage("Email must not exceed 200 characters");

            RuleFor(x => x.Age)
                .GreaterThanOrEqualTo(6).WithMessage("Age must be at least 6")
                .LessThanOrEqualTo(130).WithMessage("Age must not exceed 130");
        }
    }
}
