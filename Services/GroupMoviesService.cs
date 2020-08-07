using System;
using System.Collections.Generic;
using movieparty.Models;
using movieparty.Repositories;

namespace movieparty.Services
{
    public class GroupMoviesService
    {
        private readonly GroupMovieRepository _repo;
        public GroupMoviesService(GroupMovieRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<GroupMovieViewModel> GetAll()
        {
            return _repo.GetAll();
        }
        internal IEnumerable<GroupMovieViewModel> Get()
        {
            return _repo.Get();
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
        public IEnumerable<GroupMovieViewModel> GetMoviesByGroupId(int groupId)
        {
            return _repo.GetMoviesByGroupId(groupId);
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

        public DTOGroupMovie Edit(DTOGroupMovie editDTOGroupMovie)
        {
            DTOGroupMovie foundGroupMovie = GetById(editDTOGroupMovie.Id);
            if (foundGroupMovie.Votes < editDTOGroupMovie.Votes)
            {
                if (_repo.voteMovieGroup(editDTOGroupMovie))
                {
                    foundGroupMovie.Votes = editDTOGroupMovie.Votes;
                }
                throw new Exception("You can't view that GroupMovie");
            }
            return foundGroupMovie;
        }
    }
}