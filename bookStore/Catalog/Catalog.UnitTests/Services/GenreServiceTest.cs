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

public class GenreServiceTest
{
    private readonly IGenreService _genreService;

    private readonly Mock<IGenreRepository> _genreRepository;
    private readonly Mock<IDbContextWrapper<ApplicationDbContext>> _dbContextWrapper;
    private readonly Mock<ILogger<GenreService>> _logger;

    private readonly Genre _testGenre = new Genre()
    {
        Id = 20,
        Name = "New Genre"
    };

    public GenreServiceTest()
    {
        _genreRepository = new Mock<IGenreRepository>();
        _dbContextWrapper = new Mock<IDbContextWrapper<ApplicationDbContext>>();
        _logger = new Mock<ILogger<GenreService>>();

        var dbContextTransaction = new Mock<IDbContextTransaction>();
        _dbContextWrapper.Setup(s => s.BeginTransactionAsync(CancellationToken.None)).ReturnsAsync(dbContextTransaction.Object);

        _genreService = new GenreService(_dbContextWrapper.Object, _logger.Object, _genreRepository.Object);
    }

    [Fact]
    public async Task AddAsync_Success()
    {
        int expectedId = 1;

        _genreRepository.Setup(s => s.AddAsync(
            It.IsAny<int>(),
            It.IsAny<string>())).ReturnsAsync(expectedId);

        var result = await _genreService.AddAsync(_testGenre.Id, _testGenre.Name);

        result.Should().Be(expectedId);
    }

    [Fact]
    public async Task AddAsync_Failed()
    {
        int? expectedId = null;

        _genreRepository.Setup(s => s.AddAsync(
            It.IsAny<int>(),
            It.IsAny<string>())).ReturnsAsync(expectedId);

        var result = await _genreService.AddAsync(_testGenre.Id, _testGenre.Name);

        result.Should().Be(expectedId);
    }

    [Fact]
    public async Task DeleteAsync_Success()
    {
        var expectedId = 1;

        _genreRepository.Setup(s => s.DeleteAsync(
                It.IsAny<int>())).ReturnsAsync((Genre?)null);

        var result = await _genreService.DeleteAsync(expectedId);

        result.Should().BeNull();
    }

    [Fact]
    public async Task DeleteAsync_Failed()
    {
        var expectedId = 999;

        _genreRepository.Setup(s => s.DeleteAsync(
                It.IsAny<int>())).ReturnsAsync(new Genre { Id = expectedId });

        var result = await _genreService.DeleteAsync(expectedId);

        result.Should().NotBeNull();
    }

    [Fact]
    public async Task UpdateAsync_Success()
    {
        var updatedGenre = new Genre { Id = 20, Name = "UpdatedGenre" };

        _genreRepository.Setup(s => s.UpdateAsync(
            It.IsAny<int>(),
            It.IsAny<string>())).ReturnsAsync(updatedGenre);

        var result = await _genreService.UpdateAsync(updatedGenre.Id, updatedGenre.Name);

        result.Should().NotBeNull();
        result.Should().Be(result);
    }

    [Fact]
    public async Task UpdateAsync_Failed()
    {
        var updatedGenre = new Genre { };

        _genreRepository.Setup(s => s.UpdateAsync(
            It.IsAny<int>(),
            It.IsAny<string>())).ReturnsAsync(updatedGenre);

        var result = await _genreService.UpdateAsync(updatedGenre.Id, updatedGenre.Name);

        result.Should().Be(result);
    }
}