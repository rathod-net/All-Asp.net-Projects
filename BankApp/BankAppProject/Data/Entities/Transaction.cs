using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Transaction
    {
        public string TransactionId { get; set; }= Guid.NewGuid().ToString();
        [Required]
        public int SenderAccountId { get; set; }
        [ForeignKey("SenderAccountId")]
        public virtual BankAccount SenderAccount { get; set; }

        [Required]
        public int RecipientAccountId { get; set; }
        [ForeignKey("RecipientAccountId")]
        public virtual BankAccount RecipientAccount { get; set; }

        [Required]
        [Range(0, double.MaxValue)]
        public decimal Amount { get; set; }

        public string TransactionType { get; set; } // Deposit, Withdraw, Transfer
        public DateTime Date { get; set; } = DateTime.UtcNow;
    }
}
