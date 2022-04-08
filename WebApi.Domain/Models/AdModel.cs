using WebApi.Data.Models.Entities;

namespace WebApi.Domain.Models;

public class AdModel
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Price { get; set; }
    public string City { get; set; } = string.Empty;
    public string County { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public int? CategoryId { get; set; }
    public int? OwnerId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

public class AdResponseModel : AdModel
{
    public int Id { get; set; }
}

public class AdDetailResponseModel : AdResponseModel
{
    public AdCategoryModel? Category { get; set; }
    public AdOwner? Owner { get; set; }
}

public static class AdExtensionMethods
{
    public static Ad ProjectToAd(this AdModel model)
    {
        return new Ad
        {
            Title = model.Title,
            Description = model.Description,
            Price = model.Price,
            City = model.City,
            County = model.County,
            Street = model.Street,
            CategoryId = model.CategoryId,
            OwnerId = model.OwnerId,
            CreatedAt = model.CreatedAt,
        };
    }
    
    public static AdResponseModel ProjectToResponseModel(this Ad ad)
    {
        return new AdResponseModel
        {
            Id = ad.Id,
            Title = ad.Title,
            Description = ad.Description,
            Price = ad.Price,
            City = ad.City,
            County = ad.County,
            Street = ad.Street,
            CategoryId = ad.CategoryId,
            OwnerId = ad.OwnerId,
            CreatedAt = ad.CreatedAt,
        };
    }
    
    public static AdDetailResponseModel ProjectToDetailResponseModel(this Ad ad)
    {
        return new AdDetailResponseModel
        {
            Id = ad.Id,
            Title = ad.Title,
            Description = ad.Description,
            Price = ad.Price,
            City = ad.City,
            County = ad.County,
            Street = ad.Street,
            CategoryId = ad.CategoryId,
            OwnerId = ad.OwnerId,
            CreatedAt = ad.CreatedAt,
            Category = ad.Category?.ProjectToResponseModel(),
            // TODO add owner here
        };
    }
}