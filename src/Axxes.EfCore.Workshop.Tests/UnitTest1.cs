using Axxes.EfCore.Workshop.Data.Database;
using Axxes.EfCore.Workshop.Data.Repositories;
using Axxes.EfCore.Workshop.Domain.Models;
using Axxes.EfCore.Workshop.Tests.Helpers;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Axxes.EfCore.Workshop.Tests;

[SetUpFixture]
public class TestSetup
{
    [OneTimeSetUp]
    public async Task Setup()
    {
        // Should only run once
        await using var context = DbContextHelper.CreateMoviesContext();

        await context.Database.EnsureDeletedAsync();
        await context.Database.MigrateAsync();
    }
}

public class MovieRepositoryTest
{
    private MoviesContext _testContext;
    private MoviesContext _validationContext;
    private MovieRepository _repository;

    [SetUp]
    public void Setup()
    {
        _testContext = DbContextHelper.CreateMoviesContext();
        _validationContext = DbContextHelper.CreateMoviesContext();

        _repository = new MovieRepository(_testContext);
    }

    [Test]
    public async Task CreateTest()
    {
        // Arrange
        var movie = new Movie
        {
            Title = "Fight Club",
            ReleaseDate = DateOnly.FromDateTime(DateTime.Today),
            Description = "Brad & Ed fight it out."
        };

        // Act
        await _repository.Create(movie);

        // Assert
        movie.ItemKey.Should().NotBe(0, "Inserted movies should get an ID");

        var insertedMovie = await _validationContext.Movies.FindAsync(movie.ItemKey);

        insertedMovie.Should().BeEquivalentTo(movie);
    }
}

public class MovieRepositoryTest2
{
    private MoviesContext _testContext;
    private MoviesContext _validationContext;
    private MovieRepository _repository;

    [SetUp]
    public void Setup()
    {
        _testContext = DbContextHelper.CreateMoviesContext();
        _validationContext = DbContextHelper.CreateMoviesContext();

        _repository = new MovieRepository(_testContext);
    }

    [Test]
    public async Task CreateTest()
    {
        // Arrange
        var movie = new Movie
        {
            Title = "Fight Club",
            ReleaseDate = DateOnly.FromDateTime(DateTime.Today),
            Description = "Brad & Ed fight it out."
        };

        // Act
        await _repository.Create(movie);

        // Assert
        movie.ItemKey.Should().NotBe(0, "Inserted movies should get an ID");

        var insertedMovie = await _validationContext.Movies.FindAsync(movie.ItemKey);

        insertedMovie.Should().BeEquivalentTo(movie);
    }
}