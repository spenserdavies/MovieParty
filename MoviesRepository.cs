using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using movieparty.Models;

namespace MovieParty.Repositories
{
    public class MoviesRepository
    {
        private readonly IDbConnection _db;
        public MoviesRepository(IDbConnection db)
        {
            _db = db;
        }
        public IEnumerable<Movie> Get()
        {
            string sql = "SELECT * FROM Movies;";
            return _db.Query<Movie>(sql);
        }

        public Movie GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Movie GetMoviesByUserId(string userId)
        {
            throw new NotImplementedException();
        }

        public object Create(Movie newMovie)
        {
            string sql = @"
            INSERT INTO movies
            (title)
            VALUE
            (@Title);
            SELECT LAST_INSERT_ID()";
            newMovie.Id = _db.ExecuteScalar<int>(sql, newMovie);
            return newMovie;
        }
    }
}