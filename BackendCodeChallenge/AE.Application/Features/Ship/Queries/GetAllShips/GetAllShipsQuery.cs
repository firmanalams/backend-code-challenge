using AE.Application.Features.Ship.Shared;
using MediatR;

namespace AE.Application.Features.Ship.Queries.GetAllShips;

public record GetAllShipsQuery : IRequest<List<ShipDto>>;
