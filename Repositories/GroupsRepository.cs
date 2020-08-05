using System.Collections.Generic;
using System.Data;
using Dapper;
using movieparty.Models;

namespace movieparty.Repositories
{
    public class GroupsRepository
    {
        private readonly IDbConnection _db;
        public GroupsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Group> Get()
        {
            string sql = "SELECT * FROM groups;";
            return _db.Query<Group>(sql);
        }

        //NOTE GetGroupsByUserId?????????

        internal Group GetById(int groupId)
        {
            string sql = "SELECT * FROM groups WHERE id = @groupId;";
            return _db.QueryFirstOrDefault<Group>(sql, new { groupId });
        }

        internal Group Create(Group newGroup)
        {
            string sql = @"
            INSERT INTO groups
            (name, description, userId)
            VALUES
            (@Name, @Description, @UserId);
            SELECT LAST_INSERT_ID()";
            newGroup.Id = _db.ExecuteScalar<int>(sql, newGroup);
            return newGroup;
        }

        internal bool Edit(Group groupToUpdate, string userId)
        {
            groupToUpdate.UserId = userId;
            string sql = @"
            UPDATE groups
            SET
             description = @Description,
             name = @Name
            WHERE id = @Id
            AND userId = @UserId";
            int affectedRows = _db.Execute(sql, groupToUpdate);
            return affectedRows == 1;
        }

        internal bool Delete(int id, string userId)
        {
            string sql = "DELETE FROM groups WHERE id = @id AND userId = @userId LIMIT 1";
            int affectedRows = _db.Execute(sql, new { id, userId });
            return affectedRows == 1;
        }
    }
}