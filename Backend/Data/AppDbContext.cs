using Backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;

namespace Backend.Data
{
    public class AppDbContext: IdentityDbContext<User, IdentityRole, string>
    {
        public DbSet<Post> Posts { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
                new { Id = "1", Name = "Admin", NormalizedName = "ADMIN" },
                new { Id = "2", Name = "Moderator", NormalizedName = "MODERATOR" },
                new { Id = "3", Name = "User", NormalizedName = "USER" }
                );

            modelBuilder.Entity<User>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.User)
                .HasForeignKey(p => p.UserId)
                .OnDelete(DeleteBehavior.Cascade)
                .IsRequired();


            User user1 = new User
            {
                Bio = "test",
                ProfilePictureUrl = "test",
                UserName = "Admin1",
                Email = "admin@admin.com",
                PasswordHash = "123456"
            };

            modelBuilder.Entity<User>().HasData(user1);

            base.OnModelCreating(modelBuilder);
        }
    }
}
