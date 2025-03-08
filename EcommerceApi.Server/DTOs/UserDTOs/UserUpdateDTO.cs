using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.Server.DTOs.UserDTOs
{
    public class UserUpdateDTO
    {
        [Required]
        [StringLength(50)]
        public required string Username { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }
    }
}
