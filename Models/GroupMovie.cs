namespace movieparty.Models
{
    public class DTOGroupMovie
    {
        public int Id { get; set; }
        public int GroupId { get; set; }    
        public int MovieId { get; set; }
        public string UserId { get; set; }
    }
}