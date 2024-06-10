using Axxes.EfCore.Workshop.Domain.Models;

namespace Axxes.EfCore.Workshop.Domain.Infrastructure.Database;

public interface IMovieRepository
{
    Task<IEnumerable<Movie>> GetAll();
}