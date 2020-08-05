using System;
using System.Collections.Generic;
using movieparty.Models;
using MovieParty.Repositories;

namespace MovieParty.Services
{
    public class MoviesService
    {
        private readonly MoviesRepository _repo;
        public MoviesService(MoviesRepository repo)
        {
            _repo = repo;
        }
        public IEnumerable<Movie> Get()
        {
            return _repo.Get();
        }

        public Movie GetById(int id)
        {
            Movie foundMovie = _repo.GetById(id);
            if (foundMovie == null)
            {
                throw new Exception("Invalid Id Muchacha");
            }
            return foundMovie;
        }

        public Movie GetByUserId(string userId)
        {
            return _repo.GetMoviesByUserId(userId);
        }

        internal object Create(Movie newMovie)
        {
            return _repo.Create(newMovie);
        }
    }
}