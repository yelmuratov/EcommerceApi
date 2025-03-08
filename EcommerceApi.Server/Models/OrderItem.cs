using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EcommerceApi.Server.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        // ✅ Explicit Foreign Key Property
        [Required]
        public int OrderId { get; set; }

        [ForeignKey("OrderId")]
        public required Order Order { get; set; } // ✅ Navigation Property

        // ✅ Explicit Foreign Key Property
        [Required]
        public int ProductId { get; set; }

        [ForeignKey("ProductId")]
        public required Product Product { get; set; } // ✅ Navigation Property

        [Required]
        [Range(1, 10000, ErrorMessage = "Quantity must be between 1 and 10,000")]
        public int Quantity { get; set; }

        [Required]
        [Range(0.1, 100000, ErrorMessage = "Unit Price must be between 0.1 and 100,000")]
        [Column(TypeName = "decimal(18,2)")] // ✅ Ensures price precision in SQL
        public decimal UnitPrice { get; set; }
    }
}
