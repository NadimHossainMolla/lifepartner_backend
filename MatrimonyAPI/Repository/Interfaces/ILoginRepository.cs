using MatrimonyAPI.DTO.Request;
using MatrimonyAPI.Models;

namespace MatrimonyAPI.Repository.Interfaces
{
    public interface ILoginRepository
    {
        Task<Accounts> LoginAsync(LoginRequest entity, string storedProcedure);
    }
}
