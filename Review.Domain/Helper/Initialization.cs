using Review.Domain.Models;

namespace Review.Domain.Helper
{
    public static class Initialization
    {
        private const string loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

        public static List<Models.Review> SetFeedbacks()
        {
            var feedbacksCount = 100;
            var feedbacks = new List<Models.Review>();
            for (var i = 1; i <= feedbacksCount; i++)
                feedbacks.Add(CreateFeedback(i));
            return feedbacks;
        }

        public static Models.Review CreateFeedback(int id)
        {
            var random = new Random();
            return new Models.Review()
            {
                Id = id,
                CreationDate = DateTime.Now.AddDays(random.Next(-100, 0)),
                Grade = random.Next(0, 6),
                ProductId = random.Next(1, 10),
                Text = loremIpsum.Substring(0, random.Next(20, 100)),
                UserId = random.Next(1, 10), 
                RatingId = random.Next(1, 10),
                Status = (Status)random.Next(0, 2)
            };
        }

        public static List<Rating> SetRatings()
        {
            var ratingsCount = 100;
            var ratings = new List<Rating>();
            for (var i = 0; i < ratingsCount; i++)
                ratings.Add(CreateRating(i + 1));
            return ratings;
        }

        public static Rating CreateRating(int id)
        {
            var random = new Random();
            var feedback = CreateFeedback(id);
            var feedbacksCount = random.Next(1, 10);
            var feedbacks = new List<Models.Review>(feedbacksCount);
            for (int k = 1; k <= feedbacksCount; k++)
                feedbacks.Add(CreateFeedback(k));
            var feedbacksAverage = feedbacks.Select(x => x.Grade).Average();
            var rating = new Rating()
            {
                Id = id,
                CreationDate = DateTime.Now.AddDays(random.Next(-100, 0)),
                ProductId = random.Next(1, 10),
                Grade = Math.Round(feedbacksAverage, 2)
            };
            return rating;
        }

        public static Login SetLogin()
        {
            return new Login()
            {
                Id = 1,
                UserName = "admin",
                Password = "admin"
            };
        }
    }
}
