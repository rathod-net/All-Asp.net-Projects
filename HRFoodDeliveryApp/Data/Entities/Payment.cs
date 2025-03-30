using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Payment
    {
        public int PaymentId { get; set; }
        public int PaymentTypeMasterId { get; set; }
        public virtual PaymentTypeMaster PaymentTypeMaster { get; set; }
        public  int PaymentStatusMasterId { get;  set; }
        public virtual PaymentStatusMaster PaymentStatusMaster { get; set; }
        public int OrderId { get; set; }
        public virtual Order Order { get; set; }

        [Column(TypeName = "decimal(8,2)")]
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }


    }
}
