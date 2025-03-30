using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CategoryDAL
{
    [Table("Category")]
    public class Category
    {
        public int Id { get; set; }
        [Required, StringLength(100)]
        [Column("Name",TypeName ="varchar")]
        public string Name { get; set; }
        [Required]
        public int Rating { get; set; }
    }
}
