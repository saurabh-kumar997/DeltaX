using Deltax.Models;
using Deltax.Services;
using Microsoft.AspNetCore.Mvc;

namespace Deltax.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class ActorController : ControllerBase
{
    private readonly ILogger<MasterController> _logger;
    private readonly IActorServices _actorService;

    public ActorController(IActorServices actorService, ILogger<MasterController> logger)
    {
        _logger = logger;
        _actorService = actorService;
    }

    [HttpGet]
    public async Task<ResponseStatus<IEnumerable<ActorDTO>>> GetActorsList()
    {
        return _actorService.GetActorsListAsync();
    }

    [HttpPost]
    public async Task<ResponseStatus<ActorDTO>> AddActor([FromBodyAttribute] ActorDTO actorDTO)
    {
        return _actorService.AddActor(actorDTO);
    }
}
