using Axxes.EfCore.Workshop.Data.Database.Mapping;
using Axxes.EfCore.Workshop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Axxes.EfCore.Workshop.Data.Database;

public class MoviesContext(DbContextOptions<MoviesContext> options) 
    : DbContext(options)
{
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }

    // Might need to override the other 3 'SaveChanges' as well
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        // Change tracker
        var entries = ChangeTracker.Entries()
            .Where(entry => entry.Entity is Movie)
            .Where(entry => entry.State == EntityState.Added);

        foreach (var createdMovieEntry in entries)
        {
            createdMovieEntry.Property("CreatedAtUtc")
                .CurrentValue = DateTime.UtcNow;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}