using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;


[ApiController]
[Authorize(Policy = AuthPolicy.AllowClientPolicy)]
[Scope("catalog.cataloggenre")]
[Route(ComponentDefaults.DefaultRoute)]
public class GenreController : Controller
{
    private readonly ILogger<GenreController> _logger;
    private readonly IGenreService _genreService;

    public GenreController(
        ILogger<GenreController> logger,
        IGenreService genreService)
    {
        _logger = logger;
        _genreService = genreService;
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(int id, string name)
    {
        var result = await _genreService.AddAsync(id, name);

        if (result is null)
        {
            return NoContent();
        }

        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _genreService.DeleteAsync(id);

        if (result is null)
        {
            return NoContent();
        }

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(int id, string name)
    {
        var result = await _genreService.UpdateAsync(id, name);

        if (result is null)
        {
            return NoContent();
        }

        return Ok(result);
    }
}
