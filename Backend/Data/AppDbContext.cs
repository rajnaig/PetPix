﻿using Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;

namespace Backend.Data
{
    public class AppDbContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> opt):base(opt) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<IdentityRole>().HasData(
            //    new { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
            //    new { Id = 2, Name = "Moderator", NormalizedName = "MODERATOR" },
            //    new { Id = 3, Name = "User", NormalizedName = "USER" }
            //    );

            User user1 = new User
            {
                Bio = "test",
                ProfilePictureUrl = "test",
                UserName = "Admin1",
                Email = "admin@admin.com",
                PasswordHash = "123456"
            };

            modelBuilder.Entity<User>().HasData(user1);
        }
    }
}