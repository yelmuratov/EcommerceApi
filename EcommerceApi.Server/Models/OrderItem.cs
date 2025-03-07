using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApi.Server.Models
{
    public class OrderItem
    {
        public int Id { get; set;}

        [ForeignKey("OrderId")]
        public required Order order_id { get; set; }

        [ForeignKey("ProductId")]
        public required Product product_id { get; set; }

        [Required]
        [Range(1,10000, ErrorMessage="Quantity must be between 1 and 10,000")]
        public int Quantity { get; set; }

        [Required]
        [Range(0.1,100000,ErrorMessage ="Unit Price must be between 0.1 and 10,000")]
        public decimal unit_price { get; set; }
    }
}
