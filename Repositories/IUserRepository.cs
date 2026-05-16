namespace Zentrack.Api.Repositories;

using System.Threading.Tasks;
using Zentrack.Api.Models;

public interface IUserRepository : IRepository<User>
{
    Task<User?> GetByUsernameAsync(string username);
}
