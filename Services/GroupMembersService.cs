using System.Collections.Generic;
using movieparty.Models;
using movieparty.Repositories;

namespace movieparty.Services {
    public class GroupMembersService {

        private readonly GroupMembersRepository _repo;
        public GroupMembersService (GroupMembersRepository repo) {
            _repo = repo;
        }

        internal IEnumerable<GroupMemberViewModel> Get () {
            return _repo.Get ();
        }

        internal GroupMemberViewModel GetById (int Id) {
            GroupMemberViewModel exists = _repo.GetById (Id);
            if (exists == null) { throw new System.Exception ("Invalid GroupMember"); }
            return exists;
        }

        internal DTOGroupMember Create (DTOGroupMember newGroupMember) {
            int id = _repo.Create (newGroupMember);
            newGroupMember.Id = id;
            return newGroupMember;
        }

        internal GroupMemberViewModel Delete (int id) {
            GroupMemberViewModel exists = GetById (id);
            _repo.Delete (id);
            return exists;
        }

        public IEnumerable<GroupMemberViewModel> GetMembersByGroupId (int id) {
            return _repo.GetMembersByGroupId (id);
        }

    }
}