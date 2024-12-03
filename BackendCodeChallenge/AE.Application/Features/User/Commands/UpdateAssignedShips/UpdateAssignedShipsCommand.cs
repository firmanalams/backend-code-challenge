using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace AE.Application.Features.User.Commands.UpdateAssignedShips;

public class UpdateAssignedShipsCommand : IRequest<Unit>
{
    public UpdateAssignedShipsCommand()
    {
        ShipIds = new();
    }
    public int UserId { get; set; }
    public List<int> ShipIds { get; set; }
}
