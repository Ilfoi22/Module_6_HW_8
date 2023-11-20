using Catalog.Host.Data.Entities;

namespace Catalog.Host.Services.Interfaces;

public interface IAuthorService
{
    Task<int?> AddAsync(int id, string name);
    Task<Author?> DeleteAsync(int id);
    Task<Author?> UpdateAsync(int id, string name);
}
