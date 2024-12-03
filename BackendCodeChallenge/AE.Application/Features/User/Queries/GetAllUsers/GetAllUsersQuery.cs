using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace AE.Application.Features.User.Queries.GetAllUsers;

public record GetAllUsersQuery : IRequest<List<UserDto>>;
