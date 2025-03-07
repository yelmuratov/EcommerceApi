using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using EcommerceApi.Server.Constants;

namespace EcommerceApi.Server.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z0-9]{5,20}$", ErrorMessage = "Username must be 5-20 characters long and contain only letters and numbers.")]
        public required string Username { get; set; }

        [Required]
        [EmailAddress]
        public required string Email { get; set; }

        [Required]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[\W_]).{8,}$",ErrorMessage = "Password must be at least 8 characters long, contain an uppercase letter, a lowercase letter, a digit, and a special character.")]
        public required string Password { get; set; }

        [Required]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public Roles role { get; set; } = Roles.Customer;
    }
}
