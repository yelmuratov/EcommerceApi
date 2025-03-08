using EcommerceApi.Server.Constants;

using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.Server.DTOs.PaymentDTOs
{
    public class PaymentUpdateDTO
    {
        [Required]
        public PaymentStatuses PaymentStatus { get; set; }
    }
}
