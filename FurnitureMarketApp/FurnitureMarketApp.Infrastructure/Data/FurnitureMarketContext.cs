using FurnitureMarketApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FurnitureMarketApp.Infrastructure.Data
{
    public class FurnitureMarketContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<FurnitureItem> FurnitureItems { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        public FurnitureMarketContext(DbContextOptions<FurnitureMarketContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FurnitureItem>()
                .Property(f => f.price)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Offer>()
                .Property(o => o.offerPrice)
                .HasColumnType("decimal(10,2)");

            modelBuilder.Entity<Offer>()
                .HasOne(o => o.User)
                .WithMany(u => u.Offers)
                .HasForeignKey(o => o.ID_user);

            modelBuilder.Entity<Offer>()
                .HasOne(o => o.FurnitureItem)
                .WithMany(f => f.Offers)
                .HasForeignKey(o => o.ID_item);

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.User)
                .WithMany(u => u.Favorites)
                .HasForeignKey(f => f.ID_user);

            modelBuilder.Entity<Favorite>()
                .HasOne(f => f.FurnitureItem)
                .WithMany(fi => fi.Favorites)
                .HasForeignKey(f => f.ID_item);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.User)
                .WithMany(u => u.Messages)
                .HasForeignKey(m => m.ID_user);
        }
    }

}
