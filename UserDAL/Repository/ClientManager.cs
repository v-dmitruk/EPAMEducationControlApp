using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDAL.Entities;
using UserDAL.Interfaces;
using UserDAL.UserDbContext;

namespace UserDAL.Repository
{
    public class ClientManager : IClientManager
    {
        public UserDAL.UserDbContext.UserDbContext Database { get; set; }
        public ClientManager(UserDAL.UserDbContext.UserDbContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Database.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
