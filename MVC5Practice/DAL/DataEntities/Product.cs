using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DataEntities
{
    [Table("Product")]
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required(ErrorMessage ="Price is requried")]
        [Range(0.01,1000000,ErrorMessage =("Price Must be between 0.01 and 1,000,000."))]
        [DisplayFormat(DataFormatString ="{0:F2}",ApplyFormatInEditMode = true)]
       
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
    }
}
