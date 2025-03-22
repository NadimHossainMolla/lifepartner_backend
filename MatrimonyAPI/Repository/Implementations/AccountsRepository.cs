namespace MatrimonyAPI.Repository.Implementations
{
    using MatrimonyAPI.DTO.Request;
    using MatrimonyAPI.Models;
    using MatrimonyAPI.Models.ViewModels;
    using MatrimonyAPI.Repository.Interfaces;

    using Microsoft.Data.SqlClient;

    using System.Data;
    using System.Reflection.PortableExecutable;
    using System.Threading.Tasks;

    public class AccountsRepository : IAccountsRepository
    {
        private readonly DbContext _dbContext;

        public AccountsRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Accounts> CreateAsync(Accounts account, string storedProcedure)
        {
            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    command.Parameters.AddWithValue("@FirstName", account.FirstName);
                    command.Parameters.AddWithValue("@MiddleName", account.MiddleName);
                    command.Parameters.AddWithValue("@LastName", account.LastName);
                    command.Parameters.AddWithValue("@Age", account.Age);
                    command.Parameters.AddWithValue("@Gender", account.Gender);
                    command.Parameters.AddWithValue("@Religion", account.Religion);
                    command.Parameters.AddWithValue("@Email", account.Email);
                    command.Parameters.AddWithValue("@MobileNo", account.MobileNo);
                    command.Parameters.AddWithValue("@Password", account.Password);
                    command.Parameters.AddWithValue("@Address", account.Address);
                    command.Parameters.AddWithValue("@City", account.City);
                    command.Parameters.AddWithValue("@District", account.District);
                    command.Parameters.AddWithValue("@State", account.State);
                    command.Parameters.AddWithValue("@Zip", account.Zip);
                    command.Parameters.AddWithValue("@Country", account.Country);
                    command.Parameters.AddWithValue("@Community", account.Community);
                    command.Parameters.AddWithValue("@SubCommunity", account.SubCommunity);
                    command.Parameters.AddWithValue("@MotherTongue", account.MotherTongue);
                    command.Parameters.AddWithValue("@MatritalStatus", account.MatritalStatus);
                    command.Parameters.AddWithValue("@LivingSituation", account.LivingSituation);
                    command.Parameters.AddWithValue("@Diet", account.Diet);
                    command.Parameters.AddWithValue("@Height", account.Height);
                    command.Parameters.AddWithValue("@BodyType", account.BodyType);
                    command.Parameters.AddWithValue("@Complexion", account.Complexion);
                    command.Parameters.AddWithValue("@AlcoholDrinker", account.AlcoholDrinker);
                    command.Parameters.AddWithValue("@Smoker", account.Smoker);
                    command.Parameters.AddWithValue("@HighestQualification", account.HighestQualification);
                    command.Parameters.AddWithValue("@Profession", account.Profession);
                    command.Parameters.AddWithValue("@AnnualIncome", account.AnnualIncome);
                    command.Parameters.AddWithValue("@FatherName", account.FatherName);
                    command.Parameters.AddWithValue("@FatherStatus", account.FatherStatus);
                    command.Parameters.AddWithValue("@FatherMobileNo", account.FatherMobileNo);
                    command.Parameters.AddWithValue("@MotherName", account.MotherName);
                    command.Parameters.AddWithValue("@MotherStatus", account.MotherStatus);
                    command.Parameters.AddWithValue("@MotherMobileNo", account.MotherMobileNo);
                    command.Parameters.AddWithValue("@GurdianName", account.GurdianName);
                    command.Parameters.AddWithValue("@GurdianMobileNo", account.GurdianMobileNo);
                    command.Parameters.AddWithValue("@NoOfBrothers", account.NoOfBrothers);
                    command.Parameters.AddWithValue("@NoOfMarriedBrothers", account.NoOfMarriedBrothers);
                    command.Parameters.AddWithValue("@NoOfSisters", account.NoOfSisters);
                    command.Parameters.AddWithValue("@NoOfMarriedSisters", account.NoOfMarriedSisters);
                    command.Parameters.AddWithValue("@FamilyType", account.FamilyType);
                    command.Parameters.AddWithValue("@FamilyReligiousValues", account.FamilyReligiousValues);
                    command.Parameters.AddWithValue("@CreatedOn", account.CreatedOn);
                    command.Parameters.AddWithValue("@UpdatedOn", account.UpdatedOn);
                    command.Parameters.AddWithValue("@IsActive", account.IsActive);

                    // Execute the stored procedure and return the result
                    var result = await _dbContext.ExecuteScalarAsync(command);
                    account.Id = Convert.ToInt32(result);
                    return account;
                }
                finally
                {
                    if (command.Connection != null && command.Connection.State == ConnectionState.Open)
                    {
                        command.Connection.Close(); // Ensure the connection is closed
                    }
                }
            }

        }

        public async Task<Accounts> GetByIdAsync(int id, string storedProcedure)
        {
            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", id));

                    var reader = await _dbContext.ExecuteReaderAsync(command);
                    Accounts accountModel = null;

                    if (reader != null)
                    {
                        try
                        {
                            while (await reader.ReadAsync())
                            {
                                accountModel = new Accounts
                                {
                                    Id = reader.IsDBNull(reader.GetOrdinal("Id")) ? 0 : reader.GetInt32(reader.GetOrdinal("Id")),
                                    FirstName = reader.IsDBNull(reader.GetOrdinal("FirstName")) ? null : reader.GetString(reader.GetOrdinal("FirstName")),
                                    MiddleName = reader.IsDBNull(reader.GetOrdinal("MiddleName")) ? null : reader.GetString(reader.GetOrdinal("MiddleName")),
                                    LastName = reader.IsDBNull(reader.GetOrdinal("LastName")) ? null : reader.GetString(reader.GetOrdinal("LastName")),
                                    Age = reader.IsDBNull(reader.GetOrdinal("Age")) ? 0 : reader.GetInt32(reader.GetOrdinal("Age")),
                                    Gender = reader.IsDBNull(reader.GetOrdinal("Gender")) ? 0 : reader.GetInt32(reader.GetOrdinal("Gender")),
                                    Religion = reader.IsDBNull(reader.GetOrdinal("Religion")) ? 0 : reader.GetInt32(reader.GetOrdinal("Religion")),
                                    Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                                    MobileNo = reader.IsDBNull(reader.GetOrdinal("MobileNo")) ? null : reader.GetString(reader.GetOrdinal("MobileNo")),
                                    Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString(reader.GetOrdinal("Address")),
                                    City = reader.IsDBNull(reader.GetOrdinal("City")) ? null : reader.GetString(reader.GetOrdinal("City")),
                                    District = reader.IsDBNull(reader.GetOrdinal("District")) ? 0 : reader.GetInt32(reader.GetOrdinal("District")),
                                    State = reader.IsDBNull(reader.GetOrdinal("State")) ? 0 : reader.GetInt32(reader.GetOrdinal("State")),
                                    Zip = reader.IsDBNull(reader.GetOrdinal("Zip")) ? null : reader.GetString(reader.GetOrdinal("Zip")),
                                    Country = reader.IsDBNull(reader.GetOrdinal("Country")) ? 0 : reader.GetInt32(reader.GetOrdinal("Country")),
                                    Community = reader.IsDBNull(reader.GetOrdinal("Community")) ? null : reader.GetInt32(reader.GetOrdinal("Community")),
                                    SubCommunity = reader.IsDBNull(reader.GetOrdinal("SubCommunity")) ? null : reader.GetInt32(reader.GetOrdinal("SubCommunity")),
                                    MotherTongue = reader.IsDBNull(reader.GetOrdinal("MotherTongue")) ? null : reader.GetInt32(reader.GetOrdinal("MotherTongue")),
                                    MatritalStatus = reader.IsDBNull(reader.GetOrdinal("MatritalStatus")) ? null : reader.GetInt32(reader.GetOrdinal("MatritalStatus")),
                                    LivingSituation = reader.IsDBNull(reader.GetOrdinal("LivingSituation")) ? null : reader.GetInt32(reader.GetOrdinal("LivingSituation")),
                                    Diet = reader.IsDBNull(reader.GetOrdinal("Diet")) ? null : reader.GetInt32(reader.GetOrdinal("Diet")),
                                    Height = reader.IsDBNull(reader.GetOrdinal("Height")) ? null : reader.GetDecimal(reader.GetOrdinal("Height")),
                                    BodyType = reader.IsDBNull(reader.GetOrdinal("BodyType")) ? null : reader.GetInt32(reader.GetOrdinal("BodyType")),
                                    Complexion = reader.IsDBNull(reader.GetOrdinal("Complexion")) ? null : reader.GetInt32(reader.GetOrdinal("Complexion")),
                                    AlcoholDrinker = reader.IsDBNull(reader.GetOrdinal("AlcoholDrinker")) ? null : reader.GetBoolean(reader.GetOrdinal("AlcoholDrinker")),
                                    Smoker = reader.IsDBNull(reader.GetOrdinal("Smoker")) ? null : reader.GetBoolean(reader.GetOrdinal("Smoker")),
                                    Bio = reader.IsDBNull(reader.GetOrdinal("Bio")) ? string.Empty : reader.GetString(reader.GetOrdinal("Bio")),
                                    PartnerBio = reader.IsDBNull(reader.GetOrdinal("PartnerBio")) ? string.Empty : reader.GetString(reader.GetOrdinal("PartnerBio")),
                                    HighestQualification = reader.IsDBNull(reader.GetOrdinal("HighestQualification")) ? null : reader.GetInt32(reader.GetOrdinal("HighestQualification")),
                                    Profession = reader.IsDBNull(reader.GetOrdinal("Profession")) ? null : reader.GetInt32(reader.GetOrdinal("Profession")),
                                    AnnualIncome = reader.IsDBNull(reader.GetOrdinal("AnnualIncome")) ? 0 : reader.GetInt32(reader.GetOrdinal("AnnualIncome")),
                                    FatherName = reader.IsDBNull(reader.GetOrdinal("FatherName")) ? null : reader.GetString(reader.GetOrdinal("FatherName")),
                                    FatherStatus = reader.IsDBNull(reader.GetOrdinal("FatherStatus")) ? null : reader.GetInt32(reader.GetOrdinal("FatherStatus")),
                                    FatherMobileNo = reader.IsDBNull(reader.GetOrdinal("FatherMobileNo")) ? null : reader.GetString(reader.GetOrdinal("FatherMobileNo")),
                                    MotherName = reader.IsDBNull(reader.GetOrdinal("MotherName")) ? null : reader.GetString(reader.GetOrdinal("MotherName")),
                                    MotherStatus = reader.IsDBNull(reader.GetOrdinal("MotherStatus")) ? null : reader.GetInt32(reader.GetOrdinal("MotherStatus")),
                                    MotherMobileNo = reader.IsDBNull(reader.GetOrdinal("MotherMobileNo")) ? null : reader.GetString(reader.GetOrdinal("MotherMobileNo")),
                                    GurdianName = reader.IsDBNull(reader.GetOrdinal("GurdianName")) ? null : reader.GetString(reader.GetOrdinal("GurdianName")),
                                    GurdianMobileNo = reader.IsDBNull(reader.GetOrdinal("GurdianMobileNo")) ? null : reader.GetString(reader.GetOrdinal("GurdianMobileNo")),
                                    NoOfBrothers = reader.IsDBNull(reader.GetOrdinal("NoOfBrothers")) ? 0 : reader.GetInt32(reader.GetOrdinal("NoOfBrothers")),
                                    NoOfMarriedBrothers = reader.IsDBNull(reader.GetOrdinal("NoOfMarriedBrothers")) ? 0 : reader.GetInt32(reader.GetOrdinal("NoOfMarriedBrothers")),
                                    NoOfSisters = reader.IsDBNull(reader.GetOrdinal("NoOfSisters")) ? 0 : reader.GetInt32(reader.GetOrdinal("NoOfSisters")),
                                    NoOfMarriedSisters = reader.IsDBNull(reader.GetOrdinal("NoOfMarriedSisters")) ? 0 : reader.GetInt32(reader.GetOrdinal("NoOfMarriedSisters")),
                                    FamilyType = reader.IsDBNull(reader.GetOrdinal("FamilyType")) ? null : reader.GetInt32(reader.GetOrdinal("FamilyType")),
                                    FamilyReligiousValues = reader.IsDBNull(reader.GetOrdinal("FamilyReligiousValues")) ? null : reader.GetInt32(reader.GetOrdinal("FamilyReligiousValues")),
                                    CreatedOn = reader.IsDBNull(reader.GetOrdinal("CreatedOn")) ? null : reader.GetDateTime(reader.GetOrdinal("CreatedOn")),
                                    UpdatedOn = reader.IsDBNull(reader.GetOrdinal("UpdatedOn")) ? null : reader.GetDateTime(reader.GetOrdinal("UpdatedOn")),
                                    IsActive = reader.IsDBNull(reader.GetOrdinal("IsActive")) ? false : reader.GetBoolean(reader.GetOrdinal("IsActive"))

                                };
                            }
                        }
                        finally
                        {
                            reader.Close();
                        }
                    }

                    return accountModel;
                }
                finally
                {
                    if (command.Connection != null && command.Connection.State == ConnectionState.Open)
                    {
                        command.Connection.Close(); // Ensure the connection is closed
                    }
                }
            }
        }

        public async Task<IEnumerable<Accounts>> GetAllAsync(string storedProcedure)
        {
            var accountsList = new List<Accounts>();

            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;

                    using (var reader = await _dbContext.ExecuteReaderAsync(command))
                    {
                        try
                        {
                            while (await reader.ReadAsync())
                            {
                                var account = new Accounts
                                {
                                    Id = reader.IsDBNull(reader.GetOrdinal("Id")) ? 0 : reader.GetInt32(reader.GetOrdinal("Id")),
                                    FirstName = reader.IsDBNull(reader.GetOrdinal("FirstName")) ? null : reader.GetString(reader.GetOrdinal("FirstName")),
                                    MiddleName = reader.IsDBNull(reader.GetOrdinal("MiddleName")) ? null : reader.GetString(reader.GetOrdinal("MiddleName")),
                                    LastName = reader.IsDBNull(reader.GetOrdinal("LastName")) ? null : reader.GetString(reader.GetOrdinal("LastName")),
                                    Age = reader.IsDBNull(reader.GetOrdinal("Age")) ? 0 : reader.GetInt32(reader.GetOrdinal("Age")),
                                    Gender = reader.IsDBNull(reader.GetOrdinal("Gender")) ? 0 : reader.GetInt32(reader.GetOrdinal("Gender")),
                                    Religion = reader.IsDBNull(reader.GetOrdinal("Religion")) ? 0 : reader.GetInt32(reader.GetOrdinal("Religion")),
                                    Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                                    MobileNo = reader.IsDBNull(reader.GetOrdinal("MobileNo")) ? null : reader.GetString(reader.GetOrdinal("MobileNo")),
                                    Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? null : reader.GetString(reader.GetOrdinal("Address")),
                                    City = reader.IsDBNull(reader.GetOrdinal("City")) ? null : reader.GetString(reader.GetOrdinal("City")),
                                    District = reader.IsDBNull(reader.GetOrdinal("District")) ? 0 : reader.GetInt32(reader.GetOrdinal("District")),
                                    State = reader.IsDBNull(reader.GetOrdinal("State")) ? 0 : reader.GetInt32(reader.GetOrdinal("State")),
                                    Zip = reader.IsDBNull(reader.GetOrdinal("Zip")) ? null : reader.GetString(reader.GetOrdinal("Zip")),
                                    Country = reader.IsDBNull(reader.GetOrdinal("Country")) ? 0 : reader.GetInt32(reader.GetOrdinal("Country")),
                                    Community = reader.IsDBNull(reader.GetOrdinal("Community")) ? null : reader.GetInt32(reader.GetOrdinal("Community")),
                                    SubCommunity = reader.IsDBNull(reader.GetOrdinal("SubCommunity")) ? null : reader.GetInt32(reader.GetOrdinal("SubCommunity")),
                                    MotherTongue = reader.IsDBNull(reader.GetOrdinal("MotherTongue")) ? null : reader.GetInt32(reader.GetOrdinal("MotherTongue")),
                                    MatritalStatus = reader.IsDBNull(reader.GetOrdinal("MatritalStatus")) ? null : reader.GetInt32(reader.GetOrdinal("MatritalStatus")),
                                    LivingSituation = reader.IsDBNull(reader.GetOrdinal("LivingSituation")) ? null : reader.GetInt32(reader.GetOrdinal("LivingSituation")),
                                    Diet = reader.IsDBNull(reader.GetOrdinal("Diet")) ? null : reader.GetInt32(reader.GetOrdinal("Diet")),
                                    Height = reader.IsDBNull(reader.GetOrdinal("Height")) ? null : reader.GetDecimal(reader.GetOrdinal("Height")),
                                    BodyType = reader.IsDBNull(reader.GetOrdinal("BodyType")) ? null : reader.GetInt32(reader.GetOrdinal("BodyType")),
                                    Complexion = reader.IsDBNull(reader.GetOrdinal("Complexion")) ? null : reader.GetInt32(reader.GetOrdinal("Complexion")),
                                    AlcoholDrinker = reader.IsDBNull(reader.GetOrdinal("AlcoholDrinker")) ? null : reader.GetBoolean(reader.GetOrdinal("AlcoholDrinker")),
                                    Smoker = reader.IsDBNull(reader.GetOrdinal("Smoker")) ? null : reader.GetBoolean(reader.GetOrdinal("Smoker")),
                                    HighestQualification = reader.IsDBNull(reader.GetOrdinal("HighestQualification")) ? null : reader.GetInt32(reader.GetOrdinal("HighestQualification")),
                                    Profession = reader.IsDBNull(reader.GetOrdinal("Profession")) ? null : reader.GetInt32(reader.GetOrdinal("Profession")),
                                    AnnualIncome = reader.IsDBNull(reader.GetOrdinal("AnnualIncome")) ? 0 : reader.GetInt32(reader.GetOrdinal("AnnualIncome")),
                                    FatherName = reader.IsDBNull(reader.GetOrdinal("FatherName")) ? null : reader.GetString(reader.GetOrdinal("FatherName")),
                                    FatherStatus = reader.IsDBNull(reader.GetOrdinal("FatherStatus")) ? null : reader.GetInt32(reader.GetOrdinal("FatherStatus")),
                                    FatherMobileNo = reader.IsDBNull(reader.GetOrdinal("FatherMobileNo")) ? null : reader.GetString(reader.GetOrdinal("FatherMobileNo")),
                                    MotherName = reader.IsDBNull(reader.GetOrdinal("MotherName")) ? null : reader.GetString(reader.GetOrdinal("MotherName")),
                                    MotherStatus = reader.IsDBNull(reader.GetOrdinal("MotherStatus")) ? null : reader.GetInt32(reader.GetOrdinal("MotherStatus")),
                                    MotherMobileNo = reader.IsDBNull(reader.GetOrdinal("MotherMobileNo")) ? null : reader.GetString(reader.GetOrdinal("MotherMobileNo")),
                                    GurdianName = reader.IsDBNull(reader.GetOrdinal("GurdianName")) ? null : reader.GetString(reader.GetOrdinal("GurdianName")),
                                    GurdianMobileNo = reader.IsDBNull(reader.GetOrdinal("GurdianMobileNo")) ? null : reader.GetString(reader.GetOrdinal("GurdianMobileNo")),
                                    NoOfBrothers = reader.IsDBNull(reader.GetOrdinal("NoOfBrothers")) ? 0 : reader.GetInt32(reader.GetOrdinal("NoOfBrothers")),
                                    NoOfMarriedBrothers = reader.IsDBNull(reader.GetOrdinal("NoOfMarriedBrothers")) ? 0 : reader.GetInt32(reader.GetOrdinal("NoOfMarriedBrothers")),
                                    NoOfSisters = reader.IsDBNull(reader.GetOrdinal("NoOfSisters")) ? 0 : reader.GetInt32(reader.GetOrdinal("NoOfSisters")),
                                    NoOfMarriedSisters = reader.IsDBNull(reader.GetOrdinal("NoOfMarriedSisters")) ? 0 : reader.GetInt32(reader.GetOrdinal("NoOfMarriedSisters")),
                                    FamilyType = reader.IsDBNull(reader.GetOrdinal("FamilyType")) ? null : reader.GetInt32(reader.GetOrdinal("FamilyType")),
                                    FamilyReligiousValues = reader.IsDBNull(reader.GetOrdinal("FamilyReligiousValues")) ? null : reader.GetInt32(reader.GetOrdinal("FamilyReligiousValues")),
                                    CreatedOn = reader.IsDBNull(reader.GetOrdinal("CreatedOn")) ? null : reader.GetDateTime(reader.GetOrdinal("CreatedOn")),
                                    UpdatedOn = reader.IsDBNull(reader.GetOrdinal("UpdatedOn")) ? null : reader.GetDateTime(reader.GetOrdinal("UpdatedOn")),
                                    IsActive = reader.IsDBNull(reader.GetOrdinal("IsActive")) ? false : reader.GetBoolean(reader.GetOrdinal("IsActive"))

                                };

                                accountsList.Add(account);
                            }
                        }
                        finally
                        {
                            reader.Close();
                        }
                    }
                }
                finally
                {
                    if (command.Connection != null && command.Connection.State == ConnectionState.Open)
                    {
                        command.Connection.Close(); // Ensure the connection is closed
                    }
                }
            }

            return accountsList;
        }

        public async Task<IEnumerable<ProfileBasic>> GetAllWithFilterAsync(AccountListRequest request, string storedProcedure)
        {
            var accountsList = new List<ProfileBasic>();

            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Filter", request.Filter));
                    command.Parameters.Add(new SqlParameter("@Skip", request.Skip));
                    command.Parameters.Add(new SqlParameter("@Take", request.Take));
                    command.Parameters.Add(new SqlParameter("@AccountId", request.AccountId));

                    using (var reader = await _dbContext.ExecuteReaderAsync(command))
                    {
                        try
                        {
                            while (await reader.ReadAsync())
                            {
                                var account = new ProfileBasic
                                {
                                    Id = reader.IsDBNull(reader.GetOrdinal("Id")) ? 0 : reader.GetInt32(reader.GetOrdinal("Id")),
                                    FullName = reader.IsDBNull(reader.GetOrdinal("FullName")) ? null : reader.GetString(reader.GetOrdinal("FullName")),
                                    Age = reader.IsDBNull(reader.GetOrdinal("Age")) ? null : reader.GetString(reader.GetOrdinal("Age")),
                                    Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                                    MobileNo = reader.IsDBNull(reader.GetOrdinal("MobileNo")) ? null : reader.GetString(reader.GetOrdinal("MobileNo")),
                                    DefaultImage = reader.IsDBNull(reader.GetOrdinal("DefaultImage")) ? null : reader.GetString(reader.GetOrdinal("DefaultImage"))
                                    
                                };

                                accountsList.Add(account);
                            }
                        }
                        finally
                        {
                            reader.Close();
                        }
                    }
                }
                finally
                {
                    if (command.Connection != null && command.Connection.State == ConnectionState.Open)
                    {
                        command.Connection.Close(); // Ensure the connection is closed
                    }
                }
            }

            return accountsList;
        }

        public async Task<Accounts> UpdateAsync(Accounts entity, string storedProcedure)
        {
            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", entity.Id));
                    command.Parameters.Add(new SqlParameter("@FirstName", (object)entity.FirstName ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@MiddleName", (object)entity.MiddleName ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@LastName", (object)entity.LastName ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Age", (object)entity.Age ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Gender", (object)entity.Gender ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Religion", (object)entity.Religion ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Email", (object)entity.Email ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@MobileNo", (object)entity.MobileNo ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Address", (object)entity.Address ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@City", (object)entity.City ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@District", (object)entity.District ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@State", (object)entity.State ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Zip", (object)entity.Zip ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Country", (object)entity.Country ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Community", (object)entity.Community ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@SubCommunity", (object)entity.SubCommunity ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@MotherTongue", (object)entity.MotherTongue ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@MaritalStatus", (object)entity.MatritalStatus ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@LivingSituation", (object)entity.LivingSituation ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Diet", (object)entity.Diet ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Height", (object)entity.Height ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@BodyType", (object)entity.BodyType ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Complexion", (object)entity.Complexion ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@AlcoholDrinker", (object)entity.AlcoholDrinker ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Smoker", (object)entity.Smoker ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@HighestQualification", (object)entity.HighestQualification ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Profession", (object)entity.Profession ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@AnnualIncome", (object)entity.AnnualIncome ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@FatherName", (object)entity.FatherName ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@FatherStatus", (object)entity.FatherStatus ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@FatherMobileNo", (object)entity.FatherMobileNo ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@MotherName", (object)entity.MotherName ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@MotherStatus", (object)entity.MotherStatus ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@MotherMobileNo", (object)entity.MotherMobileNo ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@GurdianName", (object)entity.GurdianName ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@GurdianMobileNo", (object)entity.GurdianName ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@NoOfBrothers", (object)entity.NoOfBrothers ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@NoOfMarriedBrothers", (object)entity.NoOfMarriedBrothers ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@NoOfSisters", (object)entity.NoOfSisters ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@NoOfMarriedSisters", (object)entity.NoOfMarriedSisters ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@FamilyType", (object)entity.FamilyType ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@FamilyReligiousValues", (object)entity.FamilyReligiousValues ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@CreatedOn", (object)entity.CreatedOn ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@UpdatedOn", (object)entity.UpdatedOn ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@IsActive", (object)entity.IsActive ?? DBNull.Value));


                    var result = await _dbContext.ExecuteScalarAsync(command);


                    return entity;
                }
                finally
                {
                    if (command.Connection != null && command.Connection.State == ConnectionState.Open)
                    {
                        command.Connection.Close(); // Ensure the connection is closed
                    }
                }
            }
        }

        public async Task<bool> DeleteAsync(int id, string storedProcedure)
        {
            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", id));

                    var result = await _dbContext.ExecuteNonQueryAsync(command);
                    return result > 0;
                }
                finally
                {
                    if (command.Connection != null && command.Connection.State == ConnectionState.Open)
                    {
                        command.Connection.Close(); // Ensure the connection is closed
                    }
                }
            }
        }

        public async Task<RegistrationRequest> RegisterAsync(RegistrationRequest registrationRequest, string storedProcedure)
        {
            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;

                    // Add parameters
                    if (registrationRequest.Username.Contains("@"))
                        command.Parameters.AddWithValue("@Email", registrationRequest.Username);
                    else
                        command.Parameters.AddWithValue("@MobileNo", registrationRequest.Username);
                    command.Parameters.AddWithValue("@Password", registrationRequest.Password);

                    // Execute the stored procedure and return the result
                    var result = await _dbContext.ExecuteScalarAsync(command);
                    registrationRequest.Id = Convert.ToInt32(result);
                    return registrationRequest;
                }
                finally
                {
                    if (command.Connection != null && command.Connection.State == ConnectionState.Open)
                    {
                        command.Connection.Close(); // Ensure the connection is closed
                    }
                }
            }
        }

        public async Task<SideBarDetails> GetSideBarDetailsById(int id, string storedProcedure)
        {
            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", id));

                    var reader = await _dbContext.ExecuteReaderAsync(command);
                    SideBarDetails dataModel = null;

                    if (reader != null)
                    {
                        try
                        {
                            while (await reader.ReadAsync())
                            {
                                dataModel = new SideBarDetails
                                {
                                    DefaultImage = reader.IsDBNull(reader.GetOrdinal("DefaultImage")) ? null : reader.GetString(reader.GetOrdinal("DefaultImage")),
                                    FullName = reader.IsDBNull(reader.GetOrdinal("FullName")) ? null : reader.GetString(reader.GetOrdinal("FullName")),
                                    MembershipStatus = reader.IsDBNull(reader.GetOrdinal("MembershipStatus")) ? null : reader.GetString(reader.GetOrdinal("MembershipStatus")),
                                    MembershipEndDate = reader.IsDBNull(reader.GetOrdinal("MembershipEndDate")) ? null : reader.GetString(reader.GetOrdinal("MembershipEndDate"))
                                };
                            }
                        }
                        finally
                        {
                            reader.Close();
                        }
                    }

                    return dataModel;
                }
                finally
                {
                    if (command.Connection != null && command.Connection.State == ConnectionState.Open)
                    {
                        command.Connection.Close(); // Ensure the connection is closed
                    }
                }
            }
        }

        public async Task<ProfileDetails> GetProfileDetailsById(int id, string storedProcedure)
        {
            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", id));

                    var reader = await _dbContext.ExecuteReaderAsync(command);
                    ProfileDetails dataModel = null;

                    if (reader != null)
                    {
                        try
                        {
                            while (await reader.ReadAsync())
                            {
                                dataModel = new ProfileDetails
                                {
                                    Id = reader.IsDBNull(reader.GetOrdinal("Id")) ? 0 : reader.GetInt32(reader.GetOrdinal("Id")),
                                    FirstName = reader.IsDBNull(reader.GetOrdinal("FirstName")) ? string.Empty : reader.GetString(reader.GetOrdinal("FirstName")),
                                    MiddleName = reader.IsDBNull(reader.GetOrdinal("MiddleName")) ? string.Empty : reader.GetString(reader.GetOrdinal("MiddleName")),
                                    LastName = reader.IsDBNull(reader.GetOrdinal("LastName")) ? string.Empty : reader.GetString(reader.GetOrdinal("LastName")),
                                    Age = reader.IsDBNull(reader.GetOrdinal("Age")) ? string.Empty : reader.GetString(reader.GetOrdinal("Age")),
                                    Gender = reader.IsDBNull(reader.GetOrdinal("Gender")) ? string.Empty : reader.GetString(reader.GetOrdinal("Gender")),
                                    Religion = reader.IsDBNull(reader.GetOrdinal("Religion")) ? string.Empty : reader.GetString(reader.GetOrdinal("Religion")),
                                    Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? string.Empty : reader.GetString(reader.GetOrdinal("Email")),
                                    MobileNo = reader.IsDBNull(reader.GetOrdinal("MobileNo")) ? string.Empty : reader.GetString(reader.GetOrdinal("MobileNo")),
                                    Address = reader.IsDBNull(reader.GetOrdinal("Address")) ? string.Empty : reader.GetString(reader.GetOrdinal("Address")),
                                    City = reader.IsDBNull(reader.GetOrdinal("City")) ? string.Empty : reader.GetString(reader.GetOrdinal("City")),
                                    District = reader.IsDBNull(reader.GetOrdinal("District")) ? string.Empty : reader.GetString(reader.GetOrdinal("District")),
                                    State = reader.IsDBNull(reader.GetOrdinal("State")) ? string.Empty : reader.GetString(reader.GetOrdinal("State")),
                                    Zip = reader.IsDBNull(reader.GetOrdinal("Zip")) ? string.Empty : reader.GetString(reader.GetOrdinal("Zip")),
                                    Country = "India", // Static value
                                    Community = reader.IsDBNull(reader.GetOrdinal("Community")) ? string.Empty : reader.GetString(reader.GetOrdinal("Community")),
                                    SubCommunity = reader.IsDBNull(reader.GetOrdinal("SubCommunity")) ? string.Empty : reader.GetString(reader.GetOrdinal("SubCommunity")),
                                    MotherTongue = reader.IsDBNull(reader.GetOrdinal("MotherTongue")) ? string.Empty : reader.GetString(reader.GetOrdinal("MotherTongue")),
                                    MatritalStatus = reader.IsDBNull(reader.GetOrdinal("MatritalStatus")) ? string.Empty : reader.GetString(reader.GetOrdinal("MatritalStatus")),
                                    LivingSituation = reader.IsDBNull(reader.GetOrdinal("LivingSituation")) ? string.Empty : reader.GetString(reader.GetOrdinal("LivingSituation")),
                                    Diet = reader.IsDBNull(reader.GetOrdinal("Diet")) ? string.Empty : reader.GetString(reader.GetOrdinal("Diet")),
                                    Height = reader.IsDBNull(reader.GetOrdinal("Height")) ? string.Empty : reader.GetString(reader.GetOrdinal("Height")),
                                    BodyType = reader.IsDBNull(reader.GetOrdinal("BodyType")) ? string.Empty : reader.GetString(reader.GetOrdinal("BodyType")),
                                    Complexion = reader.IsDBNull(reader.GetOrdinal("Complexion")) ? string.Empty : reader.GetString(reader.GetOrdinal("Complexion")),
                                    AlcoholDrinker = reader.IsDBNull(reader.GetOrdinal("AlcoholDrinker")) ? "No" : reader.GetString(reader.GetOrdinal("AlcoholDrinker")),
                                    Smoker = reader.IsDBNull(reader.GetOrdinal("Smoker")) ? "No" : reader.GetString(reader.GetOrdinal("Smoker")),
                                    Bio = reader.IsDBNull(reader.GetOrdinal("Bio")) ? string.Empty : reader.GetString(reader.GetOrdinal("Bio")),
                                    PartnerBio = reader.IsDBNull(reader.GetOrdinal("PartnerBio")) ? string.Empty : reader.GetString(reader.GetOrdinal("PartnerBio")),
                                    HighestQualification = reader.IsDBNull(reader.GetOrdinal("HighestQualification")) ? string.Empty : reader.GetString(reader.GetOrdinal("HighestQualification")),
                                    Profession = reader.IsDBNull(reader.GetOrdinal("Profession")) ? string.Empty : reader.GetString(reader.GetOrdinal("Profession")),
                                    AnnualIncome = reader.IsDBNull(reader.GetOrdinal("AnnualIncome")) ? string.Empty : reader.GetString(reader.GetOrdinal("AnnualIncome")),
                                    FatherName = reader.IsDBNull(reader.GetOrdinal("FatherName")) ? string.Empty : reader.GetString(reader.GetOrdinal("FatherName")),
                                    FatherStatus = reader.IsDBNull(reader.GetOrdinal("FatherStatus")) ? string.Empty : reader.GetString(reader.GetOrdinal("FatherStatus")),
                                    FatherMobileNo = reader.IsDBNull(reader.GetOrdinal("FatherMobileNo")) ? string.Empty : reader.GetString(reader.GetOrdinal("FatherMobileNo")),
                                    MotherName = reader.IsDBNull(reader.GetOrdinal("MotherName")) ? string.Empty : reader.GetString(reader.GetOrdinal("MotherName")),
                                    MotherStatus = reader.IsDBNull(reader.GetOrdinal("MotherStatus")) ? string.Empty : reader.GetString(reader.GetOrdinal("MotherStatus")),
                                    MotherMobileNo = reader.IsDBNull(reader.GetOrdinal("MotherMobileNo")) ? string.Empty : reader.GetString(reader.GetOrdinal("MotherMobileNo")),
                                    GurdianName = reader.IsDBNull(reader.GetOrdinal("GurdianName")) ? string.Empty : reader.GetString(reader.GetOrdinal("GurdianName")),
                                    GurdianMobileNo = reader.IsDBNull(reader.GetOrdinal("GurdianMobileNo")) ? string.Empty : reader.GetString(reader.GetOrdinal("GurdianMobileNo")),
                                    NoOfBrothers = reader.IsDBNull(reader.GetOrdinal("NoOfBrothers")) ? string.Empty : reader.GetString(reader.GetOrdinal("NoOfBrothers")),
                                    NoOfMarriedBrothers = reader.IsDBNull(reader.GetOrdinal("NoOfMarriedBrothers")) ? string.Empty : reader.GetString(reader.GetOrdinal("NoOfMarriedBrothers")),
                                    NoOfSisters = reader.IsDBNull(reader.GetOrdinal("NoOfSisters")) ? string.Empty : reader.GetString(reader.GetOrdinal("NoOfSisters")),
                                    NoOfMarriedSisters = reader.IsDBNull(reader.GetOrdinal("NoOfMarriedSisters")) ? string.Empty : reader.GetString(reader.GetOrdinal("NoOfMarriedSisters")),
                                    FamilyType = reader.IsDBNull(reader.GetOrdinal("FamilyType")) ? string.Empty : reader.GetString(reader.GetOrdinal("FamilyType")),
                                    FamilyReligiousValues = reader.IsDBNull(reader.GetOrdinal("FamilyReligiousValues")) ? string.Empty : reader.GetString(reader.GetOrdinal("FamilyReligiousValues"))

                                };
                            }
                        }
                        finally
                        {
                            reader.Close();
                        }
                    }

                    return dataModel;
                }
                finally
                {
                    if (command.Connection != null && command.Connection.State == ConnectionState.Open)
                    {
                        command.Connection.Close(); // Ensure the connection is closed
                    }
                }
            }
        }

        public async Task<DashboardStats> GetDashboardStatsById(int id, string storedProcedure)
        {
            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", id));

                    var reader = await _dbContext.ExecuteReaderAsync(command);
                    DashboardStats dataModel = null;

                    if (reader != null)
                    {
                        try
                        {
                            while (await reader.ReadAsync())
                            {
                                dataModel = new DashboardStats
                                {
                                    ProfileCompletion = reader.IsDBNull(reader.GetOrdinal("ProfileCompletion")) ? 0 : reader.GetInt32(reader.GetOrdinal("ProfileCompletion")),
                                    TotalReceivedProposal = reader.IsDBNull(reader.GetOrdinal("TotalReceivedProposal")) ? 0 : reader.GetInt32(reader.GetOrdinal("TotalReceivedProposal")),
                                    TotalSentProposal = reader.IsDBNull(reader.GetOrdinal("TotalSentProposal")) ? 0 : reader.GetInt32(reader.GetOrdinal("TotalSentProposal")),
                                    TotalMessages = reader.IsDBNull(reader.GetOrdinal("TotalMessages")) ? 0 : reader.GetInt32(reader.GetOrdinal("TotalMessages"))

                                };
                            }
                        }
                        finally
                        {
                            reader.Close();
                        }
                    }

                    return dataModel;
                }
                finally
                {
                    if (command.Connection != null && command.Connection.State == ConnectionState.Open)
                    {
                        command.Connection.Close(); // Ensure the connection is closed
                    }
                }
            }
        }

        public async Task<PersonalInfo> UpdatePersonalInfoAsync(PersonalInfo entity, string storedProcedure)
        {
            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", entity.Id));
                    command.Parameters.Add(new SqlParameter("@FirstName", (object)entity.FirstName ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@MiddleName", (object)entity.MiddleName ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@LastName", (object)entity.LastName ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Age", (object)entity.Age ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Gender", (object)entity.Gender ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Religion", (object)entity.Religion ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Email", (object)entity.Email ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@MobileNo", (object)entity.MobileNo ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Address", (object)entity.Address ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@City", (object)entity.City ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@District", (object)entity.District ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@State", (object)entity.State ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Zip", (object)entity.Zip ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Country", (object)entity.Country ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Community", (object)entity.Community ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@SubCommunity", (object)entity.SubCommunity ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@MotherTongue", (object)entity.MotherTongue ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@MaritalStatus", (object)entity.MatritalStatus ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@LivingSituation", (object)entity.LivingSituation ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Diet", (object)entity.Diet ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Height", (object)entity.Height ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@BodyType", (object)entity.BodyType ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Complexion", (object)entity.Complexion ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@AlcoholDrinker", (object)entity.AlcoholDrinker ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@Smoker", (object)entity.Smoker ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@UpdatedOn", (object)entity.UpdatedOn ?? DBNull.Value));

                    var result = await _dbContext.ExecuteScalarAsync(command);


                    return entity;
                }
                finally
                {
                    if (command.Connection != null && command.Connection.State == ConnectionState.Open)
                    {
                        command.Connection.Close(); // Ensure the connection is closed
                    }
                }
            }
        }

        public async Task<BioDetails> UpdateBioDetailsAsync(BioDetails entity, string storedProcedure)
        {
            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", entity.Id));
                    command.Parameters.Add(new SqlParameter("@Bio", (object)entity.Bio ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@PartnerBio", (object)entity.PartnerBio ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@UpdatedOn", (object)entity.UpdatedOn ?? DBNull.Value));

                    var result = await _dbContext.ExecuteScalarAsync(command);


                    return entity;
                }
                finally
                {
                    if (command.Connection != null && command.Connection.State == ConnectionState.Open)
                    {
                        command.Connection.Close(); // Ensure the connection is closed
                    }
                }
            }
        }

        public async Task<OccupationAndEducationDetails> UpdateOccupationAndEducationDetailsAsync(OccupationAndEducationDetails entity, string storedProcedure)
        {
            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", entity.Id));
                    command.Parameters.Add(new SqlParameter("@Profession", (object)entity.Profession ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@AnnualIncome", (object)entity.AnnualIncome ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@HighestQualification", (object)entity.HighestQualification ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@PassoutYear", (object)entity.PassoutYear ?? DBNull.Value));
                    command.Parameters.Add(new SqlParameter("@UpdatedOn", (object)entity.UpdatedOn ?? DBNull.Value));

                    var result = await _dbContext.ExecuteScalarAsync(command);


                    return entity;
                }
                finally
                {
                    if (command.Connection != null && command.Connection.State == ConnectionState.Open)
                    {
                        command.Connection.Close(); // Ensure the connection is closed
                    }
                }
            }
        }

        public async Task<FamilyDetails> UpdateFamilyDetailsAsync(FamilyDetails entity, string storedProcedure)
        {
            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.Add(new SqlParameter("@Id", entity.Id));
                    command.Parameters.AddWithValue("@FatherName", (object)entity.FatherName ?? DBNull.Value);
                    command.Parameters.AddWithValue("@FatherStatus", (object)entity.FatherStatus ?? DBNull.Value);
                    command.Parameters.AddWithValue("@FatherMobileNo", (object)entity.FatherMobileNo ?? DBNull.Value);
                    command.Parameters.AddWithValue("@MotherName", (object)entity.MotherName ?? DBNull.Value);
                    command.Parameters.AddWithValue("@MotherStatus", (object)entity.MotherStatus ?? DBNull.Value);
                    command.Parameters.AddWithValue("@MotherMobileNo", (object)entity.MotherMobileNo ?? DBNull.Value);
                    command.Parameters.AddWithValue("@GurdianName", (object)entity.GurdianName ?? DBNull.Value);
                    command.Parameters.AddWithValue("@GurdianMobileNo", (object)entity.GurdianMobileNo ?? DBNull.Value);
                    command.Parameters.AddWithValue("@NoOfBrothers", (object)entity.NoOfBrothers ?? DBNull.Value);
                    command.Parameters.AddWithValue("@NoOfMarriedBrothers", (object)entity.NoOfMarriedBrothers ?? DBNull.Value);
                    command.Parameters.AddWithValue("@NoOfSisters", (object)entity.NoOfSisters ?? DBNull.Value);
                    command.Parameters.AddWithValue("@NoOfMarriedSisters", (object)entity.NoOfMarriedSisters ?? DBNull.Value);
                    command.Parameters.AddWithValue("@FamilyType", (object)entity.FamilyType ?? DBNull.Value);
                    command.Parameters.AddWithValue("@FamilyReligiousValues", (object)entity.FamilyReligiousValues ?? DBNull.Value);
                    command.Parameters.Add(new SqlParameter("@UpdatedOn", (object)entity.UpdatedOn ?? DBNull.Value));

                    var result = await _dbContext.ExecuteScalarAsync(command);


                    return entity;
                }
                finally
                {
                    if (command.Connection != null && command.Connection.State == ConnectionState.Open)
                    {
                        command.Connection.Close(); // Ensure the connection is closed
                    }
                }
            }
        }

        public async Task<Boolean> CheckProfileStepValueById(int id,string step, string storedProcedure)
        {
            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@AccountId", id));
                    command.Parameters.Add(new SqlParameter("@ColumnName", step));

                    var reader = await _dbContext.ExecuteReaderAsync(command);
                    Boolean IsTrue = false;

                    if (reader != null)
                    {
                        try
                        {
                            while (await reader.ReadAsync())
                            {
                                IsTrue = reader.IsDBNull(reader.GetOrdinal("IsTrue")) ? false : reader.GetBoolean(reader.GetOrdinal("IsTrue"));
                            }
                        }
                        finally
                        {
                            reader.Close();
                        }
                    }

                    return IsTrue;
                }
                finally
                {
                    if (command.Connection != null && command.Connection.State == ConnectionState.Open)
                    {
                        command.Connection.Close(); // Ensure the connection is closed
                    }
                }
            }
        }

        public async Task<AccountsViewModel> GetDetailsByIdAsync(int id,int accountId,  string storedProcedure)
        {
            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Id", id));
                    command.Parameters.Add(new SqlParameter("@AccountId", accountId));

                    var reader = await _dbContext.ExecuteReaderAsync(command);
                    AccountsViewModel accountModel = null;

                    if (reader != null)
                    {
                        try
                        {
                            while (await reader.ReadAsync())
                            {
                                accountModel = new AccountsViewModel
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("Id")),
                                    FullName = reader.GetString(reader.GetOrdinal("FullName")),
                                    Age = reader.GetInt32(reader.GetOrdinal("Age")),
                                    Gender = reader.GetString(reader.GetOrdinal("Gender")),
                                    Religion = reader.GetString(reader.GetOrdinal("Religion")),
                                    Email = reader.GetString(reader.GetOrdinal("Email")),
                                    MobileNo = reader.GetString(reader.GetOrdinal("MobileNo")),
                                    Address = reader.GetString(reader.GetOrdinal("Address")),
                                    City = reader.GetString(reader.GetOrdinal("City")),
                                    District = reader.GetString(reader.GetOrdinal("District")),
                                    State = reader.GetString(reader.GetOrdinal("State")),
                                    Zip = reader.GetString(reader.GetOrdinal("Zip")),
                                    Country = reader.GetString(reader.GetOrdinal("Country")),
                                    Community = reader.GetString(reader.GetOrdinal("Community")),
                                    SubCommunity = reader.GetString(reader.GetOrdinal("SubCommunity")),
                                    MotherTongue = reader.GetString(reader.GetOrdinal("MotherTongue")),
                                    MatritalStatus = reader.GetString(reader.GetOrdinal("MaritalStatus")),
                                    LivingSituation = reader.GetString(reader.GetOrdinal("LivingSituation")),
                                    Diet = reader.GetString(reader.GetOrdinal("Diet")),
                                    Height = reader.GetDecimal(reader.GetOrdinal("Height")),
                                    BodyType = reader.GetString(reader.GetOrdinal("BodyType")),
                                    Complexion = reader.GetString(reader.GetOrdinal("Complexion")),
                                    AlcoholDrinker = reader.GetString(reader.GetOrdinal("AlcoholDrinker")),
                                    Smoker = reader.GetString(reader.GetOrdinal("Smoker")),
                                    Bio = reader.IsDBNull(reader.GetOrdinal("Bio")) ? string.Empty : reader.GetString(reader.GetOrdinal("Bio")),
                                    PartnerBio = reader.IsDBNull(reader.GetOrdinal("PartnerBio")) ? string.Empty : reader.GetString(reader.GetOrdinal("PartnerBio")),
                                    HighestQualification = reader.GetString(reader.GetOrdinal("HighestQualification")),
                                    PassoutYear = reader.GetInt32(reader.GetOrdinal("PassoutYear")),
                                    Profession = reader.GetString(reader.GetOrdinal("Profession")),
                                    AnnualIncome = reader.GetString(reader.GetOrdinal("AnnualIncome")),
                                    FatherName = reader.GetString(reader.GetOrdinal("FatherName")),
                                    FatherStatus = reader.GetString(reader.GetOrdinal("FatherStatus")),
                                    FatherMobileNo = reader.GetString(reader.GetOrdinal("FatherMobileNo")),
                                    MotherName = reader.GetString(reader.GetOrdinal("MotherName")),
                                    MotherStatus = reader.GetString(reader.GetOrdinal("MotherStatus")),
                                    MotherMobileNo = reader.GetString(reader.GetOrdinal("MotherMobileNo")),
                                    GurdianName = reader.GetString(reader.GetOrdinal("GurdianName")),
                                    GurdianMobileNo = reader.GetString(reader.GetOrdinal("GurdianMobileNo")),
                                    NoOfBrothers = reader.GetInt32(reader.GetOrdinal("NoOfBrothers")),
                                    NoOfMarriedBrothers = reader.GetInt32(reader.GetOrdinal("NoOfMarriedBrothers")),
                                    NoOfSisters = reader.GetInt32(reader.GetOrdinal("NoOfSisters")),
                                    NoOfMarriedSisters = reader.GetInt32(reader.GetOrdinal("NoOfMarriedSisters")),
                                    FamilyType = reader.GetString(reader.GetOrdinal("FamilyType")),
                                    FamilyReligiousValues = reader.GetString(reader.GetOrdinal("FamilyReligiousValues"))
                                };

                            }
                        }
                        finally
                        {
                            reader.Close();
                        }
                    }

                    return accountModel;
                }
                finally
                {
                    if (command.Connection != null && command.Connection.State == ConnectionState.Open)
                    {
                        command.Connection.Close(); // Ensure the connection is closed
                    }
                }
            }
        }

    }

}
