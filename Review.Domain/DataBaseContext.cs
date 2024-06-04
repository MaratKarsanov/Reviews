using Microsoft.EntityFrameworkCore;
using Review.Domain.Helper;
using Review.Domain.Models;

namespace Review.Domain
{
    public class DataBaseContext: DbContext
    {

        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Models.Review> Feedbacks { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options): base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
                .HasOne(p => p.Rating)
                .WithMany(t => t.Reviews)
                .HasForeignKey(p => p.RatingId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Review>().HasData(Initialization.SetFeedbacks());
            modelBuilder.Entity<Rating>().HasData(Initialization.SetRatings());
            modelBuilder.Entity<Login>().HasData(Initialization.SetLogin());
        }
    }
}
