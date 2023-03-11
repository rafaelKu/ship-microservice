using Microsoft.AspNetCore.Mvc;
using Models;

namespace ship_microservice.Controllers;

[ApiController]
[Route("[controller]")]
public class ShipController : ControllerBase
{

    private readonly ILogger<ShipController> _logger;

    public ShipController(ILogger<ShipController> logger)
    {
        _logger = logger;
    }

    [HttpPost("create", Name = "CreateShip")]
    public bool CreateShip(Ship ship)
    {
        throw new NotImplementedException();
    }

    [HttpGet("get/{id}", Name = "GetShip")]
    public Ship GetShip(string id)
    {
        throw new NotImplementedException();
    }

    [HttpPut("update/{id}", Name = "UpdateShip")]
    public Ship UpdateShip(string id)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("delete/{id}", Name = "DeleteShip")]
    public bool DeleteShip(string id)
    {
        throw new NotImplementedException();
    }
}
