using Axxes.EfCore.Workshop.Data.Database;
using Axxes.EfCore.Workshop.Domain.Infrastructure.Database;
using Axxes.EfCore.Workshop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Axxes.EfCore.Workshop.Data.Repositories;

public class MovieRepository(MoviesContext db) : IMovieRepository
{
    public async Task<IEnumerable<Movie>> GetAll()
    {
        return await db.Movies.ToListAsync();
    }
}