using Mvc5CurdDatebaseAndCodeFirstApproch.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mvc5CurdDatebaseAndCodeFirstApproch.Models
{
    public class RegisterUserDbContext : DbContext
    {
        public RegisterUserDbContext() : base("name=RegisterUserDB")
            {

            }

        public DbSet<RegisterUser> registerUsers { get; set; }
    }
}