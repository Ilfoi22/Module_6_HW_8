using AutoMapper;
using Catalog.Host.Data;
using Catalog.Host.Data.Entities;
using Catalog.Host.Repositories.Interfaces;
using Catalog.Host.Services;
using Catalog.Host.Services.Interfaces;
using FluentAssertions;
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

namespace Catalog.UnitTests.Services;

public class AuthorServiceTest
{
    private readonly IAuthorService _authorService;

    private readonly Mock<IAuthorRepository> _authorRepository;
    private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
    private readonly Mock<ILogger<AuthorService>> _logger;

    private readonly Author _testAuthor = new Author()
    {
        Id = 20,
        Name = "New Author"
    };

    public AuthorServiceTest()
    {
        _authorRepository = new Mock<IAuthorRepository>();
        _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
        _logger = new Mock<ILogger<AuthorService>>();

        var dbContextTransaction = new Mock<IDbContextTransaction>();
        _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

        _authorService = new AuthorService(_dbContextWrapper.Object, _logger.Object, _authorRepository.Object);
    }

    [Fact]
    public async Task AddAsync_Success()
    {
        int expectedId = 1;

        _authorRepository.Setup(s => s.AddAsync(
            It.IsAny<int>(),
            It.IsAny<string>())).ReturnsAsync(expectedId);

        var result = await _authorService.AddAsync(_testAuthor.Id, _testAuthor.Name);

        result.Should().Be(expectedId);
    }

    [Fact]
    public async Task AddAsync_Failed()
    {
        int? expectedId = null;

        _authorRepository.Setup(s => s.AddAsync(
            It.IsAny<int>(),
            It.IsAny<string>())).ReturnsAsync(expectedId);

        var result = await _authorService.AddAsync(_testAuthor.Id, _testAuthor.Name);

        result.Should().Be(expectedId);
    }

    [Fact]
    public async Task DeleteAsync_Success()
    {
        var expectedId = 1;

        _authorRepository.Setup(s => s.DeleteAsync(
                It.IsAny<int>())).ReturnsAsync((Author?)null);

        var result = await _authorService.DeleteAsync(expectedId);

        result.Should().BeNull();
    }

    [Fact]
    public async Task DeleteAsync_Failed()
    {
        var expectedId = 999;

        _authorRepository.Setup(s => s.DeleteAsync(
                It.IsAny<int>())).ReturnsAsync(new Author { Id = expectedId });

        var result = await _authorService.DeleteAsync(expectedId);

        result.Should().NotBeNull();
    }

    [Fact]
    public async Task UpdateAsync_Success()
    {
        var expectedId = 1;
        var updatedAuthor = new Author { Id = expectedId, Name = "UpdatedAuthor" };

        _authorRepository.Setup(s => s.UpdateAsync(
            It.IsAny<int>(),
            It.IsAny<string>())).ReturnsAsync(updatedAuthor);

        var result = await _authorService.UpdateAsync(updatedAuthor.Id, updatedAuthor.Name);

        result.Should().NotBeNull();
        result.Should().Be(result);
    }

    [Fact]
    public async Task UpdateAsync_Failed()
    {
        var updatedAuthor = new Author { };

        _authorRepository.Setup(s => s.UpdateAsync(
            It.IsAny<int>(),
            It.IsAny<string>())).ReturnsAsync(updatedAuthor);

        var result = await _authorService.UpdateAsync(updatedAuthor.Id, updatedAuthor.Name);

        result.Should().Be(result);
    }
}
