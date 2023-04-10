using Application.DTO;
using Domain;
using FluentValidation;

namespace Application.Validators;

public class ItemValidator : AbstractValidator<Item>
{
    public ItemValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0).WithMessage("Id must be greater than 0.");
        RuleFor(x => x.Id).NotNull().WithMessage("Id cannot be null.");
        RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty.");
        
        RuleFor(x => x.Name).NotNull().WithMessage("Name cannot be null.");
        RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty.");
        RuleFor(x => x.Name).Matches("^[a-zA-Z0-9]*$").WithMessage("Name may only contain alphanumeric characters.");
    }
}