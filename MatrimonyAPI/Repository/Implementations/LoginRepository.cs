using MatrimonyAPI.DTO.Request;
using MatrimonyAPI.Models;
using MatrimonyAPI.Repository.Interfaces;

using Microsoft.Data.SqlClient;

using System.Data;
using System.Reflection.PortableExecutable;

namespace MatrimonyAPI.Repository.Implementations
{
    public class LoginRepository : ILoginRepository
    {
        private readonly DbContext _dbContext;

        public LoginRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Accounts> LoginAsync(LoginRequest loginRequest, string storedProcedure)
        {
            using (var command = _dbContext.CreateCommand())
            {
                try
                {
                    command.CommandText = storedProcedure;
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add(new SqlParameter("@Username", loginRequest.Username));

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
                                    Password = reader.IsDBNull(reader.GetOrdinal("Password")) ? null : reader.GetString(reader.GetOrdinal("Password")),
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
