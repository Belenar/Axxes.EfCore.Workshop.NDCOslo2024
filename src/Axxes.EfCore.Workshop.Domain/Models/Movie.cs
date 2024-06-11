using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Axxes.EfCore.Workshop.Domain.Models;

public class Movie
{
    public int ItemKey { get; set; }
    public required string Title { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string? Description { get; set; }

    public ICollection<Director> Directors { get; set; }

    public int? MainGenreId { get; set; }
    public Genre? Genre { get; set; }

    public ICollection<Genre> SecondaryGenres { get; set; } = new HashSet<Genre>();

    public byte[] RowVersion { get; set; }

    public override string ToString()
    {
        return $"{Title} ({ReleaseDate.Year})";
    }
}

public class CinemaMovie : Movie
{
    public decimal BoxOfficeRevenue { get; set; }
}

public class TelevisionMovie : Movie
{
    public required string NetworkFirstAiredOn { get; set; }
}

public class Director
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
}

public class Genre
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public ICollection<Movie> Movies { get; set; } = new HashSet<Movie>();
    public ICollection<Movie> SecondaryMovies { get; set; } = new HashSet<Movie>();
}