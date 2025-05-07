using FurnitureMarketApp.Application.DTOs;
using FurnitureMarketApp.Domain.Entities;
using FurnitureMarketApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureMarketApp.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            var users = await _unitOfWork.Users.GetAllAsync();
            return users.Select(u => new UserDto
            {
                ID = u.ID,
                email = u.email,
                name = u.name,
                password = u.password,
                user_phone = u.user_phone
            });
        }

        public async Task<UserDto> GetByIdAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null) return null;
            return new UserDto
            {
                ID = user.ID,
                email = user.email,
                name = user.name,
                password = user.password,
                user_phone = user.user_phone
            };
        }

        public async Task AddAsync(UserDto dto)
        {
            var user = new User
            {
                email = dto.email,
                name = dto.name,
                password = dto.password,
                user_phone = dto.user_phone
            };
            await _unitOfWork.Users.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(UserDto dto)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(dto.ID);
            if (user != null)
            {
                user.email = dto.email;
                user.name = dto.name;
                user.password = dto.password;
                user.user_phone = dto.user_phone;
                await _unitOfWork.Users.UpdateAsync(user);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            var user = await _unitOfWork.Users.GetByIdAsync(id);
            if (user == null)
            {
                throw new Exception($"User with ID {id} not found.");
            }

            try
            {
                await _unitOfWork.Users.DeleteAsync(id);
                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting user with ID {id}: {ex.Message}", ex);
            }
        }
    }
}
