using EcommerceApi.Server.Models;

namespace EcommerceApi.Server.Interfaces.UserInterfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers();
        Task<User> GetUserById(int id);
        Task<User> RegisterUser(User user, string password);
        Task<User> AuthenticateUser(string email, string password);
        Task<User> UpdateUser(User user);
        Task<bool> DeleteUser(int id);
    }
}
