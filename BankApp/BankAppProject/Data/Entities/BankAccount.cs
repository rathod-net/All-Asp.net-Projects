using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }
        [Required]
        public string AccountNumber { get; set; } =Guid.NewGuid().ToString();
        [Required]
        public string UserId { get; set; }
        [Required]
        public string AccountType { get; set; }
        [Required]
        [Range(0,double.MaxValue)]
        public decimal Balance { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
    }
}
