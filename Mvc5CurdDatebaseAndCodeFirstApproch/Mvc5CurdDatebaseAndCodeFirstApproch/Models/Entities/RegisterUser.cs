using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc5CurdDatebaseAndCodeFirstApproch.Models.Entities
{
    [Table("RegisterUser")]
    public class RegisterUser
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Column("User Name",TypeName ="varchar")]
        public string Username { get; set; }
        [Required]
        [StringLength(50)]
        [Column("Password", TypeName = "varchar")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}