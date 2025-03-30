using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class MenuItem
    {
        public int MenuItemId { get; set; }
        public int MenuCategoryId { get; set; }
        public virtual MenuCategory MenuCategory { get; set; }
        public string ItemName { get; set; }
        public string? Description { get; set; }
        [Column(TypeName ="decimal(8,2)")]
        public decimal Price { get; set; }
        public bool IsVeg {  get; set; }
        public bool IsAvailable { get; set; }

        public string? ImageUrl { get; set; }

        //[NotMapped]
        //public float AverageRating { get; set; }
        //[NotMapped]
        //public int ReviewCount { get; set; }
    }
}
