using Deltax.Entities;
using Deltax.Models;
using Deltax.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query;

namespace Deltax.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class MovieController : ControllerBase
{
    private readonly ILogger<MasterController> _logger;
    private readonly IMovieServices _movieServices;

    public MovieController(IMovieServices movieServices, ILogger<MasterController> logger)
    {
        _logger = logger;
        _movieServices = movieServices;
    }

    [HttpGet]
    public async Task<ResponseStatus<IIncludableQueryable<MovieDetail, Actor>>> GetAllMovies()
    {
        return _movieServices.GetAllMoviesAsync();
    }

    [HttpGet]
    public async Task<ResponseStatus<IQueryable<MovieDetail>>> GetMovieById([FromQueryAttribute] int movieId)
    {
        return _movieServices.GetMovieById(movieId);
    }

    [HttpPut]
    public async Task<ResponseStatus<MovieDTO>> UpdateMovie([FromBody] MovieDTO movieDTO)
    {
        return _movieServices.UpdateMovie(movieDTO);
    }

    [HttpPost]
    public async Task<ResponseStatus<MovieDTO>> CreateMovie([FromBody] MovieDTO movieDTO)
    {
        return _movieServices.CreateMovie(movieDTO);
    }
}
