using System.ComponentModel.DataAnnotations;

namespace Catalog.Host.Data.Entities;

public class Book
{
    public int Id { get; set; }

    [Required(ErrorMessage = "The 'Title' field is required.")]
    public string Title { get; set; } = null!;

    [Required(ErrorMessage = "The 'Author' field is required.")]
    public string Author { get; set; } = null!;

    [Required(ErrorMessage = "The 'Description' field is required.")]
    public string Description { get; set; } = null!;

    [Range(0, 1024, ErrorMessage = "The price must be greater than or equal to 0.")]
    public decimal Price { get; set; }

    [Required(ErrorMessage = "The 'CoverImageFileName' field is required.")]
    public string CoverImageFileName { get; set; } = null!;

    [Required(ErrorMessage = "The 'GenreId' field is required.")]
    public int GenreId { get; set; }

    public Genre? BookGenre { get; set; }

    [Required(ErrorMessage = "The 'AuthorId' field is required.")]
    public int AuthorId { get; set; }

    public Author? BookAuthor { get; set; }

    [Range(0, 1024, ErrorMessage = "The 'InStock' count must be greater than or equal to 0.")]
    public int InStock { get; set; }
}
