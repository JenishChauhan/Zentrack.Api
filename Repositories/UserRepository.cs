namespace Zentrack.Api.Repositories;

using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Zentrack.Api.Data;
using Zentrack.Api.Models;

public class UserRepository : Repository<User>, IUserRepository
{
    public UserRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Username == username);
    }
}
