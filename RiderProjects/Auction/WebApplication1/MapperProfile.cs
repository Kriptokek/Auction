using Auction.Models;
using AutoMapper;
using BLL.DTOs;

namespace WebApplication2
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<User, UserDTO>();
            CreateMap<UserDTO, User>();
            CreateMap<Product, ProductDTO>();
            CreateMap<ProductDTO, Product>();
            CreateMap<AuctionLotDTO, AuctionLot>();
            CreateMap<AuctionLot, AuctionLotDTO>();
        }
    }
}