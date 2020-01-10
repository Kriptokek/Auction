using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL
{
    public class AuctionLotService : IAuctionLotService
    {
        private IUnitOfWork DataBase { get; set; }
        private IMapper _mapper;

        public AuctionLotService(IUnitOfWork uow)
        {
            DataBase = uow;
            var mapconfig = new MapperConfiguration(m=>m.AddProfile(new MapConfig()));
            _mapper = mapconfig.CreateMapper();
        }

        public IEnumerable<AuctionLotDTO> GetLots()
        {
            var lots = DataBase.AuctionLotRepository.GetAll();
            List<AuctionLotDTO> list = new List<AuctionLotDTO>();
            foreach (var item in lots)
            {
                list.Add(_mapper.Map<AuctionLotDTO>(item));
            }

            return list;
        }

        public void AddLot(AuctionLotDTO auctionLotDto)
        {
            if(auctionLotDto == null)
                throw new ValidationException("Lot is not created");
            var lot = _mapper.Map<AuctionLot>(auctionLotDto);
            DataBase.AuctionLotRepository.Add(lot);
            DataBase.Save();
        }
        
        public void DeleteLot(int id)
        {
            var lot = GetLots().SingleOrDefault(l=>l.Id == id);
            if(lot == null)
                throw new ValidationException("Lot was not found");
            DataBase.AuctionLotRepository.Delete(lot.Id);
            DataBase.Save();
        }

        public void UpdateLot(int id, int newBet)
        {
            var lot = DataBase.AuctionLotRepository.Get(id);
            if(lot == null)
                throw new ValidationException("Lot was not found");
            if (newBet > lot.LastBet)
                lot.LastBet = newBet;
            DataBase.AuctionLotRepository.Update(lot);
            DataBase.Save();
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}