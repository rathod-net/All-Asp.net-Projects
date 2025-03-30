using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class PaymentTypeMaster
    {
        public int PaymentTypeMasterId { get; set; }
        public string TypeName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        // navigation 
        public virtual ICollection<Payment> Payments    { get; set; }
    }
}
