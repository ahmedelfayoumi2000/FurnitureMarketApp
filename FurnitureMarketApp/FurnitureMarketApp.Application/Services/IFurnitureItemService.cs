using FurnitureMarketApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureMarketApp.Application.Services
{
    public interface IFurnitureItemService
    {
        Task<IEnumerable<FurnitureItemDto>> GetAllAsync();
        Task<FurnitureItemDto> GetByIdAsync(int id);
        Task AddAsync(FurnitureItemDto dto);
        Task UpdateAsync(FurnitureItemDto dto);
        Task DeleteAsync(int id);
    }
}
