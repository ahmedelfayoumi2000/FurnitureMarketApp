using FurnitureMarketApp.Domain.Entities;
using FurnitureMarketApp.Domain.Interfaces;
using FurnitureMarketApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureMarketApp.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FurnitureMarketContext _context;
        private bool _disposed = false;
                
        public IRepository<User> Users { get; private set; }
        public IRepository<FurnitureItem> FurnitureItems { get; private set; }
        public IRepository<Offer> Offers { get; private set; }
        public IRepository<Message> Messages { get; private set; }
        public IRepository<Favorite> Favorites { get; private set; }

        public UnitOfWork(FurnitureMarketContext context)
        {
            _context = context;
            Users = new Repository<User>(_context);
            FurnitureItems = new Repository<FurnitureItem>(_context);
            Offers = new Repository<Offer>(_context);
            Messages = new Repository<Message>(_context);
            Favorites = new Repository<Favorite>(_context);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
                _disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
