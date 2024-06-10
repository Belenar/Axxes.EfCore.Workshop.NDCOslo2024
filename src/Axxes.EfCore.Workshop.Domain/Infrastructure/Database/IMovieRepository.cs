using Axxes.EfCore.Workshop.Domain.Models;

namespace Axxes.EfCore.Workshop.Domain.Infrastructure.Database;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetAll();
    Task<Movie?> GetById(int id);
    Task Create(Movie newMovie);
    Task<Movie?> Update(Movie changedMovie);
    Task<Movie?> Delete(int id);
}