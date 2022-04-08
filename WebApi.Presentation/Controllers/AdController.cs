using Microsoft.AspNetCore.Mvc;
using WebApi.Data.Models;
using WebApi.Domain.Models;
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
    public IActionResult GetAll()
    {
        var ads = _adRepository.GetAds();

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
    public IActionResult RemoveTodoItem(int id)
    {
        var isSuccessful = _adRepository.DeleteAd(id);

        if (!isSuccessful)
        {
            return NotFound(id);
        }

        return Ok();
    }
}