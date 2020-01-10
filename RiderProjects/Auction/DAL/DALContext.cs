using System;
using System.Collections.Generic;
using System.Data.Entity;
using DAL.Entities;

namespace DAL
{
    public class DALContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AuctionLot> AuctionLots { get; set; }

        public DALContext()
        {
            
        }
        
        public DALContext(string connectionString) 
            : base(connectionString)
        {
            
        }
    }
}