using WebApi.Domain.Models;

namespace WebApi.Domain.Repositories.Interfaces;

public interface IAdOwnerRepository
{
    List<AdOwnerResponseModel> GetAdOwners();
    AdOwnerDetailResponseModel? GetAdOwnerById(int id);
    AdOwnerResponseModel AddAdOwner(AdOwnerModel model);
    AdOwnerResponseModel? EditAdOwner(int id, AdOwnerModel model);
    bool DeleteAdOwner(int id);
}