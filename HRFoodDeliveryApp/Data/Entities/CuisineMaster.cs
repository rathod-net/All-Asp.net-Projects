using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class CuisineMaster
    {
        public int CuisineMasterId { get; set; }
        public string CuisineName { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsActive { get; set; }

        // Navigation Property
        public virtual ICollection<RestaurantCuisine> RestaurantCuisines { get; set; }
    }

}
