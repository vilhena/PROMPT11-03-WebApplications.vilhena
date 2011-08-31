using System;
using System.Collections.Generic;
using Mod03_ChelasMovies.DomainModel.Services;
using System.Linq;

namespace Mod03_ChelasMovies.DomainModel.ServicesImpl
{
    using System.Threading;
    using Mod03_ChelasMovies.DomainModel.Domain;

    public class InMemoryUsersService : IUserService
    {
        static List<User> users;

        static int newId;


        static InMemoryUsersService()
        {

            users = new List<User>
                             {

                                 new User
                                     {
                                         ID = 1,
                                         Name = "Gonçalo Vilhena",
                                         NickName = "vilhas",
                                         Username = "vilhena",
                                         //BelongsToGroups = new List<Group>()
                                     },

                                 new User
                                     {
                                         ID = 2,
                                         Name = "Cristina Vilhena",
                                         NickName = "mana",
                                         Username = "cris",
                                         //BelongsToGroups = new List<Group>()
                                     },
                                 new User
                                     {
                                         ID = 3,
                                         Name = "Ricardo Vilhena",
                                         NickName = "ric",
                                         Username = "lardocelar",
                                         //BelongsToGroups = new List<Group>()
                                     },
                                new User
                                     {
                                         ID = 4,
                                         Name = "Luis Vilhena",
                                         NickName = "luis",
                                         Username = "pai",
                                         //BelongsToGroups = new List<Group>()
                                     },
                                new User
                                     {
                                         ID = 5,
                                         Name = "Herminia Vilhena",
                                         NickName = "herminia",
                                         Username = "mae",
                                         //BelongsToGroups = new List<Group>()
                                     },
                                new User
                                     {
                                         ID = 6,
                                         Name = "Tiago Simões",
                                         NickName = "mafias",
                                         Username = "tpsimoes",
                                         //BelongsToGroups = new List<Group>()
                                     },
                                new User
                                     {
                                         ID = 7,
                                         Name = "Luis Trindade",
                                         NickName = "kalavera",
                                         Username = "kalavera",
                                         //BelongsToGroups = new List<Group>()
                                     },
                             };

        newId = users.Count;

        }


        public ICollection<User> GetAll()
        {
            return users;
        }

        public User Get(int id)
        {
            foreach (User m in users) {
                if (m.ID == id) return m;
            }
            return null;
        }


        public void Add(User newUser)
        {
            newUser.ID = Interlocked.Increment(ref newId);
            users.Add(newUser);
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Movie Search(string title)
        {
            throw new NotImplementedException();
        }

        public ICollection<User> Search(string filterCriteria, int pageIndex, int pageSize, string sortingCriteria)
        {
            //Dummy filtering
            return GetAll();
        }

        public void Fill(User user)
        {
            throw new NotImplementedException();
        }

        public User GetAuthenticatedUser(string username)
        {
            return users.Where(u => u.Username == username).FirstOrDefault();
        }


        #region Implementation of IDisposable

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        #endregion




        public ICollection<User> GetUsersFromGroup(int groupId)
        {
            throw new NotImplementedException();
        }
    }
}