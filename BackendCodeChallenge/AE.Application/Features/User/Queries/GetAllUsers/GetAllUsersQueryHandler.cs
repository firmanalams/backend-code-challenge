using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AE.Application.Contracts.Persistence;
using AutoMapper;
using MediatR;

namespace AE.Application.Features.User.Queries.GetAllUsers;

public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public GetAllUsersQueryHandler(IMapper mapper, IUserRepository userRepository)
    {
        this._mapper = mapper;
        this._userRepository = userRepository;
    }
    public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAsync();

        var result = _mapper.Map<List<UserDto>>(users);

        return result;
    }
}
