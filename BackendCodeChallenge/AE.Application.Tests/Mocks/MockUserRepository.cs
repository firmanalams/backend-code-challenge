using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AE.Application.Contracts.Persistence;
using AE.Domain;
using Moq;

namespace AE.Application.Tests.Mocks
{
    public class MockUserRepository
    {
        public static Mock<IUserRepository> GetUserMockUserRepository() 
        {
            var users = new List<User>
            {
                new User { Id = 1, Name = "Firman", Role = "Admin", Ships = new()},
                new User { Id = 2, Name = "Alamsyah", Role = "Admin"},
            };

            var mockRepo = new Mock<IUserRepository>();
            mockRepo.Setup(x => x.GetAsync()).ReturnsAsync(users);
            mockRepo.Setup(x => x.CreateAsync(It.IsAny<User>()))
                .Returns((User user) =>
                {
                    users.Add(user);
                    return Task.CompletedTask;
                });
            mockRepo.Setup(x => x.GetByIdAsync(1)).ReturnsAsync(users.ElementAt(0));
            mockRepo.Setup(x => x.GetUserWithDetails(1)).ReturnsAsync(users.ElementAt(0));
            mockRepo.Setup(x => x.UpdateAsync(It.IsAny<User>()))
                .Returns((User user) =>
                {
                    users[0] = user;
                    return Task.CompletedTask;
                });
            return mockRepo;
        }

    }
}
