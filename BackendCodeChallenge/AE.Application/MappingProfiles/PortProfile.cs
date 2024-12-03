using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AE.Application.Features.Ship.Queries.GetClosestPort;
using AE.Domain;
using AutoMapper;

namespace AE.Application.MappingProfiles;

public class PortProfile : Profile
{
    public PortProfile()
    {
        CreateMap<Port, ClosestPortDto>()
            .ForMember(p => p.EstimatedArrivalTime, o => o.Ignore())
            .ForMember(p => p.Ship, o => o.Ignore());
    }
}
