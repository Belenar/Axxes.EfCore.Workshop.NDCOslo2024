using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Axxes.EfCore.Workshop.Domain.Models;

public class Movie
{
    public int ItemKey { get; set; }
    public required string Title { get; set; }
    public DateOnly ReleaseDate { get; set; }
    public string? Description { get; set; }

    public override string ToString()
    {
        return $"{Title} ({ReleaseDate.Year})";
    }
}