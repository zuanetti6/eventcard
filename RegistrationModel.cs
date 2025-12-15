using System.ComponentModel.DataAnnotations;

namespace Myblazorapp.Models
{
    public class RegistrationModel
    {
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string Phone { get; set; } = string.Empty;

        public string Company { get; set; } = string.Empty;
        public string Comments { get; set; } = string.Empty;
    }
}
