namespace MatrimonyAPI.Repository.Interfaces
{
    using MatrimonyAPI.Models;
    using System.Threading.Tasks;
    using System.Collections.Generic;
    using MatrimonyAPI.Models.ViewModels;
    using MatrimonyAPI.DTO.Request;

    public interface IAccountsRepository : IBaseRepository<Accounts>
    {
        Task<RegistrationRequest> RegisterAsync(RegistrationRequest entity, string storedProcedure);
        Task<IEnumerable<ProfileBasic>> GetAllWithFilterAsync(AccountListRequest request, string storedProcedure);
        Task<SideBarDetails> GetSideBarDetailsById(int id, string storedProcedure);
        Task<ProfileDetails> GetProfileDetailsById(int id, string storedProcedure);
        Task<DashboardStats> GetDashboardStatsById(int id, string storedProcedure);
        Task<PersonalInfo> UpdatePersonalInfoAsync(PersonalInfo entity, string storedProcedure);
        Task<BioDetails> UpdateBioDetailsAsync(BioDetails entity, string storedProcedure);
        Task<OccupationAndEducationDetails> UpdateOccupationAndEducationDetailsAsync(OccupationAndEducationDetails entity, string storedProcedure);
        Task<FamilyDetails> UpdateFamilyDetailsAsync(FamilyDetails entity, string storedProcedure);
        Task<Boolean> CheckProfileStepValueById(int id,string step, string storedProcedure);
        Task<AccountsViewModel> GetDetailsByIdAsync(int id,int accountId, string storedProcedure);
    }

}
