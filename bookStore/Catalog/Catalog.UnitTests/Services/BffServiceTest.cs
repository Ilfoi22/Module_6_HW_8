using AutoMapper;
using Catalog.Host.Data.Entities;
using Catalog.Host.Data;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services.Interfaces;
using Catalog.Host.Services;
using Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace Catalog.UnitTests.Services;

public class BffServiceTest
{
    private readonly IBffService _bffService;

    private readonly Mock<IBffRepository> _bffRepository;
    private readonly Mock<IMapper> _mapper;
    private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
    private readonly Mock<ILogger<BffService>> _logger;

    public BffServiceTest()
    {
        _bffRepository = new Mock<IBffRepository>();
        _mapper = new Mock<IMapper>();
        _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
        _logger = new Mock<ILogger<BffService>>();

        var dbContextTransaction = new Mock<IDbContextTransaction>();
        _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

        _bffService = new BffService(_dbContextWrapper.Object, _logger.Object, _bffRepository.Object, _mapper.Object);
    }

    [Fact]
    public async Task GetBooksAsync_Success()
    {
        // Arrange
        var expectedBooks = new List<Book>
        {
            new Book { Id = 1, Author = "Author1", AuthorId = 1, GenreId = 1, CoverImageFileName = "1.png", Description = "Description1", Title = "Title1", InStock = 10, Price = 5M  },
            new Book { Id = 2, Author = "Author2", AuthorId = 2, GenreId = 2, CoverImageFileName = "2.png", Description = "Description2", Title = "Title2", InStock = 20, Price = 10M  }
        };

        // Act
        _bffRepository.Setup(s => s.GetBooksAsync()).ReturnsAsync(expectedBooks);

        var result = await _bffService.GetBooksAsync();

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetBooksAsync_Failed()
    {
        // Arrange
        var expectedBooks = new List<Book>();

        // Act
        _bffRepository.Setup(s => s.GetBooksAsync()).ReturnsAsync(expectedBooks);

        var result = await _bffService.GetBooksAsync();

        // Assert
        result.Should().BeNullOrEmpty();
    }

    [Fact]
    public async Task GetBookByIdAsync_Success()
    {
        // Arrange
        var expectedBookId = 1;
        var expectedBook = new Book { Title = "Super title" };

        // Act
        _bffRepository.Setup(s => s.GetBookByIdAsync(expectedBookId))
            .ReturnsAsync(expectedBook);

        // Asert
        var result = await _bffService.GetBookByIdAsync(expectedBookId);

        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expectedBook);
    }

    [Fact]
    public async Task GetBookByIdAsync_Failed()
    {
        // Arrange
        var expectedBookId = 999;
        var expectedBook = new Book { Title = "Not Found" };

        // Act
        _bffRepository.Setup(s => s.GetBookByIdAsync(expectedBookId))
            .ReturnsAsync((Book?)null);

        // Asert
        var result = await _bffService.GetBookByIdAsync(expectedBookId);

        result.Should().BeNull();
    }

    [Fact]
    public async Task GetAuthorsAsync_Success()
    {
        // Arrange
        var expectedAuthors = new List<Author>
        {
            new Author { Id = 1, Name = "Name1"},
            new Author { Id = 2, Name = "Name2"}
        };

        // Act
        _bffRepository.Setup(s => s.GetAuthorsAsync()).ReturnsAsync(expectedAuthors);

        var result = await _bffService.GetAuthorsAsync();

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetAuthorsAsync_Failed()
    {
        // Arrange
        var expectedAuthors = new List<Author>();

        // Act
        _bffRepository.Setup(s => s.GetAuthorsAsync()).ReturnsAsync(expectedAuthors);

        var result = await _bffService.GetAuthorsAsync();

        // Assert
        result.Should().BeNullOrEmpty();
    }

    [Fact]
    public async Task GetAuthorByIdAsync_Success()
    {
        // Arrange
        var expectedAuthorId = 1;
        var expectedAuthor = new Author { Name = "Gustaf" };

        // Act
        _bffRepository.Setup(s => s.GetAuthorByIdAsync(expectedAuthorId))
            .ReturnsAsync(expectedAuthor);

        // Asert
        var result = await _bffService.GetAuthorByIdAsync(expectedAuthorId);

        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expectedAuthor);
    }

    [Fact]
    public async Task GetAuthorByIdAsyncc_Failed()
    {
        // Arrange
        var expectedAuthorId = 999;
        var expectedAuthor = new Author { Name = "Not Found" };

        // Act
        _bffRepository.Setup(s => s.GetAuthorByIdAsync(expectedAuthorId))
            .ReturnsAsync((Author?)null);

        // Asert
        var result = await _bffService.GetAuthorByIdAsync(expectedAuthorId);

        result.Should().BeNull();
    }

    [Fact]
    public async Task GetGenresAsync_Success()
    {
        // Arrange
        var expectedGenres = new List<Genre>
        {
            new Genre { Id = 1, Name = "Name1"},
            new Genre { Id = 2, Name = "Name2"}
        };

        // Act
        _bffRepository.Setup(s => s.GetGenresAsync()).ReturnsAsync(expectedGenres);

        var result = await _bffService.GetGenresAsync();

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public async Task GetGenresAsync_Failed()
    {
        // Arrange
        var expectedGenres = new List<Genre>();

        // Act
        _bffRepository.Setup(s => s.GetGenresAsync()).ReturnsAsync(expectedGenres);

        var result = await _bffService.GetGenresAsync();

        // Assert
        result.Should().BeNullOrEmpty();
    }

    [Fact]
    public async Task GetGenresByIdAsync_Success()
    {
        // Arrange
        var expectedGenreId = 1;
        var expectedGenre = new Genre { Name = "Manga" };

        // Act
        _bffRepository.Setup(s => s.GetGenresByIdAsync(expectedGenreId))
            .ReturnsAsync(expectedGenre);

        // Asert
        var result = await _bffService.GetGenresByIdAsync(expectedGenreId);

        result.Should().NotBeNull();
        result.Should().BeEquivalentTo(expectedGenre);
    }

    [Fact]
    public async Task GetGenresByIdAsyncc_Failed()
    {
        // Arrange
        var expectedGenreId = 999;
        var expectedGenre = new Genre { Name = "Not Found" };

        // Act
        _bffRepository.Setup(s => s.GetGenresByIdAsync(expectedGenreId))
            .ReturnsAsync((Genre?)null);

        // Asert
        var result = await _bffService.GetGenresByIdAsync(expectedGenreId);

        result.Should().BeNull();
    }
}
