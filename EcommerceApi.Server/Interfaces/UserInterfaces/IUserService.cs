using EcommerceApi.Server.DTOs.UserDTOs;

namespace EcommerceApi.Server.Interfaces.UserInterfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsers();
        Task<UserDTO?> GetUserById(int id);
        Task<UserDTO> RegisterUser(UserCreateDTO userDto);
        Task<UserDTO?> AuthenticateUser(UserLoginDTO loginDto);
        Task<UserDTO?> UpdateUser(int id, UserUpdateDTO userDto);
        Task<bool> DeleteUser(int id);
    }
}
