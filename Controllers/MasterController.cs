using Deltax.Services;
using Microsoft.AspNetCore.Mvc;

namespace Deltax.Controllers;

[ApiController]
[Route("api/[controller]/[action]")]
public class MasterController : ControllerBase
{
    private readonly ILogger<MasterController> _logger;
    private readonly IMasterServices _masterService;

    public MasterController(IMasterServices masterService, ILogger<MasterController> logger)
    {
        _logger = logger;
        _masterService = masterService;
    }

    [HttpGet]
    public async Task<IActionResult> GetMasters()
    {
        return Ok(_masterService.GetMasterAsync());
    }
}
