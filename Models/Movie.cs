namespace MovieParty.Models
{
    public class Movie
    {
       public int Id { get; set; }
       public string Title { get; set; }  
       public string Img { get; set; }
    }

    public class GroupMovieViewModel : Movie
    {
    public int GroupMovieId { get; set; }
    }
}