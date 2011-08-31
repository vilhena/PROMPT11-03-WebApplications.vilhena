using System;
using System.Collections.Generic;
using Mod03_ChelasMovies.DomainModel.Domain;

namespace Mod03_ChelasMovies.DomainModel.Services
{
    public interface ICommentsService : IService<Comment>
    {
        ICollection<Comment> GetAllComments(int movieId);

        ICollection<Comment> GetForWall(string username, int pageIndex, int pageSize);
    }
}