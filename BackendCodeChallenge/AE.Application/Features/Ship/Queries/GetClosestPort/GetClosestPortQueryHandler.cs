using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AE.Application.Contracts.Persistence;
using AE.Application.Exceptions;
using AE.Application.Features.Ship.Shared;
using AE.Domain;
using AutoMapper;
using MediatR;

namespace AE.Application.Features.Ship.Queries.GetClosestPort;

public class GetClosestPortQueryHandler : IRequestHandler<GetClosestPortQuery, ClosestPortDto>
{
    private readonly IShipRepository _shipRepository;
    private readonly IPortRepository _portRepository;
    private readonly IMapper _mapper;

    public GetClosestPortQueryHandler(IShipRepository shipRepository, IPortRepository portRepository, IMapper mapper)
    {
        _shipRepository = shipRepository;
        _portRepository = portRepository;
        _mapper = mapper;
    }
    public async Task<ClosestPortDto> Handle(GetClosestPortQuery request, CancellationToken cancellationToken)
    {
        var ship = await _shipRepository.GetByIdAsync(request.Id);
        if (ship == null)
            throw new NotFoundException(nameof(ship), request.Id);

        var ports = await _portRepository.GetAsync();

        Port? closestPort = null;
        double minDistance = double.MaxValue;

        foreach (var port in ports)
        {
            double distance = Helpers.GetDistance(ship.Latitude, ship.Longitude, port.Latitude, port.Longitude);

            if (distance < minDistance)
            {
                minDistance = distance;
                closestPort = port;
            }
        }

        double estimatedArrivalTime = minDistance / ship.Velocity; // in hours

        var result = _mapper.Map<ClosestPortDto>(closestPort);
        result.EstimatedArrivalTime = estimatedArrivalTime;
        result.Ship = _mapper.Map<ShipDto>(ship);

        return result;

    }
}
