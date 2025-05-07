using FurnitureMarketApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureMarketApp.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> Users { get; }
        IRepository<FurnitureItem> FurnitureItems { get; }
        IRepository<Offer> Offers { get; }
        IRepository<Message> Messages { get; }
        IRepository<Favorite> Favorites { get; }
        Task<int> SaveChangesAsync();
    }
}
