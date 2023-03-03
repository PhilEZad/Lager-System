using Domain;
using FluentValidation;

namespace Application.Validators;

public class ItemValidator : AbstractValidator<Item>
{
    public ItemValidator()
    {
    }
}