using System.Collections.Generic;
using System.Data;
using Dapper;
using movieparty.Models;

namespace movieparty.Repositories
{
    public class MembersRepository
    {
        private readonly IDbConnection _db;
        public MembersRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Member> GetAll()
        {
            string sql = "SELECT * FROM members;";
            return _db.Query<Member>(sql);
        }

        internal Member GetById(int id)
        {
            string sql = "SELECT * FROM members WHERE id = @id;";
            return _db.QueryFirstOrDefault<Member>(sql, new { id });
        }
        
        internal Member Create(Member newMember)
        {
            string sql = @"
            INSERT INTO members 
            (userId, img)
            VALUES
            (@UserId, @Img);
            SELECT LAST_INSERT_ID();";
            newMember.Id = _db.ExecuteScalar<int>(sql, newMember);
            return newMember;
        }

        internal bool Edit(Member memberToUpdate, string userId)
        {
            memberToUpdate.UserId = userId;
            string sql = @"
            UPDATE members
            SET
            img = @Img,
            username = @UserName
            WHERE id = @Id
            AND userId = @UserId";
            int affectedRows = _db.Execute(sql, memberToUpdate);
            return affectedRows == 1;
        }

        internal bool Delete(int id, string userId)
        {
            string sql="DELETE FROM members WHERE id = @id AND userId = @UserId LIMIT 1";
            int affectedRows = _db.Execute(sql, new {id, userId });
            return affectedRows == 1;
        }

    }
}