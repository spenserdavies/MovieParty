namespace movieparty.Models
{
    public class DTOGroupMember
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int MemberId { get; set; }
        public string UserId { get; set; }
        public string Status { get; set; }
        public bool HasVoted { get; set; }
    }
}