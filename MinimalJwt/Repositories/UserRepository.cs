using MinimalJwt.Models;

namespace MinimalJwt.Repositories
{
    public class UserRepository
    {
        public static List<User> users = new()
        {
            new() 
            {
                UserName = "anil_admin", EmailAddress = "anil.admin@gmail.com", Password = "Mypass_w0rd",
                GivenName = "Anil", Surname = "Erpula", Role = "Administrator"
            },
            new() 
            {
                UserName = "mahesh_standard", EmailAddress = "mahesh.standard@gmail.com",
                Password = "Mypass_w0rd", GivenName = "Mahi", Surname = "Jada", Role = "Standarad" 
            },

        };
    }
}
