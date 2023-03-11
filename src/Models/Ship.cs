namespace Models;

public class Ship
{
    public Ship(string name, string id, int lengthInMeters, int widthInMeters)
    {
        Name = name;
        Id = id;
        LengthInMeters = lengthInMeters;
        WidthInMeters = widthInMeters;
    }

    public string Name { get; set; }
    public string Id { get; set; }
    public int LengthInMeters { get; set; }
    public int WidthInMeters { get; set; }
}