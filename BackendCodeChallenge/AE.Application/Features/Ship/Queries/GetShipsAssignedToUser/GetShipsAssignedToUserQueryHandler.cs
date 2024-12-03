using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AE.Application.Contracts.Persistence;
using AE.Application.Exceptions;
using AE.Application.Features.Ship.Shared;
using AutoMapper;
using MediatR;

namespace AE.Application.Features.Ship.Queries.GetShipsAssignedToUser;

public class GetShipsAssignedToUserQueryHandler : IRequestHandler<GetShipsAssignedToUserQuery, List<ShipDto>>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetShipsAssignedToUserQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }
    public async Task<List<ShipDto>> Handle(GetShipsAssignedToUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserWithDetails(request.userId);
        if (user == null)
            throw new NotFoundException(nameof(User), request.userId);

        var result = _mapper.Map<List<ShipDto>>(user.Ships);

        return result;
    }
}
