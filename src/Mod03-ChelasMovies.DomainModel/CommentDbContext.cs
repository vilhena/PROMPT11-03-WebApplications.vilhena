
namespace Mod03_ChelasMovies.DomainModel
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;

    /// <summary>
    /// The EF <see cref="System.Data.Entity.DbContext"/> to <see cref="Movie"/> type.
    /// </summary>
    public class CommentDbContext : DbContext
    {
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Movie>().Property(p => p.Price).HasPrecision(18, 2);
            modelBuilder.Entity<Comment>().HasRequired(c => c.Movie).WithMany(a => a.Comments);
        }

    }
}