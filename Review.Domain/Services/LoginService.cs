using Review.Domain.Models;

namespace Review.Domain.Services
{
    public class LoginService : ILoginService
    {
        private readonly DataBaseContext databaseContext;

        public LoginService(DataBaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }
        public bool CheckLogin(Login login)
        {
            foreach (var item in databaseContext.Logins)
            {
                if (item.UserName == login.UserName && item.Password == login.Password)
                    return true;
            }
            return false;
        }
    }
}
