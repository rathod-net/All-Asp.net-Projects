using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DataEntities
{
    [Table("Category")]
    public class Category
    {
        public int CategoryId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public int Rating { get; set; }

        public virtual ICollection<Product> Product { get; set; }
    }
}
