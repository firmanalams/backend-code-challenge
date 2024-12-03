using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace AE.Application.Features.Ship.Queries.GetClosestPort;

public record GetClosestPortQuery(int Id) : IRequest<ClosestPortDto>;
