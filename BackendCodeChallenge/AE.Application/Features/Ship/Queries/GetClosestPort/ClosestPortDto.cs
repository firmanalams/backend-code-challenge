using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AE.Application.Features.Ship.Shared;

namespace AE.Application.Features.Ship.Queries.GetClosestPort;

public class ClosestPortDto
{
    public ClosestPortDto()
    {
        Ship = new();
    }
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double EstimatedArrivalTime { get; set; }
    public ShipDto Ship { get; set; }
}
