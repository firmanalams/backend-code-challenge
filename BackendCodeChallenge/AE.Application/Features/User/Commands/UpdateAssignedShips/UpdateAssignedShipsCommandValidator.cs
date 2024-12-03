using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AE.Application.Contracts.Persistence;
using FluentValidation;

namespace AE.Application.Features.User.Commands.UpdateAssignedShips;

public class UpdateAssignedShipsCommandValidator : AbstractValidator<UpdateAssignedShipsCommand>
{
    private readonly IUserRepository _userRepository;
    private readonly IShipRepository _shipRepository;

    public UpdateAssignedShipsCommandValidator(IUserRepository userRepository, IShipRepository shipRepository)
    {
        _userRepository = userRepository;
        _shipRepository = shipRepository;

        RuleFor(p => p.UserId)
            .MustAsync(UserExist)
            .WithMessage("{PropertyName} does not exist");

        RuleFor(p => p.ShipIds)
            .MustAsync(ShipsExist)
            .WithMessage("{PropertyName} does not exist");
    }

    private async Task<bool> ShipsExist(List<int> list, CancellationToken token)
    {
        return await _shipRepository.IsShipsExist(list);
    }

    private async Task<bool> UserExist(int id, CancellationToken token)
    {
        return await _userRepository.GetByIdAsync(id) != null;
    }
}
