using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface IAuthorRepository
{
    Task<int?> AddAsync(int id, string name);
    Task<Author?> DeleteAsync(int id);
    Task<Author?> UpdateAsync(int id, string name);
}
