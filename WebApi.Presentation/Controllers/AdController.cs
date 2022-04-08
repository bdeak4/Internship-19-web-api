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

    [HttpPost]
    public IActionResult AddAd(AdModel ad)
    {
        var addedAd = _adRepository.AddAd(ad);
        return Ok(addedAd);
    }
}