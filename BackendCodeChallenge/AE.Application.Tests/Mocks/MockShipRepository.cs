using AE.Application.Contracts.Persistence;
using AE.Domain;
using Moq;

namespace AE.Application.Tests.Mocks
{
    public class MockShipRepository
    {
        public static Mock<IShipRepository> GetShipMockShipRepository()
        {
            var ships = new List<Ship>
            {
                new Ship { Id = 1, Name = "Sea Voyager", Latitude = 31.2320, Longitude = 121.4745, Velocity = 14.2 }, // Near Port of Shanghai
                new Ship { Id = 2, Name = "Ocean Explorer", Latitude = 1.3540, Longitude = 103.8205, Velocity = 16.5 }, // Near Port of Singapore
            };

            var mockRepo = new Mock<IShipRepository>();

            mockRepo.Setup(x => x.GetAsync()).ReturnsAsync(ships);
            mockRepo.Setup(x => x.CreateAsync(It.IsAny<Ship>()))
                .Returns((Ship ship) =>
                {
                    ships.Add(ship);
                    return Task.CompletedTask;
                });
            mockRepo.Setup(x => x.IsShipsExist(new List<int> { 1, 2})).ReturnsAsync(true);
            mockRepo.Setup(x => x.GetAsync(new List<int> { 1, 2 })).ReturnsAsync(ships);

            return mockRepo;
        }

    }
}
