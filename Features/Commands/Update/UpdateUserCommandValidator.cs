using FluentValidation;

namespace UserManagement.Features.Commands.Update
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()
        {
            RuleFor(x => x.FirstName)
            .NotEmpty().WithMessage("First Name is Required")
            .MaximumLength(100).WithMessage("First Name is Required")
            .Matches("^[a-zA-ZÀ-ÿ\\s'-]+$").WithMessage("First Name must contain only letters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last Name is Required")
                .MaximumLength(100).WithMessage("Last Name is Required")
                .Matches("^[a-zA-ZÀ-ÿ\\s'-]+$").WithMessage("Last Name must contain only letters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is Required")
                .EmailAddress().WithMessage("Email should be a valid email address")
                .MaximumLength(200).WithMessage("Email must not exceed 200 letters");

            RuleFor(x => x.Age)
                .GreaterThanOrEqualTo(18).WithMessage("The User Age must be greater or equal to 18 YO")
                .LessThanOrEqualTo(100).WithMessage("The User Age must not exceed 100 YO");
        }
    }
}
