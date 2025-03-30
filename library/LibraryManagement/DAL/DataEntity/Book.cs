using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.DataEntity
{
    [Table("Book")]
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        [Column(TypeName ="varchar")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        [RegularExpression(@"^[0-9-]+$", ErrorMessage = "Invalid ISBN format")]
        [Column(TypeName = "varchar")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Publication Name is required")]
        [Column("Publication Name", TypeName = "varchar")]
        public string PublicationName { get; set; }

        [Required(ErrorMessage = "Author Name is required")]
        [Column("Author Name", TypeName = "varchar")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        [Column("Created By", TypeName = "varchar")]
        public string CreatedBy { get; set; }

        [Required(ErrorMessage = "Created Date is required")]
        [Column("Created Date")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Category is required")]
        [Column("Category Book Id")]
       // [ForeignKey("CategoryBooks")]
        public int CategoryBookId { get; set; }

        public virtual CategoryBook CategoryBook { get; set; }
    }
}
