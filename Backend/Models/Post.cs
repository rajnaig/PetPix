﻿using System.ComponentModel.DataAnnotations;

namespace Backend.Models
{
    public class Post
    {
        [Key]
        public string Id { get; set; }
        public Guid UserId { get; set; }
        public string ImageUrl { get; set; }
        public string Caption { get; set; }
        public DateTime CreatedAt { get; set; }
        //navigation properties 

        public Post()
        {
            Id = Guid.NewGuid().ToString();
            CreatedAt = DateTime.Now;
        }
    }
}
