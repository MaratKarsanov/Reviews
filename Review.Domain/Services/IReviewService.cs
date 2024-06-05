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
        Task<List<Models.Review>> GetReviewsByProductIdAsync(int id);

        /// <summary>
        /// Получение все отзывов по продукту
        /// </summary>
        /// <param name="id">Id отзыва</param>
        /// <param name="productId">Id продукта</param>
        /// <returns></returns>
        Task<IEnumerable<Models.Review?>> GetReviewsAsync(int id);

        /// <summary>
        /// Удаление отзыва
        /// </summary>
        /// <param name="id">Id отзыва</param>
        /// <returns></returns>
        Task<bool> TryToDeleteReviewAsync(int id);
    }
}
