using MatrimonyAPI.DTO.Request;
using MatrimonyAPI.Models;

namespace MatrimonyAPI.Repository.Interfaces
{
    public interface IFilesRepository
    {
        Task<FileSaveRequest> SaveAsync(FileSaveRequest entity, string storedProcedure);

        Task<Files> GetByIdAsync(int Id, string storedProcedure);

        Task<IEnumerable<Files>> GetAllByAccountAsync(int AccountId, string storedProcedure);
        Task<IEnumerable<Files>> GetAllByTypeAsync(int AccountId,string FileType, string storedProcedure);

        Task<bool> DeleteAsync(int id, string storedProcedure);
        Task<bool> SetAsDefaultAsync(int id,int AccountId, string storedProcedure);
    }
}
