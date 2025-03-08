using EcommerceApi.Server.Constants;

namespace EcommerceApi.Server.DTOs.PaymentDTOs
{
    public class PaymentDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public decimal Amount { get; set; }
        public PaymentStatuses PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
