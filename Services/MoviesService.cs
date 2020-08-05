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

        }

        public Movie GetByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public Movie Edit(Movie editMovie, string userId)
        {
            throw new NotImplementedException();
        }

        public Movie Delete(int id, string userId)
        {
            throw new NotImplementedException();
        }
    }
}