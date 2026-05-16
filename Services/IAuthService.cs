namespace Zentrack.Api.Services;

using System.Threading.Tasks;

public interface IAuthService
{
    Task<(bool Success, string Message)> RegisterAsync(string username, string password);
    Task<(bool Success, string Token, string Message)> LoginAsync(string username, string password);
}
