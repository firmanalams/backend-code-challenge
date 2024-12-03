using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace AE.Application.Features.Ship.Commands.CreateShip;

public class CreateShipCommandValidator : AbstractValidator<CreateShipCommand>
{
    public CreateShipCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty();
        RuleFor(p => p.Latitude).NotEmpty();
        RuleFor(p => p.Longitude).NotEmpty();
    }
}
