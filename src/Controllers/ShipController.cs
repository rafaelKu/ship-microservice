using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositories;

namespace ship_microservice.Controllers;

[ApiController]
[Route("[controller]")]
public class ShipController : ControllerBase
{
    private readonly IShipRepository _shipRepository;

    public ShipController(IShipRepository shipRepository)
    {
        _shipRepository = shipRepository;
    }

    [HttpPost("create", Name = "CreateShip")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public IActionResult CreateShip(Ship ship)
    {
        var regex = @"^[A-Z]{4}-\d{4}-[A-Z]\d$";
        var match = Regex.Match(ship.Id, regex, RegexOptions.IgnoreCase);
        if (!match.Success)
            return BadRequest("Id does not match pattern.");

        var saveResult = _shipRepository.SaveShip(ship);
        return saveResult ? Ok() : Conflict();
    }

    [HttpGet("get/{id}", Name = "GetShip")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Ship))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetShip(string id)
    {
        var ship = _shipRepository.GetShipById(id);
        return ship is null ? NotFound() : Ok(ship);
    }

    [HttpPut("update/{id}", Name = "UpdateShip")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult UpdateShip(string id, Ship ship)
    {
        if (id != ship.Id)
            return BadRequest("Id can't be changed.");

        var updateResult = _shipRepository.UpdateShipById(id, ship);
        return updateResult ? Ok() : NotFound();
    }

    [HttpDelete("delete/{id}", Name = "DeleteShip")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult DeleteShip(string id)
    {
        var deleteResult = _shipRepository.DeleteShipById(id);
        return deleteResult ? Ok() : NotFound();
    }
}
