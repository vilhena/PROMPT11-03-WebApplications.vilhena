using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mod03_ChelasMovies.DomainModel.Services;
using Mod03_ChelasMovies.DomainModel.ServicesRepositoryInterfaces;
using Mod03_ChelasMovies.DomainModel.Domain;

namespace Mod03_ChelasMovies.DomainModel.ServicesImpl
{
    public class RepositoryCommentsService: RepositoryService<Comment>, ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;
        private readonly IGroupService _groupService;

        public RepositoryCommentsService(ICommentsRepository commentsRepository, IGroupService groupService):
            base(commentsRepository)
        {
            _commentsRepository = commentsRepository;
            _groupService = groupService;
        }

        public ICollection<Comment> GetAllComments(int movieId)
        {
            return _commentsRepository.GetAll().Where(c => c.Movie.ID == movieId).ToList();
        }


        public ICollection<Comment> GetForWall(string username, int pageIndex, int pageSize)
        {
            var groups = _groupService.GetAllMyGroups(username);
            var allFriends = groups.SelectMany(g => g.Users);

            return _commentsRepository.GetAll()
                .Where(c => c.Owner.Username == username
                        )
                .OrderByDescending(c => c.LastUpdated)
                .Take(pageSize).Skip(pageIndex).ToList();
        }
    }
}
