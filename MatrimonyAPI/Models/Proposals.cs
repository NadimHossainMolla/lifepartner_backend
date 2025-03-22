namespace MatrimonyAPI.Models
{
    public class Proposals
    {
        public int Id { get; set; }
        public int SentTo { get; set; }
        public int SentBy { get; set; }
        public int ProposalStatusId { get; set; }
    }
}
