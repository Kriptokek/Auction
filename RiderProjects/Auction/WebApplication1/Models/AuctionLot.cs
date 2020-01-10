using System;
using System.Collections.Generic;

namespace Auction.Models
{
    public class AuctionLot
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int QuantityOfBets { get; set; }
        public string LeaderName { get; set; }
        public DateTime DateOfClosing { get; set; }
        public User Owner { get; set; }
        public int LastBet { get; set; }
    }
}