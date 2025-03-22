using MatrimonyAPI.DTO.Request;
using MatrimonyAPI.Models;

namespace MatrimonyAPI.Repository.Interfaces
{
    public interface IFilterRepository
    {
        Task<IEnumerable<Filters>> GetAllAsync(FilterRequest request, string storedProcedure);
    }
}
