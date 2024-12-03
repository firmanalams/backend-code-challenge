using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace AE.Application.Features.User.Commands.CreateUser;

public class CreateUserCommand : IRequest<int>
{
    public string Name { get; set; } = string.Empty;
    public string Role {  get; set; } = string.Empty;
}
