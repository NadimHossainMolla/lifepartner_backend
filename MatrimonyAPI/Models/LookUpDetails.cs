namespace MatrimonyAPI.Models
{
    public class LookUpDetails
    {
        public int Id { get; set; }
        public int LookUpMasterId { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string? DisplayName { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
    }
}
