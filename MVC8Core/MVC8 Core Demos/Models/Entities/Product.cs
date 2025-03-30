using System.ComponentModel.DataAnnotations.Schema;

namespace MVC8_Core_Demos.Models.Entities
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }

        public int Stock { get; set; }
        [ForeignKey("Category")]
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
