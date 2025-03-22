using MatrimonyAPI.Models;

namespace MatrimonyAPI.Repository.Interfaces
{
    public interface ILookUpDetailsRepository : IBaseRepository<LookUpDetails>
    {
        Task<IEnumerable<LookUpDetails>> GetByParentIdAsync(int ParentId, string storedProcedure);

        Task<IEnumerable<LookUpDetails>> GetByMasterNameAsync(string MasterName, string storedProcedure);
    }
}
