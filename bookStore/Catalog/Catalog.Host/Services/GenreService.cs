using AutoMapper;
using Catalog.Host.Data.Entities;
using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Infrastructure.Services.Interfaces;
using Infrastructure.Services;

namespace Catalog.Host.Services;

public class GenreService : BaseDataService<ApplicationDbContext>, IGenreService
{
    private readonly IGenreRepository _genreRepistory;

    public GenreService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        IGenreRepository genreRepistory)
        : base(dbContextWrapper, logger)
    {
        _genreRepistory = genreRepistory;
    }

    public async Task<int?> AddAsync(int id, string name)
    {
        var result = await _genreRepistory.AddAsync(id, name);
        return result;
    }

    public async Task<Genre?> DeleteAsync(int id)
    {
        var result = await _genreRepistory.DeleteAsync(id);
        return result;
    }

    public async Task<Genre?> UpdateAsync(int id, string name)
    {
        var result = await _genreRepistory.UpdateAsync(id, name);
        return result;
    }
}
