using AE.Domain.Common;

namespace AE.Domain;

public class Ship : BaseEntity
{
    public Ship()
    {
        Users = new();
    }
    public string Name { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double Velocity  { get; set; }
    public List<User> Users { get; set; }
}
