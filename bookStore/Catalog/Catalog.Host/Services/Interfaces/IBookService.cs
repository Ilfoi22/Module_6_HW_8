using Catalog.Host.Data.Entities;

namespace Catalog.Host.Services.Interfaces;

public interface IBookService
{
    Task<int?> AddAsync(int id, string title, string author, string description, decimal price, string coverImageFileName, int genreId, int authorId, int inStock);
    Task<Book?> DeleteAsync(int id);
    Task<Book?> UpdateAsync(int id, string title, string author, string description, decimal price, string coverImageFileName, int genreId, int authorId, int inStock);
}
