using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface IBffRepository
{
    Task<List<Book>> GetBooksAsync();
    Task<Book?> GetBookByIdAsync(int id);
    Task<List<Author>> GetAuthorsAsync();
    Task<Author?> GetAuthorByIdAsync(int id);
    Task<List<Genre>> GetGenresAsync();
    Task<Genre?> GetGenresByIdAsync(int id);
}