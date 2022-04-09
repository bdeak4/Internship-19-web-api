using WebApi.Data.Models.Entities;

namespace WebApi.Domain.Models;

public class AdOwnerModel
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public class AdOwnerResponseModel : AdOwnerModel
{
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}

public class AdOwnerDetailResponseModel : AdOwnerResponseModel
{
    public ICollection<Ad> Ads { get; set; } = new List<Ad>();
}

public static class AdOwnerExtensionMethods
{
    public static AdOwner ProjectToAdOwner(this AdOwnerModel model)
    {
        return new AdOwner
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Phone = model.Phone,
            Email = model.Email,
        };
    }
    
    public static AdOwnerResponseModel ProjectToResponseModel(this AdOwner adOwner)
    {
        return new AdOwnerResponseModel
        {
            Id = adOwner.Id,
            FirstName = adOwner.FirstName,
            LastName = adOwner.LastName,
            Phone = adOwner.Phone,
            Email = adOwner.Email,
            CreatedAt = adOwner.CreatedAt,
        };
    }
}