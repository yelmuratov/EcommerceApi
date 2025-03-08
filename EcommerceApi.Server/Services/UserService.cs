using EcommerceApi.Server.Models;
using EcommerceApi.Server.Interfaces.UserInterfaces;
using EcommerceApi.Server.Constants;
using EcommerceApi.Server.DTOs.UserDTOs;

namespace EcommerceApi.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(u => new UserDTO
            {
                Id = u.Id,
                Username = u.Username,
                Email = u.Email,
                Role = u.role
            }).ToList();
        }

        public async Task<UserDTO?> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;

            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.role
            };
        }

        public async Task<UserDTO> RegisterUser(UserCreateDTO userDto)
        {
            var existingUser = await _userRepository.GetByUsernameAsync(userDto.Username);
            if (existingUser != null)
            {
                throw new Exception("Username already exists");
            }

            var newUser = new User
            {
                Username = userDto.Username,
                Email = userDto.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password), 
                role = Roles.Customer 
            };

            var createdUser = await _userRepository.AddAsync(newUser);

            return new UserDTO
            {
                Id = createdUser.Id,
                Username = createdUser.Username,
                Email = createdUser.Email,
                Role = createdUser.role
            };
        }

        public async Task<UserDTO?> AuthenticateUser(UserLoginDTO loginDto)
        {
            var user = await _userRepository.GetByUsernameAsync(loginDto.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                return null; 
            }

            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.role
            };
        }

        public async Task<UserDTO?> UpdateUser(int id, UserUpdateDTO userDto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;

            user.Username = userDto.Username;
            user.Email = userDto.Email;

            await _userRepository.UpdateAsync(user);

            return new UserDTO
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                Role = user.role
            };
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }
    }
}
