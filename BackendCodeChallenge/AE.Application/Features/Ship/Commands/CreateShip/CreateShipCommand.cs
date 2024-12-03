using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace AE.Application.Features.Ship.Commands.CreateShip;

public class CreateShipCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public double Velocity { get; set; }
}
