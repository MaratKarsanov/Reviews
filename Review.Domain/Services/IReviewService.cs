using Review.Domain.Models;

namespace Review.Domain.Services
{
    public interface IReviewService
    {
        /// <summary>
        /// Получение все отзывов по продукту
        /// </summary>
        /// <param name="id">Id продукта</param>
        /// <returns></returns>
        Task<List<Feedback>> GetFeedbacksByProductIdAsync(int id);

        /// <summary>
        /// Получение все отзывов по продукту
        /// </summary>
        /// <param name="id">Id отзыва</param>
        /// <param name="productId">Id продукта</param>
        /// <returns></returns>
        Task<IEnumerable<Feedback?>> GetReviewAsync(int id, int productId);

        /// <summary>
        /// Удаление отзыва
        /// </summary>
        /// <param name="id">Id отзыва</param>
        /// <returns></returns>
        Task<bool> TryToDeleteReviewAsync(int id);
    }
}
