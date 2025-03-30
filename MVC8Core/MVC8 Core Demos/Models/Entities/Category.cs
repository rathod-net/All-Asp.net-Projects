using System.ComponentModel.DataAnnotations.Schema;

namespace MVC8_Core_Demos.Models.Entities
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Order { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
