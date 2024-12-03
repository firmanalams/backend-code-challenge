using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AE.Application.Contracts.Persistence;
using AE.Application.Exceptions;
using AE.Application.Features.User.Commands.CreateUser;
using AE.Application.Features.User.Queries.GetAllUsers;
using AE.Application.MappingProfiles;
using AE.Application.Tests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;

namespace AE.Application.Tests.Features.Users.Commands
{
    public class CreateUserCommandHandlerTests
    {
        private readonly Mock<IUserRepository> _mockRepo;
        private IMapper _mapper;
        public CreateUserCommandHandlerTests()
        {
            _mockRepo = MockUserRepository.GetUserMockUserRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<UserProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidUser_AddedToUsersRepo()
        {
            var handler = new CreateUserCommandHandler(_mapper, _mockRepo.Object);

            await handler.Handle(new CreateUserCommand() { Name = "Admin", Role = "Admin"}, CancellationToken.None);

            var result = await _mockRepo.Object.GetAsync();

            result.Count.ShouldBe(3);
        }

        [Fact]
        public async Task Handle_InvalidUser_EmptyData()
        {
            var handler = new CreateUserCommandHandler(_mapper, _mockRepo.Object);

            await Should.ThrowAsync<BadRequestException>(async () => await handler.Handle(new CreateUserCommand(), CancellationToken.None));
            
        }
    }
}
