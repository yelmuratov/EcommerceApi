using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.Server.DTOs.UserDTOs
{
    public class UserCreateDTO
    {
        [Required]
        [StringLength(50)]
        public required string Username { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [MinLength(6)]
        public required string Password { get; set; }
    }
}
