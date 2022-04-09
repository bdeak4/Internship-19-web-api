using FluentValidation;
using WebApi.Domain.Models;

namespace WebApi.Domain.Validators;

public class AdCategoryModelValidator :  AbstractValidator<AdCategoryModel> 
{
    public AdCategoryModelValidator()
    {
        RuleFor(adCategory => adCategory.Title).NotEmpty();
        RuleFor(adCategory => adCategory.Type).IsInEnum();
    }
}