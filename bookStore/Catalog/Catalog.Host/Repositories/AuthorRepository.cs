using Catalog.Host.Data.Entities;
using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Infrastructure.Services.Interfaces;

namespace Catalog.Host.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<AuthorRepository> _logger;

    public AuthorRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<AuthorRepository> logger)
    {
        _dbContext = dbContextWrapper.DbContext;
        _logger = logger;
    }

    public async Task<int?> AddAsync(int id, string name)
    {
        var author = await _dbContext.AddAsync(new Author
        {
            Id = id,
            Name = name
        });

        await _dbContext.SaveChangesAsync();

        return author.Entity.Id;
    }

    public async Task<Author?> DeleteAsync(int id)
    {
        var author = await _dbContext.Authors.FindAsync(id);

        if (author is null)
        {
            return null;
        }

        _dbContext.Authors.Remove(author);
        await _dbContext.SaveChangesAsync();

        return author;
    }

    public async Task<Author?> UpdateAsync(int id, string name)
    {
        var author = await _dbContext.Authors.FindAsync(id);

        if (author is null)
        {
            return null;
        }

        author.Id = id;
        author.Name = name;

        _dbContext.Authors.Update(author);
        await _dbContext.SaveChangesAsync();

        return author;
    }
}
