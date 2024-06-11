using Axxes.EfCore.Workshop.Domain.Infrastructure.Database;
using Axxes.EfCore.Workshop.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Axxes.EfCore.Workshop.API.Controllers;

[Route("/[controller]")]
[ApiController]
public class MovieController(IMovieRepository movieRepo) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Movie>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var movies = await movieRepo.GetAll();

        return Ok(movies);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Movie), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        var movie = await movieRepo.GetById(id);

        if (movie is null)
            return NotFound();

        return Ok(movie);
    }

    // POST api/<MovieController>
    [HttpPost]
    [ProducesResponseType(typeof(Movie), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] Movie value)
    {
        var movie = new CinemaMovie
        {
            Title = value.Title,
            Description = value.Description,
            ReleaseDate = value.ReleaseDate,
            BoxOfficeRevenue = 1000000
        };

        await movieRepo.Create(movie);

        return CreatedAtAction(nameof(Get), new { id = movie.ItemKey }, movie);
    }

    [HttpPut("{id:int}")]
    [ProducesResponseType(typeof(Movie), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] Movie movie)
    {
        //TODO: update data
        return NotFound();
    }

    [HttpDelete("{id:int}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Remove([FromRoute] int id)
    {
        //TODO: delete data
        return NotFound();
    }
}