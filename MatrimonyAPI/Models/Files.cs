namespace MatrimonyAPI.Models
{
    
    public class Files
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string FileType { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public DateTime UploadedOn { get; set; }
        public bool IsPrimary { get; set; }
        public bool? IsVerified { get; set; }
        public DateTime? VerifiedOn { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
    }
}
