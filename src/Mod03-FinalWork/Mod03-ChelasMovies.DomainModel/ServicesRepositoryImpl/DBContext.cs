
namespace Mod03_ChelasMovies.DomainModel.ServicesRepositoryImpl
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration;

    /// <summary>
    /// The EF <see cref="System.Data.Entity.DbContext"/> to <see cref="Movie"/> type.
    /// </summary>
    public class DbContext<T> : DbContext where T:class 
    {
        public DbSet<T> DataSet { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T>();
        }

    }
}