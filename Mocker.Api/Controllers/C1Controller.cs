using Microsoft.AspNetCore.Mvc;
using Mocker.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Mocker.Api.Controllers;

[SwaggerTag]
[Host("*:81")]
[ApiController]
[Route("c1/e1")]
public class C1Controller : ControllerBase
{
    
    private readonly ILogger<C1Controller> _logger;

    public C1Controller(ILogger<C1Controller> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    [Host("*:81")]
    public IActionResult Get(I1 i1)
    {
        return Ok(new O1(i1.N1+1, i1.S2));
    }
}
