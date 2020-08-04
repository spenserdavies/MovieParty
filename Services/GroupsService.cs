using System;
using System.Collections.Generic;
using movieparty.Models;
using movieparty.Repositories;

namespace movieparty.Services
{
    public class GroupsService
    {
        private readonly GroupsRepository _repo;
        public GroupsService(GroupsRepository repo)
        {
            _repo = repo;
        }
        

        internal IEnumerable<Group> GetAll()
        {
            return _repo.Get();
        }

        internal Group GetById(int groupId)
        {
            Group foundGroup = _repo.GetById(groupId);
            if (foundGroup == null)
            {
                throw new System.Exception("Bad Id Sport");
            }
            return foundGroup;
        }

        internal Group Create(Group newGroup)
        {
            return _repo.Create(newGroup);
        }

        internal Group Edit(Group editGroup, string userId)
        {
            
            Group original = GetById(editGroup.Id);
             original.Name = editGroup.Name == null ? original.Name : editGroup.Name;
      original.Description = editGroup.Description == null ? original.Description : editGroup.Description;
        if (original.UserId == userId && _repo.Edit(original, userId))
        {
        return original;
        }
        throw new Exception("Das not urs");
        }

        internal string Delete(int id, string userId)
        {
            Group foundGroup = GetById(id);
            if (foundGroup.UserId != userId)
            {
                throw new Exception("You cant delete things that dont belong to you. :c ");
            }
            if (_repo.Delete(id, userId))
            {
                return "AHHHH YEAHHHH. Deleted. c:";
            }
            throw new Exception("Somethin' strange in the neighborhood.");
        }
    }   
}