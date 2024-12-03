using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AE.Application.Contracts.Persistence;
using AE.Application.Exceptions;
using MediatR;

namespace AE.Application.Features.Ship.Commands.UpdateShipVelocity;

public class UpdateShipVelocityCommandHandler : IRequestHandler<UpdateShipVelocityCommand, Unit>
{
    private readonly IShipRepository _shipRepository;

    public UpdateShipVelocityCommandHandler(IShipRepository shipRepository)
    {
        _shipRepository = shipRepository;
    }
    public async Task<Unit> Handle(UpdateShipVelocityCommand request, CancellationToken cancellationToken)
    {
        var ship = await _shipRepository.GetByIdAsync(request.Id);
        if (ship == null)
            throw new NotFoundException(nameof(Ship), request.Id);

        ship.Velocity = request.Velocity;

        await _shipRepository.UpdateAsync(ship);

        return Unit.Value;
    }
}
