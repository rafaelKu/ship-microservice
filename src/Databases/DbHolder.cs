using System.Collections.Concurrent;
using Models;

namespace Databases;
public class DbHolder
{
    public ConcurrentDictionary<string, Ship> Db = new();
}