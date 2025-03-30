using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class BankDetails
    {
        public int BankDetailsId { get; set; }
        public int UserId { get; set; } 
        public virtual User User { get; set; }
      
        // Bank details, payout info, etc.
        public string AccountHolderName { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string IFSCCode { get; set; }
    }
}
