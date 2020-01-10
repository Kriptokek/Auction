using System;
using System.Collections.Generic;

namespace Auction.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfPlacing { get; set; }
        public List<User> Users { get; set; }

        public Product()
        {
            Users = new List<User>();
        }
    }
}