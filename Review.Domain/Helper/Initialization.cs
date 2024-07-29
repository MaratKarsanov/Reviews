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
            var productsId = new List<Guid>()
            {
                Guid.Parse("31f5ca54-1493-4d25-bfa8-8365da02fe2a"),
                Guid.Parse("a1eb9f0e-67ac-4abe-983d-58c61dbf98c6"),
                Guid.Parse("910d6065-27fc-4f7e-9a0a-be7882000163"),
                Guid.Parse("60254d66-6224-48cc-97c5-4334cf884b12"),
                Guid.Parse("1afe4c81-b95e-41fe-bdce-8d723abf652e"),
                Guid.Parse("44a28a04-1e56-450e-a1c5-1d4737217d41"),
                Guid.Parse("20848550-ebfd-4915-8f3b-0fc179e298b2"),
                Guid.Parse("262f905c-a15c-4665-a589-ad7be5efb0dc"),
                Guid.Parse("0b48dd3b-8e8e-4d80-8779-c47b7ebaaca2"),
                Guid.Parse("dfd70e45-d919-49f8-8be8-72e3c3b13c35"),
                Guid.Parse("df617e27-6f09-44d3-85a8-527d52e5686b"),
                Guid.Parse("a055cb47-f621-4c2d-bef4-33c41081e4b7"),
                Guid.Parse("b237f4af-7618-4ce8-b2ea-997a397c994d"),
                Guid.Parse("4f80e6f7-7527-4a67-bd75-88b6aa5aa343"),
                Guid.Parse("09b6973a-c6ac-46a0-9ca8-474962f936e8"),
                Guid.Parse("138d1841-d46e-4b51-b6d6-2c9f337e7ae5")
            };
            var reviews = productsId.Select(id => CreateReview(id));
            return reviews.ToList();
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
