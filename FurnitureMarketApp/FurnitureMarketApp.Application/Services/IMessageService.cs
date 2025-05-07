using FurnitureMarketApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureMarketApp.Application.Services
{
    public interface IMessageService
    {
        Task<IEnumerable<MessageDto>> GetAllAsync();
        Task<MessageDto> GetByIdAsync(int id);
        Task AddAsync(MessageDto dto);
        Task UpdateAsync(MessageDto dto);
        Task DeleteAsync(int id);
    }
}
