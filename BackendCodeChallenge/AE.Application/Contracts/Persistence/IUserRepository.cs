using AE.Domain;

namespace AE.Application.Contracts.Persistence
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserWithDetails(int id);
    }
}
