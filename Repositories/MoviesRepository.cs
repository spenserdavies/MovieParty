using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using movieparty.Models;
namespace movieparty.Repositories
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
            string sql = "SELECT * FROM movies WHERE id = @id";
            return _db.QueryFirstOrDefault<Movie>(sql, new { id });
        }

        public Movie GetMoviesByUserId(string userId)
        {
            throw new NotImplementedException();
            string sql = "SELECT * FROM movies WHERE userId = @userId";
            return (Movie)_db.Query<Movie>(sql, new { userId });
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