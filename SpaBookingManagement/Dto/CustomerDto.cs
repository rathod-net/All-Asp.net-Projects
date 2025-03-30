using DataModel.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class CustomerDto
    {
        public int Id { get; set; }
        [Required, MaxLength(50)]
        public string Name { get; set; }
        [Required, MaxLength(255)]
        public string Address { get; set; }
        [Required, MaxLength(100)]
        [EmailAddress]
        public string Email { get; set; }
       [Required, MaxLength(50)]
       [DataType(DataType.Password)]
       public string Password { get; set; }
        [Required]
        [Phone(ErrorMessage = "Enter Correct Phone Number.")]
        public string PhoneNumber { get; set; }
        public string Role { get; set; } = "Customer";

      ///  public SeatBooking SeatBooking { get; set; }
    }
}
