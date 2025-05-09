using System.ComponentModel.DataAnnotations;

namespace ExpenseTracker.Models
{
    public class Expense
    {
        [Key]
        public Guid ExpenseId { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(100, ErrorMessage = "Title can't be more than 100 characters.")]
        public string Title { get; set; }

        [StringLength(250, ErrorMessage = "Note can't exceed 250 characters.")]
        public string Note { get; set; }

        [Required(ErrorMessage = "Amount is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be greater than zero.")]
        public decimal Amount { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        public ExpenseCategory Category { get; set; }

        [Required(ErrorMessage = "Payment Method is required.")]
        public PaymentMethod PaymentMethod { get; set; }
    }
}
