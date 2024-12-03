using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AE.Application.Contracts.Persistence;
using AE.Application.Features.User.Queries.GetAllUsers;
using AE.Application.MappingProfiles;
using AE.Application.Tests.Mocks;
using AutoMapper;
using Moq;
using Shouldly;

namespace AE.Application.Tests.Features.Users.Queries
{
    public class GetAllUsersQueryHandlerTests
    {
        private readonly Mock<IUserRepository> _mockRepo;
        private IMapper _mapper;

        public GetAllUsersQueryHandlerTests()
        {
            _mockRepo = MockUserRepository.GetUserMockUserRepository();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<UserProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task GetUserListTest()
        {
            var handler = new GetAllUsersQueryHandler(_mapper, _mockRepo.Object);

            var result = await handler.Handle(new GetAllUsersQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<UserDto>>();
            result.Count.ShouldBe(2);
        }
    }
}
