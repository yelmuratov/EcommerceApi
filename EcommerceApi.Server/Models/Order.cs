using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EcommerceApi.Server.Constants;

namespace EcommerceApi.Server.Models
{
    public class Order
    {
        public int Id { get; set; }

        [Required]
        public int UserId { get; set; } 

        [ForeignKey("UserId")]
        public required User User { get; set; } 

        [Required]
        public DateTime OrderDate { get; set; } = DateTime.UtcNow;

        [Required]
        public decimal TotalAmount { get; set; }

        [Required]
        public OrderStatuses OrderStatus { get; set; } = OrderStatuses.processing;

        [Required]
        public PaymentStatuses PaymentStatus { get; set; } = PaymentStatuses.pending;

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
