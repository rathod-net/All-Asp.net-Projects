using Login_Registration_FormUsingCodeFirstApproch.Models.Entities;
using System.Data.Entity;

namespace Login_Registration_FormUsingCodeFirstApproch.Models
{
    public class UserDbContext : DbContext
    {

        public UserDbContext() : base("name=LoginFormDB")
        {

        }
        public DbSet<User> users { get; set; }
       
    }
}
