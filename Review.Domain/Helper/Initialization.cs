using Review.Domain.Models;

namespace Review.Domain.Helper
{
    public static class Initialization
    {
        private const string loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        private static Random random = new Random();
        public const int count = 100;

        public static List<Models.Review> SetReviews()
        {
            var reviews = new List<Models.Review>();
            for (var i = 0; i < count; i++)
                reviews.Add(CreateReview(Guid.NewGuid()));
            return reviews;
        }

        public static Models.Review CreateReview(Guid id)
        {
            return new Models.Review()
            {
                Id = id,
                CreationDate = DateTime.Now.AddDays(random.Next(-100, 0)),
                Grade = random.Next(0, 6),
                ProductId = Guid.NewGuid(),
                Text = loremIpsum.Substring(0, random.Next(20, 100)),
                UserId = Guid.NewGuid(), 
                Status = (Status)random.Next(0, 2)
            };
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
