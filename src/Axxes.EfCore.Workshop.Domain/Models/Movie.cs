namespace Axxes.EfCore.Workshop.Domain.Models;

public class Movie
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string? Description { get; set; }

    public override string ToString()
    {
        return $"{Title} ({ReleaseDate.Year})";
    }
}