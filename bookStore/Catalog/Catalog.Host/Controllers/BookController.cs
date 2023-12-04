using Catalog.Host.Services.Interfaces;
using Infrastructure;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Authorize(Policy = AuthPolicy.AllowClientPolicy)]
[Scope("catalog.catalogbook")]
[Route(ComponentDefaults.DefaultRoute)]
public class BookController : Controller
{
    private readonly ILogger<BookController> _logger;
    private readonly IBookService _bookService;

    public BookController(
        ILogger<BookController> logger,
        IBookService bookService)
    {
        _logger = logger;
        _bookService = bookService;
    }

    [HttpPost]
    public async Task<IActionResult> AddAsync(int id, string title, string author, string description, decimal price, string coverImageFileName, int genreId, int authorId, int inStock)
    {
        var result = await _bookService.AddAsync(id, title, author, description, price, coverImageFileName, genreId, authorId, inStock);

        if (result is null)
        {
            return NoContent();
        }

        return Ok(result);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAsync(int id)
    {
        var result = await _bookService.DeleteAsync(id);

        if (result is null)
        {
            return NoContent();
        }

        return Ok(result);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateAsync(int id, string title, string author, string description, decimal price, string coverImageFileName, int genreId, int authorId, int inStock)
    {
        var result = await _bookService.UpdateAsync(id, title, author, description, price, coverImageFileName, genreId, authorId, inStock);

        if (result is null)
        {
            return NoContent();
        }

        return Ok(result);
    }
}