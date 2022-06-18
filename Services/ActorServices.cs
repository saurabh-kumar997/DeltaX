using AutoMapper;
using Deltax.Entities;
using Deltax.Models;

namespace Deltax.Services;


public interface IActorServices
{
    ResponseStatus<ActorDTO> AddActor(ActorDTO actorDTO);
    ResponseStatus<IEnumerable<ActorDTO>> GetActorsListAsync();
}
public class ActorServices : IActorServices
{
    private readonly DeltaDBContext _context;
    private readonly IMapper _mapper;

    public ActorServices(DeltaDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ResponseStatus<IEnumerable<ActorDTO>> GetActorsListAsync()
    {
        try
        {
            var actorsData = _mapper.Map<IEnumerable<ActorDTO>>(_context.Actors);
            return new ResponseStatus<IEnumerable<ActorDTO>>()
            {
                Data = actorsData,
                Status = BussinessStatus.Ok,
            };
        }
        catch (Exception ex)
        {
            return new ResponseStatus<IEnumerable<ActorDTO>>()
            {
                Status = BussinessStatus.Error,
                ResponseMessage = "Could not fetch the actors data"
            };
        }

    }

    public ResponseStatus<ActorDTO> AddActor(ActorDTO actorDTO)
    {
        try
        {
            var actorsData = _mapper.Map<Actor>(actorDTO);
            _context.Actors.Add(actorsData);

            _context.SaveChangesAsync();
            return new ResponseStatus<ActorDTO>()
            {
                Status = BussinessStatus.Created,
                ResponseMessage = "Actor added succesfully!"
            };
        }
        catch (Exception ex)
        {
            return new ResponseStatus<ActorDTO>()
            {
                Status = BussinessStatus.Error,
                ResponseMessage = "Could not add the actors data,Please try again!!"
            };
        }
    }

}