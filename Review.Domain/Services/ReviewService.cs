using Microsoft.EntityFrameworkCore;
using Review.Domain.Models;

namespace Review.Domain.Services
{
    public class ReviewService : IReviewService
    {
        private readonly DataBaseContext databaseContext;

        public ReviewService(DataBaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public async Task<Models.Review> TryToAddReviewAsync(AddReview addReview)
        {
            if (addReview.Grade < 0 || addReview.Grade > 5)
                return null;
            var review = new Models.Review()
            {
                ProductId = addReview.ProductId,
                Text = addReview.Text,
                Grade = addReview.Grade,
                CreationDate = DateTime.UtcNow,
                Status = Status.Actual,
                UserId = addReview.UserId
            };
            await databaseContext.Reviews.AddAsync(review!);
            await databaseContext.SaveChangesAsync();
            return review;
        }

        public async Task<List<Models.Review>> GetReviewsByProductIdAsync(Guid productId)
        {
            return await databaseContext.Reviews
                .Where(r => r.ProductId == productId && r.Status != Models.Status.Deleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<Models.Review?>> GetReviewsAsync(Guid id)
        {
            return await databaseContext.Reviews
                .Where(r => r.Id == id && r.Status != Status.Deleted)
                .ToListAsync();
        }

        public async Task<bool> TryToDeleteReviewAsync(Guid reviewId)
        {
            try
            {
                var review = await databaseContext.Reviews
                    .Where(r => r.Id == reviewId)
                    .FirstOrDefaultAsync();
                review.Status = Status.Deleted;
                await databaseContext.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
