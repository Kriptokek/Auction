using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Entities
{
    public class AuctionLot
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Title { get; set; }
        public int QuantityOfBets { get; set; }
        public string LeaderName { get; set; }
        public DateTime DateOfClosing { get; set; }
        public User Owner { get; set; }
        public int LastBet { get; set; }
    }
}