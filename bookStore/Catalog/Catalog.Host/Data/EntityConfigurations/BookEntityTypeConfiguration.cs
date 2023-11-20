using Catalog.Host.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Host.Data.EntityConfigurations;

public class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Books");

        builder.HasKey(b => b.Id);

        builder.Property(b => b.Title)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(b => b.Description)
            .IsRequired();

        builder.HasOne(b => b.BookGenre)
            .WithMany()
            .HasForeignKey(b => b.GenreId);

        builder.HasOne(b => b.BookAuthor)
            .WithMany()
            .HasForeignKey(b => b.AuthorId);
    }
}
