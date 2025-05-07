using FurnitureMarketApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureMarketApp.Application.Services
{
    public interface IFavoriteService
    {
        Task<IEnumerable<FavoriteDto>> GetAllAsync();
        Task<FavoriteDto> GetByIdAsync(int id);
        Task AddAsync(FavoriteDto dto);
        Task UpdateAsync(FavoriteDto dto);
        Task DeleteAsync(int id);
    }
}
