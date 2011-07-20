using System;
using System.Collections.Generic;

namespace Mod03_ChelasMovies.DomainModel.Services
{
    public interface ICommentsService : IService<Comment>
    {
        ICollection<Comment> GetAllComments(int movieId);
    }
}