using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
[Route(ComponentDefaults.DefaultRoute)]
public class BffController : Controller
{
    private readonly ILogger<BffController> _logger;
    private readonly IBffService _bffService;

    public BffController(
        ILogger<BffController> logger,
        IBffService bffService)
    {
        _logger = logger;
        _bffService = bffService;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAuthorsAsync()
    {
        var result = await _bffService.GetAuthorsAsync();

        if (result is null)
        {
            return NoContent();
        }

        return Ok(result);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetAuthorByIdAsync(int id)
    {
        var result = await _bffService.GetAuthorByIdAsync(id);

        if (result is null)
        {
            return NoContent();
        }

        return Ok(result);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetGenresAsync()
    {
        var result = await _bffService.GetGenresAsync();

        if (result is null)
        {
            return NoContent();
        }

        return Ok(result);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetGenresByIdAsync(int id)
    {
        var result = await _bffService.GetGenresByIdAsync(id);

        if (result is null)
        {
            return NoContent();
        }

        return Ok(result);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetBooksAsync()
    {
        var result = await _bffService.GetBooksAsync();

        if (result is null)
        {
            return NoContent();
        }

        return Ok(result);
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<IActionResult> GetBookByIdAsync(int id)
    {
        var result = await _bffService.GetBookByIdAsync(id);

        if (result is null)
        {
            return NoContent();
        }

        return Ok(result);
    }
}
