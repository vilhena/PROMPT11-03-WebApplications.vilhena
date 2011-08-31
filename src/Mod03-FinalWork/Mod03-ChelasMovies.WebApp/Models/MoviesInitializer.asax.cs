using System.Linq;
using Mod03_ChelasMovies.DomainModel.ServicesImpl;

namespace Mod03_ChelasMovies.WebApp.Models {
    
    using System.Data.Entity;
    
    using DomainModel;
    using Mod03_ChelasMovies.DomainModel.ServicesRepositoryImpl;
    using System.Web.Security;


    public class MoviesInitializer : 
        DropCreateDatabaseAlways<MovieDbContext>
        //DropCreateDatabaseIfModelChanges<MovieDbContext>
    {
        protected override void Seed(MovieDbContext context)
        {

            foreach (MembershipUser user in Membership.GetAllUsers())
            {
                Membership.DeleteUser(user.UserName, true);
            }

            var groups = new InMemoryGroupsService().GetAll().ToList();
            var acls = new InMemoryACLsService().GetAll().ToList();
            

            var movies = new InMemoryMoviesService().GetAll().ToList();
            var users = new InMemoryUsersService().GetAll().ToList();
            
            var comments = (from m in movies
                            from c in m.Comments
                            select c).ToList();
            
            groups.ForEach(g => context.Groups.Add(g));
            acls.ForEach(a => context.ACLs.Add(a));
            comments.ForEach(c => context.Comments.Add(c));

            movies.ForEach(d => context.Movies.Add(d));
            MembershipCreateStatus createStatus;
            users.ForEach(u =>
            {
                context.Users.Add(u);
                Membership.CreateUser(u.Username, u.Username, u.Username + @"@gmail.com", null, null, true, null, out createStatus);
            });
            context.SaveChanges();
        }
    }
}