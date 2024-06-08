using Microsoft.EntityFrameworkCore;

namespace Review.Domain.Services
{
    public class ReviewService : IReviewService
    {
        private readonly DataBaseContext databaseContext;

        public ReviewService(DataBaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public async Task<List<Models.Review>> GetReviewsByProductIdAsync(int productId)
        {
            return await databaseContext.Reviews
                .Where(r => r.ProductId == productId && r.Status != Models.Status.Deleted)
                .ToListAsync();
        }

        public async Task<IEnumerable<Models.Review?>> GetReviewsAsync(int id)
        {
            return await databaseContext.Reviews
                .Where(r => r.Id == id && r.Status != Models.Status.Deleted)
                .ToListAsync();
        }

        public async Task<bool> TryToDeleteReviewAsync(int reviewId)
        {
            try
            {
                var review = await databaseContext.Reviews
                    .Where(r => r.Id == reviewId)
                    .FirstOrDefaultAsync();
                review.Status = Models.Status.Deleted;
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
