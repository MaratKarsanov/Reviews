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
        Task<List<Models.Review>> GetReviewsByProductIdAsync(Guid id);

        /// <summary>
        /// Получение все отзывов по продукту
        /// </summary>
        /// <param name="id">Id отзыва</param>
        /// <param name="productId">Id продукта</param>
        /// <returns></returns>
        Task<IEnumerable<Models.Review?>> GetReviewsAsync(Guid id);

        /// <summary>
        /// Удаление отзыва
        /// </summary>
        /// <param name="id">Id отзыва</param>
        /// <returns></returns>
        Task<bool> TryToDeleteReviewAsync(Guid id);

        /// <summary>
        /// Получение отзыва
        /// </summary>
        /// <param name="addReview">Новый отзыв</param>
        /// <returns></returns>
        Task<Models.Review> TryToAddReviewAsync(AddReview addReview);
    }
}
