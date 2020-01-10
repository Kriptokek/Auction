using AutoMapper;
using BLL.DTOs;
using DAL.Entities;

namespace BLL
{
    public class MapConfig : Profile
    {
        public MapConfig()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
            CreateMap<AuctionLot, AuctionLotDTO>();
            CreateMap<AuctionLotDTO, AuctionLot>();
        }
    }
}