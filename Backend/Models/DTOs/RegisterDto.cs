using System.ComponentModel.DataAnnotations;

namespace Backend.Models.DTOs
{
    public class RegisterDto
    {
        [Required] public string Username { get; set; }

        [Required] public string Email { get; set; }


        [Required]
        [StringLength(10)]
        public string Password { get; set; }
    }
}
