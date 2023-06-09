using Review.Domain.Models;

namespace Review.Domain.Helper
{
    public static class Initialization
    {
        private const string LoremIpsum = "Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";
        public static Feedback[] SetFeedbacks()
        {
            var count = 100;
            var random = new Random();
            List<Feedback> result = new List<Feedback>(count);
            for (int i = 1; i <= count; i++)
            {
                Feedback f = CreateFeedback(random, i);
                result.Add(f);
            }
            return result.ToArray();
        }

        public static Feedback CreateFeedback(Random random, int i)
        {
            return new Feedback()
            {
                Id = i,
                CreateDate = DateTime.Now.AddDays(random.Next(-100, 0)),
                Grade = random.Next(0, 6),
                ProductId = random.Next(1, 10),
                Text = LoremIpsum.Substring(0, random.Next(20, 100)),
                UserId = random.Next(1, 10), 
                RatingId = random.Next(1, 10),
                status = (Status)random.Next(0, 2)
            };
        }

        public static Rating[] SetRatings()
        {
            var count = 100;
            var random = new Random();
            List<Rating> result = new List<Rating>(count);
            for (int i = 1; i <= count; i++)
            {
                Rating fff = CreateRating(random, i);
                result.Add(fff);
            }
            return result.ToArray();
        }

        public static Rating CreateRating(Random random, int i)
        {
            Feedback f = CreateFeedback(random, i);
            var couuntF = random.Next(1, 10);
            var feedbacs = new List<Feedback>(couuntF);
            for (int k = 1; k <= couuntF; k++)
            {
                feedbacs.Add(CreateFeedback(random, k));
            }
            var feedbacsAverage = feedbacs.Select(x => x.Grade).Average();
            var fff = new Rating()
            {
                Id = i,
                CreateDate = DateTime.Now.AddDays(random.Next(-100, 0)),
                ProductId = random.Next(1, 10),
                Grade = Math.Round(feedbacsAverage, 2)
            };
            return fff;
        }

        public static Login[] SetLogins()
        {
            var results = new List<Login>();
            var login1 = new Login()
            {  
                Id = 1,
                UserName = "admin", 
                Password = "admin" 
            };
            results.Add(login1);
            return results.ToArray();
        }
    }
}
