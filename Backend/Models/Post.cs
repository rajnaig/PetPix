namespace Backend.Models
{
    public class Post
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string ImageUrl { get; set; }
        public string Caption { get; set; }
        public DateTime CreatedAt { get; set; }
        //navigation properties 

        public Post()
        {
             CreatedAt= DateTime.Now;
        }
    }
}
