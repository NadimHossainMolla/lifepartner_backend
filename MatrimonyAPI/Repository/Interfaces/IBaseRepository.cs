namespace MatrimonyAPI.Repository.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBaseRepository<T> where T : class
    {
        Task<T> CreateAsync(T entity, string storedProcedure);
        Task<T> GetByIdAsync(int id, string storedProcedure);
        Task<IEnumerable<T>> GetAllAsync(string storedProcedure);
        Task<T> UpdateAsync(T entity, string storedProcedure);
        Task<bool> DeleteAsync(int id, string storedProcedure);

        
    }

}
