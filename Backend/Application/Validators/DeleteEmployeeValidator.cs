using FluentValidation;

namespace Application.Validators
{
    public class DeleteEmployeeValidator : AbstractValidator<int>
    {
        public DeleteEmployeeValidator()
        {
            RuleFor(x => x)
                .GreaterThan(0)
                .WithMessage("Id is invalid");
        }
    }
}
