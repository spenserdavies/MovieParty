using System.Collections.Generic;
using System.Data;
using Dapper;
using movieparty.Models;

namespace movieparty.Repositories
{
    public class GroupMembersRepository
    {
        private readonly IDbConnection _db;
        public GroupMembersRepository(IDbConnection db)
        {
            _db = db;
        }

        internal GroupMemberViewModel GetById(int Id)
        {
           string sql = "SELECT * FROM groupmembers WHERE id = @Id;";
           return _db.QueryFirstOrDefault<GroupMemberViewModel>(sql, new { Id }); 
        }

        internal IEnumerable<GroupMemberViewModel> GetAll()
        {
            string sql="SELECT * FROM groupmembers;";
            return _db.Query<GroupMemberViewModel>(sql);
        }


//NOTE IS THIS RIGHT?
        internal int Create(DTOGroupMember newDTOGroupMember)
        {
            string sql = @"
            INSERT INTO groupmembers
            (groupId, memberId)
            VALUES
            (@GroupId, @MemberId);
            SELECT LAST_INSERT_ID()";
            return _db.ExecuteScalar<int>(sql, newDTOGroupMember);
        }

        internal bool Delete(int Id)
        {
            string sql = "DELETE FROM groupmembers WHERE id = @Id AND userID = @UserId LIMIT 1;";
            int affectedRows = _db.Execute(sql, new { Id });
            return affectedRows == 1;
        }

        internal IEnumerable<GroupMemberViewModel> GetMembersByGroupId(int groupId)
        {
            string sql = @"
            SELECT 
            m.*,
            gm.id as groupMemberId
            FROM groupmembers gm
            INNER JOIN members m ON m.id = gm.memberId
            WHERE (groupId = @groupId);";
            return _db.Query<GroupMemberViewModel>(sql, new {groupId});
        }




    }
}