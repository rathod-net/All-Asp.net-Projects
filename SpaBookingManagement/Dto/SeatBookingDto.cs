using DataModel.Entites;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto
{
    public class SeatBookingDto
    {
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

      //  [ForeignKey("CustomerId")]
      //  public IEnumerable<Customer> Customer { get; set; }

        [Required]
        public int TimeSlotId { get; set; }

     //   [ForeignKey("TimeSlotId")]
      //  public TimeSlot TimeSlot { get; set; }

        [Required]
        public string BookingType { get; set; } // "Spa" or "Home"

        public decimal Price { get; set; }

        public bool IsConfirmed { get; set; } = false;
    }
}
