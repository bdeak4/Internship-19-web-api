using FluentValidation;
using WebApi.Domain.Models;
using WebApi.Domain.Repositories.Interfaces;

namespace WebApi.Domain.Validators;

public class AdModelValidator : AbstractValidator<AdModel> 
{
    public AdModelValidator(IAdCategoryRepository adCategoryRepository, IAdOwnerRepository adOwnerRepository) 
    {
        RuleFor(ad => ad.Title).NotEmpty();
        RuleFor(ad => ad.Description).NotEmpty();
        RuleFor(ad => ad.Price).GreaterThan(0);
        RuleFor(ad => ad.City).NotEmpty();
        RuleFor(ad => ad.County).NotEmpty();
        
        RuleFor(ad => ad.CategoryId)
            .Must(adCategoryRepository.AdCategoryExists)
            .When(ad => ad.CategoryId != null)
            .WithMessage("Category with categoryId must exist");
    }
}