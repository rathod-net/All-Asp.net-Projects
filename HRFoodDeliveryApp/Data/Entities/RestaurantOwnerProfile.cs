using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class RestaurantOwnerProfile
    {
        public int RestaurantOwnerProfileId { get; set; }

        // 1:1 relationship to User
        public int UserId { get; set; }
        public virtual User User { get; set; }

        // Role-specific fields for a restaurant owner
        public string BusinessLicenseNumber { get; set; }
        public string GSTIN { get; set; }    // if relevant in your region
        public string BusinessRegistrationNumber { get; set; }
        public bool IsVerified { get; set; } // whether Admin verified the owner’s documents

        public string? AdminRemarks { get; set; }

        
    }

}
