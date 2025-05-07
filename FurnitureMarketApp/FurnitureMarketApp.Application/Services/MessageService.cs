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
    public class MessageService : IMessageService
    {
        private readonly IUnitOfWork _unitOfWork;

        public MessageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<MessageDto>> GetAllAsync()
        {
            var messages = await _unitOfWork.Messages.GetAllAsync();
            return messages.Select(m => new MessageDto
            {
                ID = m.ID,
                ID_user = m.ID_user,
                date = m.date,
                content = m.content
            });
        }

        public async Task<MessageDto> GetByIdAsync(int id)
        {
            var message = await _unitOfWork.Messages.GetByIdAsync(id);
            if (message == null) return null;
            return new MessageDto
            {
                ID = message.ID,
                ID_user = message.ID_user,
                date = message.date,
                content = message.content
            };
        }

        public async Task AddAsync(MessageDto dto)
        {
            var message = new Message
            {
                ID_user = dto.ID_user,
                date = dto.date,
                content = dto.content
            };
            await _unitOfWork.Messages.AddAsync(message);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(MessageDto dto)
        {
            var message = await _unitOfWork.Messages.GetByIdAsync(dto.ID);
            if (message != null)
            {
                message.ID_user = dto.ID_user;
                message.date = dto.date;
                message.content = dto.content;
                await _unitOfWork.Messages.UpdateAsync(message);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            await _unitOfWork.Messages.DeleteAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
