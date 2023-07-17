using Microsoft.AspNetCore.Identity;

namespace Backend.Models
{
    public class User : IdentityUser
    {
        public string Bio { get; set; }
        public string ProfilePictureUrl { get; set; }

        // navigation properties 
        public virtual ICollection<Post> Posts { get; set; }

        public User()
        {
            Posts = new HashSet<Post>();
        }
    }
}