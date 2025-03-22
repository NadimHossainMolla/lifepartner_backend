namespace MatrimonyAPI.DTO.Request
{
    public class ProposalRequest
    {
        public int SendTo { get; set; }
        public int SendBy { get; set; }
        //public int ProposalStatusId { get; set; } = 1; //1=Pending,2=ViewEd,3=Approved,4=Rejected
    }
}
