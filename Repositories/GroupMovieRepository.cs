using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
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
        internal IEnumerable<GroupMovieViewModel> GetAll()
        {
            string sql = "SELECT * FROM groupmovies;";
            return _db.Query<GroupMovieViewModel>(sql);
        }
        // internal DTOGroupMovie Get(int id)
        // {
        //     string sql = "SELECT * FROM groupmovies WHERE id = @Id";
        //     return (DTOGroupMovie)_db.Query<DTOGroupMovie>(sql);
        // }

        internal IEnumerable<GroupMovieViewModel> Get()
        {
            throw new NotImplementedException();
        }

        internal DTOGroupMovie GetById(int id)
        {
            string sql = "SELECT * FROM groupmovies WHERE id = @Id";
            return _db.QueryFirstOrDefault<DTOGroupMovie>(sql, new { id });
        }
        internal IEnumerable<GroupMovieViewModel> GetMoviesByGroupId(int groupId)
        {
            string sql = @"SELECT 
            g.*,
            gm.id as groupMovieId
            FROM moviegroups gm
            INNER JOIN movies m ON m.id = mg.groupId 
            WHERE (groupId = @groupId)";
            return _db.Query<GroupMovieViewModel>(sql, new { groupId });
        }


        public bool voteMovieGroup(DTOGroupMovie moviegroupToVote)
        {
            string sql = @"
            UPDATE moviegroup
            SET
            votes = @Votes
            WHERE id = @Id";
            int affectedRows = _db.Execute(sql, moviegroupToVote);
            return affectedRows == 1;
        }

        internal bool Edit(DTOGroupMovie editGroupMovie, string userId)
        {
            string sql = @"
            UPDATE groupmovie
            SET
            groupId = @GroupId,
            movieId = @MovieId,
            userId = @UserId,
            votes = @Votes,
            WHERE id = @Id
            ";
            int affectedRows = _db.Execute(sql, editGroupMovie);
            return affectedRows == 1;
        }

        internal void Delete(int id, string userId)
        {
            string sql = "DELETE FROM groupmovies where id = @id";
            _db.Execute(sql, new { id });
        }

        internal DTOGroupMovie Create(DTOGroupMovie newGroupMovie)
        {
            string sql = @"
            INSERT INTO groupmovies
            (groupId, movieId, userId, votes)
            VALUES
            (@GroupId, @MovieId, @UserId, @Votes);
            SELECT LAST_INSERT_ID();";
            newGroupMovie.Id = _db.ExecuteScalar<int>(sql, newGroupMovie);
            return newGroupMovie;
        }

    }
}