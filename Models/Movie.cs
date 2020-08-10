namespace movieparty.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ActorOne { get; set; }
        public string ActorTwo { get; set; }
        public string ActorThree { get; set; }
        public string Runtime { get; set; }
        public string ReleaseDate { get; set; }
        public string Img { get; set; }
    }

    public class GroupMovieViewModel : Movie
    {
        public int GroupMovieId { get; set; }
    }
}