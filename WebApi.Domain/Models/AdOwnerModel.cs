using System.ComponentModel.DataAnnotations;
using WebApi.Data.Models.Entities;
using WebApi.Domain.Helpers;

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
    public ICollection<AdResponseModel> Ads { get; set; } = new List<AdResponseModel>();
}

public class AdOwnerLoginModel
{
    [Required]
    public string Email { get; set; } = String.Empty;
    [Required]
    public string Password { get; set; } = String.Empty;
}

public class AdOwnerRegisterModel
{
    [Required]
    public string Email { get; set; } = String.Empty;
    [Required]
    [MinLength(6)]
    public string Password { get; set; } = String.Empty;
    [Required]
    public string RepeatPassword { get; set; } = String.Empty;
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
    
    public static AdOwnerDetailResponseModel ProjectToDetailResponseModel(this AdOwner adOwner)
    {
        return new AdOwnerDetailResponseModel
        {
            Id = adOwner.Id,
            FirstName = adOwner.FirstName,
            LastName = adOwner.LastName,
            Phone = adOwner.Phone,
            Email = adOwner.Email,
            CreatedAt = adOwner.CreatedAt,
            Ads = adOwner.Ads.Select(ad => ad.ProjectToResponseModel()).ToList()
        };
    }
    
    public static AdOwner ProjectToAdOwner(this AdOwnerRegisterModel model)
    {
        return new AdOwner
        {
            Email = model.Email.ToLower(),
            Password = HashHelper.Hash(model.Password)
        };
    }
}