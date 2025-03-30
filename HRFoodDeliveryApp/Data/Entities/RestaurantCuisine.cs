using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public  class RestaurantCuisine
    {
        public  int RestaurantCuisineId  { get; set; }
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        public int CuisineMasterId { get; set; }
        public virtual CuisineMaster CuisineMaster { get; set; }
    }
}
