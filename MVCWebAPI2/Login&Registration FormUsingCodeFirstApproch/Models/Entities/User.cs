using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Login_Registration_FormUsingCodeFirstApproch.Models.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Column("First Name", TypeName="varchar")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        [Column("Last Name", TypeName = "varchar")]
        public string   LastName { get; set; }
        [Required]
        [Column("Email", TypeName = "varchar")]
        [DataType(DataType.EmailAddress,ErrorMessage ="Email Address Must Be Required")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(100,MinimumLength =6, ErrorMessage ="Password Must be at least 6 Characters")]
        public string Password { get; set; }
        
        [Phone(ErrorMessage ="Please Enter a Valid Phone Number")]
        [StringLength(10,ErrorMessage ="Phone Number cannot be Longer Than 10 Digits")]
        public string PhoneNumber { get; set; }
        

    }
}