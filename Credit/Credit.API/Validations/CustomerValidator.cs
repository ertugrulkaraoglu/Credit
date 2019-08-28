using Credit.API.Models.Request;
using FluentValidation;

namespace Credit.API.Validations
{
    public class CustomerValidator : AbstractValidator<CustomerCreditRequest>
    {
        public CustomerValidator()
        {
            RuleFor(x => x.IdentityNumber)
                          .NotNull()
                          .WithMessage("Identity Number cannot be null!");

            RuleFor(x => x.FirstName)
                          .NotNull()
                          .WithMessage("First Name cannot be null!");

            RuleFor(x => x.LastName)
                          .NotNull()
                          .WithMessage("Last Name cannot be null!");

            RuleFor(x => x.PhoneNumber)
                          .NotNull()
                          .WithMessage("Phone Number cannot be null!");

            RuleFor(x => x.MonthlyIncome)
                          .GreaterThan(0)
                          .WithMessage("Monthly Income must be greater than zero!");
        }
    }
}
