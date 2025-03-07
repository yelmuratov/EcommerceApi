using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApi.Server.Models
{
    public class Payment
    {
        public int Id { get; set; }
        [ForeignKey("OrderId")]
        public required Order order_id { get; set; }

        [Required]
        public DateTime payment_date { get; set; }

        [Required]
        [Range(0.01,100000,ErrorMessage ="Payment amount must be between 0.01 and 100,000")]
        public decimal amount { get; set; }

        [Required]
        [RegularExpression(@"^(completed|failed)$",ErrorMessage ="Payment status must be completed or failed")]
        public required string payment_status { get;set; }

        [RegularExpression(@"^[A-Za-z0-9\-]{10,100}$", ErrorMessage = "Transaction ID must be 10-100 alphanumeric characters.")]
        public string? TransactionId { get; set; }
    }
}
