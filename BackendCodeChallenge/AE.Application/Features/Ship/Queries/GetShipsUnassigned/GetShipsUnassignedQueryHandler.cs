using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AE.Application.Contracts.Persistence;
using AE.Application.Features.Ship.Shared;
using AutoMapper;
using MediatR;

namespace AE.Application.Features.Ship.Queries.GetShipsUnassigned;

public class GetShipsUnassignedQueryHandler : IRequestHandler<GetShipsUnassignedQuery, List<ShipDto>>
{
    private readonly IMapper _mapper;
    private readonly IShipRepository _shipRepository;

    public GetShipsUnassignedQueryHandler(IMapper mapper, IShipRepository shipRepository)
    {
        _mapper = mapper;
        _shipRepository = shipRepository;
    }
    public async Task<List<ShipDto>> Handle(GetShipsUnassignedQuery request, CancellationToken cancellationToken)
    {
        var ships = await _shipRepository.GetUnassignedAsync();

        var result = _mapper.Map<List<ShipDto>>(ships);

        return result;
    }
}
