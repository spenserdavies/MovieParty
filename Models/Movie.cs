using System.Collections.Generic;

namespace movieparty.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IEnumerable<string> Actors { get; set; }
        public int Runtime { get; set; }
        public string ReleaseDate { get; set; }
        public string Img { get; set; }
    }

    public class GroupMovieViewModel : Movie
    {
        public int GroupMovieId { get; set; }
    }
}