using System;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<User> UserRepository { get; }
        IRepository<Product> ProductRepository { get; }
        IRepository<AuctionLot> AuctionLotRepository { get; }
        void Save();
    }
}