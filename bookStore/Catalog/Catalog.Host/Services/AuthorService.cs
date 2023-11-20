using AutoMapper;
using Catalog.Host.Data.Entities;
using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Services.Interfaces;
using Infrastructure.Services;

namespace Catalog.Host.Services;

public class AuthorService : BaseDataService<ApplicationDbContext>, IAuthorService
{
    private readonly IAuthorRepository _authorRepistory;

    public AuthorService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IAuthorRepository authorRepistory)
        : base(dbContextWrapper, logger)
    {
        _authorRepistory = authorRepistory;
    }

    public async Task<int?> AddAsync(int id, string name)
    {
        var result = await _authorRepistory.AddAsync(id, name);
        return result;
    }

    public async Task<Author?> DeleteAsync(int id)
    {
        var result = await _authorRepistory.DeleteAsync(id);
        return result;
    }

    public async Task<Author?> UpdateAsync(int id, string name)
    {
        var result = await _authorRepistory.UpdateAsync(id, name);
        return result;
    }
}