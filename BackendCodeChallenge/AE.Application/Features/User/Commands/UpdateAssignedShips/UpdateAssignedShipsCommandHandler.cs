using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AE.Application.Contracts.Persistence;
using AE.Application.Exceptions;
using AE.Application.Features.User.Commands.CreateUser;
using MediatR;

namespace AE.Application.Features.User.Commands.UpdateAssignedShips;

public class UpdateAssignedShipsCommandHandler : IRequestHandler<UpdateAssignedShipsCommand, Unit>
{
    private readonly IUserRepository _userRepository;
    private readonly IShipRepository _shipRepository;

    public UpdateAssignedShipsCommandHandler(IUserRepository userRepository, IShipRepository shipRepository)
    {
        this._userRepository = userRepository;
        this._shipRepository = shipRepository;
    }
    public async Task<Unit> Handle(UpdateAssignedShipsCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateAssignedShipsCommandValidator(_userRepository, _shipRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Request", validationResult);

        var user = await _userRepository.GetUserWithDetails(request.UserId);
        user.Ships.Clear();

        var ships = await _shipRepository.GetAsync(request.ShipIds);
        user.Ships.AddRange(ships);   

        await _userRepository.UpdateAsync(user);

        return Unit.Value;
    }
}
