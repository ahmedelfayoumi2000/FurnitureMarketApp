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
    public class OfferService : IOfferService
    {
        private readonly IUnitOfWork _unitOfWork;

        public OfferService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<OfferDto>> GetAllAsync()
        {
            var offers = await _unitOfWork.Offers.GetAllAsync();
            return offers.Select(o => new OfferDto
            {
                ID = o.ID,
                ID_user = o.ID_user,
                ID_item = o.ID_item,
                offerPrice = o.offerPrice,
                status = o.status
            });
        }

        public async Task<OfferDto> GetByIdAsync(int id)
        {
            var offer = await _unitOfWork.Offers.GetByIdAsync(id);
            if (offer == null) return null;
            return new OfferDto
            {
                ID = offer.ID,
                ID_user = offer.ID_user,
                ID_item = offer.ID_item,
                offerPrice = offer.offerPrice,
                status = offer.status
            };
        }

        public async Task AddAsync(OfferDto dto)
        {
            var offer = new Offer
            {
                ID_user = dto.ID_user,
                ID_item = dto.ID_item,
                offerPrice = dto.offerPrice,
                status = dto.status
            };
            await _unitOfWork.Offers.AddAsync(offer);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(OfferDto dto)
        {
            var offer = await _unitOfWork.Offers.GetByIdAsync(dto.ID);
            if (offer != null)
            {
                offer.ID_user = dto.ID_user;
                offer.ID_item = dto.ID_item;
                offer.offerPrice = dto.offerPrice;
                offer.status = dto.status;
                await _unitOfWork.Offers.UpdateAsync(offer);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Offers.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
