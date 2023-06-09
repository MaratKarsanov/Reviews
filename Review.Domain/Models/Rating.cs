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
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// отзывы
        /// </summary>
        public List<Feedback> Feedbacks { get; set; }

        public double Grade { get; set; }
        public Rating()
        {
            Feedbacks = new List<Feedback>();
        }
    }
}
