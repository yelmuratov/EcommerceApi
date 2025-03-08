using System.ComponentModel.DataAnnotations;
using EcommerceApi.Server.Constants;

namespace EcommerceApi.Server.DTOs.UserDTOs
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public required string Username { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        public Roles Role { get; set; } = Roles.Customer;
    }
}
