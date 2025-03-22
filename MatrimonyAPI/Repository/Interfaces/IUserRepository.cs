using MatrimonyAPI.Models;

namespace MatrimonyAPI.Repository.Interfaces
{
    public interface IUserRepository
    {
        Task<Accounts?> GetUserByUsernameAsync(string username);
        Task AddUserAsync(Accounts user);
    }
}
