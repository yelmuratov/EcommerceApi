using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcommerceApi.Server.Constants;

namespace EcommerceApi.Server.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public required User user_id { get; set; }

        [Required]
        public DateTime order_date { get; set; } = DateTime.UtcNow;

        [Required]
        public decimal total_amount { get; set; }

        [Required]
        public OrderStatuses order_status { get; set; } = OrderStatuses.processing;

        [Required]
        public PaymentStatuses payment_status { get; set; } = PaymentStatuses.pending;
    }
}
