using AE.Application.Contracts.Persistence;
using AE.Domain;

namespace AE.Persistence.Repositories
{
    public class PortRepository : GenericRepository<Port>, IPortRepository
    {
        public PortRepository(DatabaseContext.AEDatabaseContext context) : base(context)
        {
        }
    }
}
