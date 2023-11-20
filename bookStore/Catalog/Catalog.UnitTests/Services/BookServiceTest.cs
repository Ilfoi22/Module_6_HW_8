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

public class BookServiceTest
{
    private readonly IBookService _bookService;

    private readonly Mock<IBookRepository> _bookRepository;
    private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
    private readonly Mock<ILogger<BookService>> _logger;

    private readonly Book _testBook = new Book()
    {
        Id = 20,
        Title = "Test Title",
        Author = "Test Author",
        Description = "Test Description",
        Price = 20.99M,
        CoverImageFileName = "10.png",
        InStock = 23,
        GenreId = 10,
        AuthorId = 10
    };

    public BookServiceTest()
    {
        _bookRepository = new Mock<IBookRepository>();
        _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
        _logger = new Mock<ILogger<BookService>>();

        var dbContextTransaction = new Mock<IDbContextTransaction>();
        _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

        _bookService = new BookService(_dbContextWrapper.Object, _logger.Object, _bookRepository.Object);
    }

    [Fact]
    public async Task AddAsync_Success()
    {
        int expectedId = 1;

        _bookRepository.Setup(s => s.AddAsync(
            It.IsAny<int>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<decimal>(),
            It.IsAny<string>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<int>())).ReturnsAsync(expectedId);

        var result = await _bookService.AddAsync(
            _testBook.Id, _testBook.Title, _testBook.Author, _testBook.Description, _testBook.Price, _testBook.CoverImageFileName, _testBook.GenreId, _testBook.AuthorId, _testBook.InStock);

        result.Should().Be(expectedId);
    }

    [Fact]
    public async Task AddAsync_Failed()
    {
        int? expectedId = null;

        _bookRepository.Setup(s => s.AddAsync(
            It.IsAny<int>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<decimal>(),
            It.IsAny<string>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<int>())).ReturnsAsync(expectedId);

        var result = await _bookService.AddAsync(
            _testBook.Id, _testBook.Title, _testBook.Author, _testBook.Description, _testBook.Price, _testBook.CoverImageFileName, _testBook.GenreId, _testBook.AuthorId, _testBook.InStock);

        result.Should().Be(expectedId);
    }

    [Fact]
    public async Task DeleteAsync_Success()
    {
        var expectedId = 1;

        _bookRepository.Setup(s => s.DeleteAsync(
                It.IsAny<int>())).ReturnsAsync((Book?)null);

        var result = await _bookService.DeleteAsync(expectedId);

        result.Should().BeNull();
    }

    [Fact]
    public async Task DeleteAsync_Failed()
    {
        var expectedId = 999;

        _bookRepository.Setup(s => s.DeleteAsync(
                It.IsAny<int>())).ReturnsAsync(new Book { Id = expectedId });

        var result = await _bookService.DeleteAsync(expectedId);

        result.Should().NotBeNull();
    }

    [Fact]
    public async Task UpdateAsync_Success()
    {
        var updatedAuthor = new Book
        {
            Id = 21,
            Title = "Test Title1",
            Author = "Test Author1",
            Description = "Test Description1",
            Price = 21.99M,
            CoverImageFileName = "11.png",
            InStock = 24,
            GenreId = 11,
            AuthorId = 11
        };

        _bookRepository.Setup(s => s.UpdateAsync(
            It.IsAny<int>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<decimal>(),
            It.IsAny<string>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<int>())).ReturnsAsync(updatedAuthor);

        var result = await _bookService.UpdateAsync(
            _testBook.Id, _testBook.Title, _testBook.Author, _testBook.Description, _testBook.Price, _testBook.CoverImageFileName, _testBook.GenreId, _testBook.AuthorId, _testBook.InStock);

        result.Should().NotBeNull();
        result.Should().Be(result);
    }

    [Fact]
    public async Task UpdateAsync_Failed()
    {
        var updatedBook = new Book { };

        _bookRepository.Setup(s => s.UpdateAsync(
            It.IsAny<int>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<string>(),
            It.IsAny<decimal>(),
            It.IsAny<string>(),
            It.IsAny<int>(),
            It.IsAny<int>(),
            It.IsAny<int>())).ReturnsAsync(updatedBook);

        var result = await _bookService.UpdateAsync(
            _testBook.Id, _testBook.Title, _testBook.Author, _testBook.Description, _testBook.Price, _testBook.CoverImageFileName, _testBook.GenreId, _testBook.AuthorId, _testBook.InStock);

        result.Should().Be(result);
    }
}
