using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Loan
    {
        public string LoanId { get; set; } = Guid.NewGuid().ToString();
        public int UserId { get; set; } // Foreign key to User table
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }
        [Required]
        [Range(1000, double.MaxValue)]
        public decimal LoanAmount { get; set; }
        [Required]
        [Range(0.1,100)]
        public double InterestRate { get; set; } // Percentage
        [Required]
        [Range(6,360)]
        public int LoanTermMonths { get; set; } // Loan Duration in months
        public string Status { get; set; } // Pending, Approved, Rejected, Paid
        public DateTime AppliedDate { get; set; } = DateTime.Now;
        public DateTime? ApprovedDate { get; set; }
        public decimal MonthlyInstallment { get; set; }

        // Navigation Property
    }
}

