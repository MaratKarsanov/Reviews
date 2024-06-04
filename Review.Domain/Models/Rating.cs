namespace Review.Domain.Models
{
    /// <summary>
    /// Рейтинг
    /// </summary>
    public class Rating
    {
        /// <summary>
        /// Id рейтинга
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Id продукта
        /// </summary>
        public int ProductId { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Отзывы
        /// </summary>
        public List<Review> Reviews { get; set; }

        public double Grade { get; set; }

        public Rating()
        {
            Reviews = new List<Review>();
        }
    }
}
