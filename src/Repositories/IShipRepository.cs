using Models;

namespace Repositories;

public interface IShipRepository
{
    public Ship? GetShipById(string shipId);

    public bool DeleteShipById(string shipId);

    public bool UpdateShipById(string shipId, Ship ship);

    public bool SaveShip(Ship ship);
}