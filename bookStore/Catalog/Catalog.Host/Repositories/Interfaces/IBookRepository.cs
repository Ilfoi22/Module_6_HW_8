using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface IBookRepository
{
    Task<int?> AddAsync(int id, string title, string author, string description, decimal price, string coverImageFileName, int genreId, int authorId, int inStock);
    Task<Book?> DeleteAsync(int id);
    Task<Book?> UpdateAsync(int id, string title, string author, string description, decimal price, string coverImageFileName, int genreId, int authorId, int inStock);
}
