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
            .Include(movie => movie.Genre)
            .Include(movie => movie.SecondaryGenres)
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

    public async Task<Movie?> Update(int id, Movie changedMovie)
    {
        var existingMovie = await db.Movies.FindAsync(id);


        if (existingMovie != null)
        {
            existingMovie.Title = changedMovie.Title;
            await db.SaveChangesAsync();
        }

        return existingMovie;
    }

    public Task<Movie?> Delete(int id)
    {
        throw new NotImplementedException();
    }
}