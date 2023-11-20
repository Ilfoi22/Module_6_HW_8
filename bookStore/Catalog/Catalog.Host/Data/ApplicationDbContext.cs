using Catalog.Host.Data.Entities;
using Catalog.Host.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Genre> Genres { get; set; } = null!;
    public DbSet<Author> Authors { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfiguration(new BookEntityTypeConfiguration());
        builder.ApplyConfiguration(new GenreEntityTypeConfiguration());
        builder.ApplyConfiguration(new AuthorEntityTypeConfiguration());
    }
}