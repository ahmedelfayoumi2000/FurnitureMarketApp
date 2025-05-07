using FurnitureMarketApp.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureMarketApp.Application.Services
{
    public interface IOfferService
    {
        Task<IEnumerable<OfferDto>> GetAllAsync();
        Task<OfferDto> GetByIdAsync(int id);
        Task AddAsync(OfferDto dto);
        Task UpdateAsync(OfferDto dto);
        Task DeleteAsync(int id);
    }
}
