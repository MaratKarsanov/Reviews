using Review.Domain.Models;

namespace Review.Domain.Services
{
    public interface ILoginService
    {
        /// <summary>
        /// Проверить логин и пароль
        /// </summary>
        /// <param name="login">Логин</param>
        /// <returns></returns>
        bool CheckLogin(Login login);
    }
}
