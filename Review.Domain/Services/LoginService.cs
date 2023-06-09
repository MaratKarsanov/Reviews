using Review.Domain.Models;
using Microsoft.EntityFrameworkCore;

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
            var containsLogin = databaseContext.Logins;
            foreach (var item in containsLogin)
            {
                if(item.UserName.Equals(login.UserName) && item.Password.Equals(login.Password))
                {
                    return true;
                    break;
                }
            }
            return false;
        }
    }
}
