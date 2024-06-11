namespace Review.Domain.Models
{
    /// <summary>
    /// Отзыв
    /// </summary>
    public class Review
    {
        /// <summary>
        /// Id отзыва
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Id продукта
        /// </summary>
        public Guid ProductId { get; set; }

        /// <summary>
        /// Id пользователя, оставившего отзыв
        /// </summary>
        public Guid UserId { get; set; }

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
        public DateTime CreationDate { get; set; }

        public Status Status { get; set; }
    }
}