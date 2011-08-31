using Mod03_ChelasMovies.DomainModel;
using Mod03_ChelasMovies.DomainModel.Services;
using Mod03_ChelasMovies.DomainModel.ServicesImpl;
using Mod03_ChelasMovies.DomainModel.ServicesRepositoryInterfaces;
using Mod03_ChelasMovies.RepImpl;
using StructureMap;
using Mod03_ChelasMovies.DomainModel.ServicesRepositoryImpl;
namespace Mod03_ChelasMovies.DependencyResolution {
    public static class IoC {
        public static IContainer Initialize() {
            ObjectFactory.Initialize(x =>
                        {
                            x.Scan(scan =>{
                                        scan.TheCallingAssembly();
                                        scan.WithDefaultConventions();
                                    });

                            // IMoviesService
                            //x.For<IMoviesService>().HttpContextScoped().Use<EFMoviesService>();
                            //x.For<IMoviesService>().HttpContextScoped().Use<InMemoryMoviesService>();
                            x.For<IMoviesService>().HttpContextScoped().Use<RepositoryMoviesService>();
                            x.For<ICommentsService>().HttpContextScoped().Use<RepositoryCommentsService>();
                            x.For<IACLService>().HttpContextScoped().Use<RepositoryACLService>();
                            x.For<IGroupService>().HttpContextScoped().Use<RepositoryGroupService>();
                            x.For<IUserService>().HttpContextScoped().Use<RepositoryUserService>();
                            x.For<IWallService>().HttpContextScoped().Use<WallService>();
                            //x.For(typeof(IService<>)).HttpContextScoped().Use(typeof(RepositoryService<>));

                            // IMoviesRepository
                            x.For<IMoviesRepository>().HttpContextScoped().Use<EFIMDBAPIMoviesRepository>();
                            x.For<ICommentsRepository>().HttpContextScoped().Use<EFICommentsRepository>();
                            x.For<IACLsRepository>().HttpContextScoped().Use<EFIACLsRepository>();
                            x.For<IGroupsRepository>().HttpContextScoped().Use<EFIGroupsRepository>();
                            x.For<IUsersRepository>().HttpContextScoped().Use<EFIUsersRepository>();
                            //x.For(typeof(IRepository<,>)).HttpContextScoped().Use(typeof(EFIRepository<,>));
                            // MovieDbContext
                            x.For<MovieDbContext>().HttpContextScoped().Use<MovieDbContext>();
                            //x.For<CommentDbContext>().HttpContextScoped().Use<MovieDbContext>();
                            //x.For<ACLDbContext>().HttpContextScoped().Use<MovieDbContext>();
                            //x.For<GroupDbContext>().HttpContextScoped().Use<MovieDbContext>();
                            //x.For<UserDbContext>().HttpContextScoped().Use<MovieDbContext>();
                            //x.For(typeof(DbContext<>)).HttpContextScoped().Use(typeof(DbContext<>));
                        });
            return ObjectFactory.Container;
        }
    }
}