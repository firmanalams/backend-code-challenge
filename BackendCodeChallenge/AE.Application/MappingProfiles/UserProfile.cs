using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AE.Application.Features.User.Commands.CreateUser;
using AE.Application.Features.User.Queries.GetAllUsers;
using AE.Domain;
using AutoMapper;

namespace AE.Application.MappingProfiles;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>().ReverseMap();
        CreateMap<CreateUserCommand, User>();
    }
}
