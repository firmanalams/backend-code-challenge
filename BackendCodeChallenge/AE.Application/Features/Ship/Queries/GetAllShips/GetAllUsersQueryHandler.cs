using AE.Application.Contracts.Persistence;
using AE.Application.Features.Ship.Shared;
using AutoMapper;
using MediatR;

namespace AE.Application.Features.Ship.Queries.GetAllShips;

public class GetAllShipsQueryHandler : IRequestHandler<GetAllShipsQuery, List<ShipDto>>
{
    private readonly IMapper _mapper;
    private readonly IShipRepository _shipRepository;

    public GetAllShipsQueryHandler(IMapper mapper, IShipRepository shipRepository)
    {
        this._mapper = mapper;
        this._shipRepository = shipRepository;
    }
    public async Task<List<ShipDto>> Handle(GetAllShipsQuery request, CancellationToken cancellationToken)
    {
        var ships = await _shipRepository.GetAsync();

        var result = _mapper.Map<List<ShipDto>>(ships);

        return result;
    }
}
