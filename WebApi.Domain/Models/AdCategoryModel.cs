using WebApi.Data.Models.Entities;
using WebApi.Data.Models.Enums;

namespace WebApi.Domain.Models;

public class AdCategoryModel
{
    public string Title { get; set; } = string.Empty;
    public CategoryType Type { get; set; } = CategoryType.Other;
}

public class AdCategoryResponseModel : AdCategoryModel
{
    public int Id { get; set; }
    public int AdCount { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

public class AdCategoryDetailResponseModel : AdCategoryResponseModel
{
    public ICollection<AdResponseModel> Ads { get; set; } = new List<AdResponseModel>();
}


public static class AdCategoryExtensionMethods
{
    public static AdCategory ProjectToAdCategory(this AdCategoryModel model)
    {
        return new AdCategory
        {
            Title = model.Title,
            Type = model.Type,
        };
    }
    
    public static AdCategoryResponseModel ProjectToResponseModel(this AdCategory adCategory)
    {
        return new AdCategoryResponseModel
        {
            Id = adCategory.Id,
            Title = adCategory.Title,
            Type = adCategory.Type,
            CreatedAt = adCategory.CreatedAt,
            AdCount = adCategory.Ads.Where(ad => ad.DeletedAt == null).ToList().Count,
        };
    }
    
    public static AdCategoryDetailResponseModel ProjectToDetailResponseModel(this AdCategory adCategory)
    {
        return new AdCategoryDetailResponseModel
        {
            Id = adCategory.Id,
            Title = adCategory.Title,
            Type = adCategory.Type,
            CreatedAt = adCategory.CreatedAt,
            Ads = adCategory.Ads.Select(ad => ad.ProjectToResponseModel()).ToList()
        };
    }
}