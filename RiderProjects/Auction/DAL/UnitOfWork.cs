using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DALContext _context;
        private IRepository<User> _userRepository;
        private IRepository<Product> _productRepository;
        private IRepository<AuctionLot> _auctionLotRepository;
        public UnitOfWork(string connectionString)
        {
            _context = new DALContext(connectionString);
        }

        public IRepository<User> UserRepository
        {
            get
            {
                if (_userRepository == null)
                {
                   _userRepository = new Repository<User>(_context);
                }
                return _userRepository;
            }
        }
        
        public IRepository<Product> ProductRepository
        {
            get
            {
                if (_productRepository == null)
                {
                    _productRepository = new Repository<Product>(_context);
                }
                return _productRepository;
            }
        }

        public IRepository<AuctionLot> AuctionLotRepository
        {
            get
            {
                if (_auctionLotRepository == null)
                {
                    _auctionLotRepository = new Repository<AuctionLot>(_context);
                }

                return _auctionLotRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}