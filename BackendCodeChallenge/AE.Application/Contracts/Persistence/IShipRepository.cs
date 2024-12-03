using AE.Domain;

namespace AE.Application.Contracts.Persistence
{
    public interface IShipRepository : IGenericRepository<Ship>
    {
        Task<List<Ship>> GetAsync(List<int> ids);
        Task<bool> IsShipsExist(List<int> ids);
        Task<List<Ship>> GetUnassignedAsync();
    }
}
