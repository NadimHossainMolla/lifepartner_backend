namespace MatrimonyAPI.Models
{
    // Accounts.cs
    using System;

    public class Accounts
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public int? Gender { get; set; }
        public int? Religion { get; set; }
        public string? Email { get; set; }
        public string? MobileNo { get; set; }
        public string? Password { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public int? District { get; set; }
        public int? State { get; set; }
        public string? Zip { get; set; }
        public int? Country { get; set; }
        public int? Community { get; set; }
        public int? SubCommunity { get; set; }
        public int? MotherTongue { get; set; }
        public int? MatritalStatus { get; set; }
        public int? LivingSituation { get; set; }
        public int? Diet { get; set; }
        public decimal? Height { get; set; }
        public int? BodyType { get; set; }
        public int? Complexion { get; set; }
        public bool? AlcoholDrinker { get; set; }
        public bool? Smoker { get; set; }
        public string? Bio { get; set; }
        public string? PartnerBio { get; set; }
        public int? HighestQualification { get; set; }
        public int? Profession { get; set; }
        public int? AnnualIncome { get; set; }
        public string? FatherName { get; set; }
        public int? FatherStatus { get; set; }
        public string? FatherMobileNo { get; set; }
        public string? MotherName { get; set; }
        public int? MotherStatus { get; set; }
        public string? MotherMobileNo { get; set; }
        public string? GurdianName { get; set; }
        public string? GurdianMobileNo { get; set; }
        public int? NoOfBrothers { get; set; }
        public int? NoOfMarriedBrothers { get; set; }
        public int? NoOfSisters { get; set; }
        public int? NoOfMarriedSisters { get; set; }
        public int? FamilyType { get; set; }
        public int? FamilyReligiousValues { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool? IsActive { get; set; }
    }

    public class PersonalInfo
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string LastName { get; set; }
        public int? Age { get; set; }
        public int? Gender { get; set; }
        public int? Religion { get; set; }
        public string? Email { get; set; }
        public string? MobileNo { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public int? District { get; set; }
        public int? State { get; set; }
        public string? Zip { get; set; }
        public int? Country { get; set; }
        public int? Community { get; set; }
        public int? SubCommunity { get; set; }
        public int? MotherTongue { get; set; }
        public int? MatritalStatus { get; set; }
        public int? LivingSituation { get; set; }
        public int? Diet { get; set; }
        public decimal? Height { get; set; }
        public int? BodyType { get; set; }
        public int? Complexion { get; set; }
        public bool? AlcoholDrinker { get; set; }
        public bool? Smoker { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }

    public class BioDetails
    {
        public int Id { get; set; }
        public string Bio { get; set; }
        public string PartnerBio { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }

    public class OccupationAndEducationDetails
    {
        public int Id { get; set; }
        public int? HighestQualification { get; set; }
        public int? PassoutYear { get; set; }
        public int? Profession { get; set; }
        public int? AnnualIncome { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }

    public class FamilyDetails
    {
        public int Id { get; set; }
        public string? FatherName { get; set; }
        public int? FatherStatus { get; set; }
        public string? FatherMobileNo { get; set; }
        public string? MotherName { get; set; }
        public int? MotherStatus { get; set; }
        public string? MotherMobileNo { get; set; }
        public string? GurdianName { get; set; }
        public string? GurdianMobileNo { get; set; }
        public int? NoOfBrothers { get; set; }
        public int? NoOfMarriedBrothers { get; set; }
        public int? NoOfSisters { get; set; }
        public int? NoOfMarriedSisters { get; set; }
        public int? FamilyType { get; set; }
        public int? FamilyReligiousValues { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }

    public class AccountsViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int? Age { get; set; }
        public string Gender { get; set; }
        public string Religion { get; set; }
        public string? Email { get; set; }
        public string? MobileNo { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string? Zip { get; set; }
        public string Country { get; set; }
        public string Community { get; set; }
        public string SubCommunity { get; set; }
        public string MotherTongue { get; set; }
        public string MatritalStatus { get; set; }
        public string LivingSituation { get; set; }
        public string Diet { get; set; }
        public decimal? Height { get; set; }
        public string BodyType { get; set; }
        public string Complexion { get; set; }
        public string AlcoholDrinker { get; set; }
        public string Smoker { get; set; }
        public string Bio { get; set; }
        public string PartnerBio { get; set; }
        public string HighestQualification { get; set; }
        public int? PassoutYear { get; set; }
        public string Profession { get; set; }
        public string AnnualIncome { get; set; }
        public string? FatherName { get; set; }
        public string FatherStatus { get; set; }
        public string? FatherMobileNo { get; set; }
        public string? MotherName { get; set; }
        public string MotherStatus { get; set; }
        public string? MotherMobileNo { get; set; }
        public string? GurdianName { get; set; }
        public string? GurdianMobileNo { get; set; }
        public int? NoOfBrothers { get; set; }
        public int? NoOfMarriedBrothers { get; set; }
        public int? NoOfSisters { get; set; }
        public int? NoOfMarriedSisters { get; set; }
        public string? FamilyType { get; set; }
        public string? FamilyReligiousValues { get; set; }
    }


}
