using EcommerceApi.Server.Constants;
using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.Server.DTOs.PaymentDTOs
{
    public class PaymentCreateDTO
    {
        [Required]
        public int OrderId { get; set; }

        [Required]
        [Range(0.1, 100000, ErrorMessage = "Amount must be between 0.1 and 100,000")]
        public decimal Amount { get; set; }

        [Required]
        public PaymentStatuses PaymentStatus { get; set; }
    }
}
