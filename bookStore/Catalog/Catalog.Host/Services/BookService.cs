using AutoMapper;
using Catalog.Host.Data.Entities;
using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Services.Interfaces;
using Infrastructure.Services;

namespace Catalog.Host.Services;

public class BookService : BaseDataService<ApplicationDbContext>, IBookService
{
    private readonly IBookRepository _bookRepistory;

    public BookService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IBookRepository bookRepistory)
        : base(dbContextWrapper, logger)
    {
        _bookRepistory = bookRepistory;
    }

    public async Task<int?> AddAsync(int id, string title, string author, string description, decimal price, string coverImageFileName, int genreId, int authorId, int inStock)
    {
        var result = await _bookRepistory.AddAsync(id, title, author, description, price, coverImageFileName, genreId, authorId, inStock);
        return result;
    }

    public async Task<Book?> DeleteAsync(int id)
    {
        var result = await _bookRepistory.DeleteAsync(id);
        return result;
    }

    public async Task<Book?> UpdateAsync(int id, string title, string author, string description, decimal price, string coverImageFileName, int genreId, int authorId, int inStock)
    {
        var result = await _bookRepistory.UpdateAsync(id, title, author, description, price, coverImageFileName, genreId, authorId, inStock);
        return result;
    }
}