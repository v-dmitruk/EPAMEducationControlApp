using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserDAL.Entities;

namespace UserDAL.UserDbContext
{
    public class UserDbContext : IdentityDbContext<ApplicationUser>
    {
        public UserDbContext(string conectionString) : base(conectionString) { }

        public DbSet<ClientProfile> ClientProfiles { get; set; }
    }
}
