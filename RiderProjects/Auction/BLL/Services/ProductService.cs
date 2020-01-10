using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.DTOs;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL
{
    public class ProductService : IProductService
    {
        private IUnitOfWork DataBase { get; set; }
        private IMapper _mapper;

        public ProductService(IUnitOfWork uow)
        {
            DataBase = uow;
            var mapconfig = new MapperConfiguration(m=>m.AddProfile(new MapConfig()));
            _mapper = mapconfig.CreateMapper();
        }
        
        public IEnumerable<ProductDTO> GetProducts()
        {
            var products = DataBase.ProductRepository.GetAll();
            List<ProductDTO> list = new List<ProductDTO>();
            foreach (var item in products)
            {
                list.Add(_mapper.Map<ProductDTO>(item));
            }

            return list;
        }

        public void AddProduct(ProductDTO productDto)
        {
            if(productDto == null)
                throw new ValidationException("Product is not created");
            var product = _mapper.Map<Product>(productDto);
            DataBase.ProductRepository.Add(product);
            DataBase.Save();
        }
        
        public void DeleteProduct(int id)
        {
            var product = GetProducts().SingleOrDefault(p => p.Id == id);
            if(product == null)
                throw new ValidationException("Product was not found");
            DataBase.ProductRepository.Delete(product.Id);
            DataBase.Save();
        }

        public void Dispose()
        {
            DataBase.Dispose();
        }
    }
}