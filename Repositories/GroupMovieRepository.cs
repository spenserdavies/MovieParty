using System;
using System.Data;
using movieparty.Models;
using Dapper;
using System.Collections.Generic;
using movieparty.Models;


namespace movieparty.Repositories
{
    public class GroupMovieRepository
    {
        public readonly IDbConnection _db;
        public GroupMovieRepository(IDbConnection db)
        {
            _db = db;
        }
        internal DTOGroupMovie Get(int id)
        {
            string sql = "SELECT * FROM groupmovies WHERE id = @Id";
            return (DTOGroupMovie)_db.Query<DTOGroupMovie>(sql);
        }

        internal DTOGroupMovie GetById(int groupId)
        {
            string sql = "SELECT * FROM groupmovies WHERE groupId = @GroupId";
            return _db.QueryFirstOrDefault<DTOGroupMovie>(sql, new { id });
        }
        internal IEnumerable<GroupMovieViewModel> GetMoviesByGroupId(int groupId, string movieId)
        {
            string sql = @"SELECT 
            g.*,
            gm.id as groupMovieId
            FROM moviegroups gm
            INNER JOIN movies m ON m.id = mg.groupId 
            WHERE (groupId = @groupId)";
            return _db.Query<GroupMovieViewModel>(sql, new { groupId, movieId });
        }


        internal void Delete(int id)
        {
            string sql = "DELETE FROM moviegroups where id = @id";
            _db.Execute(sql, new { id });
        }

        internal DTOGroupMovie Create(DTOGroupMovie newGroupMovie)
        {
            string sql = @"
            INSERT INTO moviegroups
            (groupId, movieId, userId, votes)
            VALUES
            (@GroupId, @MovieId, @UserId, @Votes);
            SELECT LAST_INSERT_ID();";
            newGroupMovie.Id = _db.ExecuteScalar<int>(sql, newGroupMovie);
            return newGroupMovie;
        }

    }
}