using Deltax.Models;
using Deltax.Services;
using Microsoft.AspNetCore.Mvc;

namespace Deltax.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ProducerController : ControllerBase
{
    private readonly ILogger<MasterController> _logger;
    private readonly IProducerServices _producerServices;

    public ProducerController(IProducerServices producerServices, ILogger<MasterController> logger)
    {
        _logger = logger;
        _producerServices = producerServices;
    }

    [HttpGet]
    public async Task<ResponseStatus<IEnumerable<ProducerDTO>>> GetProducersList()
    {
        return _producerServices.GetProducersListAsync();
    }

    [HttpPost]
    public async Task<ResponseStatus<ProducerDTO>> AddProducer([FromBodyAttribute] ProducerDTO producerDTO)
    {
        return _producerServices.AddProducer(producerDTO);
    }
}
