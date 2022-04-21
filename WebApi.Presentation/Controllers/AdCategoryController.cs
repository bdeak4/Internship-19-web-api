using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Domain.Models;
using WebApi.Domain.Repositories.Interfaces;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class AdCategoryController : ControllerBase
{
    private readonly IAdCategoryRepository _adCategoryRepository;

    public AdCategoryController(IAdCategoryRepository adCategoryRepository)
    {
        _adCategoryRepository = adCategoryRepository;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var adCategories = _adCategoryRepository.GetAdCategories();

        return Ok(adCategories);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var adCategory = _adCategoryRepository.GetAdCategoryById(id);

        if (adCategory == null)
        {
            return NotFound();
        }

        return Ok(adCategory);
    }

    [HttpPost]
    public IActionResult AddAdCategory(AdCategoryModel adCategory)
    {
        var addedAdCategory = _adCategoryRepository.AddAdCategory(adCategory);
        return Ok(addedAdCategory);
    }

    [HttpPut("{id}")]
    public IActionResult EditAdCategory(int id, AdCategoryModel adCategory)
    {
        var editedAdCategory = _adCategoryRepository.EditAdCategory(id, adCategory);
        
        if (editedAdCategory == null)
        {
            return NotFound(id);
        }

        return Ok(editedAdCategory);
    }
    
    [HttpDelete("{id}")]
    public IActionResult RemoveAdCategory(int id)
    {
        var isSuccessful = _adCategoryRepository.DeleteAdCategory(id);

        if (!isSuccessful)
        {
            return BadRequest();
        }

        return Ok();
    }
}