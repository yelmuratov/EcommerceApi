using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcommerceApi.Server.Constants;

namespace EcommerceApi.Server.Models
{
    public class Payment
    {
        public int Id { get; set; }

        [Required]
        public int OrderId { get; set; } 

        [ForeignKey("OrderId")]
        public required Order Order { get; set; } 

        [Required]
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        [Required]
        [Column(TypeName = "decimal(18,2)")] 
        [Range(0.01, 100000, ErrorMessage = "Payment amount must be between 0.01 and 100,000")]
        public decimal Amount { get; set; }

        [Required]
        public PaymentStatuses PaymentStatus { get; set; } = PaymentStatuses.pending; 

        [RegularExpression(@"^[A-Za-z0-9\-]{10,100}$", ErrorMessage = "Transaction ID must be 10-100 alphanumeric characters.")]
        public string? TransactionId { get; set; } 
}
