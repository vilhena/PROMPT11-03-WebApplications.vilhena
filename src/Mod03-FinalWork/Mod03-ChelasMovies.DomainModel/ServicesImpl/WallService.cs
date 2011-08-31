using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Mod03_ChelasMovies.DomainModel.Domain;
using Mod03_ChelasMovies.DomainModel.ServicesRepositoryInterfaces;
using Mod03_ChelasMovies.DomainModel.Services;
using Mod03_ChelasMovies.DomainModel.Views;

namespace Mod03_ChelasMovies.DomainModel.ServicesImpl
{
    public class WallService: IWallService
    {
        private readonly ICommentsService _commentsService;
        private readonly IMoviesService _moviesService;
        private const int pageSize = 15;
        private const int pageIndex = 0;

        public WallService(IMoviesService moviesService, ICommentsService commentsService)
        {
            _commentsService = commentsService;
            _moviesService = moviesService;
        }

        public ICollection<WallItem> GetMyWall(string username)
        {
            var list = new List<WallItem>();


            list = _moviesService.GetForWall(username, pageIndex, pageSize)
                .Select(m => new WallItem()
                            {
                                UserNickname = m.Owner.NickName,
                                Updated = m.LastUpdated,
                                EntityChanged = m,
                            }).ToList();

            list.AddRange(
                                _commentsService.GetForWall(username, pageIndex, pageSize)
                                    .Select(c => new WallItem()
                                    {
                                        UserNickname = c.Owner.NickName,
                                        Updated = c.LastUpdated,
                                        EntityChanged = c
                                    }).ToArray()
                            );

            return list.OrderByDescending(w=>w.Updated).ToList();
        }
    }
}
