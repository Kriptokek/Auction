using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using DAL.Entities;

namespace BLL.DTOs
{
    public class AuctionLotDTO
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