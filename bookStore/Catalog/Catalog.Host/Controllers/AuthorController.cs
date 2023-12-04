using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowClientPolicy)]
[Scope("catalog.catalogauthor")]
[Route(ComponentDefaults.DefaultRoute)]
public class AuthorController : Controller
{
    private readonly ILogger<AuthorController> _logger;
    private readonly IAuthorService _authorService;

    public AuthorController(
        ILogger<AuthorController> logger,
        IAuthorService authorService)
    {
        _logger = logger;
        _authorService = authorService;
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(int id, string name)
    {
        var result = await _authorService.AddAsync(id, name);

        if (result is null)
        {
            return NoContent();
        }

        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _authorService.DeleteAsync(id);

        if (result is null)
        {
            return NoContent();
        }

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(int id, string name)
    {
        var result = await _authorService.UpdateAsync(id, name);

        if (result is null)
        {
            return NoContent();
        }

        return Ok(result);
    }
}