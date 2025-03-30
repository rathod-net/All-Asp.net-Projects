using DAL.DataEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Model
{
    public class BookViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "ISBN is required")]
        [RegularExpression(@"^[0-9-]+$", ErrorMessage = "Invalid ISBN format")]
        public string ISBN { get; set; }

        [Required(ErrorMessage = "Publication Name is required")]
        public string PublicationName { get; set; }

        [Required(ErrorMessage = "Author Name is required")]
        public string AuthorName { get; set; }

        [Required(ErrorMessage = "Created By is required")]
        public string CreatedBy { get; set; }

        [Required(ErrorMessage = "Created Date is required")]
        public DateTime CreatedDate { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public int CategoryBookId { get; set; }

        public string CategoryType { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Books { get; set; }


    }

   
}
