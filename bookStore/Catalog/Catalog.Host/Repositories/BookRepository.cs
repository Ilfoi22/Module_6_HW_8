using Catalog.Host.Data.Entities;
using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;

namespace Catalog.Host.Repositories;

public class BookRepository : IBookRepository
{
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger<BookRepository> _logger;

    public BookRepository(
        ApplicationDbContext dbContext,
        ILogger<BookRepository> logger)
    {
        _dbContext = dbContext;
        _logger = logger;
    }

    public async Task<int?> AddAsync(int id, string title, string author, string description, decimal price, string coverImageFileName, int genreId, int authorId, int inStock)
    {
        var book = await _dbContext.AddAsync(new Book
        {
            Id = id,
            Title = title,
            Author = author,
            Description = description,
            Price = price,
            CoverImageFileName = coverImageFileName,
            GenreId = genreId,
            AuthorId = authorId,
            InStock = inStock
        });

        await _dbContext.SaveChangesAsync();

        return book.Entity.Id;
    }

    public async Task<Book?> DeleteAsync(int id)
    {
        var book = await _dbContext.Books.FindAsync(id);

        if (book is null)
        {
            return null;
        }

        _dbContext.Books.Remove(book);
        await _dbContext.SaveChangesAsync();

        return book;
    }

    public async Task<Book?> UpdateAsync(int id, string title, string author, string description, decimal price, string coverImageFileName, int genreId, int authorId, int inStock)
    {
        var book = await _dbContext.Books.FindAsync(id);

        if (book is null)
        {
            return null;
        }

        book.Id = id;
        book.Title = title;
        book.Author = author;
        book.Description = description;
        book.Price = price;
        book.CoverImageFileName = coverImageFileName;
        book.GenreId = genreId;
        book.AuthorId = authorId;
        book.InStock = inStock;

        _dbContext.Books.Update(book);
        await _dbContext.SaveChangesAsync();

        return book;
    }
}