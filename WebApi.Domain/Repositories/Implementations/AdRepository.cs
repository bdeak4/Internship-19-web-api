using Microsoft.EntityFrameworkCore;
using WebApi.Data.Models;
using WebApi.Domain.Models;
using WebApi.Domain.Repositories.Enums;
using WebApi.Domain.Repositories.Interfaces;

namespace WebApi.Domain.Repositories.Implementations;

public class AdRepository : IAdRepository
{
    private readonly WebApiAdContext _webApiAdContext;

    public AdRepository(WebApiAdContext webApiAdContext)
    {
        _webApiAdContext = webApiAdContext;
    }

    public List<AdFilterResponseModel> GetAds(AdFilterModel filter, SortType? sort)
    {
        var ads = _webApiAdContext
            .Ads
            .ApplyFilter(filter)
            .ApplySort(sort)
            .Select(ad => ad.ProjectToFilterResponseModel())
            .ToList();
        
        return ads;
    }

    public AdDetailResponseModel? GetAdById(int id)
    {
        var ad = _webApiAdContext
            .Ads
            .Include(ad => ad.Category)
            .Include(ad => ad.Owner)
            .FirstOrDefault(ad => ad.Id == id);

        if (ad == null)
        {
            return null;
        }

        ad.ViewCounter++;
        _webApiAdContext.SaveChanges();

        return ad.ProjectToDetailResponseModel();
    }

    public AdResponseModel AddAd(AdModel model)
    {
        var ad = model.ProjectToAd();

        _webApiAdContext.Ads.Add(ad);
        _webApiAdContext.SaveChanges();

        return ad.ProjectToResponseModel();
    }

    public AdResponseModel? EditAd(int id, AdModel model)
    {
        var ad = _webApiAdContext.Ads.Find(id);

        if (ad == null)
        {
            return null;
        }

        ad.Title = model.Title;
        ad.Description = model.Description;
        ad.Price = model.Price;
        ad.City = model.City;
        ad.County = model.County;
        ad.Street = model.Street;
        ad.CategoryId = model.CategoryId;
        ad.OwnerId = model.OwnerId;

        _webApiAdContext.SaveChanges();

        return ad.ProjectToResponseModel();
    }

    public bool DeleteAd(int id)
    {
        var ad = _webApiAdContext.Ads.Find(id);

        if (ad == null)
        {
            return false;
        }

        _webApiAdContext.Ads.Remove(ad);
        _webApiAdContext.SaveChanges();

        return true;
    }
}