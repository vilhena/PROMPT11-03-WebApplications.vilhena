
namespace Mod03_ChelasMovies.DomainModel.ServicesRepositoryImpl
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;
    using Mod03_ChelasMovies.DomainModel.Domain;
    using System.Data.Entity.ModelConfiguration.Conventions;

    /// <summary>
    /// The EF <see cref="System.Data.Entity.DbContext"/> to <see cref="Movie"/> type.
    /// </summary>
    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<ACL> ACLs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Comment>().HasRequired(c => c.Movie).WithMany(a => a.Comments).WillCascadeOnDelete(false);
            modelBuilder.Entity<Comment>().HasRequired(c => c.Owner);

            modelBuilder.Entity<Movie>().HasMany(m => m.Comments);
            modelBuilder.Entity<Movie>().HasRequired(m => m.Owner).WithMany().WillCascadeOnDelete(false);

            modelBuilder.Entity<Group>().HasRequired(g => g.Owner).WithMany().WillCascadeOnDelete(false);
            modelBuilder.Entity<Group>().HasMany(g => g.Users).WithMany(u=>u.BelongsToGroups);
            modelBuilder.Entity<Group>().HasRequired(g => g.Permissions);
        }

    }
}