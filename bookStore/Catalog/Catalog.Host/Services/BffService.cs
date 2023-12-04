using AutoMapper;
using Catalog.Host.Data.Entities;
using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Services.Interfaces;
using Infrastructure.Services;

namespace Catalog.Host.Services;

public class BffService : BaseDataService<ApplicationDbContext>, IBffService
{
    private readonly IBffRepository _bffRepistory;
    private readonly IMapper _mapper;

    public BffService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IBffRepository bffRepistory,
        IMapper mapper)
        : base(dbContextWrapper, logger)
    {
        _bffRepistory = bffRepistory;
        _mapper = mapper;
    }

    public async Task<List<Author>> GetAuthorsAsync()
    {
        var result = await _bffRepistory.GetAuthorsAsync();
        return result;
    }

    public async Task<Author?> GetAuthorByIdAsync(int id)
    {
        var result = await _bffRepistory.GetAuthorByIdAsync(id);
        return result;
    }

    public async Task<List<Genre>> GetGenresAsync()
    {
        var result = await _bffRepistory.GetGenresAsync();
        return result;
    }

    public async Task<Genre?> GetGenresByIdAsync(int id)
    {
        var result = await _bffRepistory.GetGenresByIdAsync(id);
        return result;
    }

    public async Task<List<Book>> GetBooksAsync()
    {
        var result = await _bffRepistory.GetBooksAsync();
        return result;
    }

    public async Task<Book?> GetBookByIdAsync(int id)
    {
        var result = await _bffRepistory.GetBookByIdAsync(id);
        return result;
    }
}