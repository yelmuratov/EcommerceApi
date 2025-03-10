using AutoMapper;
using BCrypt.Net;
using EcommerceApi.Server.DTOs.UserDTOs;
using EcommerceApi.Server.Interfaces.UserInterfaces;
using EcommerceApi.Server.Models;
using EcommerceApi.Server.Constants;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EcommerceApi.Server.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserDTO>>(users); 
        }

        public async Task<UserDTO?> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;

            return _mapper.Map<UserDTO>(user); // ✅ AutoMapper conversion
        }

        public async Task<UserDTO> RegisterUser(UserCreateDTO userDto)
        {
            var existingUser = await _userRepository.GetByUsernameAsync(userDto.Username);
            if (existingUser != null)
            {
                throw new Exception("Username already exists");
            }

            var newUser = _mapper.Map<User>(userDto);
            newUser.Password = BCrypt.Net.BCrypt.HashPassword(userDto.Password); // ✅ Hash password
            newUser.role = Roles.Customer; // ✅ Set default role

            var createdUser = await _userRepository.AddAsync(newUser);
            return _mapper.Map<UserDTO>(createdUser);
        }

        public async Task<UserDTO?> AuthenticateUser(UserLoginDTO loginDto)
        {
            var user = await _userRepository.GetByUsernameAsync(loginDto.Username);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginDto.Password, user.Password))
            {
                return null;
            }

            return _mapper.Map<UserDTO>(user); // ✅ AutoMapper conversion
        }

        public async Task<UserDTO?> UpdateUser(int id, UserUpdateDTO userDto)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null) return null;

            _mapper.Map(userDto, user); // ✅ AutoMapper updates entity
            var updatedUser = await _userRepository.UpdateAsync(user);

            return _mapper.Map<UserDTO>(updatedUser);
        }

        public async Task<bool> DeleteUser(int id)
        {
            return await _userRepository.DeleteAsync(id);
        }
    }
}
