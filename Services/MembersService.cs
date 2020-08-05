using System;
using System.Collections.Generic;
using movieparty.Models;
using movieparty.Repositories;

namespace movieparty.Services
{
    public class MembersService
    {
        private readonly MembersRepository _repo;
        public MembersService(MembersRepository repo)
        {
            _repo = repo;
        }

        public IEnumerable<Member> GetAll()
        {
            return _repo.GetAll();
        }

        public Member GetById(int id)
        {
            Member foundMember = _repo.GetById(id);
            if (foundMember == null)
            {
                throw new Exception("Invalid id");
            }
            return foundMember;
        }

        internal Member Create(Member newMember)
        {
            return _repo.Create(newMember);
        }

        internal Member Edit(Member memberToUpdate, string userId)
        {
            Member foundMember = GetById(memberToUpdate.Id);
            if (foundMember.UserId == userId && _repo.Edit(memberToUpdate, userId))
            {
                return memberToUpdate;
            }
            throw new Exception("You Can't edit that member. It isnt you.");
        }

        internal string Delete(int id, string userId)
        {
            Member foundMember = GetById(id);
            if (foundMember.UserId != userId)
            {
                throw new Exception("This isn't you.");
            }
            if (_repo.Delete(id, userId))
            {
                return "Successfully Deleted.";
            }
            throw new Exception("Something didn't work.");
        }
    }
}