using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    [Index(nameof(RoleName),IsUnique =true, Name ="IX_RoleName_Unique")]
    public class RoleMaster
    {
        public int RoleMasterId { get; set; }
        public string RoleName { get; set; }
        public string? Description { get; set;}
        public bool IsActive { get; set; }

       // public virtual ICollection<User> Users { get; set; }
    }
}
