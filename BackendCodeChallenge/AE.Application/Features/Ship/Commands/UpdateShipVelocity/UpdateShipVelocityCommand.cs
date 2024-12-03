using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace AE.Application.Features.Ship.Commands.UpdateShipVelocity;

public class UpdateShipVelocityCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public double Velocity { get; set; }
}
