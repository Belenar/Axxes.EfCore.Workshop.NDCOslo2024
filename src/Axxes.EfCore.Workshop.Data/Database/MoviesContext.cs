using Axxes.EfCore.Workshop.Data.Database.Mapping;
using Axxes.EfCore.Workshop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Axxes.EfCore.Workshop.Data.Database;

public class MoviesContext(DbContextOptions<MoviesContext> options) 
    : DbContext(options)
{
    public DbSet<Movie> Movies => Set<Movie>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
    }
}