using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class UserAddress
    {
        public int UserAddressId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public string Label { get; set; }
        public string AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string? Landmark { get; set; }
        public string? Latitude { get; set; }
        public string? Longitude { get; set; }


        }
}

