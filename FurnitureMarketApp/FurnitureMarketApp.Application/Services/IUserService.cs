using FurnitureMarketApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureMarketApp.Application.Services
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> GetByIdAsync(int id);
        Task AddAsync(UserDto dto);
        Task UpdateAsync(UserDto dto);
        Task DeleteAsync(int id);
    }
}
