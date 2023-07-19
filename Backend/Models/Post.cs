using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Backend.Models
{
    public class Post
    {
        [Key]
        public string Id { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
        public string ImageUrl { get; set; }
        public string Caption { get; set; }
        public DateTime CreatedAt { get; set; }

        //navigation properties 
        [NotMapped]
        [JsonIgnore]
        public virtual User User { get; set; }

        public Post()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
        }
    }
}
