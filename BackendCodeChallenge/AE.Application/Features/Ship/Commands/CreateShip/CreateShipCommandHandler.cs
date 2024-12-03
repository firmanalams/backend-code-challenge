using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AE.Application.Contracts.Persistence;
using AE.Application.Exceptions;
using AE.Domain;
using AutoMapper;
using MediatR;

namespace AE.Application.Features.Ship.Commands.CreateShip;

public class CreateShipCommandHandler : IRequestHandler<CreateShipCommand, int>
{
    private readonly IMapper _mapper;
    private readonly IShipRepository _shipRepository;

    public CreateShipCommandHandler(IMapper mapper, IShipRepository shipRepository)
    {
        _mapper = mapper;
        _shipRepository = shipRepository;
    }
    public async Task<int> Handle(CreateShipCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateShipCommandValidator();
        var validationResult = await validator.ValidateAsync(request);

        if (!validationResult.IsValid)
            throw new BadRequestException("Invalid Ship", validationResult);

        var shipCreate = _mapper.Map<Domain.Ship>(request);

        await _shipRepository.CreateAsync(shipCreate);

        return shipCreate.Id;
    }
}
