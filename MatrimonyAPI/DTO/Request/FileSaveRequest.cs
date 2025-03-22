namespace MatrimonyAPI.DTO.Request
{
    public class FileSaveRequest
    {
        public int Id { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public string FilePath { get; set; }
        public int AccountId { get; set; }
        public DateTime UploadedOn { get; set; }
        public bool IsPrimary { get; set; }

    }
}
