using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Models;
using WebApi.Domain.Repositories.Enums;
using WebApi.Domain.Repositories.Interfaces;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AdController : ControllerBase
{
    private readonly IAdRepository _adRepository;

    public AdController(IAdRepository adRepository)
    {
        _adRepository = adRepository;
    }

    [HttpGet]
    
    public IActionResult GetAll(string? title, int? minPrice, int? maxPrice, int? categoryId, string? county, string? city, SortType? sort)
    {
        var filter = new AdFilterModel
        {
            Title = title,
            MinPrice = minPrice,
            MaxPrice = maxPrice,
            CategoryId = categoryId,
            County = county,
            City = city
        };
        var ads = _adRepository.GetAds(filter, sort);

        return Ok(ads);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var ad = _adRepository.GetAdById(id);

        if (ad == null)
        {
            return NotFound();
        }

        return Ok(ad);
    }

    [HttpPost]
    public IActionResult AddAd(AdModel ad)
    {
        var addedAd = _adRepository.AddAd(ad);
        return Ok(addedAd);
    }

    [HttpPut("{id}")]
    public IActionResult EditAd(int id, AdModel ad)
    {
        var editedAd = _adRepository.EditAd(id, ad);
        
        if (editedAd == null)
        {
            return NotFound(id);
        }

        return Ok(editedAd);
    }
    
    [HttpDelete("{id}")]
    public IActionResult RemoveAd(int id)
    {
        var isSuccessful = _adRepository.DeleteAd(id);

        if (!isSuccessful)
        {
            return NotFound(id);
        }

        return Ok();
    }
}