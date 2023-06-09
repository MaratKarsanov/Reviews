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
        public async Task<List<Feedback>> GetFeedbacksByProductIdAsync(int id)
        {
            return await databaseContext.Feedbacks.ToListAsync();
        }

        public async Task<IEnumerable<Feedback?>> GetReviewAsync(int id, int productId)
        {
            return await databaseContext.Feedbacks.Where(x => x.Id == id).ToListAsync();
        }

        public async Task<bool> TryToDeleteReviewAsync(int id)
        {
            try
            {
                var Review = await databaseContext.Feedbacks.Where(x => x.Id == id).FirstOrDefaultAsync();
                databaseContext.Feedbacks.Remove(Review!);
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
