namespace movieparty.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }    
        public string Img { get; set; }
    }

    public class GroupMemberViewModel : Member
    {
        public int GroupMemberId { get; set; }
    }
}