using AutoMapper;
using Deltax.Entities;
using Deltax.Models;

namespace Deltax.Services;


public interface IProducerServices
{
    ResponseStatus<IEnumerable<ProducerDTO>> GetProducersListAsync();
    ResponseStatus<ProducerDTO> AddProducer(ProducerDTO producerDTO);
}
public class ProducerServices : IProducerServices
{
    private readonly DeltaDBContext _context;
    private readonly IMapper _mapper;

    public ProducerServices(DeltaDBContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public ResponseStatus<IEnumerable<ProducerDTO>> GetProducersListAsync()
    {
        try
        {
            var actorsData = _mapper.Map<IEnumerable<ProducerDTO>>(_context.Producers);
            return new ResponseStatus<IEnumerable<ProducerDTO>>()
            {
                Data = actorsData,
                Status = BussinessStatus.Ok,
            };
        }
        catch (Exception ex)
        {
            return new ResponseStatus<IEnumerable<ProducerDTO>>()
            {
                Status = BussinessStatus.Error,
                ResponseMessage = "Could not fetch the producers data"
            };
        }

    }

    public ResponseStatus<ProducerDTO> AddProducer(ProducerDTO producerDTO)
    {
        try
        {
            var producerData = _mapper.Map<Producer>(producerDTO);
            _context.Producers.Add(producerData);

            _context.SaveChangesAsync();
            return new ResponseStatus<ProducerDTO>()
            {
                Status = BussinessStatus.Created,
                ResponseMessage = "Actor added succesfully!"
            };
        }
        catch (Exception ex)
        {
            return new ResponseStatus<ProducerDTO>()
            {
                Status = BussinessStatus.Error,
                ResponseMessage = "Could not add the actors data,Please try again!!"
            };
        }
    }

}