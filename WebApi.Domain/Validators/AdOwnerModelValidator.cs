using FluentValidation;
using WebApi.Domain.Models;

namespace WebApi.Domain.Validators;

public class AdOwnerModelValidator : AbstractValidator<AdOwnerModel>
{
    public AdOwnerModelValidator()
    {
        RuleFor(adOwner => adOwner.FirstName).NotEmpty();
        RuleFor(adOwner => adOwner.LastName).NotEmpty();
        RuleFor(adOwner => adOwner.Phone).NotEmpty();
        RuleFor(adOwner => adOwner.Email).EmailAddress();
    }
}