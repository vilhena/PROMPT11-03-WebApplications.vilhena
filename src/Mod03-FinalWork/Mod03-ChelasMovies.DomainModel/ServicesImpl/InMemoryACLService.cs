using System;
using System.Collections.Generic;
using Mod03_ChelasMovies.DomainModel.Services;
using System.Linq;

namespace Mod03_ChelasMovies.DomainModel.ServicesImpl
{
    using System.Threading;
    using Mod03_ChelasMovies.DomainModel.Domain;

    public class InMemoryACLsService : IACLService
    {
        static List<ACL> acls;

        static int newId;


        static InMemoryACLsService()
        {

            var groupService = new InMemoryGroupsService();
            acls = new List<ACL>
                             {
                                 //Full Permissions
                                 new ACL
                                     {
                                         ID = 1,
                                         Read = true,
                                         Change = true,
                                         Delete = true,
                                     },
                                 //All Can Add
                                 new ACL
                                     {
                                         ID = 2,
                                         Read = true,
                                         Change = false,
                                         Delete = false,
                                     },
                                 //All Can read friends Group (only for vilhena)
                                 new ACL
                                     {
                                         ID = 3,
                                         Read = true,
                                         Change = false,
                                         Delete = false,
                                     },

                                 //All Can add friends and pais Group (only for vilhena)
                                 new ACL
                                     {
                                         ID = 4,
                                         Read = true,
                                         Change = true,
                                         Delete = false,
                                     },
                                 //All Can Add friends Group (only for kalavera)
                                 new ACL
                                     {
                                         ID = 5,
                                         Read = true,
                                         Change = false,
                                         Delete = true,
                                     },
                                 //All Can Read Empty Group (only for kalavera)
                                 new ACL
                                     {
                                         ID = 6,
                                         Read = true,
                                         Change = true,
                                         Delete = true,
                                     },

                             };

        newId = acls.Count;

        }


        public ICollection<ACL> GetAll()
        {
            return acls;
        }

        public ACL Get(int id)
        {
            foreach (ACL m in acls) {
                if (m.ID == id) return m;
            }
            return null;
        }


        public void Add(ACL newAcl)
        {
            newAcl.ID = Interlocked.Increment(ref newId);
            acls.Add(newAcl);
        }

        public void Update(ACL acl)
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

        public ICollection<ACL> Search(string filterCriteria, int pageIndex, int pageSize, string sortingCriteria)
        {
            //Dummy filtering
            return GetAll();
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

        public IList<User> GetAllUsersThatAllowsRead(string username)
        {
            throw new NotImplementedException();
        }
    }
}