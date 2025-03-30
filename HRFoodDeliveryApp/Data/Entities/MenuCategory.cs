using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class MenuCategory
    {
        public int MenuCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? Description { get; set; }
        public int DisplayOrder { get; set; }

        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        // navigation 
        public virtual ICollection<MenuItem> MenuItems { get; set; }

    }
}
