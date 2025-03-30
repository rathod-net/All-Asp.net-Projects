using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DataEntity
{
    public class CategoryBook
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Category Type is required")]
        [Column("Category Type", TypeName = "varchar")]
        public string CategoryType { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
