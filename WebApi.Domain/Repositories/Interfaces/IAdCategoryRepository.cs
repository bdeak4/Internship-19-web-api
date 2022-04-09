using WebApi.Data.Models.Entities;
using WebApi.Domain.Models;

namespace WebApi.Domain.Repositories.Interfaces;

public interface IAdCategoryRepository
{
    List<AdCategoryResponseModel> GetAdCategories();
    AdCategoryDetailResponseModel? GetAdCategoryById(int id);
    AdCategoryResponseModel AddAdCategory(AdCategoryModel model);
    AdCategoryResponseModel? EditAdCategory(int id, AdCategoryModel model);
    bool DeleteAdCategory(int id);
}