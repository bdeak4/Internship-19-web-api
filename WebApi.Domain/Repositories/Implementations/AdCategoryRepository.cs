using Microsoft.EntityFrameworkCore;
using WebApi.Data.Models;
using WebApi.Domain.Models;
using WebApi.Domain.Repositories.Interfaces;

namespace WebApi.Domain.Repositories.Implementations;

public class AdCategoryRepository : IAdCategoryRepository
{
    private readonly WebApiAdContext _webApiAdContext;

    public AdCategoryRepository(WebApiAdContext webApiAdContext)
    {
        _webApiAdContext = webApiAdContext;
    }

    public List<AdCategoryResponseModel> GetAdCategories()
    {
        var adCategories = _webApiAdContext
            .AdCategories
            .Select(c => c.ProjectToResponseModel())
            .ToList();
        
        return adCategories;
    }

    public AdCategoryDetailResponseModel? GetAdCategoryById(int id)
    {
        var adCategory = _webApiAdContext
            .AdCategories
            .Include(c => c.Ads)
            .FirstOrDefault(c => c.Id == id);

        if (adCategory == null)
        {
            return null;
        }

        return adCategory.ProjectToDetailResponseModel();
    }

    public AdCategoryResponseModel AddAdCategory(AdCategoryModel model)
    {
        var adCategory = model.ProjectToAdCategory();

        _webApiAdContext.AdCategories.Add(adCategory);
        _webApiAdContext.SaveChanges();

        return adCategory.ProjectToResponseModel();
    }

    public AdCategoryResponseModel? EditAdCategory(int id, AdCategoryModel model)
    {
        var adCategory = _webApiAdContext.AdCategories.Find(id);

        if (adCategory == null)
        {
            return null;
        }

        adCategory.Title = model.Title;
        adCategory.Type = model.Type;

        _webApiAdContext.SaveChanges();

        return adCategory.ProjectToResponseModel();
    }

    public bool DeleteAdCategory(int id)
    {
        var adCategory = _webApiAdContext.AdCategories.Find(id);

        if (adCategory == null)
        {
            return false;
        }

        _webApiAdContext.AdCategories.Remove(adCategory);
        _webApiAdContext.SaveChanges();

        return true;
    }
    
    public bool AdCategoryExists(int? id)
    {
        return _webApiAdContext.AdCategories.Find(id) != null;
    }

}