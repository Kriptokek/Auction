using System.Collections.Generic;
using BLL.DTOs;

namespace BLL.Interfaces
{
    public interface IAuctionLotService
    {
        IEnumerable<AuctionLotDTO> GetLots();
        void AddLot(AuctionLotDTO auctionLotDto);
        void UpdateLot(int id, int newBet);
        void DeleteLot(int id);
        void Dispose();
    }
}