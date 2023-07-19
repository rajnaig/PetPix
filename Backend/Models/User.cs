using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    public class User : IdentityUser
    {
        public string? Bio { get; set; }
        public string? ProfilePictureUrl { get; set; }
        public byte[]? PasswordSalt { get; set; }

        // navigation properties 
        [NotMapped]
        public virtual ICollection<Post> Posts { get; set; }

        public User()
        {
            Posts = new HashSet<Post>();
        }
    }
}