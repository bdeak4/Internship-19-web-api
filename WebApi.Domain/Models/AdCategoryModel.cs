using WebApi.Data.Models.Entities;
using WebApi.Data.Models.Enums;

namespace WebApi.Domain.Models;

public class AdCategoryModel
{
    public string Title { get; set; } = string.Empty;
    public CategoryType Type { get; set; } = CategoryType.Other;
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

public class AdCategoryResponseModel : AdCategoryModel
{
    public int Id { get; set; }
}

public class AdCategoryDetailResponseModel : AdResponseModel
{
    public ICollection<Ad> Ads { get; set; } = new List<Ad>();
}


public static class AdCategoryExtensionMethods
{
    public static AdCategory ProjectToAdCategory(this AdCategoryModel model)
    {
        return new AdCategory
        {
            Title = model.Title,
            Type = model.Type,
            CreatedAt = model.CreatedAt,
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
        };
    }
}