using Axxes.EfCore.Workshop.Domain.Infrastructure.Database;
using Axxes.EfCore.Workshop.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Axxes.EfCore.Workshop.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MovieController(IMovieRepository movieRepo) : ControllerBase
{
    private readonly IMovieRepository _movieRepo = movieRepo;

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Movie>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var movies = await _movieRepo.GetAll();

        return Ok(movies);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Movie), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(int id)
    {
        //TODO: fetch data
        return NotFound();
    }

    // POST api/<MovieController>
    [HttpPost]
    [ProducesResponseType(typeof(Movie), StatusCodes.Status201Created)]
    public async Task<IActionResult> Create([FromBody] Movie value)
    {
        //TODO: insert data
        return CreatedAtAction(nameof(Get), value.Id);
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