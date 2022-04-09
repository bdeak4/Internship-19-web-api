using Microsoft.EntityFrameworkCore;
using WebApi.Data.Models;
using WebApi.Domain.Models;
using WebApi.Domain.Repositories.Interfaces;

namespace WebApi.Domain.Repositories.Implementations;

public class AdOwnerRepository : IAdOwnerRepository
{
    private readonly WebApiAdContext _webApiAdContext;

    public AdOwnerRepository(WebApiAdContext webApiAdContext)
    {
        _webApiAdContext = webApiAdContext;
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
            .Include(c => c.Ads)
            .FirstOrDefault(c => c.Id == id);

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
        var adOwner = _webApiAdContext.AdOwners.Find(id);

        if (adOwner == null)
        {
            return false;
        }

        _webApiAdContext.AdOwners.Remove(adOwner);
        _webApiAdContext.SaveChanges();

        return true;
    }
}