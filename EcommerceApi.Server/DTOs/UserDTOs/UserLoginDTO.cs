using System.ComponentModel.DataAnnotations;

namespace EcommerceApi.Server.DTOs.UserDTOs
{
    public class UserLoginDTO
    {
        [Required]
        public required string Username { get; set; } 

        [Required]
        public required string Password { get; set; }
    }

}
