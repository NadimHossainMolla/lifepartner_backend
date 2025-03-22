namespace MatrimonyAPI.Models.ViewModels
{
    public class ProfileDetails
    {
        // Basic Details
        public int Id { get; set; } 
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Age { get; set; } = string.Empty;

        // Lookup-based Fields
        public string Gender { get; set; } = string.Empty;
        public string Religion { get; set; } = string.Empty;
        public string Community { get; set; } = string.Empty;
        public string SubCommunity { get; set; } = string.Empty;
        public string MotherTongue { get; set; } = string.Empty;
        public string MatritalStatus { get; set; } = string.Empty;
        public string LivingSituation { get; set; } = string.Empty;
        public string Diet { get; set; } = string.Empty;
        public string BodyType { get; set; } = string.Empty;
        public string Complexion { get; set; } = string.Empty;

        // Contact Information
        public string Email { get; set; } = string.Empty;
        public string MobileNo { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;
        public string Country { get; set; } = "India"; // Static value

        // Physical Attributes
        public string Height { get; set; } = string.Empty;

        // Boolean Flags
        public string AlcoholDrinker { get; set; } = "No"; // Default to "No"
        public string Smoker { get; set; } = "No"; // Default to "No"

        // Personal Information
        public string Bio { get; set; } = string.Empty;
        public string PartnerBio { get; set; } = string.Empty;

        // Educational and Professional Details
        public string HighestQualification { get; set; } = string.Empty;
        public string Profession { get; set; } = string.Empty;
        public string AnnualIncome { get; set; } = string.Empty;

        // Family Details
        public string FatherName { get; set; } = string.Empty;
        public string FatherStatus { get; set; } = string.Empty;
        public string FatherMobileNo { get; set; } = string.Empty;
        public string MotherName { get; set; } = string.Empty;
        public string MotherStatus { get; set; } = string.Empty;
        public string MotherMobileNo { get; set; } = string.Empty;
        public string GurdianName { get; set; } = string.Empty;
        public string GurdianMobileNo { get; set; } = string.Empty;

        // Siblings Details
        public string NoOfBrothers { get; set; } = string.Empty;
        public string NoOfMarriedBrothers { get; set; } = string.Empty;
        public string NoOfSisters { get; set; } = string.Empty;
        public string NoOfMarriedSisters { get; set; } = string.Empty;

        // Family Details
        public string FamilyType { get; set; } = string.Empty;
        public string FamilyReligiousValues { get; set; } = string.Empty;
    }

}
