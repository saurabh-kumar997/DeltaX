using AutoMapper;
using Deltax.Entities;
using Deltax.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Deltax.Services;


public interface IMovieServices
{
    ResponseStatus<IIncludableQueryable<MovieDetail, Actor>> GetAllMoviesAsync();
    ResponseStatus<IQueryable<MovieDetail>> GetMovieById(int movieId);
    ResponseStatus<MovieDTO> UpdateMovie(MovieDTO movie);
    ResponseStatus<MovieDTO> CreateMovie(MovieDTO movie);
}
public class MovieServices : IMovieServices
{
    private readonly DeltaDBContext _context;
    private readonly IMapper _mapper;

    public MovieServices(DeltaDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ResponseStatus<IIncludableQueryable<MovieDetail, Actor>> GetAllMoviesAsync()
    {
        try
        {
            var data = _context.MovieDetails.Include(movie => movie.Movie).Include(actor => actor.Actor);

            return new ResponseStatus<IIncludableQueryable<MovieDetail, Actor>>
            {
                Status = BussinessStatus.Ok,
                Data = data
            };
        }
        catch (Exception ex)
        {
            return new ResponseStatus<IIncludableQueryable<MovieDetail, Actor>>
            {
                Status = BussinessStatus.Error,
                ResponseMessage = "Could not fetch the Movie data"
            };
        }
    }

    public ResponseStatus<IQueryable<MovieDetail>> GetMovieById(int movieId)
    {
        try
        {
            var data = _context.MovieDetails.Include(movie => movie.Movie).Include(actor => actor.Actor).Where(x => x.MovieId == movieId);
            return new ResponseStatus<IQueryable<MovieDetail>>
            {
                Status = BussinessStatus.Ok,
                Data = data
            };
        }
        catch (Exception ex)
        {
            return new ResponseStatus<IQueryable<MovieDetail>>
            {
                Status = BussinessStatus.Error,
                ResponseMessage = "Could not fetch the Movie data"
            };
        }
    }
    public ResponseStatus<MovieDTO> UpdateMovie(MovieDTO movie)
    {
        try
        {
            var data = _context.Movies.Where(x => x.MovieId == movie.MovieId);

            if (data.Count() > 0)
            {
                _context.Movies.Update(_mapper.Map<Movie>(movie));

                _context.SaveChanges();

                return new ResponseStatus<MovieDTO>
                {
                    Status = BussinessStatus.Updated,
                    ResponseMessage = "Update Successfully"
                };
            }
            else
            {
                return new ResponseStatus<MovieDTO>
                {
                    Status = BussinessStatus.NotFound,
                    ResponseMessage = "cannot find the movie to update"
                };
            }



        }
        catch (Exception ex)
        {
            return new ResponseStatus<MovieDTO>
            {
                Status = BussinessStatus.Error,
                ResponseMessage = "Could not update the Movie data"
            };
        }
    }

    public ResponseStatus<MovieDTO> CreateMovie(MovieDTO movie)
    {
        try
        {
            var data = _context.Movies.Where(x => x.MovieId == movie.MovieId);

            if (data.Count() > 0)
            {
                return new ResponseStatus<MovieDTO>
                {
                    Status = BussinessStatus.Error,
                    ResponseMessage = "Movie Already Exist"
                };

            }
            else
            {
                _context.Movies.Add(_mapper.Map<Movie>(movie));
                _context.SaveChanges();

                return new ResponseStatus<MovieDTO>
                {
                    Status = BussinessStatus.Created,
                    ResponseMessage = "Movie added Successfully"
                };
            }



        }
        catch (Exception ex)
        {
            return new ResponseStatus<MovieDTO>
            {
                Status = BussinessStatus.Error,
                ResponseMessage = "Could not update the Movie data"
            };
        }
    }

}