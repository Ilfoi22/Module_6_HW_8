using Catalog.Host.Data.Entities;
using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;

namespace Catalog.Host.Repositories;

public class GenreRepository : IGenreRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<GenreRepository> _logger;

    public GenreRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<GenreRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<int?> AddAsync(int id, string name)
    {
        var genre = await _dbContext.Genres.AddAsync(new Genre
        {
            Id = id,
            Name = name
        });

        await _dbContext.SaveChangesAsync();

        return genre.Entity.Id;
    }

    public async Task<Genre?> DeleteAsync(int id)
    {
        var genre = await _dbContext.Genres.FindAsync(id);

        if (genre is null)
        {
            return null;
        }

        _dbContext.Genres.Remove(genre);
        await _dbContext.SaveChangesAsync();

        return genre;
    }

    public async Task<Genre?> UpdateAsync(int id, string name)
    {
        var genre = await _dbContext.Genres.FindAsync(id);

        if (genre is null)
        {
            return null;
        }

        genre.Id = id;
        genre.Name = name;

        _dbContext.Genres.Update(genre);
        await _dbContext.SaveChangesAsync();

        return genre;
    }
}
