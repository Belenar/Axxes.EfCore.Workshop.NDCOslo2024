using Axxes.EfCore.Workshop.Data.Database;
using Axxes.EfCore.Workshop.Domain.Infrastructure.Database;
using Axxes.EfCore.Workshop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Axxes.EfCore.Workshop.Data.Repositories;

public class MovieRepository(MoviesContext db) : IMovieRepository
{
    public async Task<IEnumerable<Movie>> GetAll()
    {
        return await db.Movies
            .ToListAsync();
    }

    public async Task<Movie?> GetById(int id)
    {
        var movie = await db.Movies.FindAsync(id);

        return movie;
    }

    public async Task Create(Movie newMovie)
    {
        db.Movies.Add(newMovie);
        await db.SaveChangesAsync();
    }

    public Task<Movie?> Update(Movie changedMovie)
    {
        throw new NotImplementedException();
    }

    public Task<Movie?> Delete(int id)
    {
        throw new NotImplementedException();
    }
}