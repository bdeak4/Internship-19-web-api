using Microsoft.EntityFrameworkCore;
using WebApi.Data.Models;
using WebApi.Domain.Helpers;
using WebApi.Domain.Models;
using WebApi.Domain.Repositories.Interfaces;
using WebApi.Domain.Services;

namespace WebApi.Domain.Repositories.Implementations;

public class AdOwnerRepository : IAdOwnerRepository
{
    private readonly WebApiAdContext _webApiAdContext;
    private readonly JwtService _jwtService;

    public AdOwnerRepository(WebApiAdContext webApiAdContext, JwtService jwtService)
    {
        _webApiAdContext = webApiAdContext;
        _jwtService = jwtService;
    }

    public List<AdOwnerResponseModel> GetAdOwners()
    {
        var adOwners = _webApiAdContext
            .AdOwners
            .Select(c => c.ProjectToResponseModel())
            .ToList();
        
        return adOwners;
    }

    public AdOwnerDetailResponseModel? GetAdOwnerById(int id)
    {
        var adOwner = _webApiAdContext
            .AdOwners
            .Include(o => o.Ads)
            .FirstOrDefault(o => o.Id == id);

        if (adOwner == null)
        {
            return null;
        }

        return adOwner.ProjectToDetailResponseModel();
    }

    public AdOwnerResponseModel AddAdOwner(AdOwnerModel model)
    {
        var adOwner = model.ProjectToAdOwner();

        _webApiAdContext.AdOwners.Add(adOwner);
        _webApiAdContext.SaveChanges();

        return adOwner.ProjectToResponseModel();
    }

    public AdOwnerResponseModel? EditAdOwner(int id, AdOwnerModel model)
    {
        var adOwner = _webApiAdContext.AdOwners.Find(id);

        if (adOwner == null)
        {
            return null;
        }

        adOwner.FirstName = model.FirstName;
        adOwner.LastName = model.LastName;
        adOwner.Phone = model.Phone;
        adOwner.Email = model.Email;

        _webApiAdContext.SaveChanges();

        return adOwner.ProjectToResponseModel();
    }

    public bool DeleteAdOwner(int id)
    {
        var adOwner = _webApiAdContext
            .AdOwners
            .Include(o => o.Ads)
            .FirstOrDefault(o => o.Id == id);

        if (adOwner == null || adOwner.Ads.Count > 0)
        {
            return false;
        }

        _webApiAdContext.AdOwners.Remove(adOwner);
        _webApiAdContext.SaveChanges();

        return true;
    }
    
    public bool AdOwnerExists(int? id)
    {
        return _webApiAdContext.AdOwners.Find(id) != null;
    }

    public string? Login(AdOwnerLoginModel model)
    {
        var user = _webApiAdContext
            .AdOwners
            .FirstOrDefault(u => u.Email == model.Email.ToLower());

        if (user == null)
        {
            return null;
        }

        var isValid = HashHelper.ValidatePassword(model.Password, user.Password);

        if (!isValid)
        {
            return null;
        }

        var token = _jwtService.GetJwtToken(user.ProjectToDetailResponseModel());

        return token;
    }

    public bool Register(AdOwnerRegisterModel model)
    {
        if (model.Password != model.RepeatPassword)
        {
            return false;
        }

        var isTaken = _webApiAdContext
            .AdOwners
            .Any(u => u.Email == model.Email.ToLower());

        if (isTaken)
        {
            return false;
        }

        var user = model.ProjectToAdOwner();
        _webApiAdContext.AdOwners.Add(user);
        _webApiAdContext.SaveChanges();

        return true;

    }
}