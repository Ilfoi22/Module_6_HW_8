using Catalog.Host.Data.Entities;
using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Services.Interfaces;

namespace Catalog.Host.Repositories;

public class BffRepository : IBffRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<BffRepository> _logger;

    public BffRepository(
        IDbContextWrapper<ApplicationDbContext> dbContext,
        ILogger<BffRepository> logger)
    {
        _dbContext = dbContext.DbContext;
        _logger = logger;
    }

    public async Task<List<Author>> GetAuthorsAsync()
    {
        return await _dbContext.Authors.ToListAsync();
    }

    public async Task<Author?> GetAuthorByIdAsync(int id)
    {
        return await _dbContext.Authors
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Genre>> GetGenresAsync()
    {
        return await _dbContext.Genres.ToListAsync();
    }

    public async Task<Genre?> GetGenresByIdAsync(int id)
    {
        return await _dbContext.Genres
            .Where(g => g.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<List<Book>> GetBooksAsync()
    {
        return await _dbContext.Books.ToListAsync();
    }

    public async Task<Book?> GetBookByIdAsync(int id)
    {
        return await _dbContext.Books
            .Where(b => b.Id == id)
            .FirstOrDefaultAsync();
    }
}
