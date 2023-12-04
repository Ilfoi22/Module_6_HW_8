using Catalog.Host.Data.Entities;

namespace Catalog.Host.Data;

public class DbInitializer
{
    public static async Task Initialize(ApplicationDbContext context)
    {
        await context.Database.EnsureCreatedAsync();

        if (!context.Genres.Any())
        {
            await context.Genres.AddRangeAsync(GetPreconfiguredGenres());

            await context.SaveChangesAsync();
        }

        if (!context.Authors.Any())
        {
            await context.Authors.AddRangeAsync(GetPreconfiguredAuthors());

            await context.SaveChangesAsync();
        }

        if (!context.Books.Any())
        {
            await context.Books.AddRangeAsync(GetPreconfiguredBooks());

            await context.SaveChangesAsync();
        }
    }

    private static IEnumerable<Genre> GetPreconfiguredGenres()
    {
        return new List<Genre>
        {
            new Genre() { Id = 1, Name = "Fantasy" },
            new Genre() { Id = 2, Name = "Science Fiction" },
            new Genre() { Id = 3, Name = "Detective" },
            new Genre() { Id = 4, Name = "Romance" },
            new Genre() { Id = 5, Name = "Adventure" }
        };
    }

    private static IEnumerable<Author> GetPreconfiguredAuthors()
    {
        return new List<Author>
        {
            new Author() { Id = 1, Name = "J.R.R. Tolkien" },
            new Author() { Id = 2, Name = "Isaac Asimov" },
            new Author() { Id = 3, Name = "Jane Austen" },
            new Author() { Id = 4, Name = "Agatha Christie" },
            new Author() { Id = 5, Name = "George R.R. Martin" }
        };
    }

    private static IEnumerable<Book> GetPreconfiguredBooks()
    {
        return new List<Book>
        {
            new Book() { Id = 1, Title = "The Lord of the Rings", Author = "J.R.R. Tolkien", Description = "An epic battle in the world of Middle-earth", Price = 15.99M, CoverImageFileName = "1.png", InStock = 50, GenreId = 1, AuthorId = 1 },
            new Book() { Id = 2, Title = "The Silmarillion", Author = "J.R.R. Tolkien", Description = "History of ancient Middle-earth", Price = 9.99M, CoverImageFileName = "2.png", InStock = 34, GenreId = 1, AuthorId = 1 },
            new Book() { Id = 3, Title = "I, Robot", Author = "Isaac Asimov", Description = "Classic book about intelligent robots", Price = 13.50M, CoverImageFileName = "3.png", InStock = 25, GenreId = 2, AuthorId = 2 },
            new Book() { Id = 4, Title = "The Martian Chronicles", Author = "Isaac Asimov", Description = "Fantasies about the colonization of Mars", Price = 7.99M, CoverImageFileName = "4.png", InStock = 41, GenreId = 2, AuthorId = 2 },
            new Book() { Id = 5, Title = "Murder at the Vicarage", Author = "Agatha Christie", Description = "A classic detective novel", Price = 8.99M, CoverImageFileName = "5.png", InStock = 45, GenreId = 4, AuthorId = 4 },
            new Book() { Id = 6, Title = "Murder on the Orient Express", Author = "Agatha Christie", Description = "Investigation on a train", Price = 11.20M, CoverImageFileName = "6.png", InStock = 30, GenreId = 4, AuthorId = 4 },
            new Book() { Id = 7, Title = "Pride and Prejudice", Author = "Jane Austen", Description = "A classic tale of love and society", Price = 9.50M, CoverImageFileName = "7.png", InStock = 21, GenreId = 3, AuthorId = 3 },
            new Book() { Id = 8, Title = "Sense and Sensibility", Author = "Jane Austen", Description = "A story of love and adventure", Price = 10.00M, CoverImageFileName = "8.png", InStock = 15, GenreId = 3, AuthorId = 3 },
            new Book() { Id = 9, Title = "A Game of Thrones", Author = "George R.R. Martin", Description = "Intrigues and battles for the throne", Price = 14.99M, CoverImageFileName = "9.png", InStock = 60, GenreId = 5, AuthorId = 5 },
            new Book() { Id = 10, Title = "A Clash of Kings", Author = "George R.R. Martin", Description = "Continuation of the epic in Westeros", Price = 16.25M, CoverImageFileName = "10.png", InStock = 19, GenreId = 5, AuthorId = 5 },
        };
    }
}