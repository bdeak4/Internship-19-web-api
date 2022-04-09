using WebApi.Domain.Models;
using WebApi.Domain.Repositories.Enums;

namespace WebApi.Domain.Repositories.Interfaces;

public interface IAdRepository
{
    List<AdFilterResponseModel> GetAds(AdFilterModel filter, SortType? sort);
    AdDetailResponseModel? GetAdById(int id);
    AdResponseModel AddAd(AdModel model);
    AdResponseModel? EditAd(int id, AdModel model);
    bool DeleteAd(int id);
    bool AdExists(int? id);
}