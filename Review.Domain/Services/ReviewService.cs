using Review.Domain.Models;
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
        public async Task<List<Models.Review>> GetReviewsByProductIdAsync(int id)
        {
            return await databaseContext.Feedbacks.ToListAsync();
        }

        public async Task<IEnumerable<Models.Review?>> GetReviewAsync(int id, int productId)
        {
            return await databaseContext.Feedbacks.Where(x => x.Id == id).ToListAsync();
        }

        public async Task<bool> TryToDeleteReviewAsync(int id)
        {
            try
            {
                var review = await databaseContext.Feedbacks.Where(f => f.Id == id).FirstOrDefaultAsync();
                databaseContext.Feedbacks.Remove(review!);
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
