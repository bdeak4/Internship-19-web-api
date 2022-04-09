using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Models;
using WebApi.Domain.Repositories.Interfaces;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AdOwnerController : ControllerBase
{
    private readonly IAdOwnerRepository _adOwnerRepository;

    public AdOwnerController(IAdOwnerRepository adOwnerRepository)
    {
        _adOwnerRepository = adOwnerRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var adOwners = _adOwnerRepository.GetAdOwners();

        return Ok(adOwners);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var adOwner = _adOwnerRepository.GetAdOwnerById(id);

        if (adOwner == null)
        {
            return NotFound();
        }

        return Ok(adOwner);
    }

    [HttpPost]
    public IActionResult AddAdOwner(AdOwnerModel adOwner)
    {
        var addedAdOwner = _adOwnerRepository.AddAdOwner(adOwner);
        return Ok(addedAdOwner);
    }

    [HttpPut("{id}")]
    public IActionResult EditAdOwner(int id, AdOwnerModel adOwner)
    {
        var editedAdOwner = _adOwnerRepository.EditAdOwner(id, adOwner);
        
        if (editedAdOwner == null)
        {
            return NotFound(id);
        }

        return Ok(editedAdOwner);
    }
    
    [HttpDelete("{id}")]
    public IActionResult RemoveAdOwner(int id)
    {
        var isSuccessful = _adOwnerRepository.DeleteAdOwner(id);

        if (!isSuccessful)
        {
            return NotFound(id);
        }

        return Ok();
    }
}