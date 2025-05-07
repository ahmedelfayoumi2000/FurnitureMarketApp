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
    public class FurnitureItemService : IFurnitureItemService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FurnitureItemService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<FurnitureItemDto>> GetAllAsync()
        {
            var items = await _unitOfWork.FurnitureItems.GetAllAsync();
            return items.Select(i => new FurnitureItemDto
            {
                ID = i.ID,
                category = i.category,
                description = i.description,
                imageURL = i.imageURL,
                price = i.price,
                title = i.title
            });
        }

        public async Task<FurnitureItemDto> GetByIdAsync(int id)
        {
            var item = await _unitOfWork.FurnitureItems.GetByIdAsync(id);
            if (item == null) return null;
            return new FurnitureItemDto
            {
                ID = item.ID,
                category = item.category,
                description = item.description,
                imageURL = item.imageURL,
                price = item.price,
                title = item.title
            };
        }

        public async Task AddAsync(FurnitureItemDto dto)
        {
            var item = new FurnitureItem
            {
                category = dto.category,
                description = dto.description,
                imageURL = dto.imageURL,
                price = dto.price,
                title = dto.title
            };
            await _unitOfWork.FurnitureItems.AddAsync(item);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(FurnitureItemDto dto)
        {
            var item = await _unitOfWork.FurnitureItems.GetByIdAsync(dto.ID);
            if (item != null)
            {
                item.category = dto.category;
                item.description = dto.description;
                item.imageURL = dto.imageURL;
                item.price = dto.price;
                item.title = dto.title;
                await _unitOfWork.FurnitureItems.UpdateAsync(item);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.FurnitureItems.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
