using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AE.Application.Contracts.Persistence;
using AE.Application.Features.User.Commands.CreateUser;
using AE.Application.Features.User.Commands.UpdateAssignedShips;
using AE.Application.Tests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;

namespace AE.Application.Tests.Features.Users.Commands
{
    public class UpdateAssignedShipsCommandHandlerTests
    {
        private readonly Mock<IUserRepository> _mockUserRepo;
        private readonly Mock<IShipRepository> _mockShipRepo;
        public UpdateAssignedShipsCommandHandlerTests()
        {
            _mockUserRepo = MockUserRepository.GetUserMockUserRepository();
            _mockShipRepo = MockShipRepository.GetShipMockShipRepository();
        }

        [Fact]
        public async Task Handle_ValidAssignShipToUser()
        {
            var handler = new UpdateAssignedShipsCommandHandler(_mockUserRepo.Object, _mockShipRepo.Object);

            await handler.Handle(new UpdateAssignedShipsCommand() { UserId = 1, ShipIds = new List<int> { 1, 2 } }, CancellationToken.None);

            var result = await _mockUserRepo.Object.GetAsync();

            result.ElementAt(0).Ships.Count.ShouldBe(2);
        }
    }
}
