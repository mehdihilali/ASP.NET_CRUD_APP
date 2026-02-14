using FluentValidation;
using UserManagement.DTO;

namespace UserManagement.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {
            // Regle 1 : First Name et Last Name sont Requis
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First Name is Required")
                .Matches("^[a-zA-ZÀ-ÿ\\s'-]+$").WithMessage("First Name must contain only letters")
                .MaximumLength(100).WithMessage("First Name must not exceed 100 characters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is Required")
                .Matches("^[a-zA-ZÀ-ÿ\\s'-]+$").WithMessage("Last Name must contain only letters")
                .MaximumLength(100).WithMessage("Last Name must not exceed 100 characters");

            // Regle 2 : Email doit etre valide + requis
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email must be a valid email address")
                .MaximumLength(200).WithMessage("Email must not exceed 200 characters");

            // Regle 3 : Age doit etre entre 6 et 130
            RuleFor(x => x.Age)
                .GreaterThanOrEqualTo(6).WithMessage("Age must be greater then 5 YO")
                .LessThanOrEqualTo(130).WithMessage("Age must not exceed 130");
        }
    }
}
