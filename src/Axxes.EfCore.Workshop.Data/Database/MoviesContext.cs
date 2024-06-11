using Axxes.EfCore.Workshop.Data.Database.Mapping;
using Axxes.EfCore.Workshop.Domain.Models;
using Axxes.EfCore.Workshop.Domain.Tenants;
using Microsoft.EntityFrameworkCore;

namespace Axxes.EfCore.Workshop.Data.Database;

public class MoviesContext(DbContextOptions<MoviesContext> options, TenantService tenantService) 
    : DbContext(options)
{
    public string? TenantId => tenantService.GetTenantId();
    
    public DbSet<Movie> Movies => Set<Movie>();
    public DbSet<Genre> Genres => Set<Genre>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new MovieConfiguration(this));
        modelBuilder.ApplyConfiguration(new TelevisionMovieConfiguration());
        modelBuilder.ApplyConfiguration(new CinemaMovieConfiguration());
        modelBuilder.ApplyConfiguration(new GenreConfiguration());

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

            createdMovieEntry.Property("TenantId")
                .CurrentValue = tenantService.GetTenantId();
        }

        return base.SaveChangesAsync(cancellationToken);
    }
}