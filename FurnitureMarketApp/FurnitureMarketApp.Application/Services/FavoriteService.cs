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
    public class FavoriteService : IFavoriteService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FavoriteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<FavoriteDto>> GetAllAsync()
        {
            var favorites = await _unitOfWork.Favorites.GetAllAsync();
            return favorites.Select(f => new FavoriteDto
            {
                ID = f.ID,
                ID_user = f.ID_user,
                ID_item = f.ID_item,
                name = f.name
            });
        }

        public async Task<FavoriteDto> GetByIdAsync(int id)
        {
            var favorite = await _unitOfWork.Favorites.GetByIdAsync(id);
            if (favorite == null) return null;
            return new FavoriteDto
            {
                ID = favorite.ID,
                ID_user = favorite.ID_user,
                ID_item = favorite.ID_item,
                name = favorite.name
            };
        }

        public async Task AddAsync(FavoriteDto dto)
        {
            var favorite = new Favorite
            {
                ID_user = dto.ID_user,
                ID_item = dto.ID_item,
                name = dto.name
            };
            await _unitOfWork.Favorites.AddAsync(favorite);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(FavoriteDto dto)
        {
            var favorite = await _unitOfWork.Favorites.GetByIdAsync(dto.ID);
            if (favorite != null)
            {
                favorite.ID_user = dto.ID_user;
                favorite.ID_item = dto.ID_item;
                favorite.name = dto.name;
                await _unitOfWork.Favorites.UpdateAsync(favorite);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Favorites.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
