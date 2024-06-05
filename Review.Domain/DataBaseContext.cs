using Microsoft.EntityFrameworkCore;
using Review.Domain.Helper;
using Review.Domain.Models;

namespace Review.Domain
{
    public class DataBaseContext: DbContext
    {

        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Models.Review> Reviews { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DataBaseContext(DbContextOptions<DataBaseContext> options): base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Review>()
                .HasOne(r => r.Rating)
                .WithMany(r => r.Reviews)
                .HasForeignKey(r => r.RatingId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Models.Review>().HasData(Initialization.SetReviews());
            modelBuilder.Entity<Rating>().HasData(Initialization.SetRatings());
            modelBuilder.Entity<Login>().HasData(Initialization.SetLogin());
        }
    }
}
