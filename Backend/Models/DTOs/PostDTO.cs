namespace Backend.Models.DTOs
{
    public class PostDTO
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public string ImageUrl { get; set; }
        public string Caption { get; set; }
        public DateTime CreatedAt { get; set; }


        public PostDTO()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
        }
    }
}