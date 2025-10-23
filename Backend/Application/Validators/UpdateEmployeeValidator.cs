using Application.Requests;
using FluentValidation;

namespace Application.Validators
{
    public class UpdateEmployeeValidator : AbstractValidator<UpdateEmployeeRequest>
    {
        public UpdateEmployeeValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Id is invalid");

            RuleFor(x => x.FirstName)
                .NotNull()
                .WithMessage("Firt name is null")
                .NotEmpty()
                .WithMessage("Firt name is empty")
                .MinimumLength(4)
                .WithMessage("Firt name should have 4 characters");

            RuleFor(x => x.LastName)
                .NotNull()
                .WithMessage("Last name is null")
                .NotEmpty()
                .WithMessage("Last name is empty")
                .MinimumLength(4)
                .WithMessage("Last name should have 4 characters");

            RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("Email is null")
                .NotEmpty()
                .WithMessage("Email is empty")
                .EmailAddress()
                .WithMessage("Email is invalid");

            RuleFor(x => x.Position)
                .NotNull()
                .WithMessage("Position is null")
                .NotEmpty()
                .WithMessage("Position is empty")
                .MinimumLength(4)
                .WithMessage("Position should have 4 characters");
        }
    }
}
