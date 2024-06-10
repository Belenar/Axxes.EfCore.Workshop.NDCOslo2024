using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Axxes.EfCore.Workshop.Domain.Models;

public class Movie
{
    public int ItemKey { get; set; }
    public required string Title { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string? Description { get; set; }

    public int? MainGenreId { get; set; }
    public Genre? Genre { get; set; }

    public ICollection<Genre> SecondaryGenres { get; set; } = new HashSet<Genre>();

    public override string ToString()
    {
        return $"{Title} ({ReleaseDate.Year})";
    }
}

public class Genre
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    public ICollection<Movie> SecondaryMovies { get; set; } = new HashSet<Movie>();
}