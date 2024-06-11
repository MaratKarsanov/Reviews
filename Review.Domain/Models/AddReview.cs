namespace Review.Domain.Models
{
    public class AddReview
    {
        public Guid ProductId { get; set; }
        public Guid UserId { get; set; }
        public string? Text { get; set; }
        public int Grade { get; set; }
    }
}
