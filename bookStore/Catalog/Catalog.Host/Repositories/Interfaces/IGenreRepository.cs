using Catalog.Host.Data.Entities;

namespace Catalog.Host.Repositories.Interfaces;

public interface IGenreRepository
{
    Task<int?> AddAsync(int id, string name);
    Task<Genre?> DeleteAsync(int id);
    Task<Genre?> UpdateAsync(int id, string name);
}
