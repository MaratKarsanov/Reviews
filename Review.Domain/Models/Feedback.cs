namespace Review.Domain.Models
{
    /// <summary>
    /// Отзыв
    /// </summary>
    public class Feedback
    {
        /// <summary>
        /// Id отзыва
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id продукта
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Id пользователя, оставившего отзыв
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Текст отзыва
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// Оценка (количество звезд)
        /// </summary>
        public int Grade { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreateDate { get; set; }

        public int RatingId { get; set; }

        public Rating Rating { get; set; }

        public Status status { get; set; }
    }
}
public enum Status
{

    None = 0,
    Actual = 1,
    Deleted = 2
}
