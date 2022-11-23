using MinimalJwt.Models;
using MinimalJwt.Repositories;

namespace MinimalJwt.Services
{
    public class UserService:IUserService
    {
        public User Get(UserLogin userLogin)
        {
            User user = UserRepository.users.FirstOrDefault(x => x.UserName.Equals
            (userLogin.UserName,StringComparison.OrdinalIgnoreCase) && x.Password.Equals
            (userLogin.Password));

            return user;    
        }
    }
}
