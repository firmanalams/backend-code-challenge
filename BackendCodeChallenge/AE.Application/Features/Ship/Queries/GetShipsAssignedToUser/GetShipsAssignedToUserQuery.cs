using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AE.Application.Features.Ship.Shared;
using MediatR;

namespace AE.Application.Features.Ship.Queries.GetShipsAssignedToUser;

public record GetShipsAssignedToUserQuery(int userId) : IRequest<List<ShipDto>>;