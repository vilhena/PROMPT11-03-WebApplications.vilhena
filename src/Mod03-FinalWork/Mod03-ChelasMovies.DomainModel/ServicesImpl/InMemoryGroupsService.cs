using System;
using System.Collections.Generic;
using Mod03_ChelasMovies.DomainModel.Services;
using System.Linq;

namespace Mod03_ChelasMovies.DomainModel.ServicesImpl
{
    using System.Threading;
    using Mod03_ChelasMovies.DomainModel.Domain;

    public class InMemoryGroupsService : IGroupService
    {
        static List<Group> groups;

        static int newId;

        

        static InMemoryGroupsService()
        {
            var userService = new InMemoryUsersService();
            var aclService = new InMemoryACLsService();

            groups = new List<Group>
                             {

                                 new Group
                                     {
                                         ID = 1,
                                         Name = "Friends",
                                         Owner = userService.GetAll().Where(u=>u.Username == "vilhena").First(),
                                         Users = new List<User>(){
                                             userService.GetAll().Where(u=>u.Username == "kalavera").First(),
                                             userService.GetAll().Where(u=>u.Username == "tpsimoes").First(),
                                         },
                                         Permissions = aclService.Get(1),
                                     },
                                 new Group
                                     {
                                         ID = 2,
                                         Name = "Pais",
                                         Owner = userService.GetAll().Where(u=>u.Username == "vilhena").First(),
                                         Users = new List<User>(){
                                             userService.GetAll().Where(u=>u.Username == "pai").First(),
                                             userService.GetAll().Where(u=>u.Username == "mae").First(),
                                         },
                                         Permissions = aclService.Get(2),
                                     },
                                 new Group
                                     {
                                         ID = 3,
                                         Name = "irmaos",
                                         Owner = userService.GetAll().Where(u=>u.Username == "vilhena").First(),
                                         Users = new List<User>(){
                                             userService.GetAll().Where(u=>u.Username == "cris").First(),
                                             userService.GetAll().Where(u=>u.Username == "lardocelar").First(),
                                         },
                                         Permissions = aclService.Get(3),
                                     },                                 
                                 new Group
                                     {
                                         ID = 4,
                                         Name = "Friends",
                                         Owner = userService.GetAll().Where(u=>u.Username == "cris").First(),
                                         Users = new List<User>(){
                                             userService.GetAll().Where(u=>u.Username == "kalavera").First(),
                                         },
                                         Permissions = aclService.Get(4),
                                     },
                                 new Group
                                     {
                                         ID = 5,
                                         Name = "Friends",
                                         Owner = userService.GetAll().Where(u=>u.Username == "kalavera").First(),
                                         Users = new List<User>(){
                                             userService.GetAll().Where(u=>u.Username == "vilhena").First(),
                                             userService.GetAll().Where(u=>u.Username == "cris").First(),
                                             userService.GetAll().Where(u=>u.Username == "tpsimoes").First(),
                                         },
                                         Permissions = aclService.Get(5),
                                     },
                                 new Group
                                     {
                                         ID = 6,
                                         Name = "Empty",
                                         Owner = userService.GetAll().Where(u=>u.Username == "kalavera").First(),
                                         Users = new List<User>(),
                                         Permissions = aclService.Get(6),
                                     },
                             };

        newId = groups.Count;

        }


        public ICollection<Group> GetAll()
        {
            return groups;
        }

        public Group Get(int id)
        {
            foreach (Group m in groups) {
                if (m.ID == id) return m;
            }
            return null;
        }


        public void Add(Group newGroup)
        {
            newGroup.ID = Interlocked.Increment(ref newId);
            groups.Add(newGroup);
        }

        public void Update(Group group)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Group Search(string title)
        {
            throw new NotImplementedException();
        }

        public ICollection<Group> Search(string filterCriteria, int pageIndex, int pageSize, string sortingCriteria)
        {
            //Dummy filtering
            return GetAll();
        }

        public void Fill(Group group)
        {
            throw new NotImplementedException();
        }

        public ICollection<Group> GetAllMyGroups(string user)
        {
            throw new NotImplementedException();
        }

        public void AddUserToGroup(int groupId, string username)
        {
            throw new NotImplementedException();
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



        
    }
}