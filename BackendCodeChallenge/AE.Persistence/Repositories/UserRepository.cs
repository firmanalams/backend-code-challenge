using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AE.Application.Contracts.Persistence;
using AE.Domain;
using Microsoft.EntityFrameworkCore;

namespace AE.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext.AEDatabaseContext context) : base(context)
        {
        }

        public async Task<User> GetUserWithDetails(int id)
        {
            return await _context.Users
                .Include(u => u.Ships)
                .FirstOrDefaultAsync(u => u.Id == id);
        }
    }
}
