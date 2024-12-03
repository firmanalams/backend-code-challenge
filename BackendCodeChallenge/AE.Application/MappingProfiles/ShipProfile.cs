using AE.Application.Features.Ship.Shared;
using AE.Domain;
using AutoMapper;

namespace AE.Application.MappingProfiles;

public class ShipProfile : Profile
{
    public ShipProfile()
    {
        CreateMap<Ship, ShipDto>().ReverseMap();
    }
}
