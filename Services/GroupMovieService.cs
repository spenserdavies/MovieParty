using System;
using System.Collections.Generic;
using movieparty.Models;
using movieparty.Repositories;

namespace movieparty.Services {
    public class GroupMovieService {
        private readonly GroupMovieRepository _repo;
        public GroupMovieService (GroupMovieRepository repo) {
            _repo = repo;
        }
        public DTOGroupMovie GetById (int id) {
            DTOGroupMovie exists = _repo.GetById (id);
            if (exists == null) {
                throw new Exception ("Invalid Group Movie");
            }
            return exists;
        }
        public IEnumerable<GroupMovieViewModel> GetMoviesByGroupId (int movieId, string groupId) {
            return _repo.GetMoviesByGroupId (movieId, groupId);
        }

        internal object Get () {
            throw new NotImplementedException ();
        }

        internal IEnumerable<GroupMovieViewModel> Get (int groupId) {
            return _repo.GetByGroupId (groupId);
        }

        public DTOGroupMovie Create (DTOGroupMovie newDTOGroupMovie) {
            return _repo.Create (newDTOGroupMovie);
        }

        public DTOGroupMovie Delete (string userId, int id) {
            DTOGroupMovie exists = GetById (id);
            _repo.Delete (id, userId);
            return exists;
        }

        public DTOGroupMovie Edit (DTOGroupMovie editDTOGroupMovie) {
            DTOGroupMovie foundGroupMovie = GetById (editDTOGroupMovie.Id);
            if (foundGroupMovie.Votes < editDTOGroupMovie.Votes) {
                if (_repo.voteGroupMovie (editDTOGroupMovie)) {
                    foundGroupMovie.Votes = editDTOGroupMovie.Votes;
                }
                throw new Exception ("You can't view that GroupMovie");
            }
            return foundGroupMovie;
        }
    }
}