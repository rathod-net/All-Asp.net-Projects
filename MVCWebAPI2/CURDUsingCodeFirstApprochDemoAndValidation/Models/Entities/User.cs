using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CURDUsingCodeFirstApprochDemoAndValidation.Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Column("First Name",TypeName ="varchar")]
        [StringLength(50)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string FacebookUrl { get; set; }


    }
}