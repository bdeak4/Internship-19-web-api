using WebApi.Domain.Models;

namespace WebApi.Domain.Repositories.Interfaces;

public interface IAdRepository
{
    List<AdResponseModel> GetAds();
    AdDetailResponseModel? GetAdById(int id);
    AdResponseModel AddAd(AdModel model);
    AdResponseModel? EditAd(int id, AdModel model);
    bool DeleteAd(int id);
}