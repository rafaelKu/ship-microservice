using Databases;
using Models;

namespace Repositories;

public class ShipRepository : IShipRepository
{
    private readonly DbHolder _dbHolder;
    public ShipRepository(DbHolder dbHolder)
    {
        _dbHolder = dbHolder;
    }

    public Ship? GetShipById(string shipId) => _dbHolder.Db.GetValueOrDefault(shipId);

    public bool DeleteShipById(string shipId) => _dbHolder.Db.Remove(shipId, out _);

    public bool UpdateShipById(string shipId, Ship ship)
    {
        if (!_dbHolder.Db.ContainsKey(shipId))
            return false;

        _dbHolder.Db[shipId] = ship;
        return true;
    }

    public bool SaveShip(Ship ship) => _dbHolder.Db.TryAdd(ship.Id, ship);
}