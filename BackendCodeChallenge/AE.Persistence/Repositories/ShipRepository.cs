using AE.Application.Contracts.Persistence;
using AE.Domain;
using Microsoft.EntityFrameworkCore;

namespace AE.Persistence.Repositories
{
    public class ShipRepository : GenericRepository<Ship>, IShipRepository
    {
        public ShipRepository(DatabaseContext.AEDatabaseContext context) : base(context)
        {
        }

        public async Task<List<Ship>> GetAsync(List<int> ids)
        {
            return await _context.Ships
                .AsNoTracking()
                .Where(s => ids.Contains(s.Id))
                .ToListAsync();
        }

        public async Task<List<Ship>> GetUnassignedAsync()
        {
            var unrelatedShips = await _context.Ships
                    .AsNoTracking()
                    .Where(ship => !ship.Users.Any())
                    .ToListAsync();

            return unrelatedShips;
        }

        public async Task<bool> IsShipsExist(List<int> ids)
        {
            var existingCount = await _context.Ships
                .Where(ship => ids.Contains(ship.Id))
                .CountAsync();

            return existingCount == ids.Count;
        }
    }
}
