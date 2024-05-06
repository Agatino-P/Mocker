using Microsoft.AspNetCore.Mvc;
using Mocker.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Mocker.Api.Controllers;

[Host("*:82")]
[ApiController]
[Route("c2/e2")]

//[Swagger]
public class C2Controller : ControllerBase
{

    private readonly ILogger<C2Controller> _logger;

    public C2Controller(ILogger<C2Controller> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    [Host("*:82")]
    public IActionResult Get(I2 i2)
    {
        return Ok(new O2(i2.T1.ToUpperInvariant(), i2.T2.ToLowerInvariant()));
    }
}
