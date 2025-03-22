namespace MatrimonyAPI.DTO.Request
{
    public class FileUploadRequest
    {
        public IFormFile file { get; set; }
        public int accountId { get; set; }
        public string fileType { get; set; }
    }
}
