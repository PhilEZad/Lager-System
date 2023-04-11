using Application.DTO;
using Domain;
using FluentValidation;

namespace Application.Validators;

public class ItemValidator : AbstractValidator<Item>
{
    public ItemValidator()
    {
        RuleSet("Default", () =>
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
            RuleFor(x => x.Id).NotNull().WithMessage("Id cannot be null.");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty.");
            RuleFor(x => x.Name).Matches("^[a-zA-Z0-9]*$").WithMessage("Name may only contain alphanumeric characters.");
        });

        RuleSet("Add", () =>
        {
            RuleFor(x => x.Id).Equal(0).WithMessage("Id must be 0.");
            RuleFor(x => x.Id).NotNull().WithMessage("Id cannot be null.");

            RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty.");
            RuleFor(x => x.Name).Matches("^[a-zA-Z0-9]*$").WithMessage("Name may only contain alphanumeric characters.");
        });
    }
}