namespace MatrimonyAPI.DTO.Request
{
    public class AccountListRequest
    {
        public string Filter { get; set; }
        public int Skip { get; set; }
        public int Take { get; set; }
        public int AccountId { get; set; }
    }
}
