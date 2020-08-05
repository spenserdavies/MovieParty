using System;
using System.Collections.Generic;
using movieparty.Models;
using movieparty.Repositories;
using movieparty.Models;

namespace movieparty.Services
{
    public class GroupMovieService
    {
        private readonly GroupMovieRepository _repo;
        public GroupMovieService(GroupMovieRepository repo)
        {
            _repo = repo;
        }
        public DTOGroupMovie GetById(int id)
        {
            DTOGroupMovie exists = _repo.GetById(id);
            if (exists == null)
            {
                throw new Exception("Invalid Group Movie");
            }
            return exists;
        }
        public IEnumerable<GroupMovieViewModel> GetMoviesByGroupId(int movieId, int groupId)
        {
            return _repo.GetMoviesByGroupId(movieId, groupId);
        }

        internal IEnumerable<GroupMovieViewModel> Get(int groupId)
        {
            return _repo.GetByGroupId(groupId);
        }


        public DTOGroupMovie Create(DTOGroupMovie newDTOGroupMovie)
        {
            return _repo.Create(newDTOGroupMovie);
        }

        public DTOGroupMovie Delete(string userId, int id)
        {
            DTOGroupMovie exists = GetById(id);
            _repo.Delete(id, userId);
            return exists;
        }
    }
}