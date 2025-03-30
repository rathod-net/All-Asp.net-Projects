using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class PaymentStatusMaster
    {
        public int PaymentStatusMasterId { get; set; }
        public string StatusName { get; set; }

        public string? Description { get; set; }
        public bool IsActive { get; set; }

        // navigation
         public virtual ICollection<Payment> Payments { get; set; }
    }
}
