using AutoMapper;
using Deltax.Entities;
using Deltax.Models;

namespace Deltax.Helpers.AutoMap;

public class AutoMapperClass : Profile
{
    public AutoMapperClass()
    {
        CreateMap<Actor, ActorDTO>().ReverseMap();
        CreateMap<Movie, MovieDTO>().ReverseMap();
        CreateMap<Producer, ProducerDTO>().ReverseMap();
        CreateMap<MovieDetail, MovieDetailDTO>().ReverseMap();
    }
}