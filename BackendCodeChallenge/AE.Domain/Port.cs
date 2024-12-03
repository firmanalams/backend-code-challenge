using AE.Domain.Common;

namespace AE.Domain;

public class Port : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
}